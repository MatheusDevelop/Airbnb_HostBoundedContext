using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Domain.Mocks.Repository
{
    public class AcommodationRepository : IAcommodationRepository
    {
        public bool throwException { get; set; } = false;
        public void AddAcommodationAndUpdateFurnitureSchedule(Acommodation acomoddation)
        {
            if (throwException)
            {
                throw new Exception("Error in Acommodation database");
            }
            List<Furniture> furnituesInDatabase = GetAllFurnitues();

            //Mock example to search
            acomoddation.Furniture.id = furnituesInDatabase[0].id;

            AddAcommodationToDatabase(acomoddation);

            var furnitureToUpdate = furnituesInDatabase.Find(e => e.id == acomoddation.Furniture.id);

            furnitureToUpdate.AcommodationsDatasSchedule.Add(new Schedule(acomoddation.Checkin, acomoddation.Checkout));

            var debugThisForSeeInDebugMock = furnitureToUpdate;

        }
        private List<Furniture> GetAllFurnitues()
        {
            List<Furniture> furnituesInDatabase = new List<Furniture>();
            PopulateMockData(furnituesInDatabase);
            return furnituesInDatabase;
        }
        private void AddAcommodationToDatabase(Acommodation acommodation)
        {
            List<Acommodation> acommodationsInDatabase = new List<Acommodation>();
            acommodationsInDatabase.Add(acommodation);
        }
        private void PopulateMockData(List<Furniture> furnituesInDatabase)
        {
            for (int aleactoryNumber = 0; aleactoryNumber < 10; aleactoryNumber++)
            {
                furnituesInDatabase.Add(new Furniture(
                    $"Detalhe {aleactoryNumber}",
                    new Adress(
                        $"Rua ${aleactoryNumber}",
                        $"{aleactoryNumber}00",
                        $"Cidade {aleactoryNumber}"
                        )
                    ));
            }
        }
    }
}
