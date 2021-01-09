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
        public Furniture(string details, Adress adress)
        {
            Details = details;
            Adress = adress;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Details, "Furniture details", "This details of furniture is null or empty")
                .HasMaxLen(Details,255, "Furniture details", "This details exceed the limit of 255 characters")
                );
            AddNotifications(Adress);
        }

        public string Details { get; private set; }
        public Adress Adress { get; private set; }
        public List<Schedule> AcommodationsDatasSchedule { get; private set; } = new List<Schedule>();
    }
}
