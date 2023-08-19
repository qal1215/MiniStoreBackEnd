﻿using System.ComponentModel.DataAnnotations;

namespace MiniStore.Models
{
    public class WorkShift
    {
        [Key]
        public string Id { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string EmployeeId { get; set; } = null!;

        public int WorkshiftTypeId { get; set; }

        public int ApprovalStatusId { get; set; }

        public bool IsHoliday { get; set; }

        public bool IsSunday { get; set; }

        public decimal CoefficientsSalary { get; set; } = 1;

        public Employee Employee { get; set; }

        public WorkshiftType WorkshiftType { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }
    }
}
