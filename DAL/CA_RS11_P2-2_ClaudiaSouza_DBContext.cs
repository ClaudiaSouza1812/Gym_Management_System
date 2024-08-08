using Microsoft.EntityFrameworkCore;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL
{
    public class CA_RS11_P2_2_ClaudiaSouza_DBContext : DbContext
    {
        public CA_RS11_P2_2_ClaudiaSouza_DBContext(DbContextOptions<CA_RS11_P2_2_ClaudiaSouza_DBContext>options) : base(options) { }

        public virtual DbSet<Contract> Contract { get; set; } = null!;
        public virtual DbSet<Client> Client {  get; set; } = null!;
        public virtual DbSet<Payment> Payment { get; set; } = null!;
        public virtual DbSet<Membership> Membership { get; set; } = null!;
        public virtual DbSet<Modality> Modality { get; set; } = null!;
        public virtual DbSet<ContractModality> ContractModality { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContractModality>()
                .HasKey(cm => new { cm.ContractId, cm.ModalityId });

            modelBuilder.Entity<ContractModality>()
                .HasOne(cm => cm.Contract)
                .WithMany(c => c.ContractModalities)
                .HasForeignKey(cm => cm.ContractId);

            modelBuilder.Entity<ContractModality>()
                .HasOne(cm => cm.Modality)
                .WithMany(m => m.ContractModalities)
                .HasForeignKey(cm => cm.ModalityId);

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

            modelBuilder.Entity<CreateClientViewModel>().HasNoKey();

        }
    }
}
