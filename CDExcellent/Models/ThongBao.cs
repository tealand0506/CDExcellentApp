using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    public class ThongBao{
        [Key]
        public int IdThongBao {get;set;}
        public string TuaDe {get;set;}
        public string NoiDung {get;set;}
        public DateTime NgayTao{get;set;}
        public bool DaXem {get;set;}


        public string? IdNguoiGui { get;set;}
        [ForeignKey("IdNguoiGui")]
        public User? NguoiGui {get; set;}

        public string? IdNguoiNhan { get;set;}
        [ForeignKey("IdNguoiNhan")]
        public User? NguoiNhan {get; set;}


    }
}