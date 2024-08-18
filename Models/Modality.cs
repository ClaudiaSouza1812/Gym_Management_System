﻿using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
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
        [DisplayName("Modality Id")]
        public int ModalityId { get; set; }

        [Required(ErrorMessage = "Modality Name is required")]
        [Column(TypeName = "nvarchar")]
        [StringLength(30, ErrorMessage = "Limit of 40 characters")]
        [DisplayName("Modality Name")]
        public string ModalityName { get; set; }

        [Required(ErrorMessage = "Modality Package is required")]
        [Column(TypeName = "int")]
        [DisplayName("Modality Package")]
        [EnumDataType(typeof(EnumModalityPackage))]
        public EnumModalityPackage ModalityPackage { get; set; }

        [NotMapped]
        public string? SecondModalityName { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<ContractModality>? ContractModalities { get; set; }

        #endregion

        #region Constructors

        public Modality()
        {
            ContractModalities = new List<ContractModality>();
        }

        public Modality(string modalityName, EnumModalityPackage modalityPackage) : this() 
        {
            ModalityName = modalityName;
            ModalityPackage = modalityPackage;
        }

        #endregion
    }
}
