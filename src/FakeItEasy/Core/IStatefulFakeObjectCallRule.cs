namespace FakeItEasy.Core
{
    /// <summary>
    /// Allows for intercepting call to a fake object and
    /// act upon them. Implement this interface rather than <see cref="IFakeObjectCallRule"/>
    /// when the rule contains state that must be restored when <see cref="Fake.ResetToInitialConfiguration(object)"/>
    /// is invoked.
    /// </summary>
    public interface IStatefulFakeObjectCallRule : IFakeObjectCallRule
    {
        /// <summary>
        /// Create a copy of this rule, so the original's state may be independently mutated.
        /// </summary>
        /// <returns>A new rule with a snapshot of the current one's state.</returns>
        IStatefulFakeObjectCallRule Clone();
    }
}
