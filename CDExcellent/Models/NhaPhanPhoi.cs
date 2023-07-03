using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("NhaPhanPhoi")]
    public class NhaPhanPhoi
    {
        [Key]
        public int IdNPP {get;set;}
        public string TenNPP {get;set;}
        public string DiaChi {get;set;}
        public string Email {get;set;}
        public string SDT {get;set;}

    }
}