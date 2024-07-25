using System.ComponentModel.DataAnnotations;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IPerson
    {
        #region Scalar Properties

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string NIF { get; }
        public DateTime BirthDate { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string Address { get; }
        public string PostalCode { get; }
        public string City { get; }
        public string Country { get; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; }

        #endregion

    }
}
