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

        protected overrIde voId OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
