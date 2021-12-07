using System;
using System.Collections.Generic;
using System.Text;

namespace _2021_AoC_7
{
    public class SubAlignmentSystem
    {
        public int FindMedian(List<int> data)
        {
            data.Sort();
            return data[(data.Count + 1) / 2 - 1];
        }

        public int CalculateFuelUsageLinear(int targetAlignment, List<int> currentAlignments)
        {
            int fuelUsage = 0;

            foreach (int alignment in currentAlignments)
            {
                fuelUsage += Math.Abs(alignment - targetAlignment);
            }

            return fuelUsage;
        }

        public int CalculateFuelUsageExponential(int targetAlignment, List<int> currentAlignments)
        {
            int fuelUsage = 0;

            foreach (int alignment in currentAlignments)
            {
                int distance = Math.Abs(targetAlignment - alignment);
                fuelUsage += distance * (distance + 1) / 2;
            }

            return fuelUsage;
        }
    }
}
