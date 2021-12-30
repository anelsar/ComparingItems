using System;
using System.Collections.Generic;

namespace TestTask.Services
{
    public class GenerateRandomValues : IRandomValueGenerate
    {
        // generating a random value

        private List<int> RandomValues { get; set; }
        public GenerateRandomValues()
        {
            RandomValues = new List<int>();
        }
        public List<int> GenerateValues(int lowerLimit, int uperLimit)
        {
            Random rnd = new Random();
            var firstRandomValue = rnd.Next(lowerLimit, uperLimit);
            var secondRanomItem = rnd.Next(lowerLimit, uperLimit);
            while (firstRandomValue == secondRanomItem)
                secondRanomItem = rnd.Next(lowerLimit, uperLimit);
            RandomValues.Add(firstRandomValue);
            RandomValues.Add(secondRanomItem);
            return RandomValues;
        }
    }
}