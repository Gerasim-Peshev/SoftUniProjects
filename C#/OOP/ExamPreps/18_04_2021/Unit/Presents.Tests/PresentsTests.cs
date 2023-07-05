namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Present_Tests()
        {
            Present present = new Present("Car", 44.44);
            Assert.AreEqual("Car", present.Name);
            Assert.AreEqual(44.44, present.Magic);
        }
    }
}
