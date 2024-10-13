using Microsoft.EntityFrameworkCore; // Imports Entity Framework Core functionality
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums; // Imports custom enums
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models; // Imports model classes

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL // Data Access Layer namespace
{
    // DbContext class representing the database context
    public class CA_RS11_P2_2_ClaudiaSouza_DBContext : DbContext
    {
        #region Scalar Properties

        // DbSet properties represent database tables
        // The 'virtual' keyword allows for overriding in derived contexts if needed
        public virtual DbSet<Contract> Contract { get; set; } = null!;
        public virtual DbSet<Client> Client { get; set; } = null!;
        public virtual DbSet<Payment> Payment { get; set; } = null!;
        public virtual DbSet<Membership> Membership { get; set; } = null!;
        public virtual DbSet<Modality> Modality { get; set; } = null!;
        public virtual DbSet<ContractModality> ContractModality { get; set; } = null!;

        #endregion

        #region Constructor

        // Constructor that takes DbContextOptions
        // This allows the context to be configured externally (e.g., in Program.cs)
        public CA_RS11_P2_2_ClaudiaSouza_DBContext(DbContextOptions<CA_RS11_P2_2_ClaudiaSouza_DBContext>options) : base(options) { }

        #endregion

        #region Methods and Functions

        // Method to configure the model creating using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between Contract and Modality by making the ContractModality join entity
            // Set the composite primary key for the 
            modelBuilder.Entity<ContractModality>()
                .HasKey(cm => new { cm.ContractId, cm.ModalityId });
            // Set the relationship n : 1 between ContractModalities and Contract
            modelBuilder.Entity<ContractModality>()
                .HasOne(cm => cm.Contract)
                .WithMany(c => c.ContractModalities)
                .HasForeignKey(cm => cm.ContractId);
            // Set the relationship n : 1 between ContractModalities and Modality
            modelBuilder.Entity<ContractModality>()
                .HasOne(cm => cm.Modality)
                .WithMany(m => m.ContractModalities)
                .HasForeignKey(cm => cm.ModalityId);

            // Seed initial data for Client entity
            modelBuilder.Entity<Client>()
                .HasData(new Client
                {
                    Id = 1,
                    FirstName = "Claudia",
                    LastName = "Souza",
                    NIF = "999999999",
                    BirthDate = new DateTime(1992, 12, 18),
                    Email = "teste1@teste.com",
                    PhoneNumber = "123456789",
                    Address = "Rua teste1, 123",
                    PostalCode = "9999-999",
                    City = "Coimbra",
                    Country = "Portugal",
                    CreatedAt = new DateTime(2024, 08, 03),
                    UpdatedAt = null,
                    Status = Enums.EnumClientStatus.Active,
                    PaymentType = Enums.EnumPaymentType.Monthly,
                    Loyal = false
                },
                new Client
                {
                    Id = 2,
                    FirstName = "Simone",
                    LastName = "Souza",
                    NIF = "888888888",
                    BirthDate = new DateTime(1984, 12, 08),
                    Email = "teste2@teste.com",
                    PhoneNumber = "987654321",
                    Address = "Rua teste2, 321",
                    PostalCode = "8888-888",
                    City = "São Paulo",
                    Country = "Brasil",
                    CreatedAt = new DateTime(2024, 08, 03),
                    UpdatedAt = null,
                    Status = Enums.EnumClientStatus.Active,
                    PaymentType = Enums.EnumPaymentType.PerSession,
                    Loyal = false
                });
            // Seed initial data for Membership entity
            modelBuilder.Entity<Membership>()
                .HasData(
                new Membership
                {
                    MembershipId = 1,
                    MembershipType = "Monthly",
                    DiscountPercentage = 0
                },
                new Membership
                {
                    MembershipId = 2,
                    MembershipType = "Monthly Loyal",
                    DiscountPercentage = 10
                },
                new Membership
                {
                    MembershipId = 3,
                    MembershipType = "Per Session",
                    DiscountPercentage = 0
                });
            // Seed initial data for Modality entity
            modelBuilder.Entity<Modality>()
                .HasData(
                new Modality
                {
                    ModalityId = 1,
                    ModalityName = EnumModalityName.Bodybuilding.ToString(),
                    ModalityPackage = EnumModalityPackage.OneModality
                },
                new Modality
                {
                    ModalityId = 2,
                    ModalityName = $"{EnumModalityName.Swimming.ToString()}/{EnumModalityName.Bodybuilding.ToString()}",
                    ModalityPackage = EnumModalityPackage.TwoModalities
                },
                new Modality
                {
                    ModalityId = 3,
                    ModalityName = EnumModalityName.AllModalities.ToString(),
                    ModalityPackage = EnumModalityPackage.AllInclusive
                });
        }

        #endregion
    }
}
