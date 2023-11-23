using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebINV.Models;

namespace WebINV.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<WebINV.Models.cadCli> cadCli { get; set; } = default!;

        public DbSet<WebINV.Models.CadProd> CadProd { get; set; } = default!;

        public DbSet<WebINV.Models.InvMaqui> InvMaqui { get; set; } = default!;

        public DbSet<WebINV.Models.InvSoft> InvSoft { get; set; } = default!;
    }
}
