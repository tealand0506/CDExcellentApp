using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.DTO
{
    public class CongViecDTO
    {
        public string TuaDe{get;set;}
        public string MoTa{get;set;}
        public DateTime BatDau {get;set;}
        public DateTime KetThuc {get;set;}

        public int IdLichTrinh {get;set;}
        public string EmailNguoiNhan {get;set;}
    }
}