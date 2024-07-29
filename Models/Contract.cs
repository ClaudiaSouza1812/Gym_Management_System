using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class Contract : IContract
    {
        #region Scalar Properties

        [Key]
        [DisplayName("Contract ID")]
        public int ContractId { get; set; }

        [Required(ErrorMessage = "The field 'Contract Date' is mandatory")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Contract Date")]
        public DateTime ContractDate { get; set; }

        #endregion

        #region Navigation Properties

        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public virtual IClient Client { get; set; }

        [Required]
        [ForeignKey("Membership")]
        public int MembershipId { get; set; }

        public virtual IMembership Membership { get; set; }

        [Required]
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        public virtual IPayment Payment { get; set; }

        #endregion

        #region Constructors

        // Constructor for new contracts
        public Contract()
        {
            ContractDate = DateTime.UtcNow;
        }

        // Constructor for existent contracts
        public Contract(DateTime contractDate, int clienteId, int membershipId, int paymentId)
        { 
            ContractDate = contractDate;
            ClientId = clienteId;
            MembershipId = membershipId;
            PaymentId = paymentId;
        }

        #endregion

    }
}
