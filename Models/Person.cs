
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public abstract class Person : Interfaces.IPerson
    {
        #region Scalar Properties
        [Required(ErrorMessage = "The field 'Name' is mandatory.")]
        [Column(TypeName = "nvarchar")]
        [StringLength(30, ErrorMessage = "Limit of 30 characters")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field 'Last Name' is mandatory.")]
        [Column(TypeName = "nvarchar")]
        [StringLength(30, ErrorMessage = "Limit of 30 characters")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field 'NIF' is mandatory.")]
        [Column(TypeName = "nvarchar")]
        [StringLength(9, ErrorMessage = "Limit of 9 characters.")]
        [DisplayName("NIF")]
        public string NIF { get; set; }

        [Required(ErrorMessage = "The field 'Birth Date' is mandatory.")]
        [Column(TypeName = "date")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The field 'Email' is mandatory.")]
        [Column(TypeName = "nvarchar")]
        [StringLength(50, ErrorMessage = "Limit of 50 characters.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(9, ErrorMessage = "Limit of 9 characters.")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50, ErrorMessage = "Limit of 50 characters.")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(8, ErrorMessage = "Limit of 8 characters.")]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50, ErrorMessage = "Limit of 50 characters.")]
        [DisplayName("City")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50, ErrorMessage = "Limit of 50 characters.")]
        [DisplayName("Country")]
        public string Country { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        #endregion

        #region Constructors

        public Person(string firstName, string lastName, string nif, DateTime birthDate, string email, string phoneNumber, string address, string postalCode, string city, string country)
        {             
            FirstName = firstName;
            LastName = lastName;
            NIF = nif;
            BirthDate = birthDate;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        #endregion
    }
}
