﻿using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IMethods;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Methods
{
    public class CalculateMonthlyPayment : PaymentCalculator
    {
        #region Constructor

        public CalculateMonthlyPayment(IPayment payment) : base(payment) { }

        #endregion

        protected overrIde decimal CalculatePaymentApplication()
        {
            return _payment.PaymentBaseValue * _payment.PaymentBaseRate;
        }
        
    }
}
