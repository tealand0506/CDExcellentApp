using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("User")]

    public class User
    {
        [Key]
        public int IdUser {get; set;}
        [Required]
        public string HoTen {get; set;}
        [Required]
        public DateTime NgaySinh {get;set;}
        [Required]
        public DateTime NgayTG {get;set;} = DateTime.Now;
        [Required]
        public string SDT {get;set;}
        [Required]
        public string Email {get;set;}
        [Required]
        public string DiaChi {get;set;}

        public int IdAccount{get;set;}
        [ForeignKey("IAccount")]
        public Account Accounts { get; set; }
        public int IdChucVu {get;set;}
        [ForeignKey("IdChucVu")]
        public ChucVu chucVus {get;set;}
    }
}