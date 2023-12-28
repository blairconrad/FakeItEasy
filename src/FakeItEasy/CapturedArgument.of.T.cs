namespace FakeItEasy
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Holds argument values captured from calls to a faked member.
    /// </summary>
    /// <typeparam name="T">The type of the argument.</typeparam>
    public class CapturedArgument<T> : CapturedArgument<T, T>
    {
        private static readonly Func<T, T> Identity = t => t;

        /// <summary>
        /// Initializes a new instance of the <see cref="CapturedArgument{T}"/> class.
        /// </summary>
        public CapturedArgument()
            : this(Identity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CapturedArgument{T}"/> class.
        /// </summary>
        /// <param name="freezer">
        ///   Transforms incoming argument values before storing the result.
        ///   Useful when argument values may be mutated between calls and you want
        ///   to store a copy that will not be modified.
        /// </param>
        public CapturedArgument(Func<T, T> freezer)
            : base(freezer)
        {
        }

        public INegatableArgumentConstraintManager<T> That =>
            A<T>.That.IsCapturedTo(this).And;

        /// <summary>
        /// Gets a constraint that considers any value of an argument as valid.
        /// </summary>
        /// <remarks>This is a shortcut for the "Ignored"-property.</remarks>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "But it's kinda cool right?")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CLSCompliant(false)]
#pragma warning disable SA1300 // Element must begin with upper-case letter
        public T _ => this.Ignored;
#pragma warning restore SA1300 // Element must begin with upper-case letter

        /// <summary>
        /// Gets a constraint that considers any value of an argument as valid.
        /// </summary>
        public T Ignored => this.That.Matches(x => true, x => x.Write(nameof(this.Ignored)));
    }
}
