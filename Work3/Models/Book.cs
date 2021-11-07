using System;
using Work3.Interfaces.Models;

namespace Work3.Models
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int AgeRestriction { get; set; }
        public int IdAuthor { get; set; }

        public Book() { }

        public Book(int id, string name, string genre,
            int ageRestriction, int idAuthor) =>
            (Id, Name, Genre, AgeRestriction, IdAuthor) =
            (id < 1 ? RandomizeNewId() : id,
            name, genre, ageRestriction, idAuthor);

        public Book(string name, string genre,
            int ageRestriction, int idAuthor) => 
            (Id, Name, Genre, AgeRestriction, IdAuthor) = 
            (RandomizeNewId(), name, genre, ageRestriction, idAuthor);

        private int RandomizeNewId() =>
            new Random(DateTime.Now.Millisecond)
            .Next(1, int.MaxValue);
    }
}