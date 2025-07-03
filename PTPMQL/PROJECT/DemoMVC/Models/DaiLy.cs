using DemoMVC.Models;

namespace DaiLy.Models
{
    
    public class DaiLy
    {
        
    
        public string MaDaiLy { get; set; }

       
           public string TenDaiLy { get; set; }

     
        public string DiaChi { get; set; }

       
        public string NguoiDaiDien { get; set; }

        
        public string DienThoai { get; set; }

        // Foreign key
       
        public string MaHTPP { get; set; }

        // Navigation property để truy xuất thông tin hệ thống phân phối
        
       
    }
}