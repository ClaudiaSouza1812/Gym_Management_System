// SOLID Principles applied in this class:
//
// Single Responsibility Principle (SRP):
// - This class has the single responsibility of representing a Contract entity.
//
// Liskov Substitution Principle (LSP):
// - By implementing the IContract interface, this class ensures that it can be used wherever an IContract is expected.
using Humanizer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    // Class representing a Contract entity, implementing IContract interface
    public class Contract : IContract
    {
        // Scalar Properties: These are properties that hold a single value of a specific data type.
        // They typically represent the basic attributes of the entity and often correspond directly to database columns.
        #region Scalar Properties

        [Key] // Specifies that this property is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indicates that the database should generate this value
        [DisplayName("Contract Id")] // Sets the display name for UI purposes
        public int ContractId { get; set; }

        [Required] // Specifies that this field is required
        [ForeignKey("Client")] // Indicates that this is a foreign key referencing the Client entity
        [DisplayName("Client Id")] // Sets the display name for UI purposes
        public int ClientId { get; set; }

        [Required] // Specifies that this field is required
        [ForeignKey("Membership")] // Indicates that this is a foreign key referencing the Membership entity
        [DisplayName("Membership Id")] // Sets the display name for UI purposes
        public int MembershipId { get; set; }

        [Required(ErrorMessage = "The field 'Contract Date' is mandatory")] // Specifies that this field is required with a custom error message
        [Column(TypeName = "date")] // Specifies the database column type
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // Specifies how the date should be formatted
        [DisplayName("Contract Start Date")] // Sets the display name for UI purposes
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field 'Contract Date' is mandatory")] // Specifies that this field is required with a custom error message
        [Column(TypeName = "date")]  // Specifies the database column type
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // Specifies how the date should be formatted
        [DisplayName("Contract End Date")] // Sets the display name for UI purposes
        public DateTime EndDate { get; set; }

        [NotMapped] // Indicates that this property should not be mapped to the database
        [DisplayName("Modality Package")] // Sets the display name for UI purposes
        public EnumModalityPackage? SelectedModalityPackage { get; set; }

        #endregion

        // Navigation Properties: These properties represent relationships to other entities.
        // They are typically used in ORMs like Entity Framework for defining associations.
        #region Navigation Properties
        // The virtual keyword allows for the property to be overridden, which is necessary for Entity Framework's lazy loading proxy generation.

        // Represents the associated Client entity
        public virtual Client? Client { get; set; }

        // Represents the associated Membership entity
        public virtual Membership? Membership { get; set; }

        // Collection of Payment entities associated with this Contract
        public virtual ICollection<Payment>? Payments { get; set; }

        // Collection of ContractModality entities associated with this Contract
        public virtual ICollection<ContractModality>? ContractModalities { get; set; }

        #endregion

        // Constructors: These methods initialize new instances of the Contract class.
        #region Constructors
        // Default constructor
        public Contract()
        {
            StartDate = DateTime.Now;
            EndDate = StartDate.Date.AddYears(1); // Sets the end date to one year from the start date
            Payments = new List<Payment>(); // Initializes the Payments collection
            ContractModalities = new List<ContractModality>(); // Initializes the ContractModalities collection
        }

        // Parameterized constructor
        public Contract(DateTime startDate, DateTime endstartDate, int clienteId, int membershipId) : this()
        { 
            ClientId = clienteId;
            MembershipId = membershipId;
            StartDate = startDate;
            EndDate = endstartDate;
        }

        #endregion

    }
}
