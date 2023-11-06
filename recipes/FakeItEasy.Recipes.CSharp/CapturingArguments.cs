namespace FakeItEasy.Recipes.CSharp;

using FakeItEasy.Configuration;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Xunit;

public class CapturingArguments
{
    //// --8<-- [start:IListLogger]
    public interface IListLogger
    {
        void LogDebug(string message, IEnumerable<string> list);

        void LogInfo(string message, IEnumerable<string> list);
    }
    //// --8<-- [end:IListLogger]

    [Fact]
    public void SquishShouldLogBeforeSquishing()
    {
        //// --8<-- [start:AccessByIndex]
        // Arrange
        var logger = A.Fake<IListLogger>();
        var squisher = new Squisher(logger);

        // Act
        squisher.Squish(new List<string> { "one", "two", "three", "four" });

        // Assert
        Fake.GetArgumentValues<IEnumerable<string>>(1)
            .CapturedBy(() => logger.LogInfo(A<string>._, An<IEnumerable<string>>._))
            .Should().BeEquivalentTo(new[] { new[] { "one", "two", "three", "four" } });
        ////// --8<-- [end:AccessByIndex]
    }

    [Fact]
    public void SquishShouldLogBeforeSquishingName()
    {
        //// --8<-- [start:AccessByName]
        // Arrange
        var logger = A.Fake<IListLogger>();
        var squisher = new Squisher(logger);

        // Act
        squisher.Squish(new List<string> { "one", "two", "three", "four" });

        // Assert
        var expectations = new[] { new[] { "one", "two", "three", "four" } };
        Fake.GetArgumentValues<IEnumerable<string>>("list")
            .CapturedBy(() => logger.LogInfo(A<string>._, An<IEnumerable<string>>._))
            .Should().BeEquivalentTo(expectations);
        ////// --8<-- [end:AccessByName]
    }

    //// --8<-- [start:Squisher]
    internal class Squisher
    {
        private readonly IListLogger logger;

        public Squisher(IListLogger logger) => this.logger = logger;

        public string Squish(IEnumerable<string> list)
        {
            this.logger.LogInfo("about to squish", list);
            var result = string.Join(string.Empty, list);
            this.logger.LogDebug("squished", list);
            return result;
        }
    }
    //// --8<-- [end:Squisher]
}
