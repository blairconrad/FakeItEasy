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
        var capturedList = new CapturedArgument<IEnumerable<string>>();

        var logger = A.Fake<IListLogger>();
        A.CallTo(() => logger.Log(
                "after popping",
                An<IEnumerable<string>>.That.IsCapturedTo(capturedList)))
            .DoesNothing();

        var popper = new Popper(logger);

        // Act
        popper.PopOne(new List<string> { "one", "two", "three", "four" });

        // Assert
        capturedList.LastValue.Should().BeEquivalentTo("two", "three", "four");
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
