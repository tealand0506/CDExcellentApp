using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("TaiKhoan")]

    public class TaiKhoan
    {
        [Key]
        public int IdTaiKhoan {get; set;}

        public string IdUser {get;set;}
        [ForeignKey("IdUser")]
        public User Users { get;set;}
        
        [Required]
        public string TenDN {get; set;} // email
        [Required]
        public string Password {get; set;}
        [Required]
        public DateTime tgThamGia {get;set;}
        public DateTime? tgDoiMK {get;set;}
        public DateTime? tgDangNhap {get;set;}
        //public string Role { get; set; }
        [Required]
        public bool Active {get;set;} = true;
    }
}