using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Net;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class Client : Person, IClient
    {
        
        #region Scalar Properties

        [Required(ErrorMessage = "The field 'Status' is mandatory.")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Client Status")]
        public EnumClientStatus Status { get; set; }

        #endregion

        #region Navigation Properties

        // Relationship: Client 1 - N Payment
        // Relationship: Client 1 - N Membership
        // Client will go as a foreign key in Payment and Membership
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
        public virtual ICollection<Membership> Memberships { get; set; } = new HashSet<Membership>();

        #endregion

        #region Constructors

        public Client() : base()
        { 
            Status = EnumClientStatus.Active;
        } 

        public Client(string firstName, string lastName, string nif, DateTime birthDate, string email, string phoneNumber, string address, string postalCode, string city, string country, EnumClientStatus status) : base(firstName, lastName, nif, birthDate, email, phoneNumber, address, postalCode, city, country)
        {
            Status = status;
        }

        #endregion

    }
}
