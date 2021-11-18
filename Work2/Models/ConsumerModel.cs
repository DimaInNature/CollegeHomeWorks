using System;
using System.Collections.Generic;
using Work2.Models.Base;

namespace Work2.Models
{
    public class ConsumerModel : BaseModel
    {
        public int YearOfBirth { get; set; }
        public string StreetName { get; set; }

        public ConsumerModel() => Id = RandomizeNewId();

        public static List<ConsumerModel> Create(int count)
        {
            var consumers = new List<ConsumerModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                consumers.Add(CreateRandom());
            }

            return consumers;
        }

        public static List<ConsumerModel> EnumerableCreate(int count)
        {
            var consumers = new List<ConsumerModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                var consumer = CreateRandom(i);
                consumers.Add(consumer);
            }

            return consumers;
        }

        public static ConsumerModel Create(int yearOfBirth, string streetName) => new()
        {
            YearOfBirth = yearOfBirth,
            StreetName = streetName
        };

        public override string ToString() =>
            $"Street is {StreetName}, year of birth is {YearOfBirth}, {Id}";

        private static ConsumerModel CreateRandom() => new ()
        {
            StreetName = RandomizeNewStreetName(),
            YearOfBirth = RandomizeNewYearOfBirth()
        };

        private static ConsumerModel CreateRandom(int id) => new()
        {
            Id = id,
            StreetName = RandomizeNewStreetName(),
            YearOfBirth = RandomizeNewYearOfBirth()
        };

        private static string RandomizeNewStreetName() =>
            $"Street {new Random().Next(1, 10)}";

        private static int RandomizeNewYearOfBirth() =>
            new Random().Next(1980, DateTime.Now.Year);
    }
}