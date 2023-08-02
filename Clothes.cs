using System.ComponentModel.DataAnnotations;



namespace MyCLOSET.Models
{
    public class Clothes
    {
        public int Id { get; set; }


        public string Name { get; set; } = string.Empty;


        public string Size { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;


        public string Image { get; set; } = string.Empty;


        public string Material { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;       

        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
