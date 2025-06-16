using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Smart_Tire_app_Server.Additionals;

namespace Smart_Tire_app_Server.Models
{
    public class Fine
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(Bracket))]
        public string BracketId { get; set; }
        public Bracket Bracket { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string CarNumber { get; set; }

        [Required]
        public FineStatusEnum Status { get; set; }

        [Required]
        public string UnlockCode { get; set; }

        public Fine() { }

        public Fine(string id, string bracketId, Bracket bracket, DateTime date, string userId, User user,
                    double latitude, double longitude, double amount, string carNumber, FineStatusEnum fineStatus,
                    string unlockCode)
        {
            Id = id;
            BracketId = bracketId;
            Bracket = bracket;
            Date = date;
            UserId = userId;
            User = user;
            Latitude = latitude;
            Longitude = longitude;
            Amount = amount;
            CarNumber = carNumber;
            Status = fineStatus;
            UnlockCode = unlockCode;
        }
    }
}
