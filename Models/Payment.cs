using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class Payment : IPayment
    {
        #region Scalar Properties

        [Key]
        [DisplayName("Payment Id")]
        public int PaymentId { get; set; }

        [Required]
        [ForeignKey("Contract Id")]
        public int ContractId { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [DisplayName("Payment Base Value")]
        public decimal PaymentBaseValue { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [DisplayName("Payment Rate")]
        public decimal PaymentBaseRate { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Payment Date")]
        public DateTime PaymentDate { get; set; }

        #endregion

        #region Computed Property
        [Column(TypeName = "decimal(6,2)")]
        [DisplayName("Payment Value")]
        public decimal PaymentTotalValue { get; set; }

        #endregion


        #region Navigation Properties

        public virtual Contract? Contract {  get; set; }

        #endregion

        #region Constructors

        public Payment(){}

        public Payment(decimal paymentBaseValue,  decimal paymentBaseRate, DateTime paymentDate)
        {
            PaymentBaseValue = paymentBaseValue;
            PaymentBaseRate = paymentBaseRate;
            PaymentDate = paymentDate;
        }

        #endregion

        

    }
}
