using System;

namespace Work4.Models
{
    public class MovementLog
    {
        public int Id { get; set; }
        public int EmployeId { get; set; }
        public int StructuralDivisionId { get; set; }
        public int PostId { get; set; }
        public double Rate { get; set; }
        public double Salary { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public string OrderNumber { get; set; }
        public string WorkStatus { get; set; }

        public MovementLog() { }

        public MovementLog(int employeId, int structuralDivisionId,
            int postId, double rate, double salary, DateTime? dateOfEmployement,
            string orderNumber, string workStatus) =>
            (EmployeId, StructuralDivisionId, PostId, Rate, Salary,
            DateOfEmployment, OrderNumber, WorkStatus) =
            (employeId, structuralDivisionId, postId, rate, salary,
            dateOfEmployement, orderNumber, workStatus);

        public MovementLog(int id, int employeId, int structuralDivisionId,
            int postId, double rate, double salary, DateTime? dateOfEmployement,
            string orderNumber, string workStatus) =>
            (Id, EmployeId, StructuralDivisionId, PostId, Rate, Salary,
            DateOfEmployment, OrderNumber, WorkStatus) =
            (id, employeId, structuralDivisionId, postId, rate, salary,
            dateOfEmployement, orderNumber, workStatus);
    }
}
