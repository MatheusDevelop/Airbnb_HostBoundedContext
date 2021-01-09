using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IAcommodationRepository
    {
        void AddAcommodationAndUpdateFurnitureSchedule(Acommodation acomoddation);
    }
}
