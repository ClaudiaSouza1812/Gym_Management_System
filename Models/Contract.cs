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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Contract Id")]
        public int ContractId { get; set; }

        [Required]
        [ForeignKey("Client")]
        [DisplayName("Client Id")]
        public int ClientId { get; set; }

        [Required]
        [ForeignKey("Membership")]
        [DisplayName("Membership Id")]
        public int MembershipId { get; set; }

        [Required(ErrorMessage = "The field 'Contract Date' is mandatory")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Contract Date")]
        public DateTime ContractDate { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Client? Client { get; set; }

        public virtual Membership? Membership { get; set; }

        public virtual ICollection<Payment>? Payments { get; set; }
        public virtual ICollection<ContractModality>? ContractModalities { get; set; }

        #endregion

        #region Constructors

        // Constructor for new contracts
        public Contract()
        {
            ContractDate = DateTime.Now;
            Payments = new List<Payment>();
            ContractModalities = new List<ContractModality>();
        }

        // Constructor for existent contracts
        public Contract(DateTime contractDate, int clienteId, int membershipId) : this()
        { 
            ClientId = clienteId;
            MembershipId = membershipId;
            ContractDate = contractDate;
        }

        #endregion

    }
}
