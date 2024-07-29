﻿using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using System.Diagnostics.Contracts;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IPayment
    {
        #region Scalar Properties

        int PaymentID { get; }
        EnumPaymentType PaymentType { get; }
        decimal PaymentBaseValue { get; }
        decimal PaymentBaseRate { get; }
        decimal PaymentTotalValue { get; }
        DateTime PaymentDate { get; }

        #endregion

        IContract Contract { get; set; }
    }
}
