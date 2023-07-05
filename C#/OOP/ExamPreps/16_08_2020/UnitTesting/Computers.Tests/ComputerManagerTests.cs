using System;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            ComputerManager computer1 = new ComputerManager();
            ComputerManager computer2 = new ComputerManager();
            Assert.AreEqual(computer1.Computers, computer2.Computers);
        }

        [Test]
        public void AddMethod()
        {
            ComputerManager computer = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                computer.AddComputer(new Computer(null, "towa", -39));
            });

            Assert.Throws<ArgumentException>(() =>
            {
                computer.AddComputer(new Computer("Misho", "Ono", 200));
                computer.AddComputer(new Computer("Misho","Ono",20));
            });

            Assert.AreEqual(1, computer.Computers.Count);
        }
    }
}