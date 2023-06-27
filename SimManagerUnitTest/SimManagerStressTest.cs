using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthology.Models;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.Win32.SafeHandles;

namespace SimManagerUnitTest
{
    [TestClass]
    public class SimManagerStressTest
    {
        [TestMethod]
        public void TestFactories()
        {
            AnthologyFactory.GenerateAgents(10000, 20);
            AnthologyFactory.GenerateSimLocations(10, 20);
            AnthologyFactory.GeneratePrimaryActions(10);
            
            string agentsSerialized = World.ReadWrite.SerializeAllAgents();
            string locationsSerialized = World.ReadWrite.SerializeAllLocations();
            string actionsSerialized = World.ReadWrite.SerializeAllActions();

            Assert.IsTrue(agentsSerialized.Contains("a_0"));
            Assert.IsTrue(agentsSerialized.Contains("a_99"));
            Assert.IsTrue(locationsSerialized.Contains("l_0"));
            Assert.IsTrue(locationsSerialized.Contains("l_4"));
            Assert.IsTrue(actionsSerialized.Contains("action_0"));
            Assert.IsTrue(actionsSerialized.Contains("action_9"));
            
            
            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(1440);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 10000);
            
            // Need to populate location grid with location set. Could be solved by saving an generation to json files and loading them with Init()
            
            
        }
    }
}
