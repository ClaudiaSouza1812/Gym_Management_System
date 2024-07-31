﻿using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
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
        [DisplayName("Payment ID")]
        public int PaymentID { get; set; }

        [Required]
        [ForeignKey("Contract")]
        public int ContractId { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Payment Type")]
        [EnumDataType(typeof(EnumPaymentType))]
        public EnumPaymentType PaymentType { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [DisplayName("Payment Base Value")]
        public decimal PaymentBaseValue { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [DisplayName("Payment Rate")]
        public decimal PaymentBaseRate { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [DisplayName("Payment Total Value")]
        public decimal PaymentTotalValue { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Payment Date")]
        public DateTime PaymentDate { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Contract Contract {  get; set; }

        #endregion

        #region Constructors

        public Payment()
        {
            PaymentType = EnumPaymentType.PerSession;
            PaymentBaseValue = 0;
            PaymentBaseRate = 0;
            PaymentTotalValue = 0;
            PaymentDate = DateTime.UtcNow;
        }

        public Payment(EnumPaymentType paymentType, decimal paymentBaseValue,  decimal paymentBaseRate, DateTime paymentDate)
        {
            PaymentType = paymentType;
            PaymentBaseValue = paymentBaseValue;
            PaymentBaseRate = paymentBaseRate;
            PaymentTotalValue = paymentBaseValue * paymentBaseRate;
            PaymentDate = paymentDate;
        }

        #endregion

        

    }
}
