using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPIApp.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<LoaiHangHoa> LoaiHangHoas { get; set; }
    }
}
