﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPIApp.Data
{
    [Table("LoaiHangHoa")]
    public class LoaiHangHoa
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }

        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
