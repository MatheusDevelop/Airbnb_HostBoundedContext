using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Domain.Mocks.Services
{
    public class PaymentService : IPaymentService
    {
        public bool throwException { get; set; } = false;
        public void makeAPayment(Payment payment)
        {
            if (throwException)
            {
                throw new Exception("Error in database payment");
            }
        }
    }
}
