/*
Areas that adhere to SOLID:
The class has a single responsibility of representing a Client.
It's extensible through inheritance.
It implements a specific interface (IClient).
*/

using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Net;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    // Client class inheriting from Person and implementing IClient interface
    public class Client : Person, IClient
    {
        #region Scalar Properties

        [Required(ErrorMessage = "The field 'Status' is mandatory.")] // Makes this field mandatory with a custom error message
        [Column(TypeName = "int")] // Specifies the database column type as int
        [DisplayName("Status")] // Specifies the display name for the property in the UI as "Status"
        [EnumDataType(typeof(EnumClientStatus))] // Specifies that this property should be treated as an enum of type EnumClientStatus
        public EnumClientStatus Status { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        [Column(TypeName = "int")]
        [DisplayName("Payment Type")]
        [EnumDataType(typeof(EnumPaymentType))]
        public EnumPaymentType PaymentType { get; set; }

        [Required(ErrorMessage = "The field 'Loyal Member' is mandatory.")]
        [Column(TypeName = "bit")]
        [DisplayName("Loyal Member")]
        public bool Loyal { get; set; }

        #endregion

        // Navigation properties that represent relationships between entities
        #region Navigation Properties

        // Collection of contracts associated with this client, representing the one-to-many relationship
        // virtual keyword enables lazy loading in Entity Framework
        public virtual ICollection<Contract> Contracts { get; set; }

        #endregion

        #region Constructors

        // Default constructor receive the base properties if Person and adds the Client properties
        public Client() : base()
        { 
            Loyal = false;
            Status = EnumClientStatus.Active;
            Contracts = new List<Contract>();
        }

        // Parameterized constructor
        public Client(string firstName, string lastName, string nif, DateTime birthDate, string email, string phoneNumber, string address, string postalCode, string city, string country, EnumClientStatus status, bool loyal) : base(firstName, lastName, nif,  birthDate, email, phoneNumber, address, postalCode, city, country)
        {
            Loyal = loyal;
            Status = status;
            Contracts = new List<Contract>();
        }

        #endregion
    }
}
