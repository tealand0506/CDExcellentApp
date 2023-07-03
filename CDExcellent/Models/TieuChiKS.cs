using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("TieuChiKS")]
    
    public class TieuChiKS
    {
        [Key]
        public int IdTieuChi {get;set;}
        [Required, MaxLength(100)]
        public string NoiDung {get; set;}
    }
}