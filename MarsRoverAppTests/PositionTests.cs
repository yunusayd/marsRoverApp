using System;
using MarsRoverApp;
using NUnit.Framework;

namespace MarsRoverAppTests
{
    public class PositionTests
    {
        [TestCase("1 1 N", 1,1, Direction.N)]
        [TestCase("100 200 E", 100, 200, Direction.E)]
        [TestCase("4 5 W", 4, 5, Direction.W)]
        [TestCase("4 5 S", 4, 5, Direction.S)]
        [Test]
        public void ItShouldWorkCreateGrid(string input, int x, int y, Direction direction)
        {
            // arrange 
            var position = new Position(input);
            // assert
            Assert.AreEqual(x, position.X);
            Assert.AreEqual(y, position.Y);
            Assert.AreEqual(direction, position.Direction);
        }
        

        [TestCase("A")]
        [TestCase("")]
        [TestCase("1_2")]
        [TestCase("1 2 K")]
        [Test]
        public void ItShouldNotWorkArgumentException(string input)
        {
            // assert
            Assert.Throws<ArgumentException>(() => new Position(input));
        }
    }
}
