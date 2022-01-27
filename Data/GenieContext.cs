using GenieClient.Data.Configurations;
using GenieClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Data
{
    public class GenieContext : DbContext
    {
        public GenieContext(DbContextOptions<GenieContext> options) : base(options) { }
        public DbSet<ClientSetting> ClientSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientSettingConfiguration());
        }
    }
}
