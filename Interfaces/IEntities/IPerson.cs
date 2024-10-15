using System.ComponentModel.DataAnnotations;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    // Interface defining the contract for a Person entity
    public interface IPerson
    {
        // Region grouping scalar properties
        // Scalar properties are properties that hold a single value of a specific type
        // They are distinct from navigation properties which represent relationships between entities
        #region Scalar Properties

        // Unique identifier for the person
        // Meaning: A non-negative integer that uniquely identifies each person record
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string NIF { get; }
        // Person's birth date (nullable)
        // Meaning: A DateTime value representing the person's date of birth, can be null if unknown
        DateTime? BirthDate { get; }
        string Email { get; }
        string PhoneNumber { get; }
        string Address { get; }
        string PostalCode { get; }
        string City { get; }
        string Country { get; }
        // Timestamp of when the person record was created
        // Meaning: A DateTime value indicating when this person's information was first added to the system
        DateTime CreatedAt { get; }
        // Timestamp of when the person record was last updated (nullable)
        // Meaning: A DateTime value indicating when this person's information was last modified, can be null if never updated
        DateTime? UpdatedAt { get; }

        #endregion

    }
}
