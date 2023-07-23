using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExcellent.DTO
{
    public class TaiKhoanDTO
    {
        public string Ten {get;set;}
        public string DiaChi {get;set;}
        public string SDT{get;set;}
        public string Email {get;set;}
    }

    public class DoiMatKhau
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string Token { get; set; }
    }
}