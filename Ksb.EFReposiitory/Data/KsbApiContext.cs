using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ksb.Domain;

namespace Ksb.Api.Data
{
    public class KsbApiContext : DbContext
    {
        public KsbApiContext (DbContextOptions<KsbApiContext> options)
            : base(options)
        {
        }

        public DbSet<Ksb.Domain.Children> Children { get; set; }
    }
}
