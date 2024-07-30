using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
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

        public virtual ICollection<ContractModality> ContractModalities { get; set; }

        #endregion

        #region Constructors

        public Modality()
        {
            ModalityName = new EnumModalityName();
            ModalityPackage = EnumModalityPackage.OneModality;
            ContractModalities = new List<ContractModality>();
        }

        public Modality(EnumModalityName modalityName, EnumModalityPackage modalityPackage) : this() 
        {
            ModalityName = modalityName;
            ModalityPackage = modalityPackage;
        }

        #endregion
    }
}
