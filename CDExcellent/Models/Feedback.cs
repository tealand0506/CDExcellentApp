using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("Feedback")]

    public class Feedback
    {
        [Key]
        public int ID {get;set;}
        public string Email {get;set;}

        public int IdCongViec{get;set;}
        [ForeignKey("IdCongViec")]
        public CongViec CongViecs{get;set;}

        public string NoiDung{get;set;}
        public DateTime NgayGui{get;set;}
    
    }
}