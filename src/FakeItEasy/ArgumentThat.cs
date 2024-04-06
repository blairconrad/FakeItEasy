namespace FakeItEasy
{
   /// <summary>
    /// Provides an API entry point for constraining arguments of fake object calls.
    /// </summary>
    public static class ArgumentThat
    {
        /// <summary>
        /// Tests that the passed in argument is the same instance (reference) as the specified value.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="value">The reference to compare to.</param>
        /// <returns>A dummy argument value.</returns>
        public static T IsSameAs<T>(T value) => A<T>.That.IsSameAs(value);
    }
}
