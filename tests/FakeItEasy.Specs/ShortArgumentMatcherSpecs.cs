namespace FakeItEasy.Specs
{
    using System;
    using FakeItEasy.Tests.TestHelpers;
    using FluentAssertions;
    using Xbehave;
    using Xunit;
    using static FakeItEasy.ArgumentThat;

    public static class ShortArgumentMatcherSpecs
    {
        public interface IFoo
        {
            int Bar(object o);
        }

        [Scenario]
        public static void AssertIsSameAsFails(IFoo fake, Exception exception)
        {
            "Given a fake"
                .x(() => fake = A.Fake<IFoo>());

            "When I assert that a method was called with a specific object using a short argument matcher"
                .x(() => exception = Record.Exception(() =>
                A.CallTo(() => fake.Bar(IsSameAs(new object()))).MustHaveHappened()));

            "Then it fails with an appropriate message"
                .x(() => exception.Should().BeAnExceptionOfType<ExpectationException>()
                   .WithMessage("*<same as System.Object>*"));
        }
    }
}
