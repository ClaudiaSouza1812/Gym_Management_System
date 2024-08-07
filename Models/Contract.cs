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
        [DisplayName("Contract Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field 'Contract Date' is mandatory")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Contract End Date")]
        public DateTime EndDate { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Client? Client { get; set; }

        public virtual Membership? Membership { get; set; }

        public virtual ICollection<Payment>? Payments { get; set; }
        public virtual ICollection<ContractModality>? ContractModalities { get; set; }

        #endregion

        #region Constructors

        
        public Contract()
        {
            StartDate = DateTime.Now;
            EndDate = StartDate.Date.AddYears(1);
            Payments = new List<Payment>();
            ContractModalities = new List<ContractModality>();
        }

        
        public Contract(DateTime startDate, DateTime endstartDate, int clienteId, int membershipId) : this()
        { 
            ClientId = clienteId;
            MembershipId = membershipId;
            StartDate = startDate;
            EndDate = endstartDate;
        }

        #endregion

    }
}
