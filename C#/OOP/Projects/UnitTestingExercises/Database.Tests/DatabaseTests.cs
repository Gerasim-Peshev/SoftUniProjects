using System;
using System.Runtime.InteropServices.ComTypes;
using Database;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database myDatabase;
        [SetUp]
        public void Setup()
        {
           this.myDatabase = new Database(new int[] { 1, 2, 3, 4, 5, 6 });
        }
        [Test]
        public void Add_Number()
        {
            int num = 4;
            this.myDatabase.Add(num);
            Assert.AreEqual(7,this.myDatabase.Count);
        }

        [Test]
        public void Remove_Number()
        {
            this.myDatabase.Remove();
            Assert.AreEqual(5,this.myDatabase.Count);
        }

        [Test]
        public void Returning_Array()
        {
            int[] newReturnedArray = this.myDatabase.Fetch();
            int[] expectedArray = new int[] {1, 2, 3, 4, 5, 6};

            Assert.AreEqual(expectedArray,newReturnedArray);
        }

        [Test]
        public void Overflow_Constructor()
        {
            int[] numbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
            Assert.Throws<InvalidOperationException>(() =>
            {
                new Database(numbers);
            });
        }
    }
}
