using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    // a concrete class implement the IMembership interface contract
    public class Membership : IMembership
    {
        // properties with a single value
        #region Scalar Properties
        // data annotations
        [Key] // primary key
        [DisplayName("Membership Id")] // name to be displayed for the user
        public int MembershipId { get; set; } // public property that can be read and set

        [Required(ErrorMessage = "Membership Type is required")] // mandatory, not null
        [Column(TypeName = "nvarchar")] // database column data type
        [StringLength(30, ErrorMessage = "Limit of 30 characters")] // max length with an error message
        [DisplayName("Membership Type")]
        public string MembershipType { get; set; }

        [Required(ErrorMessage = "The field 'Discount' is mandatory.")]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 20, ErrorMessage = "Discount must be between 0% and 20%.")] // range limit for the discount with an error message
        [DisplayName("Discount Percentage")]
        [DisplayFormat(DataFormatString = "{0:F2}%")] // display the discount with 2 decimal houses and a % sign
        public decimal DiscountPercentage { get; set; }

        #endregion

        // Define relationship between entities
        #region Navigation Properties

        // represent the collection of contracts associated with this entity, the relationship 1 : n and the database communication between them 
        public virtual ICollection<Contract> Contracts { get; set; }

        #endregion

        // methods called to construct the object when it is instantiated
        #region Constructors

        // parameterless default constructor
        public Membership()
        {
            MembershipType = string.Empty;
            Contracts = new List<Contract>();
        }

        // parameterized constructor 
        public Membership(string membershipType, decimal discountPercentage) : this()
        {
            MembershipType = membershipType;
            DiscountPercentage = discountPercentage;
        }

        #endregion  
    }
}
