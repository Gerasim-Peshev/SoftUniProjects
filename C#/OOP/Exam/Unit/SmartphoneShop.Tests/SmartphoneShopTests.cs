using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop3 = new Shop(4);

        [Test]
        public void SmartPhone_Tests()
        {
            Smartphone smartphone = new Smartphone("Poco_F1", 4000);
            Assert.AreEqual("Poco_F1", smartphone.ModelName);
            Assert.AreEqual(4000, smartphone.CurrentBateryCharge);
            Assert.AreEqual(4000, smartphone.MaximumBatteryCharge);
        }
        [Test]
        public void Ctor_And_Capacity_Tests()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-4);
            });


            Shop shop = new Shop(4);
            Assert.AreEqual(4, shop.Capacity);
            Assert.AreEqual(0, shop.Count);

            Shop shop2 = shop;
            Assert.That(shop.Equals(shop2));
            //listPhonesCheck
        }

        [Test]
        public void Add_Tests()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("iPhone_11_Pro", 3800);
            Smartphone smartphone2 = new Smartphone("Xiaomi_Poco_F1", 4000);
            Smartphone smartphone3 = new Smartphone("Xiaomi_Poco_X3_Pro",5000);

            shop.Add(smartphone1);
            Assert.AreEqual(1, shop.Count);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone1);
            });

            shop.Add(smartphone2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone3);
            });
        }

        [Test]
        public void Remove_Tests()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("iPhone_11_Pro", 3800);
            Smartphone smartphone2 = new Smartphone("Xiaomi_Poco_F1", 4000);

            shop.Add(smartphone1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(smartphone2.ModelName);
            });
            shop.Remove(smartphone1.ModelName);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void TestPhone_Tests()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("iPhone_11_Pro", 3800);
            Smartphone smartphone2 = new Smartphone("Xiaomi_Poco_F1", 4000);

            shop.Add(smartphone1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(smartphone2.ModelName, 300);
            });
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(smartphone1.ModelName, 5000);
            });

            shop.TestPhone(smartphone1.ModelName,800);
            Assert.AreEqual(smartphone1.CurrentBateryCharge, 3000);
        }

        [Test]
        public void ChargePhone_Tests()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("iPhone_11_Pro", 3800);
            Smartphone smartphone2 = new Smartphone("Xiaomi_Poco_F1", 4000);

            shop.Add(smartphone1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(smartphone2.ModelName);
            });
            shop.ChargePhone(smartphone1.ModelName);
            Assert.AreEqual(3800,smartphone1.CurrentBateryCharge);
            Assert.AreEqual(smartphone1.MaximumBatteryCharge, smartphone1.CurrentBateryCharge);
        }
    }
}