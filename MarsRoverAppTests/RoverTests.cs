using NUnit.Framework;
using System;
using System.Linq;

namespace MarsRoverAppTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM", "1 3 N\n5 1 E\n")]
        [Test]
        public void ItShouldWorkMoveOnExam(string input, string expectedOutput)
        {
            // arrange
            var lines = input.Split("\n").ToList();
            var expectedOutPositions = expectedOutput.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            // act
            var result = MarsRoverApp.Program.Process(lines);

            // assert
            Assert.AreEqual(result.Count, expectedOutPositions.Length);
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i].Position.GetInfo(), expectedOutPositions[i]);
            }
        }
    }
}