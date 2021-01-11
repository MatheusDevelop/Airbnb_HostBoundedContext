using MongoDB.Bson.Serialization.Attributes;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Schedule:Entity
    {
        protected Schedule()
        {

        }
        public Schedule(DateTime checkIn, DateTime checkout)
        {
            CheckIn = checkIn.Date;
            Checkout = checkout.Date;
        }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CheckIn { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Checkout { get; set; }

       
        public List<DateTime> getUnvaibleDays()
        {
            var list = new List<DateTime>();
            var countForDates = (int)Checkout.Subtract(CheckIn).TotalDays;

            for (int x = 0 ; x < countForDates; x++)
            {
                list.Add(CheckIn.AddDays(x));
            }
            list.Add(Checkout);
            return list;
        }

    }
}
