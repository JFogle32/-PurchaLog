namespace MyCloset.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Size { get; set; }
        public bool Status { get; set; }
        public string? Image { get; set; }
        public string? Notes { get; set; }
        public int UserId { get; set; }
    }
}

