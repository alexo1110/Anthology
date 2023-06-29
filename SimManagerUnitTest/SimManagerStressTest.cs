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
        private const int NUM_ACTIONS = 10;
        private const int NUM_ITERATIONS = 60;

        [TestMethod]
        public void TestHundredAgentsFiveLocations()
        {
            AnthologyFactory.GenerateAgents(100, 10);
            AnthologyFactory.GenerateSimLocations(5, 10);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);
            
            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredAgentsTenLocations()
        {
            AnthologyFactory.GenerateAgents(100, 10);
            AnthologyFactory.GenerateSimLocations(10, 10);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredAgentsTwentyLocations()
        {
            AnthologyFactory.GenerateAgents(100, 10);
            AnthologyFactory.GenerateSimLocations(20, 10);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsTenLocations()
        {
            AnthologyFactory.GenerateAgents(1000, 20);
            AnthologyFactory.GenerateSimLocations(10, 20);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsFiftyLocations()
        {
            AnthologyFactory.GenerateAgents(1000, 20);
            AnthologyFactory.GenerateSimLocations(50, 20);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsHundredLocations()
        {
            AnthologyFactory.GenerateAgents(1000, 20);
            AnthologyFactory.GenerateSimLocations(100, 20);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsHundredLocations()
        {
            AnthologyFactory.GenerateAgents(10000, 40);
            AnthologyFactory.GenerateSimLocations(100, 40);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsFiveHundredLocations()
        {
            AnthologyFactory.GenerateAgents(10000, 40);
            AnthologyFactory.GenerateSimLocations(500, 40);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsThousandLocations()
        {
            AnthologyFactory.GenerateAgents(10000, 40);
            AnthologyFactory.GenerateSimLocations(1000, 40);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsThousandLocations()
        {
            AnthologyFactory.GenerateAgents(100000, 200);
            AnthologyFactory.GenerateSimLocations(1000, 200);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsFiveThousandLocations()
        {
            AnthologyFactory.GenerateAgents(100000, 200);
            AnthologyFactory.GenerateSimLocations(5000, 200);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsTenThousandLocations()
        {
            AnthologyFactory.GenerateAgents(100000, 200);
            AnthologyFactory.GenerateSimLocations(10000, 200);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsTenThousandLocations()
        {
            AnthologyFactory.GenerateAgents(1000000, 400);
            AnthologyFactory.GenerateSimLocations(10000, 400);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsFiftyThousandLocations()
        {
            AnthologyFactory.GenerateAgents(1000000, 400);
            AnthologyFactory.GenerateSimLocations(50000, 400);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsHundredThousandLocations()
        {
            AnthologyFactory.GenerateAgents(1000000, 400);
            AnthologyFactory.GenerateSimLocations(100000, 400);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }
    }
}
