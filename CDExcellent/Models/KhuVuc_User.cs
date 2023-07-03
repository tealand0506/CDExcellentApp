using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("KhuVuc_User")]
    public class KhuVuc_User
    {
        [Key]
        public int Id{get;set;}
        
        [Required]
        public int IdKhuVuc { get;set;}
        [ForeignKey("IdKhuVuc")]
        public KhuVuc KhuVucs {get;set;}

        [Required]
        public int IdUser {get;set;}
        [ForeignKey("IdUser")]
        public User Users{get;set;}
    }
}