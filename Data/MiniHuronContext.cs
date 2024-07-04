using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MinihuronBackend.Data
{
    public class MiniHuronContext : DbContext
    {
        public MiniiHuronContext(DbContextOptions<> options) : base(options)
    }
}