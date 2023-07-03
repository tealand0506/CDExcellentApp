using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("ChucVu")]

    public class ChucVu
    {
        [Key]
        public int IdChucVu {get;set;}
        public string TenChucVu {get;set;}
    }
}