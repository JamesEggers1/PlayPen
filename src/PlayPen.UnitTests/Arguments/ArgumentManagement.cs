// ============================================================
// Requirements:
// ============================================================
// 1. Constructor should take a string array to initialize
// 2. should be able to convert an array into an argument dictionary
// 3. should be able to convert an array into a flag dictionary
// 4. Should skip non-conformant arguments
// 5. should be able to retrieve specific if argument exists
// 6. should be able to retrieve null if argument doesn't exists
// 7. should be able to retrieve true if flag exists
// 8. should be able to retrieve false if flag doesn't exists
// ============================================================

using NUnit.Framework;
using PlayPen.Arguments;

namespace PlayPen.UnitTests.Arguments
{
    [TestFixture]
    public class ArgumentManagement
    {
        private string[] _argArray;

        [SetUp]
        public void Setup()
        {
            _argArray = new string[]
                             {
                                 "command",
                                 "-a:firstArg",
                                 "-b:secondArg",
                                 "-flag1",
                                 "-flag2",
                                 "-flag3"
                             };
            
        }

        [Test]
        public void Should_Have_A_Constructor_That_Takes_An_Array()
        {
            var argMngr = new ArgumentManager(_argArray);
        }

        [Test]
        public void Should_Convert_Array_To_Argument_Dictionary()
        {
            var argMngr = new ArgumentManager(_argArray);
            var args = argMngr.ArgumentCount;
            Assert.AreEqual(2, args);
        }

        [Test]
        public void Should_Convert_Array_To_Flag_List()
        {
            var argMngr = new ArgumentManager(_argArray);
            var flags = argMngr.FlagCount;
            Assert.AreEqual(3, flags);
        }

        [Test]
        public void Should_Skip_NonConformant_Arguments()
        {
            var argMngr = new ArgumentManager(_argArray);
            var flags = argMngr.FlagCount;
            var args = argMngr.ArgumentCount;
            Assert.AreEqual(5, flags + args);
        }

        [Test]
        public void Should_Be_Able_To_Retrieve_Specific_Argument()
        {
            var argMngr = new ArgumentManager(_argArray);
            var arg = argMngr.GetArgumentValue("-a");
            Assert.AreEqual("firstArg", arg);
        }

        [Test]
        public void Should_Be_Able_To_Retrieve_Null_If_Argument_Not_Found()
        {
            var argMngr = new ArgumentManager(_argArray);
            var arg = argMngr.GetArgumentValue("-unknown");
            Assert.IsNull(arg);
        }

        [Test]
        public void Should_Be_Able_To_Retrieve_Specific_Flag()
        {
            var argMngr = new ArgumentManager(_argArray);
            var flag = argMngr.GetFlagValue("-flag1");
            Assert.IsTrue(flag);
        }

        [Test]
        public void Should_Be_Able_To_Return_False_If_Flag_Not_Found()
        {
            var argMngr = new ArgumentManager(_argArray);
            var flag = argMngr.GetFlagValue("-flagx");
            Assert.IsFalse(flag);
        }
    }
}
