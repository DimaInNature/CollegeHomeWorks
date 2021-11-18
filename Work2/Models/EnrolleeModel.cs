using System;
using System.Collections.Generic;
using Work2.Models.Base;

namespace Work2.Models
{
    public class EnrolleeModel : BaseModel
    {
        public string Surname { get; set; }
        public int SchoolNumber { get; set; }
        public int YearOfIntering { get; set; }

        public EnrolleeModel() => Id = RandomizeNewId();

        public static List<EnrolleeModel> Create(int count)
        {
            var enrollies = new List<EnrolleeModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                enrollies.Add(CreateRandom());
            }

            return enrollies;
        }

        public static EnrolleeModel Create(string surname,
            int schoolNumber, int yearOfIntering) => new()
        {
            Surname = surname, 
            SchoolNumber = schoolNumber, 
            YearOfIntering = yearOfIntering
        };

        public override string ToString() =>
            $"Surname is {Surname}, school number is {SchoolNumber}, " +
            $"year of intering is {YearOfIntering}";

        private static EnrolleeModel CreateRandom() => new()
        {
            Surname = RandomizeNewSurname(),
            SchoolNumber = RandomizeSchoolNumber(),
            YearOfIntering = RandomizeYearOfEntering()
        };

        private static string RandomizeNewSurname()
        {
            var surnames = new List<string>()
            {
                "Ivanov", "Johnson", "Walker", "Hall","White",
                "Wilson","Moore","Taylor","Harris","Petrov"
            };

            int randValue = new Random().Next(surnames.Count);

            return surnames[randValue];
        }

        private static int RandomizeSchoolNumber() =>
            new Random().Next(1, 10);

        private static int RandomizeYearOfEntering() =>
            new Random().Next(2015, DateTime.Now.Year);
    }
}