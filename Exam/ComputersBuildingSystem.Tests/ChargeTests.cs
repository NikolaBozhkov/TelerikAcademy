using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputersBuildingSystem.Tests
{
    using ComputersBuildingSystem;
    using ComputersBuildingSystem.DeviceComponents;

    [TestClass]
    public class ChargeTests
    {
        [TestMethod]
        public void ChargingWithValueBelowMaximumShouldMakeThePercentage0()
        {
            var battery = new LaptopBattery();
            battery.Charge(-1000);
            Assert.AreEqual(0, battery.Percentage);
        }

        [TestMethod]
        public void ChargingWtihMoreThanMaximumShouldMakeThePercentage100()
        {
            var battery = new LaptopBattery();
            battery.Charge(1000);
            Assert.AreEqual(100, battery.Percentage);
        }

        [TestMethod]
        public void ChargingWithPositiveShouldIncreaseThePercentageOfTheBattery()
        {
            var battery = new LaptopBattery();
            battery.Charge(10);
            Assert.AreEqual(60, battery.Percentage);
        }

        [TestMethod]
        public void ChargingWithNegativeShouldIncreaseThePercentageOfTheBattery()
        {
            var battery = new LaptopBattery();
            battery.Charge(-10);
            Assert.AreEqual(40, battery.Percentage);
        }
    }
}
