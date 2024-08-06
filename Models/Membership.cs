using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class Membership : IMembership
    {
        #region Scalar Properties
        [Key]
        [DisplayName("Membership Id")]
        public int MembershipId { get; set; }

        [Required(ErrorMessage = "Membership Name is required")]
        [Column(TypeName = "int")]
        [DisplayName("Membership Name")]
        [EnumDataType(typeof(EnumMembershipName))]
        public EnumMembershipName MembershipName { get; set; }

        [Required(ErrorMessage = "The field 'Discount' is mandatory.")]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0,20, ErrorMessage = "Discount must be between 0 and 20.")]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "The field 'Start Date' is mandatory.")]
        [Column(TypeName = "date")]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        #endregion

        #region Navigation Properties
        

        public virtual ICollection<Contract> Contracts { get; set; }

        #endregion

        #region Constructors

        public Membership()
        {
            MembershipName = EnumMembershipName.Regular;
            Discount = 0;
            StartDate = DateTime.UtcNow;
            Contracts = new List<Contract>();
        }

        public Membership(EnumMembershipName membershipName, decimal discount, DateTime startDate)
        {
            MembershipName = membershipName;
            Discount = discount;
            StartDate = startDate;
            Contracts = new List<Contract>();
        }

        #endregion

        
        
    }
}
