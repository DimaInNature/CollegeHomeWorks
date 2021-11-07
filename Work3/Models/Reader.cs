using System;
using Work3.Interfaces.Models;

namespace Work3.Models
{
    public class Reader : IReader, IHuman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfTaking { get; set; }
        public Book Book { get; set; }
        public int Years { get; set; }

        public Reader() { }

        public Reader(int id, string name, string surname, string patronymic,
            DateTime birthDay, string phone, Book book) =>
            (Id, Name, Surname, Patronymic, FullName,
            BirthDay, Phone, DateOfTaking, Book, Years) =
            (id < 1 ? RandomizeNewId() : id, name, surname, patronymic,
            CreateFullName(), birthDay.ToUniversalTime(), phone,
            DateTime.UtcNow.ToUniversalTime(), book, CalculateYear(birthDay));
    
        public Reader(string name, string surname, string patronymic,
            DateTime birthDay, string phone, Book book) =>
            (Id, Name, Surname, Patronymic, FullName,
            BirthDay, Phone, DateOfTaking, Book, Years) =
            (RandomizeNewId(), name, surname, patronymic, CreateFullName(),
            birthDay.ToUniversalTime(), phone, DateTime.UtcNow.ToUniversalTime(),
            book, CalculateYear(birthDay));

        private int CalculateYear(DateTime birthDay) =>
            birthDay > DateTime.Today
            .AddYears((DateTime.Today.Year - birthDay.Year) - 1)
            ? (DateTime.Today.Year - birthDay.Year) - 1 
            : DateTime.Today.Year - birthDay.Year;

        private string CreateFullName() =>
            $"{Name} {Surname} {Patronymic}";

        private int RandomizeNewId() =>
            new Random().Next(1, int.MaxValue);
    }
}