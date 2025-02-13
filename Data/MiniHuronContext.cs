using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinihuronBackend.Models;

namespace MinihuronBackend.Data
{
    public class MiniHuronContext : DbContext
    {
        public MiniHuronContext(DbContextOptions<MiniHuronContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Folder> folders { get; set; }
        public DbSet<Archive> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archive>()
            .HasOne(f=>f.Folder)
            .WithMany(f=>f.Files)
            .HasForeignKey(f=>f.FolderId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Folder>()
            .HasMany(f=>f.Subfolder)
            .WithOne(f=>f.parentFolder)
            .HasForeignKey(f=>f.parentFolderId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}