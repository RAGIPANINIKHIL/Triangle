using Ivanti;
using Ivanti.Controllers;
using NUnit.Framework;


namespace ivanti.Tests
{
    public class GetTriangleRowAndColumnTests
    {
        private TriangleController triangleController;

        [SetUp]

        public void setup()
        {
            triangleController = new TriangleController();

        }

        [Test]
        public void shouldNotThrowAnyErrorWhenInputIsNUll()
        {
            Assert.DoesNotThrow(() => triangleController.GetTriangleRowAndColumn(null));
        }
        [Test]
        public void shouldReturnCorrectRowAndColumnWhenTriangleColumnNumberIsEven()
        {
            var coordinates = new TriangleCoordinates() {
                point1 = new int[2],
                point2 = new int[2],
                point3 = new int[2]
            };
            coordinates.point1[0] = 50;
            coordinates.point1[1] = 0;
            coordinates.point2[0] = 50;
            coordinates.point2[1] = 10;
            coordinates.point3[0] = 40;
            coordinates.point3[1] = 10;
            var triangleRowandColumn = triangleController.GetTriangleRowAndColumn(coordinates);
            Assert.AreEqual("F10", triangleRowandColumn);
        }
        [Test]
        public void shouldReturnCorrectRowAndColumnWhenTriangleColumnNumberIsOdd()
        {
            var coordinates = new TriangleCoordinates()
            {
                point1 = new int[2],
                point2 = new int[2],
                point3 = new int[2]
            };
            coordinates.point1[0] = 40;
            coordinates.point1[1] = 0;
            coordinates.point2[0] = 50;
            coordinates.point2[1] = 0;
            coordinates.point3[0] = 40;
            coordinates.point3[1] = 10;
            var triangleRowandColumn = triangleController.GetTriangleRowAndColumn(coordinates);
            Assert.AreEqual("F9", triangleRowandColumn);
        }
    }
}
