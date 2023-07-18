using System.ComponentModel.DataAnnotations;

namespace CDExcellent.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
