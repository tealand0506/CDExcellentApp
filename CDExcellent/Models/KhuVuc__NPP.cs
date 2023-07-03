using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("KhuVuc_NPP")]
    public class KhuVuc_NPP
    {
        [Key]
        public int Id{get;set;}
        
        [Required]
        public int IdKhuVuc {get;set;}
        [ForeignKey("IdKhuVuc")]
        public KhuVuc KhuVucs {get;set;}

        [Required]
        public int IdNPP {get;set;}
        [ForeignKey("IdNPP")]
        public NhaPhanPhoi NhaPhanPhois{get;set;}
    }
}