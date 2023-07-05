using System.Collections.Generic;
using System.Xml.Serialization;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Robots.Tests
{
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void Retutn_Robot_With_Positive_Input()
        {
            var robot1 = new Robot("Tony", 444);
            Assert.AreEqual("Tony", robot1.Name);
        }
        [Test]
        public void Retutn_Robot_With_Positive_Battery_Input()
        {
            var robot1 = new Robot("Tony", 444);
            Assert.AreEqual(444, robot1.Battery);
        }
        [Test]
        public void Retutn_Robot_With_Positive_MaximumBattery_Input()
        {
            var robot1 = new Robot("Tony", 444);
            Assert.AreEqual(444, robot1.MaximumBattery);
        }
        [Test]
        public void Retutn_Robot_With_NullName_Input()
        {
            var robot1 = new Robot(null, 444);
            Assert.AreEqual(null, robot1.Name);
        }
        [Test]
        public void Retutn_Robot_With_EmptyName_Input()
        {
            var robot1 = new Robot("", 444);
            Assert.AreEqual("", robot1.Name);
        }
        [Test]
        public void Return_RoboManager_Ctor_Positive()
        {
            var manager = new RobotManager(4);
            //manager.Add(new Robot("Tony", 444));

            Assert.AreEqual(0, manager.Count);
        }
        [Test]
        public void Returt_RoboManager_Add_Positive()
        {
            var manager = new RobotManager(4);
            manager.Add(new Robot("Tony", 444));

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void Returt_RoboManager_Add_AlreadyAdded_InvalidOperation_Negative()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var manager = new RobotManager(4);
                manager.Add(new Robot("Tony", 444));
                manager.Add(new Robot("Tony", 444));
            });
        }
        [Test]
        public void Returt_RoboManager_Add_InvalidOperation_CapacityOverFlow_Negative()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var manager = new RobotManager(1);
                manager.Add(new Robot("Tony", 444));
                manager.Add(new Robot("Tony", 444));
            });
        }

        [Test]
        public void Return_RoboManager_Remove_Positive()
        {
            var manager = new RobotManager(2);
            manager.Add(new Robot("Tony", 444));
            manager.Remove("Tony");
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void Return_RoboManager_Remove_Exeption_Negative()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var manager = new RobotManager(2);
                manager.Add(new Robot("Tony", 444));
                manager.Remove("Misho");
            });
        }

        [Test]
        public void Return_RoboManager_Capacity_Positive()
        {
            var manager = new RobotManager(4);
            Assert.AreEqual(4, manager.Capacity);
        }

        [Test]
        public void Return_RoboManager_Capacity_Exeption_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var manager = new RobotManager(4);
            });
        }

        [Test]
        public void Return_RoboManager_Work_Positive()
        {
            var manager = new RobotManager(2);
            manager.Add(new Robot("Tony", 444));
            manager.Work("Tony", "OverTaking", 44);
            Assert.AreEqual(1, manager.Count);
        }
        [Test]
        public void Return_RoboManager_Work_RoboNotFound_Negative()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var manager = new RobotManager(2);
                manager.Add(new Robot("Tony", 444));
                manager.Work("Misho", "OverTaking", 44);
            });
        }
        [Test]
        public void Return_RoboManager_Work_NotEnoughtBattery_Negative()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var manager = new RobotManager(2);
                manager.Add(new Robot("Tony", 444));
                manager.Work("Tony", "OverTaking", 4444);
            });
        }
        [Test]
        public void Return_RoboManager_Charge_RobotNotFound_Negative()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var manager = new RobotManager(2);
                manager.Add(new Robot("Tony", 444));
                manager.Charge("Misho");
            });
        }
        [Test]
        public void Return_RoboManager_Charge_Positive()
        {
            var manager = new RobotManager(2);
            manager.Add(new Robot("Tony", 444));
            manager.Charge("Tony");
            Assert.AreEqual(1, manager.Count);
        }
    }
}
