using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Net;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class Client : Person, Interfaces.IClient
    {
        #region Scalar Properties
        [Key]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "The field 'Status' is mandatory.")]
        [Column(TypeName = "nvarchar")]
        [StringLength(3, ErrorMessage = "Limit of 3 characters, e.g. 'yes' or 'no'")]
        [DisplayName("Status")]
        public EnumClientStatus Status { get; set; }
        #endregion

        #region Constructor
        public Client(string firstName, string lastName, string nif, DateOnly birthDate, string email, string phoneNumber, string address, string postalCode, string city, string country, EnumClientStatus status) : base(firstName, lastName, nif, birthDate, email, phoneNumber, address, postalCode, city, country)
        {
            Status = status;
        }
        #endregion

        // ToDo: Add Navigation Properties
        #region Navigation Properties


        #endregion

    }
}
