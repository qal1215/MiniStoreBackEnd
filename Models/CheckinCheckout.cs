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

        [ForeignKey("Workshift")]
        public required string WorkshiftId { get; set; }

        public Workshift? Workshift { get; set; }

    }
}
