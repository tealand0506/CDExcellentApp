
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("KhaoSat")]
    public class KhaoSat
    {
        [Key]
        public int IdKhaoSat{get;set;}
        public DateTime NgayKS{get;set;}
        public TimeSpan GioKS {get;set;}
        
        public int IdLichTrinh {get;set;}
        [ForeignKey("IdLichTrinh")]
        public LichTrinh LichTrinnhs {get;set;}

        public int IdTieuChi {get;set;}
        [ForeignKey("IdTieuChi")]
        public TieuChiKS TieuChiKSs { get; set; }

        //public string
        public double MucDo {get;set;}
    }
}