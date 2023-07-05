using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_Test()
        {
            RaceEntry race = new RaceEntry();
            Assert.AreEqual(0, race.Counter);
        }

        [Test]
        public void Add_Tests()
        {
            RaceEntry race = new RaceEntry();

            string result = race.AddDriver(new UnitDriver("Gero", new UnitCar("BMW M4", 444, 3000)));
            Assert.AreEqual("Driver Gero added in race.",result);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(new UnitDriver("Gero", new UnitCar("Bez M4", 4, 0.3)));
            });

            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        public void Add_Test_NullExeption()
        {
            RaceEntry race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(null);
            });
        }

        [Test]
        public void Calculate_Tests()
        {
            RaceEntry race = new RaceEntry();

            race.AddDriver(new UnitDriver("Gero", new UnitCar("BMW M4", 444, 3000)));

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            });

            race.AddDriver(new UnitDriver("Stich", new UnitCar("Nissan 350Z", 313, 3500)));
            race.AddDriver(new UnitDriver("Sasho", new UnitCar("Ferrari 599GTO", 661, 6000)));

            double expected = race.CalculateAverageHorsePower();

            Assert.AreEqual(expected, race.CalculateAverageHorsePower());
        }
    }
}