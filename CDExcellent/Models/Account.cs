using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int IdAccount {get;set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime tgThamGia {get;set;}
        public bool Status {get;set;}        
        public string Token{get;set;}
    }
}