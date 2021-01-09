using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.Result
{
    public class FurnitureReservationResult
    {
        public Furniture FurnitureDetails { get;  set; }
        public string PaymentConfirmation { get;  set; }
        public DateTime Checkin { get;  set; }
        public DateTime Checkout { get;  set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
