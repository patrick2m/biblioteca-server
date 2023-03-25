using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using biblioteca_server.Data.Models;

namespace biblioteca_server.Data
{
    public class biblioteca_serverContext : DbContext
    {
        public biblioteca_serverContext (DbContextOptions<biblioteca_serverContext> options)
            : base(options)
        {
        }

        public DbSet<biblioteca_server.Data.Models.Livro> Livro { get; set; } = default!;
    }
}
