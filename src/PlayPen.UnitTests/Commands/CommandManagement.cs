// ============================================================
// Requirements:
// ============================================================
// 1. Commands should be auto-discoverable
// 2. Should Be able to retrieve a specific command.
// 
// 
// 
// 
// ============================================================
using System.Reflection;
using NUnit.Framework;
using PlayPen.Commands;

namespace PlayPen.UnitTests.Commands
{
    [TestFixture]
    public class CommandManagement
    {
        private CommandManager _cmdMgr;

        [SetUp]
        public void Setup()
        {
            _cmdMgr = new CommandManager();
            var type = typeof(CommandManager);
            var method = type.GetMethod("LoadCommands", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(_cmdMgr, null);
        }

        [Test]
        public void Should_Auto_Discover_Commands()
        {
            var exists = _cmdMgr.CommandExists("test");

            Assert.IsTrue(exists);
        }

        [Test]
        public void Should_Be_Able_To_Retrieve_A_Command()
        {
            var cmd = _cmdMgr.GetCommand("test");

            Assert.IsNotNull(cmd);
        }
    }
}
