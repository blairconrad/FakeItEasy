namespace FakeItEasy
{
    using System.Collections.Generic;
    using System.Linq;
    using FakeItEasy.Configuration;

    public static class ArgumentCollectionExtensions
    {
        public static IEnumerable<T?> Get<T>(this IEnumerable<ArgumentCollection> @this, int index)
        {
            Guard.AgainstNull(@this);
            return @this.Select(ac => ac.Get<T>(index));
        }

        public static IEnumerable<T?> Get<T>(this IEnumerable<ArgumentCollection> @this, string argumentName)
        {
            Guard.AgainstNull(@this);
            return @this.Select(ac => ac.Get<T>(argumentName));
        }
    }
}
