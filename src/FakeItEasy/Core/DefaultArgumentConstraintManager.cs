namespace FakeItEasy.Core
{
    using System;
    using System.Data;

    internal class DefaultArgumentConstraintManager<T>
        : ICapturableArgumentConstraintManager<T>,
          ICapturingArgumentConstraintManager<T>
    {
        private readonly Action<MatchesConstraint> onConstraintCreated;

        public DefaultArgumentConstraintManager(Action<IArgumentConstraint> onConstraintCreated)
            : this((MatchesConstraint constraint) => onConstraintCreated(constraint))
        {
        }

        private DefaultArgumentConstraintManager(Action<MatchesConstraint> onConstraintCreated) =>
            this.onConstraintCreated = onConstraintCreated;

        public INegatableArgumentConstraintManager<T> And => this;

        public IArgumentConstraintManager<T> Not =>
            new DefaultArgumentConstraintManager<T>(
                constraint => this.onConstraintCreated(new NotMatchesConstraint(constraint)));

        public T Ignored => this.Matches(x => true, x => x.Write(nameof(this.Ignored)));

        public T _ => this.Ignored;

        public ICapturingArgumentConstraintManager<T> IsCapturedTo(CapturedArgument<T> capturedArgument) =>
            new DefaultArgumentConstraintManager<T>(
                constraint => this.onConstraintCreated(new CapturesConstraint(constraint, capturedArgument)));

        public T Matches(Func<T, bool> predicate, Action<IOutputWriter> descriptionWriter)
        {
            this.onConstraintCreated(new MatchesConstraint(predicate, descriptionWriter));
            return default!;
        }

        private class NotMatchesConstraint : MatchesConstraint
        {
            public NotMatchesConstraint(MatchesConstraint constraint)
                : base(
                      argument => !constraint.IsValid(argument),
                      writer =>
                      {
                          writer.Write("not ");
                          constraint.WriteBareDescription(writer);
                      })
            {
            }
        }

        private class CapturesConstraint : MatchesConstraint, IHaveASideEffect
        {
            private readonly CapturedArgument<T> capturedArgument;

            public CapturesConstraint(MatchesConstraint constraint, CapturedArgument<T> capturedArgument)
                : base(argument => constraint.IsValid(argument), constraint.WriteBareDescription)
            {
                this.capturedArgument = capturedArgument;
            }

            public void ApplySideEffect(object? argument) => this.capturedArgument.Add((T)argument!);
        }

        private class MatchesConstraint
            : ITypedArgumentConstraint
        {
            private static readonly bool IsNullable = typeof(T).IsNullable();

            private readonly Func<T, bool> predicate;
            private readonly Action<IOutputWriter> descriptionWriter;

            public MatchesConstraint(Func<T, bool> predicate, Action<IOutputWriter> descriptionWriter)
            {
                this.predicate = predicate;
                this.descriptionWriter = descriptionWriter;
            }

            public Type Type => typeof(T);

            public override string ToString() => this.GetDescription();

            public void WriteDescription(IOutputWriter writer)
            {
                writer.Write('<');
                this.WriteBareDescription(writer);
                writer.Write('>');
            }

            public bool IsValid(object? argument)
            {
                if (!IsValueValidForType(argument))
                {
                    return false;
                }

                try
                {
                    return this.predicate.Invoke((T)argument!);
                }
                catch (Exception ex)
                {
                    throw new UserCallbackException(ExceptionMessages.UserCallbackThrewAnException($"Argument matcher {this.GetDescription()}"), ex);
                }
            }

            public void WriteBareDescription(IOutputWriter writer)
            {
                try
                {
                    this.descriptionWriter.Invoke(writer);
                }
                catch (Exception ex)
                {
                    throw new UserCallbackException(ExceptionMessages.UserCallbackThrewAnException("Argument matcher description"), ex);
                }
            }

            private static bool IsValueValidForType(object? argument)
            {
                if (argument is null)
                {
                    return IsNullable;
                }

                return argument is T;
            }

            private string GetDescription()
            {
                var writer = ServiceLocator.Resolve<StringBuilderOutputWriter.Factory>().Invoke();
                ((IArgumentConstraint)this).WriteDescription(writer);
                return writer.Builder.ToString();
            }
        }
    }
}
