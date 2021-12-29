using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work5.Models
{
    public class MovementLog
    {
        public int Id { get; set; }
        public int EmployeId { get; set; }
        public int PostId { get; set; }  
        public DateTime DateOfEmployment { get; set; }
        public DateTime? DateOfDismission { get; set; }
        public DateTime DateofCreation { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Rate { get; set; }

        [NotMapped]
        public Employe Employe { get; set; }
        [NotMapped]
        public Post Post { get; set; }
    }
}