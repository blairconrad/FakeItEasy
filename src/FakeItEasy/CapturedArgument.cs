namespace FakeItEasy
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Holds argument values captured from calls to a faked member.
    /// </summary>
    /// <typeparam name="T">The type of the argument.</typeparam>
    public class CapturedArgument<T>
    {
        private readonly List<T> values = new();

        /// <summary>
        /// Gets the captured values.
        /// </summary>
        /// <remarks>
        /// Will be empty if no arguments were captured.
        /// </remarks>
        public IReadOnlyList<T> Values => this.values;

        /// <summary>
        /// Gets the last captured value.
        /// </summary>
        /// <returns>
        /// The last captured value.
        /// </returns>
        /// <exception cref="ExpectationException">
        /// If no arguments were captured.
        /// </exception>
        public T GetLastValue()
        {
            if (this.values.Any())
            {
                return this.values.Last();
            }

            throw new ExpectationException(ExceptionMessages.NoCapturedValues);
        }

        /// <summary>
        /// Add a captured value.
        /// </summary>
        /// <param name="value">The new value to capture.</param>
        internal void Add(T value) => this.values.Add(value);
    }
}
