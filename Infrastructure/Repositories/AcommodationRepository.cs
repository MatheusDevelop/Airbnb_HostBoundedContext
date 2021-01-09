using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System;

namespace Infrastructure.Repositories
{
    public class AcommodationRepository :Repository, IAcommodationRepository
    {
        
        public void AddAcommodationAndUpdateFurnitureSchedule(Acommodation acomoddation)
        {
            try
            {

                            


            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
