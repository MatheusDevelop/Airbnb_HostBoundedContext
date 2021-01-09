using Domain.Commands.Request;
using Domain.Commands.Result;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using FluentValidator;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class FurnitureReservationHandler : Notifiable ,  IRequestHandler<
        FurnitureReservationRequest,
        FurnitureReservationResult
    >
   
    {
        private readonly IFurnitureRepository _furnitureRep;
        private readonly IAcommodationRepository _acommodationRep;
        private readonly IPaymentService _paymentService;

        public FurnitureReservationHandler(
            IFurnitureRepository furnitureRep
            , IAcommodationRepository acommodationRep
            , IPaymentService paymentService)
        {
            _furnitureRep = furnitureRep;
            _acommodationRep = acommodationRep;
            _paymentService = paymentService;
        }

        public Task<FurnitureReservationResult> Handle(FurnitureReservationRequest request, CancellationToken cancellationToken)
        {
            var result = new FurnitureReservationResult();

            if (request.Invalid)
            {
                AddNotifications(request);
                foreach (var notification in Notifications)
                {
                    result.Errors.Add(notification.Message);
                }
                return Task.FromResult(result);
            }

            try
            {

                if (_furnitureRep.AlreadyHostedForThisTime(
                        request.Furniture,
                        request.Checkin,
                        request.Checkout
                    ))
                {
                    AddNotification("Furniture handler", "this furniture already hosted for this time");
                }


            }catch(Exception ex)
            {
                AddNotification("Internal error", ex.Message);

                result.Errors.Add(ex.Message);
                return Task.FromResult(result);
            }


            var newAccomodationReserve = new Acommodation(
               request.User,
               request.Furniture,
               request.Checkin,
               request.Checkout);

            newAccomodationReserve.AddPayment(request.Payment);

            if (newAccomodationReserve.Invalid)
            {
                AddNotification("Error in acomoddation", "This acomoddation is invalid");
                AddNotifications(newAccomodationReserve);
            }



            if (this.Invalid)
            {

                foreach(var notification in Notifications)
                {
                    result.Errors.Add(notification.Message);
                }
                return Task.FromResult(result);
            }


            
            try
            {
                _paymentService.makeAPayment(request.Payment);
                _acommodationRep.AddAcommodationAndUpdateFurnitureSchedule(newAccomodationReserve);   

            }catch(Exception ex)
            {
                AddNotification("External error", ex.Message);

                result.Errors.Add(ex.Message);
                return Task.FromResult(result);
            }


            result.FurnitureDetails = newAccomodationReserve.Furniture;
            result.Checkin = newAccomodationReserve.Checkin;
            result.Checkout = newAccomodationReserve.Checkout;

            return Task.FromResult(result);
        }


    }
}
