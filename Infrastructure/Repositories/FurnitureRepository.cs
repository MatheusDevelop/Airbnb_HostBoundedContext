using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System;

namespace Infrastructure.Repositories
{
    public class FurnitureRepository : Repository, IFurnitureRepository
    {
        public IMongoCollection<Furniture> _furnitures { get; set; }
        public FurnitureRepository(IAirBnbContext con):base(con)
        {
            _furnitures = database.GetCollection<Furniture>("furnitures");  
        }
        
        public bool AlreadyHostedForThisTime(Furniture furniture, DateTime checkIn, DateTime checkOut)
        {
            try
            {
                checkIn = checkIn.Date;
                checkOut = checkOut.Date;

                var searchedFurniture = _furnitures.Find(e => e.id == furniture.id).FirstOrDefault();

                if (searchedFurniture == null)
                    throw new Exception(message: "Several error: Unvaible furniture, please contact this for developer");

                if (searchedFurniture.AcommodationsDatasSchedule.Count == 0)
                    return false;

                foreach(var oneSchedule in searchedFurniture.AcommodationsDatasSchedule)
                {
                    var verifySchedule = new Schedule(checkIn, checkOut);
                    foreach(var dayVerify in verifySchedule.getUnvaibleDays())
                    {
                        if (oneSchedule.getUnvaibleDays().Contains(dayVerify))
                            return true;
                    }
                }

                return false;
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
