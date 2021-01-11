using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System;

namespace Infrastructure.Repositories
{
    public class AcommodationRepository :Repository, IAcommodationRepository
    {
        private readonly IMongoCollection<Acommodation> _acommodation;
        private readonly IMongoCollection<Furniture> _furnitures;
        public AcommodationRepository(IAirBnbContext con):base(con)
        {
            _acommodation = database.GetCollection<Acommodation>("acommodations");
            _furnitures = database.GetCollection<Furniture>("furnitures");
        }
        public void AddAcommodationAndUpdateFurnitureSchedule(Acommodation acomoddation)
        {
            try
            {
                var searchedFurniture = _furnitures.Find(e => e.id == acomoddation.Furniture.id).FirstOrDefault();
                searchedFurniture.AcommodationsDatasSchedule.Add(new Schedule(acomoddation.Checkin, acomoddation.Checkout));

                _furnitures.ReplaceOne(e => e.id == searchedFurniture.id, searchedFurniture);

                _acommodation.InsertOne(acomoddation);

                
                    

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
