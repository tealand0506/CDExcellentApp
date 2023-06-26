using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    public class KhuVuc
    {
        public int IdKhuVuc {get;set;}
        public string TenKhuVuc {get;set;}
        
        public int IdNhaPhanPhoi {get;set;}
        [ForeignKey("IdNhaPhanPhoi")]
        public NhaPhanPhoi NhaPhanPhois {get;set;}
    }
}