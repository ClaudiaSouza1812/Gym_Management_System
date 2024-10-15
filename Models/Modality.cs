// SOLID Principles applied in this class:
//
// Single Responsibility Principle (SRP):
// - This class has the single responsibility of representing a Modality entity.
// - It encapsulates all properties and behaviors related to a Modality.
//
// Liskov Substitution Principle (LSP):
// - By implementing the IModality interface, this class ensures that it can be used wherever an IModality is expected.
//
// Interface Segregation Principle (ISP):
// - The class implements the focused IModality interface, adhering to a specific contract.

using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    // Modality class implementing IModality interface
    public class Modality : IModality
    {
        #region Scalar Properties
        [Key] // Marks this property as the primary key for the entity
        [DisplayName("Modality Id")] // Sets the display name for UI purposes
        public int ModalityId { get; set; }

        [Required(ErrorMessage = "Modality Name is required")] // Makes this field mandatory with a custom error message
        [Column(TypeName = "nvarchar")] // Specifies the database column type
        [StringLength(30, ErrorMessage = "Limit of 40 characters")] // Sets max length with custom error message
        [DisplayName("Modality Name")] // Sets the display name for UI purposes
        public string ModalityName { get; set; }

        [Required(ErrorMessage = "Modality Package is required")]
        [Column(TypeName = "int")]
        [DisplayName("Modality Package")]
        [EnumDataType(typeof(EnumModalityPackage))]
        public EnumModalityPackage ModalityPackage { get; set; }

        [NotMapped] // Indicates that this property should not be mapped to the database
        public string? SecondModalityName { get; set; } // Nullable string property

        #endregion

        #region Navigation Properties
        // Collection of related ContractModality entities
        // virtual keyword enables lazy loading in Entity Framework
        public virtual ICollection<ContractModality>? ContractModalities { get; set; }

        #endregion

        #region Constructors
        // Default constructor
        public Modality()
        {
            // added after the project delivery:
            ModalityName = string.Empty;
            ModalityPackage = EnumModalityPackage.OneModality;
            //

            // Initialize the ContractModalities collection to prevent null reference exceptions
            ContractModalities = new List<ContractModality>();
        }
        // Parameterized constructor
        // Calls the default constructor using this() to ensure ContractModalities is initialized
        public Modality(string modalityName, EnumModalityPackage modalityPackage) : this() 
        {
            ModalityName = modalityName;
            ModalityPackage = modalityPackage;
        }

        #endregion
    }
}
