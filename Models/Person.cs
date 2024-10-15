
// Imports necessary namespaces for data annotations, database schema, and component model
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
// Imports the IPerson interface from the project's interfaces
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    // Abstract base class for Person entities, implementing the IPerson interface
    // Abstract: Cannot be instantiated directly, meant to be inherited by concrete classes
    public abstract class Person : IPerson
    {
        #region Scalar Properties

        // Unique identifier for the person
        // Data Annotations:
        // [Key]: Marks this property as the primary key in the database
        // [DisplayName]: Specifies the display name for the property in the UI
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field 'Name' is mandatory.")] // Validation: field must have a value
        [Column(TypeName = "nvarchar")] // Database mapping: specifies the column type
        [StringLength(30, ErrorMessage = "Limit of 30 characters")] // Validation: limits string length
        [DisplayName("First Name")] // Specifies the display name for the property in the UI as "Id"
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
        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }

        [EmailAddress] // Validates the input as an email address
        [Required(ErrorMessage = "The field 'Email' is mandatory.")]
        [Column(TypeName = "nvarchar")]
        [StringLength(50, ErrorMessage = "Limit of 50 characters.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Phone] // Validates the input as a phone number
        [Column(TypeName = "nvarchar")]
        [StringLength(9, ErrorMessage = "Limit of 9 characters.")]
        [DisplayName("Phone")]
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

        [Column(TypeName = "datetime2")]
        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        [DisplayName("Updated At")]
        public DateTime? UpdatedAt { get; set; }

        #endregion

        // Computed properties: Properties that are calculated based on other properties
        #region Computed Property

        // Full name of the person, combining first and last name
        [DisplayName("Name")]
        public string FullName => $"{FirstName} {LastName}";

        #endregion

        // Constructors: Special methods for creating and initializing objects of this class
        #region Constructors

        // Default constructor
        // Initializes all string properties to empty strings and sets dates
        public Person()
        { 
            FirstName = string.Empty;
            LastName = string.Empty;
            NIF = string.Empty;
            BirthDate = new DateTime();
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        // Parameterized constructor
        // Allows creation of a Person object with all details provided
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
            CreatedAt = DateTime.Now;
            UpdatedAt = null;
        }

        #endregion
    }
}
