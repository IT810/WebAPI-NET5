using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPIApp.Data
{
    public enum TinhTrangDonDatHang
    {
        New = 0,
        Payment = 1,
        Complete = 2, 
        Cancel = -2
    }

    public class DonHang
    {
        public Guid MaDH {get; set;}
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public TinhTrangDonDatHang TinhTrangDonHang { get; set; }
        public string NguoiNhanHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

    }
}
