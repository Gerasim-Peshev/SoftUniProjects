using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Presents.Tests
{
    [TestFixture]
    public class BagTests
    {
        [Test]
        public void Ctor_Tests()
        {
            Bag bag = new Bag();
            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void Create_Tests()
        {
            Bag bag = new Bag();

            Present present = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });

            present = new Present("Car", 44.44);
            
            string result = bag.Create(present);
            Assert.AreEqual($"Successfully added present {present.Name}.", result);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Remove_Tests()
        {
            Bag bag = new Bag();
            Present present = new Present("Car", 44.44);

            bag.Create(present);

            Assert.IsTrue(bag.Remove(present));
            Assert.IsFalse(bag.Remove(present));
        }

        [Test]
        public void GetPresWithLeastmagic_Tests()
        {
            Bag bag = new Bag();
            Present present = new Present("Car", 44.44);

            bag.Create(present);
            Present actualPresent = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(present,actualPresent);
        }

        [Test]
        public void GetPresent_Tests()
        {
            Bag bag = new Bag();
            Present present = new Present("BMW M4", 44.44);

            Assert.AreEqual(null, bag.GetPresent(present.Name));


                bag.Create(present);

            Present actualPresent = bag.GetPresent("BMW M4");
            Assert.AreEqual(present, actualPresent);
        }

        [Test]
        public void GetPresents_Tests()
        {
            Bag bag = new Bag();

            bag.Create(new Present("BMW M4", 44.44));
            bag.Create(new Present("BMW M5", 55.55));

            IReadOnlyCollection<Present> presents =
                new ReadOnlyCollection<Present>(new List<Present>()
                                                    {new Present("BMW M4", 44.44), new Present("BMW M5", 55.55)});

            IReadOnlyCollection<Present> actialPresents = bag.GetPresents();

            Assert.AreNotEqual(presents, actialPresents);
        }
    }
}
