using System.ComponentModel.DataAnnotations;

namespace AuthSystem.Models
{
    public class HorarioOnibusModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string HorarioSaida { get; set; }
    }
}