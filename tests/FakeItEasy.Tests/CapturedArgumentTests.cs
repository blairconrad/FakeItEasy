namespace FakeItEasy.Tests
{
    using System;
    using System.Linq.Expressions;
    using Xunit;

    public class CapturedArgumentTests
    {
        [Fact]
        public void Constructor_should_be_null_guarded()
        {
#pragma warning disable CA1806 // Do not ignore method results
            Expression<Action> call = () => A.Captured<string>(s => s);
#pragma warning restore CA1806 // Do not ignore method results
            call.Should().BeNullGuarded();
        }
    }
}
