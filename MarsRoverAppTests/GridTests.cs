using System;
using MarsRoverApp;
using NUnit.Framework;

namespace MarsRoverAppTests
{
    public class GridTests
    {
        [TestCase("1 1", 1, 1)]
        [TestCase("100 200", 100, 200)]
        [TestCase("4 5", 4, 5)]
        [Test]
        public void ItShouldWorkCreateGrid(string input, int x, int y)
        {
            // arrange 
            var grid = new Grid(input);
            // assert
            Assert.AreEqual(x, grid.X);
            Assert.AreEqual(y, grid.Y);
        }

        [TestCase("-1 1")]
        [TestCase("-100 -99")]
        [Test]
        public void ItShouldNotWorkOutOfRangeException(string input)
        {
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(input));
        }

        [TestCase(-1, 1)]
        [TestCase(1, -99)]
        [Test]
        public void ItShouldNotWorkOutOfRangeException(int x, int y)
        {
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(x, y));
        }

        [TestCase("A")]
        [TestCase("")]
        [TestCase("1_2")]
        [Test]
        public void ItShouldNotWorkArgumentException(string input)
        {
            // assert
            Assert.Throws<ArgumentException>(() => new Grid(input));
        }
    }
}