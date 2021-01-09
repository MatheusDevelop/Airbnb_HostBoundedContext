using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IFurnitureRepository
    {
        public bool AlreadyHostedForThisTime(Furniture furniture,DateTime checkIn,DateTime checkOut);
    }
}
