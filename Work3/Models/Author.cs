using System;
using Work3.Interfaces.Models;

namespace Work3.Models
{
    public class Author : IAuthor, IHuman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string FullName { get; set; }

        public Author() { }

        public Author(int id, string name,
            string surname, string patronymic) =>
            (Id, Name, Surname, Patronymic, FullName) = 
            (id < 1 ? RandomizeNewId() : id, name,
            surname, patronymic, CreateFullName());
      
        public Author(string name, string surname, string patronymic) =>
            (Id, Name, Surname, Patronymic, FullName) =
            (RandomizeNewId(),name, surname, patronymic,
            CreateFullName());

        private int RandomizeNewId() =>
            new Random().Next(1, int.MaxValue);

        private string CreateFullName() =>
            $"{Name} {Surname} {Patronymic}";
    }
}