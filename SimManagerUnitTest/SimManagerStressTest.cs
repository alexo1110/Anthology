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
        private const int GRID_SIZE_5 = 4;
        private const int GRID_SIZE_10 = 5;
        private const int GRID_SIZE_20 = 7;
        private const int GRID_SIZE_50 = 10;
        private const int GRID_SIZE_100 = 15;
        private const int GRID_SIZE_500 = 32;
        private const int GRID_SIZE_1k = 45;
        private const int GRID_SIZE_5k = 100;
        private const int GRID_SIZE_10k = 142;
        private const int GRID_SIZE_50k = 317;
        private const int GRID_SIZE_100k = 448;
        private readonly static bool TEST_100 = true; // set to true to run tests for hundred agents
        private readonly static bool TEST_1k = true; // set to true to run tests for thousand agents
        private readonly static bool TEST_10k = true; // set to true to run tests for ten thousand agents
        private readonly static bool TEST_100k = false; // set to true to run tests for hundred thousand agents
        private readonly static bool TEST_1m = false; // set to true to run tests for million agents

        [TestMethod]
        public void Test100Agents5Locations()
        {
            if (!TEST_100) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE_5);
            AnthologyFactory.GenerateSimLocations(5, GRID_SIZE_5);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);
            
            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100Agents10Locations()
        {
            if (!TEST_100) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE_10);
            AnthologyFactory.GenerateSimLocations(10, GRID_SIZE_10);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100Agents20Locations()
        {
            if (!TEST_100) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE_20);
            AnthologyFactory.GenerateSimLocations(20, GRID_SIZE_20);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100Agents50Locations()
        {
            if (!TEST_100) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE_50);
            AnthologyFactory.GenerateSimLocations(50, GRID_SIZE_50);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100Agents100Locations()
        {
            if (!TEST_100) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE_100);
            AnthologyFactory.GenerateSimLocations(100, GRID_SIZE_100);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100Agents500Locations()
        {
            if (!TEST_100) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE_500);
            AnthologyFactory.GenerateSimLocations(500, GRID_SIZE_500);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100Agents1kLocations()
        {
            if (!TEST_100) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE_1k);
            AnthologyFactory.GenerateSimLocations(1000, GRID_SIZE_1k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100Agents5kLocations()
        {
            if (!TEST_100) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE_5k);
            AnthologyFactory.GenerateSimLocations(5000, GRID_SIZE_5k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100Agents10kLocations()
        {
            if (!TEST_100) return;
            AnthologyFactory.GenerateAgents(100, GRID_SIZE_10k);
            AnthologyFactory.GenerateSimLocations(10000, GRID_SIZE_10k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1kAgents5Locations()
        {
            if (!TEST_1k) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE_5);
            AnthologyFactory.GenerateSimLocations(5, GRID_SIZE_5);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1kAgents10Locations()
        {
            if (!TEST_1k) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE_10);
            AnthologyFactory.GenerateSimLocations(10, GRID_SIZE_10);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1kAgents20Locations()
        {
            if (!TEST_1k) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE_20);
            AnthologyFactory.GenerateSimLocations(20, GRID_SIZE_20);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1kAgents50Locations()
        {
            if (!TEST_1k) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE_50);
            AnthologyFactory.GenerateSimLocations(50, GRID_SIZE_50);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1kAgents100Locations()
        {
            if (!TEST_1k) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE_100);
            AnthologyFactory.GenerateSimLocations(100, GRID_SIZE_100);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1kAgents500Locations()
        {
            if (!TEST_1k) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE_500);
            AnthologyFactory.GenerateSimLocations(500, GRID_SIZE_500);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1kAgents1kLocations()
        {
            if (!TEST_1k) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE_1k);
            AnthologyFactory.GenerateSimLocations(1000, GRID_SIZE_1k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1kAgents5kLocations()
        {
            if (!TEST_1k) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE_5k);
            AnthologyFactory.GenerateSimLocations(5000, GRID_SIZE_5k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1kAgents10kLocations()
        {
            if (!TEST_1k) return;
            AnthologyFactory.GenerateAgents(1000, GRID_SIZE_10k);
            AnthologyFactory.GenerateSimLocations(10000, GRID_SIZE_10k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test10kAgents5Locations()
        {
            if (!TEST_10k) return; 
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE_5);
            AnthologyFactory.GenerateSimLocations(5, GRID_SIZE_5);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test10kAgents10Locations()
        {
            if (!TEST_10k) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE_10);
            AnthologyFactory.GenerateSimLocations(10, GRID_SIZE_10);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test10kAgents20Locations()
        {
            if (!TEST_10k) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE_20);
            AnthologyFactory.GenerateSimLocations(20, GRID_SIZE_20);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test10kAgents50Locations()
        {
            if (!TEST_10k) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE_50);
            AnthologyFactory.GenerateSimLocations(50, GRID_SIZE_50);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test10kAgents100Locations()
        {
            if (!TEST_10k) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE_100);
            AnthologyFactory.GenerateSimLocations(100, GRID_SIZE_100);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test10kAgents500Locations()
        {
            if (!TEST_10k) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE_500);
            AnthologyFactory.GenerateSimLocations(500, GRID_SIZE_500);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test10kAgents1kLocations()
        {
            if (!TEST_10k) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE_1k);
            AnthologyFactory.GenerateSimLocations(1000, GRID_SIZE_1k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test10kAgents5kLocations()
        {
            if (!TEST_10k) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE_5k);
            AnthologyFactory.GenerateSimLocations(5000, GRID_SIZE_5k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test10kAgents10kLocations()
        {
            if (!TEST_10k) return;
            AnthologyFactory.GenerateAgents(10000, GRID_SIZE_10k);
            AnthologyFactory.GenerateSimLocations(10000, GRID_SIZE_10k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100kAgents5Locations()
        {
            if (!TEST_100k) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE_5);
            AnthologyFactory.GenerateSimLocations(5, GRID_SIZE_5);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100kAgents10Locations()
        {
            if (!TEST_100k) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE_10);
            AnthologyFactory.GenerateSimLocations(10, GRID_SIZE_10);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100kAgents20Locations()
        {
            if (!TEST_100k) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE_20);
            AnthologyFactory.GenerateSimLocations(20, GRID_SIZE_20);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100kAgents50Locations()
        {
            if (!TEST_100k) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE_50);
            AnthologyFactory.GenerateSimLocations(50, GRID_SIZE_50);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100kAgents100Locations()
        {
            if (!TEST_100k) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE_100);
            AnthologyFactory.GenerateSimLocations(100, GRID_SIZE_100);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100kAgents500Locations()
        {
            if (!TEST_100k) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE_500);
            AnthologyFactory.GenerateSimLocations(500, GRID_SIZE_500);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100kAgents1kLocations()
        {
            if (!TEST_100k) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE_1k);
            AnthologyFactory.GenerateSimLocations(1000, GRID_SIZE_1k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100kAgents5kLocations()
        {
            if (!TEST_100k) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE_5k);
            AnthologyFactory.GenerateSimLocations(5000, GRID_SIZE_5k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test100kAgents10kLocations()
        {
            if (!TEST_100k) return;
            AnthologyFactory.GenerateAgents(100000, GRID_SIZE_10k);
            AnthologyFactory.GenerateSimLocations(10000, GRID_SIZE_10k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1mAgents5Locations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_5);
            AnthologyFactory.GenerateSimLocations(5, GRID_SIZE_5);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1mAgents10Locations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_10);
            AnthologyFactory.GenerateSimLocations(10, GRID_SIZE_10);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1mAgents20Locations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_20);
            AnthologyFactory.GenerateSimLocations(20, GRID_SIZE_20);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1mAgents50Locations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_50);
            AnthologyFactory.GenerateSimLocations(50, GRID_SIZE_50);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1mAgents100Locations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_100);
            AnthologyFactory.GenerateSimLocations(100, GRID_SIZE_100);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1mAgents500Locations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_500);
            AnthologyFactory.GenerateSimLocations(500, GRID_SIZE_500);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1mAgents1kLocations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_1k);
            AnthologyFactory.GenerateSimLocations(1000, GRID_SIZE_1k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1mAgents5kLocations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_5k);
            AnthologyFactory.GenerateSimLocations(5000, GRID_SIZE_5k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        [TestMethod]
        public void Test1mAgents10kLocations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_10k);
            AnthologyFactory.GenerateSimLocations(10000, GRID_SIZE_10k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        //[TestMethod]
        public void Test1mAgents50kLocations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_50k);
            AnthologyFactory.GenerateSimLocations(50000, GRID_SIZE_50k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }

        //[TestMethod]
        public void Test1mAgents100kLocations()
        {
            if (!TEST_1m) return;
            AnthologyFactory.GenerateAgents(1000000, GRID_SIZE_100k);
            AnthologyFactory.GenerateSimLocations(100000, GRID_SIZE_100k);
            AnthologyFactory.GeneratePrimaryActions(NUM_ACTIONS);

            Stopwatch timer = Stopwatch.StartNew();
            ExecutionManager.RunSim(NUM_ITERATIONS);
            timer.Stop();
            Assert.IsTrue(timer.ElapsedMilliseconds < 1, "Time elapsed = " + timer.ElapsedMilliseconds + "ms.");
        }
    }
}
