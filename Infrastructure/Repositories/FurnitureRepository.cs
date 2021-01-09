using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using System;

namespace Infrastructure.Repositories
{
    public class FurnitureRepository : Repository, IFurnitureRepository
    {
        
        public bool AlreadyHostedForThisTime(Furniture furniture, DateTime checkIn, DateTime checkOut)
        {
            try
            {

                return true;
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
