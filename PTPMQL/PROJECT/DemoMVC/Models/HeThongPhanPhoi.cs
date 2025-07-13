using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class HeThongPhanPhoi
    {
        [Key]
        public string MaHTPP { get; set; }
        public string TenHTPP { get; set; }

        // Navigation property (nếu muốn liên kết với DaiLy)
        public ICollection<DaiLy> DaiLys { get; set; }
    }
}