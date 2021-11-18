using System;
using System.Collections.Generic;
using Work2.Models.Base;

namespace Work2.Models
{
    public class SubjectModel : BaseModel
    {
        public string Name { get; set; }

        public SubjectModel() => Id = RandomizeNewId();

        public static List<SubjectModel> Create(int count)
        {
            var subjects = new List<SubjectModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                subjects.Add(CreateRandom());
            }

            return subjects;
        }

        public static List<SubjectModel> EnumerableCreate(int count)
        {
            var subjects = new List<SubjectModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                subjects.Add(CreateRandom(i));
            }

            return subjects;
        }

        public static SubjectModel Create(string name) => new()
        {
            Name = name
        };

        public override string ToString() =>
            $"Name is {Name}";

        private static SubjectModel CreateRandom() => new()
        {
            Name = RandomizeNewName()
        };

        private static SubjectModel CreateRandom(int id) => new()
        {
            Id = id,
            Name = RandomizeNewName()
        };

        private static string RandomizeNewName()
        {
            var names = new List<string>()
            {
                "Mathematics","Physics","Biology", "History", "Geography",
                "Physical culture", "Computer science", "Painting", "Culture"
            };

            var randValue = new Random().Next(0, names.Count);

            return names[randValue];
        }
    }
}