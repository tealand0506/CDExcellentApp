namespace CDExcellent.Models
{
    public class LichTrinh
    {
        public int IdLichTrinh { get;set;}
        public string TuaDe {get;set;}

        public DateTime fNgay {get;set;}
        public DateTime tNgay {get;set;}

        public int IdNhaPhanPhoi {get;set;}
        public string MucDich {get;set;}
        public string KhachMoi {get;set;}    
        public bool Status {get; set;}
    }

}