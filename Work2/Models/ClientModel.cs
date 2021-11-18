using System;
using System.Collections.Generic;
using Work2.Models.Base;

namespace Work2.Models
{
    public class ClientModel : BaseModel
    {
        public int Year { get; set; }
        public int NumberMonth { get; set; }
        public int DurationOfActivitiesInHours { get; set; }

        public ClientModel() => Id = RandomizeNewId();

        public static List<ClientModel> Create(int count)
        {
            var clients = new List<ClientModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                clients.Add(CreateRandom());
            }

            return clients;
        }

        public static ClientModel Create(int year,
            int numberMonth, int durationOfActivitiesInHours) => new() 
        {
            DurationOfActivitiesInHours = durationOfActivitiesInHours, 
            NumberMonth = numberMonth, 
            Year = year
        };

        public override string ToString() => 
            $"Id is {Id}, year is {Year}, number month is {NumberMonth}, " + 
            $"Duration in activities (in hours) is {DurationOfActivitiesInHours}";
        
        private static ClientModel CreateRandom() => new () 
        {
            DurationOfActivitiesInHours = RandomizeNewDuration(), 
            NumberMonth = RandomizeNewNumberMonth(), 
            Year = RandomizeNewYear()
        };

        private static int RandomizeNewDuration() =>
            new Random().Next(1, 1000);

        private static int RandomizeNewNumberMonth() =>
            new Random().Next(1, 12);

        private static int RandomizeNewYear() =>
            new Random().Next(2015, 2021);
    }
}