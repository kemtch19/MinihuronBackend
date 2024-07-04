using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinihuronBackend.Models;

namespace MinihuronBackend.Data
{
    public class MinihuronContext : DbContext
    {
        private MinihuronContext(DbContextOptions<MinihuronContext> options): base(options){

        }

        public DbSet<User> Users { get; set; }
    }
}