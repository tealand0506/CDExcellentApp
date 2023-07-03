using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("BaiViet")]
    public class BaiViet
    {
        [Key]
        public int IdBaiViet {get;set;}
        public string TuaDe {get;set;}
        public string Image{get;set;}
        public string NoiDung {get;set;}

        public DateTime ThoiGian {get;set;}
        public bool DangTai{get;set;}
    }
}