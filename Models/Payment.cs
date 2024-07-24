﻿using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.Entities;
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

        [Required(ErrorMessage = "Payment Type is required")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Payment Type")]
        public EnumPaymentType PaymentType { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [DisplayName("Payment Value")]
        public decimal PaymentValue { get; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Payment Date")]
        public DateTime PaymentDate { get; set; }

        #endregion

        #region Navigation Properties

        // Relationship: Payment N - 1 Client
        // Relationship: Payment N - 1 Membership

        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Membership")]
        public int MembershipID { get; set; }
        public virtual Membership Membership { get; set; }

        #endregion

        #region Constructors

        public Payment()
        {
            PaymentDate = DateTime.UtcNow;
        }

        public Payment(EnumPaymentType paymentType, int clientId, int membershipId) : this()
        {
            PaymentType = paymentType;
            ClientID = clientId;
            MembershipID = membershipId;
        }

        #endregion

        

    }
}
