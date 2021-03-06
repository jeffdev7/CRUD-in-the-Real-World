using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Entities;


namespace smartfy.portal_api.Infra.CrossCutting.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHostingEnvironment _env;


       
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            new Veiculo().Configure(modelBuilder.Entity<Veiculo>());
            new TipoVeiculo().Configure(modelBuilder.Entity<TipoVeiculo>());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHostingEnvironment env) : base(options)
        {
            _env = env;
        }

        public ApplicationDbContext() { }
    }

    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            var configurations = Assembly.GetExecutingAssembly().DefinedTypes.Where(t =>
                    t.ImplementedInterfaces.Any(i =>
                        i.IsGenericType &&
                        i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name,
                            StringComparison.InvariantCultureIgnoreCase)
                    ) &&
                    t.IsClass &&
                    !t.IsAbstract &&
                    !t.IsNested)
                .ToList();

            foreach (var configuration in configurations)
            {
                try
                {
                    var entityType = configuration.BaseType.GenericTypeArguments.SingleOrDefault(t => t.IsClass);
                    var applyConfigMethod = typeof(ModelBuilder).GetMethod("Configure");
                    var applyConfigGenericMethod = applyConfigMethod.MakeGenericMethod(entityType);
                    applyConfigGenericMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(configuration) });
                }
                catch (Exception e)
                {
                }
            }
        }

        //new Partner().Configure(modelBuilder.Entity<Partner>());
    }
}
