using Common;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProyectDbContext : DbContext
    {
        private IConfigurationLib config;
        public ProyectDbContext(DbContextOptions<ProyectDbContext> options) : base(options)
        {}
        public DbSet<User> Users { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<BoxOpening> BoxOpenings { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Conversion> Conversion { get; set; }
        public DbSet<DetailConversion> DetailConversions { get; set; }
        public DbSet<DetailShopping> DetailShopping { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<FinalProduct> FinalProducts { get; set; }
        public DbSet<Kardex> Kardex { get; set; }
        public DbSet<MovementType> MovementType { get; set; }
        public DbSet<Movementbox> Movementbox { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SalesDetail { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Shopping> Shopping { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<TypeClient> TypeClients { get; set; }
    }
}
