using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class Membership : IMembership
    {
        #region Scalar Properties
        [Key]
        [DisplayName("Membership ID")]
        public int MembershipId { get; set; }

        [Required(ErrorMessage = "The field 'Loyal Member' is mandatory.")]
        [Column(TypeName = "bit")]
        [DisplayName("Loyal Member")]
        public bool IsLoyal { get; set; }

        [Required(ErrorMessage = "The field 'Discount' is mandatory.")]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0,20)]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "The field 'Start Date' is mandatory.")]
        [Column(TypeName = "date")]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field 'End Date' is mandatory.")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        #endregion

        #region Navigation Properties
        

        public virtual ICollection<IContract> Contracts { get; set; }

        #endregion

        #region Constructors

        public Membership()
        {
            IsLoyal = false;
            Discount = 0;
            StartDate = DateTime.UtcNow;
            EndDate = DateTime.UtcNow.AddMonths(4);
            Contracts = new List<IContract>();
        }

        public Membership(bool isLoyal, decimal discount, DateTime startDate, DateTime endDate)
        {
            IsLoyal = isLoyal;
            Discount = discount;
            StartDate = startDate;
            EndDate = endDate;
            Contracts = new List<IContract>();
        }

        #endregion

        
        
    }
}
