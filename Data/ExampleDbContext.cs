using EntityFrameworkCore.DataProtection.Encryption.Interfaces;
using EntityFrameworkCore.DataProtection.Example.Web.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.DataProtection.Example.Web.Data
{
    public class ExampleDbContext: DbContext
    {
        private readonly IModelBuilderExtension modelBuilderExtension;
        private readonly IConfiguration configuration;

        public ExampleDbContext(IModelBuilderExtension modelBuilderExtension, IConfiguration configuration)
        {
            this.modelBuilderExtension = modelBuilderExtension;
            this.configuration = configuration;
        }

        public DbSet<EncryptExample> EncryptExamples { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Data"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilderExtension.UseEncryption(modelBuilder);

            modelBuilder.Entity<EncryptExample>(entity =>
            {
                entity.ToTable("EncryptExamples");
                entity.HasKey(p => p.UUID);
                entity.Property(p => p.UUID).HasDefaultValueSql("NEWID()");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
