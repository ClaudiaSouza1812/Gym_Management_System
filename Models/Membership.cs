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

        [Required(ErrorMessage = "Membership Type is required")]
        [Column(TypeName = "nvarchar")]
        [StringLength(30, ErrorMessage = "Limit of 30 characters")]
        [DisplayName("Membership Type")]
        public string MembershipType { get; set; }

        [Required(ErrorMessage = "The field 'Discount' is mandatory.")]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 20, ErrorMessage = "Discount must be between 0% and 20%.")]
        [DisplayName("Discount Percentage")]
        [DisplayFormat(DataFormatString = "{0:F2}%")]
        public decimal DiscountPercentage { get; set; }

        #endregion

        #region Navigation Properties


        public virtual ICollection<Contract> Contracts { get; set; }

        #endregion

        #region Constructors

        public Membership()
        {
            MembershipType = string.Empty;
            Contracts = new List<Contract>();
        }

        public Membership(string membershipType, decimal discountPercentage) : this()
        {
            MembershipType = membershipType;
            DiscountPercentage = discountPercentage;
        }

        #endregion

        
        
    }
}
