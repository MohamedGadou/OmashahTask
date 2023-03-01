using Microsoft.EntityFrameworkCore;
using OmashahTask.Domain.Entities;
using OmashahTask.Infrastructure.EntityConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmashahTask.Infrastructure.DBContext
{
    public class OmashahTaskDbContext: DbContext
    {
        public OmashahTaskDbContext(DbContextOptions<OmashahTaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemEntityTypeConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
