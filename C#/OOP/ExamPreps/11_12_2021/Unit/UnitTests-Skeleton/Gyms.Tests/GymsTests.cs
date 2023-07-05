using System;
using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Ctor_Tests()
        {
            Gym gym = new Gym("Silite", 4);

            Assert.AreEqual("Silite", gym.Name);
            Assert.AreEqual(4, gym.Capacity);
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym2 = new Gym(null, 4);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym3 = new Gym("Silite", -4);
            });
        }

        [Test]
        public void Add_Athlet_Method()
        {
            Gym gym = new Gym("Silite", 1);
            gym.AddAthlete(new Athlete("Gero"));
            Assert.AreEqual(1, gym.Count);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(new Athlete("Sasho"));
            });
        }

        [Test]
        public void Remove_Athleth_Method()
        {
            Gym gym = new Gym("Silite",1);
            gym.AddAthlete(new Athlete("Emo"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(null);
            });
            gym.RemoveAthlete("Emo");
            Assert.AreEqual(0,gym.Count);
        }

        [Test]
        public void Injured_Athleth_Method()
        {
            Gym gym = new Gym("Silite", 1);
            gym.AddAthlete(new Athlete("Hris"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Sasho");
            });
            Athlete athlete = gym.InjureAthlete("Hris");
            Assert.AreEqual(true,athlete.IsInjured);
        }

        [Test]
        public void Report_Tests()
        {
            Gym gym = new Gym("Silite", 1);
            gym.AddAthlete(new Athlete("Gero"));

            string message = gym.Report();
            Assert.AreEqual($"Active athletes at {gym.Name}: Gero", message);
        }
    }
}
