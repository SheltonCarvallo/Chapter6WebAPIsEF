using Invoice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreData.Data
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {

        }
        public InvoiceDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("data source=DESKTOP-REDKEOB;initial catalog= CUSTOMERS_INVOICES;user id= PortalApi;password=123456;TrustServerCertificate=True;MultipleActiveResultSets=true");


        //One-to-Many
        public DbSet<InvoiceModel> Invoices => Set<InvoiceModel>(); //Dbset<T> Defined the Invoices property, which is a DbSet<Invoice> type. It is used to represent the Invoices table in the database.

        public DbSet<InvoiceItemModel> InvoiceItems => Set<InvoiceItemModel>();


        //One-to-One
        public DbSet<ContactModel> Contacts => Set<ContactModel>();
        public DbSet<AddressModel> Addresses => Set<AddressModel>();

        //Many-to-Many
        public DbSet<ActorModel> Actors => Set<ActorModel>();
        public DbSet<MovieModel> Movies => Set<MovieModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceModel>().HasData(
                    new InvoiceModel
                    {
                        id = Guid.NewGuid(),
                        InvoiceNumber = "INV-001",
                        ContactName = "Myrian",
                        Description = "Invoice for the first month",
                        Amount = 100,
                        InvoiceDate = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero),
                        DueDate = new DateTimeOffset(2023, 1, 15, 0, 0, 0, TimeSpan.Zero),
                        Status = InvoiceStatusModel.AwaitPayment
                    },
                    new InvoiceModel
                    {
                        id = Guid.NewGuid(),
                        InvoiceNumber = "INV-002",
                        ContactName = "Kyle",
                        Description = "Invoice for the first month",
                        Amount = 200,
                        InvoiceDate = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero),
                        DueDate = new DateTimeOffset(2021, 1, 15, 0, 0, 0, TimeSpan.Zero),
                        Status = InvoiceStatusModel.AwaitPayment
                    },
                    new InvoiceModel
                    { 
                        id = Guid.NewGuid(),
                        InvoiceNumber = "INV-003",
                        ContactName = "Roy",
                        Description = "Invoice for the first month",
                        Amount = 300,
                        InvoiceDate = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero),
                        DueDate = new DateTimeOffset(2021, 1, 15, 0, 0, 0, TimeSpan.Zero),
                        Status = InvoiceStatusModel.Draft
                    }

                );
        }
    }
}
