using Domain.Commands.Result;
using Domain.Entities;
using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.Request
{
    public class FurnitureReservationRequest:Notifiable,IRequest<FurnitureReservationResult>
    {        
        public User User { get;  set; }
        public Furniture Furniture { get;  set; }
        public Payment Payment { get;  set; }
        public DateTime Checkin { get;  set; }
        public DateTime Checkout { get;  set; }
        
    }
}
