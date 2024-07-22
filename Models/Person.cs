
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class Person : Interfaces.IPerson
    {
        [Required(ErrorMessage = "The field 'Name' is mandatory.")]
        [Column(TypeName = "nvarchar")]
        [StringLength(30, ErrorMessage = "Limit of 30 characters")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string NIF { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
