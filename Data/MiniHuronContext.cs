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
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Archive> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archive>()
            .HasOne(f=>f.Folders)
            .WithMany(f=>f.Archive)
            .HasForeignKey(f=>f.FolderId)
            .onDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Folder>()
            .HasMany(f=>f.subFolder)
            .WithOne(f=>f.parentFolder)
            .HasForeignKey(f=>f.parentFolderId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}