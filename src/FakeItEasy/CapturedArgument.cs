namespace FakeItEasy
{
    /// <summary>
    /// Holds an argument value captured from a call to a faked member.
    /// </summary>
    /// <typeparam name="T">The type of the argument.</typeparam>
    public class CapturedArgument<T>
    {
        /// <summary>
        /// Gets the last captured value.
        /// </summary>
        /// <remarks>
        /// Will be <c>default</c> if no argument was captured.</remarks>
        public T LastValue { get; internal set; } = default!;
    }
}
