using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("LichTrinh")]
    public class LichTrinh
    {
        [Key]
        public int IdLichTrinh { get;set;}
        public string TuaDe {get;set;}
        public DateTime NgayTao {get;set;}
        public DateTime BatDau {get;set;}
        public DateTime KetThuc {get;set;}

        public string MucDich {get;set;}
        public string KhachMoi {get;set;}
        
        public int IdNPP {get;set;}        
        [ForeignKey("IdNPP")]
        public NhaPhanPhoi NhaPhanPhois {get;set;}

        public string IdNguoiTao {get;set;}
        [ForeignKey("IdNguoiTao")]
        public User Users {get;set;}     
    }

}