using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.DTO
{
    public class LichTrinhDTO
    {
        public string TuaDe {get;set;}
        public DateTime BatDau {get;set;}
        public DateTime KetThuc{get;set;}

        public string MucDich {get;set;}
        public string KhachMoi {get;set;}
        
        public int IdNPP {get;set;}        
    }

}