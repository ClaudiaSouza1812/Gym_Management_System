using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class Contract : Interfaces.IContract
    {
        #region Scalar Properties
        [Key]
        public int ContractID { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public int MembershipID { get; set; }
        public string Terms { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        #endregion

        #region Navigation Properties

        public Client Client { get; set; }
        public Membership Membership { get; set; }

        
        #endregion
        
        #region Constructor
        public Contract(string terms, DateTime startDate, DateTime endDate, Client client)
        {
            Terms = terms;
            StartDate = startDate;
            EndDate = endDate;
            Client.ClientID = client.ClientID;
            Client.FirstName = client.FullName;
        }
        #endregion
        
    }
}
