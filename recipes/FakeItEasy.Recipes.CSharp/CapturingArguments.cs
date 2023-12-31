namespace FakeItEasy.Recipes.CSharp;

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

public class CapturingArguments
{
    //// --8<-- [start:IListLogger]
    public interface IListLogger
    {
        void Log(string message, IEnumerable<int> list);
    }
    //// --8<-- [end:IListLogger]

    [Fact]
    public void OperationsShouldLog()
    {
        //// --8<-- [start:SimpleCapture]
        // Arrange
        var capturedMessage = new Captured<string>();

        var logger = A.Fake<IListLogger>();
        A.CallTo(() => logger.Log(
                capturedMessage._,
                An<IEnumerable<int>>._))
            .DoesNothing();

        var calculator = new Calculator(logger);

        // Act
        calculator.Add([1, 2, 3, 4]);
        calculator.Square(7);

        // Assert
        capturedMessage.Values.Should().BeEquivalentTo(
            "about to add",
            "about to square");

        // Or if you only care about the last value:
        capturedMessage.GetLastValue().Should().Be(
            "about to square");
        //// --8<-- [end:SimpleCapture]
    }

    [Fact]
    public void CaptureInputThatContainsThree()
    {
        //// --8<-- [start:ConstrainedCapture]
        // Arrange
        var capturedMessage = new Captured<string>();

        var logger = A.Fake<IListLogger>();
        A.CallTo(() => logger.Log(
                capturedMessage.That.Contains("add"),
                An<IEnumerable<int>>._))
            .DoesNothing();

        var calculator = new Calculator(logger);

        // Act
        calculator.Add([1, 2, 3, 4]);
        calculator.Square(7);
        calculator.Add([8, 9]);

        // Assert
        capturedMessage.Values.Should().BeEquivalentTo(
            "about to add",
            "about to add");
        //// --8<-- [end:ConstrainedCapture]
    }

    [Fact]
    public void NaivelyCaptureMutatedList()
    {
        var test = () =>
        {
            //// --8<-- [start:NaivelyCaptureMutatedList]
            // Arrange
            var capturedSummands = new Captured<IEnumerable<int>>();

            var logger = A.Fake<IListLogger>();
            A.CallTo(() => logger.Log(
                    "about to add",
                    capturedSummands._))
                .DoesNothing();

            var calculator = new Calculator(logger);

            // Act
            List<int> summands = [1, 2, 3, 4];
            calculator.Add(summands); // capturedSummands captures summands
            summands.RemoveAt(0);
            calculator.Add(summands); // captures summands again - same instance

            // Assert
            // passes:
            capturedSummands.Values[1].Should().BeEquivalentTo(2, 3, 4);

            // fails - summands contains only 2, 3, and 4:
            capturedSummands.Values[0].Should().BeEquivalentTo(1, 2, 3, 4);
            //// --8<-- [end:NaivelyCaptureMutatedList]
        };

        test.Should().ThrowExactly<AssertionFailedException>()
            .WithMessage(@"*but {2, 3, 4}*contains 1 item(s) less than*{1, 2, 3, 4}*");
    }

    [Fact]
    public void CaptureCopiedMutatedList()
    {
        //// --8<-- [start:CaptureCopiedMutatedList]
        // Arrange
        var capturedSummands = new Captured<IEnumerable<int>>(l => l.ToList());

        var logger = A.Fake<IListLogger>();
        A.CallTo(() => logger.Log(
                "about to add",
                capturedSummands._))
            .DoesNothing();

        var calculator = new Calculator(logger);

        // Act
        List<int> summands = [1, 2, 3, 4];
        calculator.Add(summands); // capturedSummands captures copy of summands
        summands.RemoveAt(0);
        calculator.Add(summands); // capturedSummands captures copy of summands

        // Assert
        // both pass:
        capturedSummands.Values[1].Should().BeEquivalentTo(2, 3, 4);
        capturedSummands.Values[0].Should().BeEquivalentTo(1, 2, 3, 4);
        //// --8<-- [end:CaptureCopiedMutatedList]
    }

    [Fact]
    public void CaptureCopiedMutatedListToNewType()
    {
        //// --8<-- [start:CaptureCopiedMutatedListToNewType]
        // Arrange
        var capturedSummands = new Captured<IEnumerable<int>, string>(
            l => string.Join(" + ", l));

        var logger = A.Fake<IListLogger>();
        A.CallTo(() => logger.Log(
                "about to add",
                capturedSummands._))
            .DoesNothing();

        var calculator = new Calculator(logger);

        // Act
        List<int> summands = [1, 2, 3, 4];
        calculator.Add(summands); // capturedSummands captures transformed summands
        summands.RemoveAt(0);
        calculator.Add(summands); // capturedSummands captures transformed summands

        // Assert
        capturedSummands.Values[1].Should().Be("2 + 3 + 4");
        capturedSummands.Values[0].Should().Be("1 + 2 + 3 + 4");
        //// --8<-- [end:CaptureCopiedMutatedListToNewType]
    }

    //// --8<-- [start:Calculator]
    internal class Calculator(IListLogger logger)
    {
        public int Add(IList<int> summands)
        {
            logger.Log("about to add", summands);
            return summands.Sum();
        }

        public int Square(int input)
        {
            logger.Log("about to square", [input]);
            return input * input;
        }
    }
    //// --8<-- [end:Calculator]
}
