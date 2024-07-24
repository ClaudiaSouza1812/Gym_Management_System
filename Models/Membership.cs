using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.Entities;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class Membership : IMembership
    {
        #region Scalar Properties
        [Key]
        [DisplayName("Membership ID")]
        public int MembershipID { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "The field 'Membership Type' is mandatory.")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Membership Type")]
        public EnumMembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "The field 'Loyal Member' is mandatory.")]
        [Column(TypeName = "bit")]
        [DisplayName("Loyal Member")]
        public bool IsLoyal { get; set; }

        [Required(ErrorMessage = "The field 'Discount' is mandatory.")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "The field 'Start Date' is mandatory.")]
        [Column(TypeName = "date")]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field 'End Date' is mandatory.")]
        [Column(TypeName = "date")]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        #endregion

        #region Navigation Properties
        // Relationship: Membership N - 1 Client
        // Relationship: Membership N - N GymModality
        [ForeignKey("Client")]
        public Client Client { get; set; }
        ICollection<GymModality> GymModalities { get; set; }

        #endregion

        #region Constructors
        public Membership()
        {
            GymModalities = new HashSet<GymModality>();
        }
        #endregion

        
        
    }
}
