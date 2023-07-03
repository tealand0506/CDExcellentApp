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

        public TimeSpan GioDB {get;set;}
        public TimeSpan GioKQ {get;set;}
        public DateTime fNgay {get;set;}
        public DateTime tNgay {get;set;}

        public int IdNPP {get;set;}        
        [ForeignKey("IdNPP")]
        public NhaPhanPhoi NhaPhanPhois {get;set;}

//        public int IdUser {get;set;}
//        [ForeignKey("IdUser")]
//        public User Users {get;set;}
//        
        public string MucDich {get;set;}
        public string KhachMoi {get;set;}    
        public bool Status {get; set;}
    }

}