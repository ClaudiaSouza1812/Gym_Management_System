using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class ContractModality : IContractModality
    {
        // Navigation properties define relationships between entities
        // They allow for easy traversal between related objects in the object graph
        // In Entity Framework, they are used to represent and manage relationships in the database
        #region Scalar Properties

        // This property represents the ID of the associated Contract
        [Required] // This attribute specifies that the property is required (non-nullable)
        [ForeignKey("Contract Id")] // This attribute specifies that this property is a foreign key
        public int ContractId { get; set; }

        // This property represents the ID of the associated Modality
        [Required] // This attribute specifies that the property is required (non-nullable)
        [ForeignKey("Modality Id")] // This attribute specifies that this property is a foreign key
        public int ModalityId { get; set; }

        #endregion

        // Navigation properties define relationships between entities
        // They allow for easy traversal between related objects in the object graph
        // In Entity Framework, they are used to represent and manage relationships in the database
        #region Navigation Properties

        // This property represents the associated Contract entity
        // The 'virtual' keyword enables lazy loading in Entity Framework
        // The '?' indicates that this property is nullable
        public virtual Contract? Contract { get; set; }

        // This property represents the associated Modality entity
        // The 'virtual' keyword enables lazy loading in Entity Framework
        // The '?' indicates that this property is nullable
        public virtual Modality? Modality { get; set; }

        #endregion

    }
}
