using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Tire_app_Server.Models
{
    public class PaidFine
    {
        [Key]
        [ForeignKey(nameof(Fine))]
        public string FineId { get; set; }
        public Fine Fine { get; set; }

        [Required]
        public DateTime PaymentTime { get; set; }

        public PaidFine() { }

        public PaidFine(string fineId, Fine fine, DateTime paymentTime, string unlockCode)
        {
            FineId = fineId;
            Fine = fine;
            PaymentTime = paymentTime;
        }
    }
}
