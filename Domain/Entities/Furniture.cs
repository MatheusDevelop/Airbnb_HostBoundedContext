using Domain.ValueObjects;
using FluentValidator.Validation;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Furniture:Entity
    {
        protected Furniture()
        {

        }

        public Furniture(string details, Adress adress)
        {
            Details = details;
            Adress = adress;

            Contract  = new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Details, "Furniture details", "This details of furniture is null or empty")
                .HasMaxLen(Details,255, "Furniture details", "This details exceed the limit of 255 characters")
            ;
            Contract.AddNotifications(Adress);
        }

        public string Details { get; private set; }
        public Adress Adress { get; private set; }
        public List<Schedule> AcommodationsDatasSchedule { get; private set; } = new List<Schedule>();
    }
}
