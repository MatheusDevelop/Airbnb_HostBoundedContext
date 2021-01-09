using Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Schedule:Entity
    {
        public Schedule(DateTime checkIn, DateTime checkout)
        {
            CheckIn = checkIn;
            Checkout = checkout;

            UnvaibleDays = getUnvaibleDays();

        }
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public List<DateTime> UnvaibleDays { get;}

        private List<DateTime> getUnvaibleDays()
        {
            var list = new List<DateTime>();
            var countForDates = 1;

            for (int x = CheckIn.Day ; x < Checkout.Day; x++)
            {
                list.Add(CheckIn.AddDays(countForDates));
                countForDates++;
            }
            list.Add(CheckIn);
            return list;
        }

    }
}
