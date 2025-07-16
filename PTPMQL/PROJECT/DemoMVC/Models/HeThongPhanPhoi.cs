using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class HeThongPhanPhoi
    {
        [Key]
        [Display(Name = "Mã Hệ Thống Phân Phối")]
        public string MaHTPP { get; set; }
        [Display(Name = "Tên Hệ Thống Phân Phối")]
        public string TenHTPP { get; set; }
        public ICollection<DaiLy>? DaiLy { get; set; }
    }
}