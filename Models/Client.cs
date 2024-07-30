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

        public virtual ICollection<Contract> Contracts { get; set; }

        #endregion

        #region Constructors

        public Client() : base()
        { 
            Status = EnumClientStatus.Active;
            Contracts = new List<Contract>();
        } 

        public Client(string firstName, string lastName, string nif, DateTime birthDate, string email, string phoneNumber, string address, string postalCode, string city, string country, EnumClientStatus status) : base(firstName, lastName, nif, birthDate, email, phoneNumber, address, postalCode, city, country)
        {
            Status = status;
            Contracts = new List<Contract>();
        }

        #endregion

    }
}
