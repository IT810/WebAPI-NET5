using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPIApp.Models
{
    public class LoaiHangHoaModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
