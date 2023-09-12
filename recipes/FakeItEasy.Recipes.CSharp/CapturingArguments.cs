namespace FakeItEasy.Recipes.CSharp;

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
        var list = new List<string> { "one", "two", "three" };
        var logger = A.Fake<IListLogger>();
        var popper = new Popper(logger);

        popper.PopOne(list);

        A.CallTo(() => logger.Log("after popping", new[] { "two", "three" })).MustHaveHappened();
    }

    //// --8<-- [start:Popper]
    public class Popper
    {
        private readonly IListLogger logger;

        public Popper(IListLogger logger) => this.logger = logger;

        public void PopOne(IList<string> list)
        {
            list.RemoveAt(0);
            this.logger.Log("after popping", list);
        }

        public void PopTwo(IList<string> list)
        {
            list.RemoveAt(0);
            this.logger.Log("after popping one", list);
            list.RemoveAt(0);
            this.logger.Log("after popping another", list);
        }
    }
    //// --8<-- [end:Popper]
}
