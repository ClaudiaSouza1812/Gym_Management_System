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
        [DisplayName("Membership ID")]
        public int MembershipID { get; set; }

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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        #endregion

        #region Navigation Properties
        // Relationship: Membership N - 1 Client
        // Relationship: Membership N - N Modality
        // Membership will go as a foreign key in Client and Modality
        [ForeignKey("Client")]
        public int ClientID { get; set; }

        public Client Client { get; set; }

        ICollection<Modality> Modalities { get; set; }

        #endregion

        #region Constructors
        public Membership()
        {
            Modalities = new HashSet<Modality>();
        }
        #endregion

        
        
    }
}
