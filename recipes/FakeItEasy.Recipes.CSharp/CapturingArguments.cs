namespace FakeItEasy.Recipes.CSharp;

using FluentAssertions;
using System.Collections.Generic;

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
                An<IEnumerable<string>>.That.IsCapturedTo(capturedLists)))
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
