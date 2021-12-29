using System;

namespace Work5.Models.Struct
{
    public struct TaskFiveQuery
    {
        public int Number { get; set; }
        public string Status { get; set; }
        public Post Post { get; set; }
        public Employe Employe { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public DateTime? DateOfDismission { get; set; }
        public DateTime? DateofCreation { get; set; }
        public string Description { get; set; }
    }
}