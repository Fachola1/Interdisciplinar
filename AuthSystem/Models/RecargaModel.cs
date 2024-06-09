namespace AuthSystem.Models
{
    public class RecargaModel
    {
        public int Id { get; set; }  // Primary Key

        public string UserId { get; set; }  // Foreign Key

        public decimal ValorRecarga { get; set; }

        public string UserName { get; set; }  
    }
}