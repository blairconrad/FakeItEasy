namespace FakeItEasy
{
    using System;

    /// <summary>
    /// Holds argument values captured from calls to a faked member.
    /// </summary>
    /// <typeparam name="T">The type of the argument.</typeparam>
    public class Captured<T> : Captured<T, T>
    {
        private static readonly Func<T, T> Identity = t => t;

        /// <summary>
        /// Initializes a new instance of the <see cref="Captured{T}"/> class.
        /// </summary>
        public Captured()
            : this(Identity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Captured{T}"/> class.
        /// </summary>
        /// <param name="freezer">
        ///   Transforms incoming argument values before storing the result.
        ///   Useful when argument values may be mutated between calls and you want
        ///   to store a copy that will not be modified.
        /// </param>
        public Captured(Func<T, T> freezer)
            : base(freezer)
        {
        }
    }
}
