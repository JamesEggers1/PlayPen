using PlayPen.Commands;

namespace PlayPen.UnitTests.Commands
{
    [ConsoleCommand(Name = "test")]
    public class TestCommand : ConsoleCommandBase
    {
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
