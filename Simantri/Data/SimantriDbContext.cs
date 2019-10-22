using System;
using System.Linq;
using System.Reflection;
using Fathcore.EntityFramework;
using Fathcore.EntityFramework.AuditTrail;
using Fathcore.EntityFramework.Builders;
using Microsoft.EntityFrameworkCore;

namespace Simantri.Data
{
    public class SimantriDbContext : BaseDbContext
    {
        public SimantriDbContext(DbContextOptions<SimantriDbContext> options, IAuditHandler auditHandler) : base(options, auditHandler)
        {
        }

        /// <summary>
        /// Further configuration the model.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                    && (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<,>)
                        || type.BaseType.GetGenericTypeDefinition() == typeof(QueryTypeConfiguration<>)));

            foreach (Type typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
