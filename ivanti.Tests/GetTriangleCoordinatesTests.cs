using Ivanti.Controllers;
using NUnit.Framework;

namespace ivanti.Tests
{

    [TestFixture]
    public class GetTriangleCoordinatesTests
    {

        private TriangleController triangleController;

        [SetUp]

        public void setup()
        {
            triangleController = new TriangleController();

        }

        [Test]
        public void shouldNotThrowAnyErrorWhenInputIsNUll() {
            Assert.DoesNotThrow( () => triangleController.GetTriangleCoordinates(null));
        }
        [Test]
        public void shouldReturnCorrectCoordinatesdWhenTriangleColumnNumberIsEven() {
            var trianglecoordinates = triangleController.GetTriangleCoordinates("F10");
            Assert.AreEqual(50,trianglecoordinates.point1[0]);
            Assert.AreEqual(0, trianglecoordinates.point1[1]);
            Assert.AreEqual(50, trianglecoordinates.point2[0]);
            Assert.AreEqual(10, trianglecoordinates.point2[1]);
            Assert.AreEqual(40, trianglecoordinates.point3[0]);
            Assert.AreEqual(10, trianglecoordinates.point3[1]);
        }
        [Test]
        public void shouldReturnCorrectCoordinatesdWhenTriangleColumnNumberIsOdd()
        {
            var trianglecoordinates = triangleController.GetTriangleCoordinates("F9");
            Assert.AreEqual(40, trianglecoordinates.point1[0]);
            Assert.AreEqual(0, trianglecoordinates.point1[1]);
            Assert.AreEqual(50, trianglecoordinates.point2[0]);
            Assert.AreEqual(0, trianglecoordinates.point2[1]);
            Assert.AreEqual(40, trianglecoordinates.point3[0]);
            Assert.AreEqual(10, trianglecoordinates.point3[1]);
        }
    }
}
