namespace FakeItEasy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Holds argument values captured from calls to a faked member.
    /// </summary>
    /// <typeparam name="TArg">The type of the argument.</typeparam>
    /// <typeparam name="TCap">The type of the value to capture from the argument.</typeparam>
    public class CapturedArgument<TArg, TCap>
    {
        private readonly List<TCap> values = new();
        private readonly Func<TArg, TCap> freezer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CapturedArgument{TArg, TCap}"/> class.
        /// </summary>
        /// <param name="freezer">
        ///   Transforms incoming argument values before storing the result.
        ///   Useful when argument values may be mutated between calls and you want
        ///   to store a copy that will not be modified.
        /// </param>
        public CapturedArgument(Func<TArg, TCap> freezer) => this.freezer = Guard.AgainstNull(freezer);

        /// <summary>
        /// Gets the captured values.
        /// </summary>
        /// <remarks>
        /// Will be empty if no arguments were captured.
        /// </remarks>
        public IReadOnlyList<TCap> Values => this.values;

        /// <summary>
        /// Gets the last captured value.
        /// </summary>
        /// <returns>
        /// The last captured value.
        /// </returns>
        /// <exception cref="ExpectationException">
        /// If no arguments were captured.
        /// </exception>
        public TCap GetLastValue()
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
        internal void Add(TArg value) => this.values.Add(this.freezer(value));
    }
}
