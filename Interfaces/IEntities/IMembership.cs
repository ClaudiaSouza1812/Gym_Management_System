// import the namespace of the needed classes to be used within this class
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
// Define the class namespace
namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{   // Define the contract for the class that will implement this interface
    public interface IMembership
    {
        // scalar properties have a single value
        #region Scalar Properties

        int MembershipId { get; } // read-only, should only be set once during the object creation
        string MembershipType { get; }
        decimal DiscountPercentage { get; }

        #endregion
    }
}
