using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {

        Rover r1;

        [TestInitialize]
        public void Initialize()
        {
            r1 = new Rover(1);

        }

        [TestCleanup]
        public void Cleanup()
        {
            r1 = null;
        }

        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Assert.AreEqual(r1.Position, 1);
            
        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Assert.AreEqual(r1.Mode, "NORMAL");
        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Assert.AreEqual(r1.GeneratorWatts, 110);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            

            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER") };

            r1.ReceiveMessage(new Message("name", commands));

            Assert.AreEqual("LOW_POWER", r1.Mode);
        }

        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER") , new Command("MOVE",2)};

            r1.ReceiveMessage(new Message("name", commands));

            Assert.AreEqual(1,r1.Position);

        }

        [TestMethod]
        public void RoverReturnsAMessageForAnUnknownCommand()
        {
            Command[] commands = { new Command("change mode", "LOW_POWER")};

            

            Assert.AreEqual("Invalid Entry.", r1.ReceiveMessage(new Message("name", commands)));

        }

    }

    
}
