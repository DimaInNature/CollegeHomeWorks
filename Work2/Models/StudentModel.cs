using System;
using System.Collections.Generic;
using Work2.Enums;
using Work2.Models.Base;

namespace Work2.Models
{
    public class StudentModel : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public ESchoolGrade Grade { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public int SubjectId { get; set; }

        public StudentModel() => Id = RandomizeNewId();

        public static List<StudentModel> Create (int count)
        {
            var students = new List<StudentModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                students.Add(CreateRandom());
            }

            return students;
        }

        public static List<StudentModel> EnumerableCreate(int count)
        {
            var students = new List<StudentModel>();

            count = count < 0 ? 0 : count;

            for (int i = 0; i < count; i++)
            {
                students.Add(CreateRandom(i));
            }

            return students;
        }

        public static StudentModel Create(string name, string surname, string patronymic,
            ESchoolGrade grade, string group, int subjectId) => new()
        {
            Name = name,
            Surname = surname,
            Patronymic = patronymic,
            Grade = grade,
            Group = group, 
            SubjectId = subjectId
        };

        public override string ToString() => 
            $"Full name is {GetFullName()}, grade is {Grade}, " +
            $"group is {Group}, subject id is {SubjectId}";

        private static StudentModel CreateRandom()
        {
            var student = new StudentModel()
            {
                Name = RandomizeNewName(),
                Surname = RandomizeNewSurname(),
                Patronymic = RandomizeNewPatronymic(),
                Grade = RandomizeNewSchoolGrade(),
                Group = RandomizeNewGroup(),
                SubjectId = RandomizeNewId()
            };

            student.FullName = $"{student.Name} {student.Surname} {student.Patronymic}";

            return student;
        }

        private static StudentModel CreateRandom(int id)
        {
            var student = new StudentModel()
            {
                Id = id,
                Name = RandomizeNewName(),
                Surname = RandomizeNewSurname(),
                Patronymic = RandomizeNewPatronymic(),
                Grade = RandomizeNewSchoolGrade(),
                Group = RandomizeNewGroup(),
                SubjectId = RandomizeNewId()
            };

            student.FullName = $"{student.Name} {student.Surname} {student.Patronymic}";

            return student;
        }

        private static string RandomizeNewName()
        {
            var names = new List<string>()
            {
                "Dmitry", "Ivan","Alex", "Paul", "Jack",
                "Karl", "Jared", "Oleg", "Henry", "Matt"
            };

            int randomValue = new Random().Next(0, names.Count);

            return names[randomValue];
        }

        private static string RandomizeNewSurname()
        {
            var surnames = new List<string>()
            {
                "Ivanov", "Johnson", "Walker", "Hall","White",
                "Wilson","Moore","Taylor","Harris","Petrov"
            };

            int randValue = new Random().Next(0,surnames.Count);

            return surnames[randValue];
        }

        private static string RandomizeNewPatronymic()
        {
            var patronymics = new List<string>()
            {
                "Dmitrievich", "Olegovich", "Artemievich", string.Empty
            };

            int randValue = new Random().Next(0, patronymics.Count);

            return patronymics[randValue];
        }

        private static ESchoolGrade RandomizeNewSchoolGrade() =>
            (ESchoolGrade)new Random().Next(2, 5);

        private static string RandomizeNewGroup() =>
            $"Group {new Random().Next(1,10)}";

        private string GetFullName() =>
            $"{Name} {Surname} {Patronymic}";
    }
}