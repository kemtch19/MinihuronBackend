using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MinihuronBackend.Data
{
    public class MiniHuronContext : DbContext
    {
        public MiniHuronContext(DbContextOptions<MiniHuronContext> options) : base(options){}
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Folder> Folders { get; set; }
        public DbSet<Models.Archive> Archives { get; set; }
    }
}