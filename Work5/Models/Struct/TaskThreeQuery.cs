using System;

namespace Work5.Models.Struct
{
    public struct TaskThreeQuery
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfEmployment { get; set; }
    }
}