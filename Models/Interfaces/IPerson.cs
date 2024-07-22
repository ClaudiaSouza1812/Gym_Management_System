using System.ComponentModel.DataAnnotations;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Interfaces
{
    public interface IPerson
    {
        #region Scalar Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIF { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        #endregion

    }
}
