using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Domain.Mocks.Repository
{
    public class FurnitureRepository : IFurnitureRepository
    {
        public bool setAlreadyHosted { get; set; } = false;
        public bool throwException { get; set; } = false;
        public bool AlreadyHostedForThisTime(Furniture furniture, DateTime checkIn, DateTime checkOut)
        {
            if (throwException)
            {
                throw new Exception("Error in Furniture database");
            }

            return setAlreadyHosted;
        }
    }
}
