using Domain.Commands.Request;
using Domain.Entities;
using Domain.Handlers;
using Domain.ValueObjects;
using System;
using Tests.Domain.Mocks.Repository;
using Tests.Domain.Mocks.Services;
using Xunit;

namespace Tests.Domain.Handlers
{
    public class FurnitureReservationHandlerTest
    {
        
        [Fact]
        public void Handler_Should_Be_Valid_When_Request_Is_Valid()
        {
            var repAcommodation = new AcommodationRepository();
            var repFurniture = new FurnitureRepository();
            var payService = new PaymentService();

            var handler = new FurnitureReservationHandler(repFurniture, repAcommodation, payService);

            var user = new User("Matheus barbosa", "mathvierabarbosa@gmail.com", new Adress("Rua x","123","SÃO PAULO"));
            var furniture = new Furniture("Descriçao", new Adress("Rua y", "321", "SÃO PAULO"));

            var payment = new Payment(500, 500);

            var commandRequest = new FurnitureReservationRequest() { User = user, Furniture = furniture, Payment = payment, Checkin = DateTime.Now, Checkout = DateTime.Now.AddDays(3) };
            var res = handler.Handle(commandRequest, new System.Threading.CancellationToken());


            Assert.True(handler.Valid);
            
        }

        [Fact]
        public void Handler_Should_Be_Invalid_When_Payment_Invalid()
        {
            var repAcommodation = new AcommodationRepository();
            var repFurniture = new FurnitureRepository();
            var payService = new PaymentService();

            var handler = new FurnitureReservationHandler(repFurniture, repAcommodation, payService);

            var user = new User("Matheus barbosa", "mathvierabarbosa@gmail.com", new Adress("Rua x", "123", "SÃO PAULO"));
            var furniture = new Furniture("Descriçao", new Adress("Rua y", "321", "SÃO PAULO"));

            var payment = new Payment(500, 200);

            var commandRequest = new FurnitureReservationRequest() { User = user, Furniture = furniture, Payment = payment, Checkin = DateTime.Now, Checkout = DateTime.Now.AddDays(3) };
            var res = handler.Handle(commandRequest, new System.Threading.CancellationToken());


            Assert.True(handler.Invalid);

        }
        [Fact]
        public void Handler_Should_Be_Invalid_When_Email_Is_Null()
        {
            var repAcommodation = new AcommodationRepository();
            var repFurniture = new FurnitureRepository();
            var payService = new PaymentService();

            var handler = new FurnitureReservationHandler(repFurniture, repAcommodation, payService);

            var user = new User("Matheus barbosa", "", new Adress("Rua x", "123", "SÃO PAULO"));
            var furniture = new Furniture("Descriçao", new Adress("Rua y", "321", "SÃO PAULO"));

            var payment = new Payment(500, 500);

            var commandRequest = new FurnitureReservationRequest() { User = user, Furniture = furniture, Payment = payment,Checkin= DateTime.Now, Checkout = DateTime.Now.AddDays(3) };
            var res = handler.Handle(commandRequest, new System.Threading.CancellationToken());

            Assert.True(handler.Invalid);

        }
        [Fact]
        public void Handler_Should_Be_Invalid_When_Email_Is_NotEmail()
        {
            var repAcommodation = new AcommodationRepository();
            var repFurniture = new FurnitureRepository();
            var payService = new PaymentService();

            var handler = new FurnitureReservationHandler(repFurniture, repAcommodation, payService);

            var user = new User("Matheus barbosa", "notemail", new Adress("Rua x", "123", "SÃO PAULO"));
            var furniture = new Furniture("Descriçao", new Adress("Rua y", "321", "SÃO PAULO"));

            var payment = new Payment(500, 500);

            var commandRequest = new FurnitureReservationRequest() { User = user, Furniture = furniture, Payment = payment, Checkin = DateTime.Now, Checkout = DateTime.Now.AddDays(3) };
            var res = handler.Handle(commandRequest, new System.Threading.CancellationToken());

            Assert.True(handler.Invalid);

        }
        [Fact]
        public void Handler_Should_Be_Invalid_When_Checks_Is_Invalid()
        {
            var repAcommodation = new AcommodationRepository();
            var repFurniture = new FurnitureRepository();
            var payService = new PaymentService();

            var handler = new FurnitureReservationHandler(repFurniture, repAcommodation, payService);

            var user = new User("Matheus barbosa", "mathvierabarbosa@gmail.com", new Adress("Rua x", "123", "SÃO PAULO"));
            var furniture = new Furniture("Descriçao", new Adress("Rua y", "321", "SÃO PAULO"));

            var payment = new Payment(500, 500);

            var commandRequest = new FurnitureReservationRequest() { User = user, Furniture = furniture, Payment = payment, Checkin = DateTime.Now.AddDays(-2), Checkout = DateTime.Now.AddDays(2) };
            var res = handler.Handle(commandRequest, new System.Threading.CancellationToken());

            Assert.True(handler.Invalid);

        }

        [Fact]
        public void Handler_Should_Be_Invalid_When_Payment_Is_Invalid()
        {
            
            var repAcommodation = new AcommodationRepository();
            var repFurniture = new FurnitureRepository();
            var payService = new PaymentService();

            payService.throwException = true;

            var handler = new FurnitureReservationHandler(repFurniture, repAcommodation, payService);

            var user = new User("Matheus barbosa", "mathvierabarbosa@gmail.com", new Adress("Rua x", "123", "SÃO PAULO"));
            var furniture = new Furniture("Descriçao", new Adress("Rua y", "321", "SÃO PAULO"));

            var payment = new Payment(500, 500);

            var commandRequest = new FurnitureReservationRequest() { User = user, Furniture = furniture, Payment = payment, Checkin = DateTime.Now, Checkout = DateTime.Now.AddDays(3) };
            var res = handler.Handle(commandRequest, new System.Threading.CancellationToken());

            Assert.True(handler.Invalid);

        }
        [Fact]
        public void Debugger_Test_for_see_notifications()
        {

            var repAcommodation = new AcommodationRepository();            
            var repFurniture = new FurnitureRepository();

            repFurniture.throwException = true;

            var payService = new PaymentService();

            var handler = new FurnitureReservationHandler(repFurniture, repAcommodation, payService);

            var user = new User("Matheus", "mathvierabarbosa@gmail.com", new Adress("Rua x", "123", "SÃO PAULO"));
            var furniture = new Furniture(" descriçao", new Adress("Rua y", "321", "SÃO PAULO"));

            var payment = new Payment(500, 500);

            var commandRequest = new FurnitureReservationRequest() { User = user, Furniture = furniture, Payment = payment, Checkin = DateTime.Now, Checkout = DateTime.Now.AddDays(3) };
            var res = handler.Handle(commandRequest, new System.Threading.CancellationToken());

            Assert.True(handler.Invalid);

        }
    }
}
