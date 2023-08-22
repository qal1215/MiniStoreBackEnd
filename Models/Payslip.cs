using System.ComponentModel.DataAnnotations;

namespace MiniStore.Models
{
    public class Payslip
    {
        [Key]
        public required string PayslipId { get; set; }

        public required string EmployeeId { get; set; }

        public required int Month { get; set; }

        public required int Year { get; set; }

        public decimal BaseSalaryPerHour { get; set; } = 0;

        public decimal BaseSalary { get; set; }

        public decimal Deductions { get; set; } = 0;

        public decimal Bonuses { get; set; } = 0;

        public decimal TotalSalary { get; set; }

        public int TotalWorkHours { get; set; } = 0;

        public int TotalWorkLate { get; set; } = 0;

        public DateTime StartDay { get; set; }

        public DateTime EndDay { get; set; }

        public Employee Employee { get; set; } = null!;

        public List<WorkShift>? WorkShifts { get; set; }
    }
}
