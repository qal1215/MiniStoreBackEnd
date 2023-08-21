using MiniStore.Models;

namespace MiniStore.ViewModels
{
    public class ViewSalary
    {
    }

    public class InitSalary
    {
        public required string EmployeeId { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }

    public record UpdatePayslip
    {
        public string PayslipId { get; set; }

        public decimal BaseSalary { get; set; }

        public decimal Deductions { get; set; } = 0;

        public decimal Bonuses { get; set; } = 0;

        public decimal TotalSalary { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDate { get; set; }
    }

    public record ViewPayslip
    {
        public string PayslipId { get; set; }

        public string EmployeeName { get; set; }

        public int Month { get; set; }

        public decimal BaseSalary { get; set; }

        public decimal Deductions { get; set; } = 0;

        public decimal Bonuses { get; set; } = 0;

        public decimal TotalSalary { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDate { get; set; }

        public Employee Employee { get; set; } = null!;

    }
}
