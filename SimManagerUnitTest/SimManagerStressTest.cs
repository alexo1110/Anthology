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
        private const int NUM_ACTIONS = 10; // number of possible actions each agent can consider choosing
        private const int NUM_ITERATIONS = 60; // number of iterations to run each test
        private const int GRID_SIZE = 400; // size of the map grid for each test
        private readonly static bool TEST_HUNDRED = false; // set to true to run tests for hundred agents
        private readonly static bool TEST_THOUSAND = false; // set to true to run tests for thousand agents
        private readonly static bool TEST_TEN_THOUSAND = false; // set to true to run tests for ten thousand agents
        private readonly static bool TEST_HUNDRED_THOUSAND = false; // set to true to run tests for hundred thousand agents
        private readonly static bool TEST_MILLION = false; // set to true to run tests for million agents

        [TestMethod]
        public void TestHundredAgentsFiveLocations()
        {
            if (!TEST_HUNDRED) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(5, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);
            
            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredAgentsTenLocations()
        {
            if (!TEST_HUNDRED) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(10, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredAgentsTwentyLocations()
        {
            if (!TEST_HUNDRED) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(20, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredAgentsFiftyLocations()
        {
            if (!TEST_HUNDRED) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(50, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredAgentsHundredLocations()
        {
            if (!TEST_HUNDRED) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(100, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredAgentsFiveHundredLocations()
        {
            if (!TEST_HUNDRED) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(500, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredAgentsThousandLocations()
        {
            if (!TEST_HUNDRED) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(1000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredAgentsFiveThousandLocations()
        {
            if (!TEST_HUNDRED) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(5000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredAgentsTenThousandLocations()
        {
            if (!TEST_HUNDRED) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(10000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsFiveLocations()
        {
            if (!TEST_THOUSAND) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(5, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsTenLocations()
        {
            if (!TEST_THOUSAND) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(10, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsTwentyLocations()
        {
            if (!TEST_THOUSAND) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(20, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsFiftyLocations()
        {
            if (!TEST_THOUSAND) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(50, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsHundredLocations()
        {
            if (!TEST_THOUSAND) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(100, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsFiveHundredLocations()
        {
            if (!TEST_THOUSAND) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(500, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsThousandLocations()
        {
            if (!TEST_THOUSAND) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(1000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsFiveThousandLocations()
        {
            if (!TEST_THOUSAND) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(5000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestThousandAgentsTenThousandLocations()
        {
            if (!TEST_THOUSAND) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(10000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsFiveLocations()
        {
            if (!TEST_TEN_THOUSAND) return; 
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(5, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsTenLocations()
        {
            if (!TEST_TEN_THOUSAND) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(10, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsTwentyLocations()
        {
            if (!TEST_TEN_THOUSAND) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(20, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsFiftyLocations()
        {
            if (!TEST_TEN_THOUSAND) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(50, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsHundredLocations()
        {
            if (!TEST_TEN_THOUSAND) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(100, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsFiveHundredLocations()
        {
            if (!TEST_TEN_THOUSAND) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(500, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsThousandLocations()
        {
            if (!TEST_TEN_THOUSAND) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(1000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsFiveThousandLocations()
        {
            if (!TEST_TEN_THOUSAND) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(5000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestTenThousandAgentsTenThousandLocations()
        {
            if (!TEST_TEN_THOUSAND) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(10000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsFiveLocations()
        {
            if (!TEST_HUNDRED_THOUSAND) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(5, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsTenLocations()
        {
            if (!TEST_HUNDRED_THOUSAND) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(10, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsTwentyLocations()
        {
            if (!TEST_HUNDRED_THOUSAND) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(20, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsFiftyLocations()
        {
            if (!TEST_HUNDRED_THOUSAND) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(50, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsHundredLocations()
        {
            if (!TEST_HUNDRED_THOUSAND) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(100, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsFiveHundredLocations()
        {
            if (!TEST_HUNDRED_THOUSAND) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(500, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsThousandLocations()
        {
            if (!TEST_HUNDRED_THOUSAND) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(1000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsFiveThousandLocations()
        {
            if (!TEST_HUNDRED_THOUSAND) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(5000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestHundredThousandAgentsTenThousandLocations()
        {
            if (!TEST_HUNDRED_THOUSAND) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(10000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsFiveLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(5, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsTenLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(10, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsTwentyLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(20, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsFiftyLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(50, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsHundredLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(100, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsFiveHundredLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(500, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsThousandLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(1000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsFiveThousandLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(5000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsTenThousandLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(10000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsFiftyThousandLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(50000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void TestMillionAgentsHundredThousandLocations()
        {
            if (!TEST_MILLION) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE);
            AnthologyFactory.GenerateSimLocations(100000, GRID_SIZE);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }
    }
}
