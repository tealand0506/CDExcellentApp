using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models{
    [Table("CongViec")]
    public class CongViec
    {
        [Key]
        public int IdCV { get;set;}
        public string TuaDe{get;set;}
        public DateTime fDate {get;set;}
        public DateTime tDate {get;set;}

        public int IdLichTrinh {get;set;}
        [ForeignKey("IdLichTrinh")]
        public LichTrinh LichTrinhs{get;set;}

        // public int? IdUser {get;set;}
        // [ForeignKey("IdUser")]
        // public User Users {get; set;}
    }
}