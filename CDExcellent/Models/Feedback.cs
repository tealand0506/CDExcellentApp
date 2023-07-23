using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("ChucVu")]

    public class Feedback
    {
        [Key]
        public int ID {get;set;}
        public string IdNguoiGui {get;set;}
        [ForeignKey("IdNguoiGui")]
        public User NguoiGuis{get;set;}

        public int IdCongViec{get;set;}
        [ForeignKey("IdCongViec")]
        public CongViec CongViecs{get;set;}

        public string NoiDung{get;set;}
        public DateTime NgayGui{get;set;}
    
    }
}