using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniStore.Models
{
    public class CheckinCheckout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CheckinTime { get; set; }

        public DateTime CheckoutTime { get; set; }

        public string? ImageCheckin { get; set; }

        public string? ImageCheckout { get; set; }

        public string WorkShiftId { get; set; } = null!;

        public WorkShift? WorkShift { get; set; }

    }
}
