namespace MiniStore.ViewModels
{
    public class ViewWorkshift
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public required string WorkshiftType { get; set; }
    }

    public class RegisterWorkshift
    {
        public required string EmployeeId { get; set; }

        public required List<ViewWorkshift> Workshifts { get; set; }
    }

    public class ViewConfirmWorkshift
    {
        public string EmployeeId { get; set; } = null!;

        public string WorkshiftId { get; set; } = null!;

        public bool IsConfirm { get; set; }
    }
}
