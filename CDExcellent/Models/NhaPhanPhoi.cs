using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    public class NhaPhanPhoi
    {
        public int IdNhaPhanPhoi {get;set;}
        public string TenNhaPhanPhoi {get;set;}
        public string DiaChi {get;set;}
        public string Email {get;set;}
        public string SDT {get;set;}

        public int IdChucVu {get;set;}
        [ForeignKey("IdChucVu")]
        public ChucVu ChucVus { get; set; }
    }
}