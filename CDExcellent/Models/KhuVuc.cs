using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("KhuVuc")]
    public class KhuVuc
    {
        [Key]
        public int IdKhuVuc {get;set;}
        public string TenKhuVuc {get;set;}
    }
}