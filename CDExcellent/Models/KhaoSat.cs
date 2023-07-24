
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
        
        public bool A {get;set;}
        public bool B {get;set;}
        public bool C {get;set;}
        public bool D {get;set;}


        public string IdUser {get;set;}
        [ForeignKey("IdUser")]
        public User Users {get;set;}

        public int IdTieuChi {get;set;}
        [ForeignKey("IdTieuChi")]
        public TieuChiKS TieuChiKSs { get; set; }

    }
}