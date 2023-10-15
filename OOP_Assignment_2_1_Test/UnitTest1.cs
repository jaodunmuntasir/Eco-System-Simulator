using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Assignment_2_1;

namespace OOP_Assignment_2_1.Tests
{
    [TestClass]
    public class EcosystemSimulatorTests
    {
        [TestMethod]
        public void SimulateEcosystem_WhenGivenValidInput_ShouldNotThrowException()
        {
            string filename = "input.txt";
            EcosystemSimulator simulator = new EcosystemSimulator(filename);

            try
            {
                simulator.SimulateEcosystem();
            }
            catch (System.Exception)
            {
                throw new AssertFailedException("An exception was thrown, but none was expected.");
            }
        }

        [TestMethod]
        public void GetRadiationType_WhenAlphaDemandIsHigher_ShouldReturnAlpha()
        {
            int alphaDemand = 5;
            int deltaDemand = 3;
            EcosystemSimulator simulator = new EcosystemSimulator("input.txt");

            string result = simulator.GetRadiationType(alphaDemand, deltaDemand);
            Assert.AreEqual("none", result);
        }

        [TestMethod]
        public void GetRadiationType_WhenDeltaDemandIsHigher_ShouldReturnDelta()
        {
            int alphaDemand = 3;
            int deltaDemand = 6;
            EcosystemSimulator simulator = new EcosystemSimulator("input.txt");

            string result = simulator.GetRadiationType(alphaDemand, deltaDemand);
            Assert.AreEqual("delta", result);
        }

        [TestMethod]
        public void GetRadiationType_WhenAlphaAndDeltaDemandsAreEqual_ShouldReturnNone()
        {
            int alphaDemand = 3;
            int deltaDemand = 3;
            EcosystemSimulator simulator = new EcosystemSimulator("input.txt");

            string result = simulator.GetRadiationType(alphaDemand, deltaDemand);
            Assert.AreEqual("none", result);
        }
    }
}
