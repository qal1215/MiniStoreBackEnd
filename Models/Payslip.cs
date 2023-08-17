using System.ComponentModel.DataAnnotations;

namespace MiniStore.Models
{
    public class Payslip
    {
        [Key]
        public required string PayslipId { get; set; }

        public required string EmployeeId { get; set; }

        public required string Month { get; set; }

        public decimal BaseSalary { get; set; }

        public decimal Deductions { get; set; } = 0;

        public decimal Bonuses { get; set; } = 0;

        public decimal TotalSalary { get; set; }

        public List<WorkShift>? WorkShifts { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDate { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}
