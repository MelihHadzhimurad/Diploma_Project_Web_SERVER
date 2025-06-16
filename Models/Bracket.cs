using System.ComponentModel.DataAnnotations;

namespace Smart_Tire_app_Server.Models
{
    public class Bracket
    {
        [Key]
        public string Id { get; set; }

        public Bracket(string id) { Id = id; }

        public Bracket() { }
    }
}
