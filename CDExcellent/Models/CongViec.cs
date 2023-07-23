using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models{
    [Table("CongViec")]
    public class CongViec
    {
        [Key]
        public int IdCV { get;set;}
        public string TuaDe{get;set;}
        public string MoTa{get;set;}
        public DateTime NgayTao {get;set;} = DateTime.Now;
        public DateTime BatDau {get;set;}
        public DateTime KetThuc {get;set;}
        public bool HoanThanh{get;set;}

        public int IdLichTrinh {get;set;}
        [ForeignKey("IdLichTrinh")]
        public LichTrinh LichTrinhs{get;set;}

        public string? IdNguoiTao {get;set;}
        [ForeignKey("IdNguoiTao")]  
        public User? NguoiTaos {get; set;}

        public string? IdNguoiNhan {get;set;}
        [ForeignKey("IdNguoiNhan")]
        public User? NguoiNhans {get; set;}
    }
}