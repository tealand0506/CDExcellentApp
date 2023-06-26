using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    public class ThongBao{
        [Key]
        public int IdThongBao {get;set;}
        public string TuaDe {get;set;}
        public string NoiDunng {get;set;}
        public string NguoiGui {get;set;}

        public int IdUser { get;set;}
        [ForeignKey("IdUser")]
        public User Users {get; set;}
    }
}