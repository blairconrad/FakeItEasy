namespace FakeItEasy.Recipes.CSharp;

using FluentAssertions;
using FluentAssertions.Execution;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class CapturingArguments
{
    //// --8<-- [start:IListLogger]
    public interface IListLogger
    {
        void Log(string message, IEnumerable<string> list);
    }
    //// --8<-- [end:IListLogger]

    [Fact]
    public void PopOneShouldLogAfterPopping()
    {
        //// --8<-- [start:SimpleCapture]
        // Arrange
        var capturedLists = new CapturedArgument<IEnumerable<string>>();

        var logger = A.Fake<IListLogger>();
        A.CallTo(() => logger.Log(
                "after popping",
                An<IEnumerable<string>>.That.IsCapturedTo(capturedLists)._))
            .DoesNothing();

        var popper = new Popper(logger);

        // Act
        popper.PopOne(new List<string> { "one", "two", "three", "four" });
        popper.PopOne(new List<string> { "seven", "ate", "nine" });

        // Assert
        capturedLists.Values.Should().BeEquivalentTo(
            new[] { "two", "three", "four" },
            new[] { "ate", "nine" });

        // Or if you only care about the last value:
        capturedLists.GetLastValue().Should().BeEquivalentTo(
            new[] { "ate", "nine" });
        //// --8<-- [end:SimpleCapture]
    }

    [Fact]
    public void CaptureInputThatContainsThree()
    {
        //// --8<-- [start:ConstrainedCapture]
        // Arrange
        var capturedLists = new CapturedArgument<IEnumerable<string>>();

        var logger = A.Fake<IListLogger>();
        A.CallTo(() => logger.Log(
                "after popping",
                An<IEnumerable<string>>.That.IsCapturedTo(capturedLists)
                                       .And.Contains("three")))
            .DoesNothing();

        var popper = new Popper(logger);

        // Act
        popper.PopOne(new List<string> { "one", "two", "three", "four" });
        popper.PopOne(new List<string> { "seven", "ate", "nine" });
        popper.PopOne(new List<string> { "five", "three" });

        // Assert
        capturedLists.Values.Should().BeEquivalentTo(
            new[] { "two", "three", "four" },
            new[] { "three" });
        //// --8<-- [end:ConstrainedCapture]
    }

    [Fact]
    public void NaivelyCaptureMutatedList()
    {
        var test = () =>
        {
            //// --8<-- [start:NaivelyCaptureMutatedList]
            // Arrange
            var capturedLists = new CapturedArgument<IEnumerable<string>>();

            var logger = A.Fake<IListLogger>();
            A.CallTo(() => logger.Log(
                    "after popping",
                    An<IEnumerable<string>>.That.IsCapturedTo(capturedLists)._))
                .DoesNothing();

            var popper = new Popper(logger);

            // Act
            var list = new List<string> { "one", "two", "three", "four" };
            popper.PopOne(list); // capturedLists captures list
            popper.PopOne(list); // capturedLists captures list again - same instance

            // Assert
            // passes:
            capturedLists.Values[1].Should().BeEquivalentTo("three", "four");

            // fails - list contains only "three" and "four":
            capturedLists.Values[0].Should().BeEquivalentTo("two", "three", "four");
            //// --8<-- [end:NaivelyCaptureMutatedList]
        };

        test.Should().ThrowExactly<AssertionFailedException>()
            .WithMessage(@"*but {""three"", ""four""}*contains 1 item(s) less than*{""two"", ""three"", ""four""}*");
    }

    [Fact]
    public void CaptureCopiedMutatedList()
    {
        //// --8<-- [start:CaptureCopiedMutatedList]
        // Arrange
        var capturedLists =
            new CapturedArgument<IEnumerable<string>>(Enumerable.ToList);

        var logger = A.Fake<IListLogger>();
        A.CallTo(() => logger.Log(
                "after popping",
                An<IEnumerable<string>>.That.IsCapturedTo(capturedLists)._))
            .DoesNothing();

        var popper = new Popper(logger);

        // Act
        var list = new List<string> { "one", "two", "three", "four" };
        popper.PopOne(list); // capturedLists captures copy of list
        popper.PopOne(list); // capturedLists captures copy of list

        // Assert
        capturedLists.Values[1].Should().BeEquivalentTo("three", "four");
        capturedLists.Values[0].Should().BeEquivalentTo("two", "three", "four");
        //// --8<-- [end:CaptureCopiedMutatedList]
    }

    [Fact]
    public void CaptureCopiedMutatedListToNewType()
    {
        //// --8<-- [start:CaptureCopiedMutatedListToNewType]
        // Arrange
        var capturedLists = new CapturedArgument<IEnumerable<string>, string>(
            l => string.Join(" - ", l!));

        var logger = A.Fake<IListLogger>();
        A.CallTo(() => logger.Log(
                "after popping",
                An<IEnumerable<string>>.That.IsCapturedTo(capturedLists)._))
            .DoesNothing();

        var popper = new Popper(logger);

        // Act
        var list = new List<string> { "one", "two", "three", "four" };
        popper.PopOne(list); // capturedLists captures transformed list
        popper.PopOne(list); // capturedLists captures transformed list

        // Assert
        capturedLists.Values[1].Should().Be("three - four");
        capturedLists.Values[0].Should().Be("two - three - four");
        //// --8<-- [end:CaptureCopiedMutatedListToNewType]
    }

    //// --8<-- [start:Popper]
    internal class Popper
    {
        private readonly IListLogger logger;

        public Popper(IListLogger logger) => this.logger = logger;

        public void PopOne(IList<string> list)
        {
            list.RemoveAt(0);
            this.logger.Log("after popping", list);
        }
    }
    //// --8<-- [end:Popper]
}
