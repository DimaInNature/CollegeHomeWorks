using System;

namespace Work4.Struct
{
    public struct EmployeStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int WorkExperience { get; set; }
    }

}
