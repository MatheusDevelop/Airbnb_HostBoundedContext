using FluentValidator.Validation;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Acommodation:Entity
    {
        protected Acommodation()
        {

        }
        public Acommodation(User user, Furniture furniture, DateTime checkin, DateTime checkout)
        {
            User = user;
            Furniture = furniture;
            Checkin = checkin.Date;
            Checkout = checkout.Date;

            Contract = new ValidationContract()
                .Requires()
                   .IsGreaterOrEqualsThan(checkin, DateTime.Now.Date, "AccomodationCheckIn", "This accomodation checkin is not valid because this date is in past")
                   .IsGreaterThan(checkout, DateTime.Now, "AccomodationCheckOut", "This accomodation checkout is not valid because the time")
                   .IsFalse(checkin.Date == checkout.Date, "AccomodationCheckout", "This accomodation checkout is not valid because the checkin is the same time")
                ;
           

        }
        public User User { get; private set; }
        public Furniture Furniture { get; private set; }
        public Payment Payment { get; private set; }
        public DateTime Checkin { get; private set; }
        public DateTime Checkout { get; private set; }
        public void AddPayment(Payment payment)
        {
            //Business rules

            if (!payment.Contract.Valid)
            {
                Contract.AddNotifications(payment.Contract);
            }
            Payment = payment;           

        }
    }
}
