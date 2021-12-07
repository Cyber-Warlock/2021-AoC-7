using System;
using System.Collections.Generic;
using Xunit;
using _2021_AoC_7;
using System.Linq;

namespace _2021_AoC_7_Test
{
    public class SubAlignmentSystemTest
    {
        [Theory]
        [InlineData(new int[] { 3, 6, 1, 3, 7, 9, 8 }, 6)]
        [InlineData(new int[] { 9, 9, 9, 1, 1, 1, 2 }, 2)]
        public void FindMedian_FindsMedianInOddCountData(int[] data, int expectedMedian)
        {
            // Arrange
            var sys = new SubAlignmentSystem();

            // Act
            int foundMedian = sys.FindMedian(data.ToList());

            // Assert
            Assert.Equal(expectedMedian, foundMedian);
        }

        [Theory]
        [InlineData(new int[] { 9, 2, 3, 5, 6, 4, 1, 8 }, 4)]
        [InlineData(new int[] { 8, 7, 5, 6, 3, 2, 8, 8 }, 6)]
        public void FindMedian_FindsMedianInEvenCountData(int[] data, int expectedMedian)
        {
            // Arrange
            var sys = new SubAlignmentSystem();

            // Act
            int foundMedian = sys.FindMedian(data.ToList());

            // Assert
            Assert.Equal(expectedMedian, foundMedian);
        }

        [Theory]
        [InlineData(3, new int[] { 1, 3, 3, 6, 8 }, 10)]
        [InlineData(6, new int[] { 5, 5, 6, 7, 6, 8, 5, 5, 5, 6, 1}, 13)]
        public void CalculateFuelUsageLinear_FindsActualFuelUsage(int targetAlignment, int[] currentAlignment, int expectedFuelUsage)
        {
            // Arrange
            var sys = new SubAlignmentSystem();

            // Act
            int calculatedFuelUsage = sys.CalculateFuelUsageLinear(targetAlignment, currentAlignment.ToList());

            // Assert
            Assert.Equal(expectedFuelUsage, calculatedFuelUsage);
        }

        // func y=1.776357*10^{-14}+0.5x+0.5x^{2}
        [Theory]
        [InlineData(new int[] { 1, 3, 3, 6, 8 }, 21)] //avg 4 //align:fuel (1:49) (2:34) (3:24) (4:21) (5:23) (6:30)
        [InlineData(new int[] { 5, 5, 6, 7, 6, 8, 5, 5, 5, 6, 1 }, 22)] //avg 5 //align:fuel (3:22)
        public void CalculateFuelUsageExponential_FindsActualFuelUsage(int[] currentAlignment, int expectedFuelUsage)
        {
            // Arrange
            var sys = new SubAlignmentSystem();

            var currentAlignmentList = currentAlignment.ToList();
            // Find the average alignment
            int targetAlignment = (int)currentAlignmentList.Average();

            // Act
            int calculatedFuelUsage = sys.CalculateFuelUsageExponential(targetAlignment, currentAlignmentList);

            // Assert
            Assert.Equal(expectedFuelUsage, calculatedFuelUsage);
        }
    }
}
