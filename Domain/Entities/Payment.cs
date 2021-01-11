using FluentValidator.Validation;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Payment:Entity
    {
        public Payment(decimal price, decimal totalPaid)
        {
            Price = price;
            TotalPaid = totalPaid;
            Contract = new ValidationContract()
                .Requires()
                .IsGreaterThan(Price,1,"Payment price","This price is lower than 0")
                .IsTrue(Price == TotalPaid,"Payment total paid","This payment is not valid because of this total paid")
                ;
        }

        public decimal Price  { get; private set; }
        public decimal TotalPaid { get; private set; }
    }
}
