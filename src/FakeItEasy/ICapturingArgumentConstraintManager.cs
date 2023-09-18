namespace FakeItEasy
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Continues configuration of argument matcher after intent to capture values is registered.
    /// </summary>
    /// <typeparam name="T">The type of argument to constrain.</typeparam>
    [CLSCompliant(false)]
    public interface ICapturingArgumentConstraintManager<T>
    {
        /// <summary>
        /// Gets a constraint that considers any value of an argument as valid.
        /// </summary>
        /// <remarks>This is a shortcut for the "Ignored"-property.</remarks>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "But it's kinda cool right?")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [CLSCompliant(false)]
#pragma warning disable SA1300 // Element must begin with upper-case letter
        public T _ { get; }
#pragma warning restore SA1300 // Element must begin with upper-case letter

        /// <summary>
        /// Gets a constraint that considers any value of an argument as valid.
        /// </summary>
        public T Ignored { get; }

        /// <summary>
        /// Continues constraint specification after capture destination is specfied.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "And", Justification = "Part of the fluent syntax.")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Fluent API.")]
        INegatableArgumentConstraintManager<T> And { get; }
    }
}
