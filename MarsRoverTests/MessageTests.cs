using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        Message m1;

        [TestInitialize]
        public void Initialize()
        {
            m1 = new Message("Name", commands);
        }

        [TestCleanup]
        public void CleanUp()
        {
            m1 = null;
        }

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("", commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Message required.", ex.Message);
            }
        }

        [TestMethod]
        public void ConstructorSetsName()
        {
            Assert.AreEqual(m1.Name, "Name");

        }

        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Assert.AreEqual(m1.Commands, commands);
        }

    }
}
