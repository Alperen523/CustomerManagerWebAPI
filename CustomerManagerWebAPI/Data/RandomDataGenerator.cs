using System;
using System.Collections.Generic;

namespace CustomerManagerWebApiByAlp.Data
{
    public static class RandomDataGenerator
    {
        private static readonly List<string> FirstNames = new List<string>
        {
            "John", "Jane", "Michael", "Sarah", "David", "Emma", "Chris", "Emily", "James", "Olivia"
        };

        private static readonly List<string> LastNames = new List<string>
        {
            "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor"
        };

        private static readonly List<string> Streets = new List<string>
        {
            "Main St", "Elm St", "2nd St", "Oak St", "Pine St", "Maple St", "Cedar St", "Birch St", "Walnut St", "Peachtree St"
        };


        private static readonly Random random = new Random();

        public static string GetRandomFirstName()
        {
            return FirstNames[random.Next(FirstNames.Count)];
        }

        public static string GetRandomLastName()
        {
            return LastNames[random.Next(LastNames.Count)];
        }


        public static string GetRandomStreet()
        {
            return $"{random.Next(1, 1000)} {Streets[random.Next(Streets.Count)]}";
        }

        public static DateTime GetRandomDateOfBirth()
        {
            int year = random.Next(1950, 2005);
            int month = random.Next(1, 13);
            int day = random.Next(1, 28); // Simplified, avoiding complexities of different month lengths
            return new DateTime(year, month, day);
        }
    }
}
