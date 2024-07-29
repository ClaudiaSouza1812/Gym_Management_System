using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class ContractModality : IContractModality
    {
        #region Scalar Properties

        [Key]
        [DisplayName("Contract/Modality ID")]
        public int ContractModalityId { get; set; }

        [Required]
        [ForeignKey("Contract")]
        public int ContractId { get; set; }

        [Required]
        [ForeignKey("Modality")]
        public int ModalityId { get; set; }


        #endregion

        #region Navigation Properties

        public IContract Contract { get; set; }

        public IModality Modality { get; set; }

        #endregion

    }
}
