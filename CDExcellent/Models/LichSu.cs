using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    public class LichSu
    {
        [Key]
        public int IdLichSu { get;set;}
        public string TuaDe {get;set;}

        public DateTime fNgay {get;set;}
        public DateTime tNgay {get;set;}

        public int IdNPP {get;set;}
        [ForeignKey("IdNPP")]
        public NhaPhanPhoi NhaPhanPhois {get;set;}
        public string MucDich {get;set;}
        public string KhachMoi {get;set;}    
        public bool Status {get; set;}
    }

}