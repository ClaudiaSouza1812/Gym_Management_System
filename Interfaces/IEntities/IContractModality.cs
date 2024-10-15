// This line imports the Models namespace from the project, allowing the use of model classes
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

// This defines the namespace for the interface, organizing it within the project structure
namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    // This interface defines the contract for ContractModality entities
    // It specifies the properties that any class implementing this interface must have
    public interface IContractModality
    {
        // This region groups related properties together for better code organization
        // Scalar properties represent single, atomic values (as opposed to collections or complex objects)
        // They typically correspond to individual columns in a database table
        // In this case, they represent the foreign keys for the many-to-many relationship between Contract and Modality entities
        #region Scalar Properties

        // This property represents the unique identifier for a Contract
        // It's read-only, indicating that it should only be set once (likely during object creation)
        int ContractId { get; }

        int ModalityId { get; }

        #endregion

    }

}
