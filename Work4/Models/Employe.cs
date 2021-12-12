using System;

namespace Work4.Models
{
    public class Employe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public Employe() { }

        public Employe(string name, string surname, string patronymic,
            DateTime? birthDay, string gender, string address) =>
            (Name, Surname, Patronymic, BirthDay, Gender, Address) =
            (name, surname, patronymic, birthDay, gender, address);

        public Employe(int id, string name, string surname, string patronymic,
           DateTime? birthDay, string gender, string address) =>
           (Id, Name, Surname, Patronymic, BirthDay, Gender, Address) =
           (id, name, surname, patronymic, birthDay, gender, address);
    }
}
