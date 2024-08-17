using System.ComponentModel.DataAnnotations;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IPerson
    {
        #region Scalar Properties

        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string NIF { get; }
        DateTime? BirthDate { get; }
        string Email { get; }
        string PhoneNumber { get; }
        string Address { get; }
        string PostalCode { get; }
        string City { get; }
        string Country { get; }
        DateTime CreatedAt { get; }
        DateTime? UpdatedAt { get; }

        #endregion

    }
}
