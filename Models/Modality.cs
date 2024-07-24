using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class Modality : IModality
    {
        #region Scalar Properties
        [Key]
        [DisplayName("Modality ID")]
        public int ModalityID { get; set; }

        [Required(ErrorMessage = "Modality Name is required")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Modality Name")]
        public EnumModalityName ModalityName { get; set; }

        [Required(ErrorMessage = "Modality Type is required")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Modality Type")]
        public EnumModalityPackage ModalityPackage { get; set; }

        
        #endregion

        #region Navigation Properties

        // Relantionship: Modality 1 - N Membership
        // Modality will go as a foreign key in Membership
        public ICollection<Membership> Memberships { get; set; }

        #endregion

        #region Constructors

        public Modality()
        {
            Memberships = new HashSet<Membership>();
        }

        #endregion
    }
}
