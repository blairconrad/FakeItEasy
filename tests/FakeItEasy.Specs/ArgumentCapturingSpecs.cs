namespace FakeItEasy.Specs
{
    using System;
    using FakeItEasy.Tests.TestHelpers;
    using FluentAssertions;
    using Xbehave;
    using Xunit;

    public static class ArgumentCapturingSpecs
    {
        [Scenario]
        public static void CaptureSingleValueFromA(Action<int> fake, CapturedArgument<int> capturedArgument)
        {
            "Given a fake"
                .x(() => fake = A.Fake<Action<int>>());

            "And a capturedArgument instance"
                .x(() => capturedArgument = new CapturedArgument<int>());

            "And a fake method is configured to capture its argument to that instance"
                .x(() => A.CallTo(() => fake.Invoke(A<int>.That.IsCapturedTo(capturedArgument)))
                            .DoesNothing());

            "When the method is called"
                .x(() => fake.Invoke(354897));

            "Then the captured argument instance's last value matches the input"
                .x(() => capturedArgument.GetLastValue().Should().Be(354897));
        }

        [Scenario]
        public static void CaptureSingleValueFromAn(Action<int> fake, CapturedArgument<int> capturedArgument)
        {
            "Given a fake"
                .x(() => fake = A.Fake<Action<int>>());

            "And a capturedArgument instance"
                .x(() => capturedArgument = new CapturedArgument<int>());

            "And a fake method is configured to capture its argument to that instance"
                .x(() => A.CallTo(() => fake.Invoke(An<int>.That.IsCapturedTo(capturedArgument)))
                            .DoesNothing());

            "When the method is called"
                .x(() => fake.Invoke(798453));

            "Then the captured argument instance's last value matches the input"
                .x(() => capturedArgument.GetLastValue().Should().Be(798453));
        }

        [Scenario]
        public static void MismatchedVerifyWithCapture(
            Action<int, int> fake, CapturedArgument<int> capturedArgument, Exception exception)
        {
            "Given a fake"
                .x(() => fake = A.Fake<Action<int, int>>());

            "And a capturedArgument instance"
                .x(() => capturedArgument = new CapturedArgument<int>());

            "And a method on the fake is called"
                .x(() => fake.Invoke(354897, -3));

            "When we assert that the call must've happened with a capturing argument and another non-matching argument"
                .x(() => exception = Record.Exception(
                    () => A.CallTo(() => fake.Invoke(An<int>.That.IsCapturedTo(capturedArgument), 3))
                            .MustHaveHappened()));

            "Then an exception is thrown, indicating that there was no constraint on the argument"
                .x(() => exception.Should().BeAnExceptionOfType<ExpectationException>()
                    .WithMessageModuloLineEndings(@"

  Assertion failed for the following call:
    System.Action`2[System.Int32,System.Int32].Invoke(arg1: <Ignored>, arg2: 3)
  Expected to find it once or more but didn't find it among the calls:
    1: System.Action`2[System.Int32,System.Int32].Invoke(arg1: 354897, arg2: -3)

"));
        }

        [Scenario]
        public static void ValueNotCapturedOnRuleMismatch(
            Action<int, string> fake, CapturedArgument<int> capturedArgument, Exception exception)
        {
            "Given a fake"
                .x(() => fake = A.Fake<Action<int, string>>());

            "And a capturedArgument instance"
                .x(() => capturedArgument = new CapturedArgument<int>());

            "And a fake method with 2 parameters is configured to capture an argument to that instance"
                .x(() => A.CallTo(() => fake.Invoke(An<int>.That.IsCapturedTo(capturedArgument), "matching"))
                            .DoesNothing());

            "When the method is called with non-matching arguments"
                .x(() => fake.Invoke(354897, "not matching"));

            "Then no values are captured"
                .x(() => capturedArgument.Values.Should().BeEmpty());
        }

        [Scenario]
        public static void GetLastValueThrowsAfterNoCaptures(
            Action<int, string> fake, CapturedArgument<int> capturedArgument, Exception exception)
        {
            "Given a fake"
                .x(() => fake = A.Fake<Action<int, string>>());

            "And a capturedArgument instance"
                .x(() => capturedArgument = new CapturedArgument<int>());

            "And a fake method is configured to capture an argument to that instance"
                .x(() => A.CallTo(() => fake.Invoke(An<int>.That.IsCapturedTo(capturedArgument), "matching"))
                            .DoesNothing());

            "When the method is called with non-matching arguments"
                .x(() => fake.Invoke(354897, "not matching"));

            "And we try to get the last captured value"
                .x(() => exception = Record.Exception(() => capturedArgument.GetLastValue()));

            "Then an exception is thrown"
                .x(() => exception.Should()
                    .BeAnExceptionOfType<ExpectationException>()
                    .WithMessage("No values were captured."));
        }

        [Scenario]
        public static void CaptureArgumentsFromMultipleCalls(Action<int> fake, CapturedArgument<int> capturedArgument)
        {
            "Given a fake"
                .x(() => fake = A.Fake<Action<int>>());

            "And a capturedArgument instance"
                .x(() => capturedArgument = new CapturedArgument<int>());

            "And a fake method is configured to capture its argument to that instance"
                .x(() => A.CallTo(() => fake.Invoke(A<int>.That.IsCapturedTo(capturedArgument)))
                            .DoesNothing());

            "When the method is called"
                .x(() => fake.Invoke(589711));

            "And the method is called again"
                .x(() => fake.Invoke(846722));

            "And the method is called yet again"
                .x(() => fake.Invoke(359633));

            "Then the captured argument instance's values match the inputs"
                .x(() => capturedArgument.Values.Should().BeEquivalentTo(589711, 846722, 359633));
        }
    }
}
