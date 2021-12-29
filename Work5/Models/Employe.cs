using System;

namespace Work5.Models
{
    public class Employe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Gender { get; set; }

        public Employe() { }

        public Employe(string name, string surname, string patronymic,
            DateTime? birthDay, string address) =>
            (Name, Surname, Patronymic, BirthDay, Gender) =
            (name, surname, patronymic, birthDay, address);

        public Employe(int id, string name, string surname, string patronymic,
           DateTime? birthDay, string gender) =>
           (Id, Name, Surname, Patronymic, BirthDay, Gender) =
           (id, name, surname, patronymic, birthDay, gender);
    }
}