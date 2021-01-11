using Domain.ValueObjects;
using FluentValidator.Validation;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User:Entity
    {
        protected User()
        {

        }
        public User(string name, string email, Adress adress)
        {
            Name = name;
            Email = email;
            Adress = adress;

            Contract  = new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Name,"User Name","User name is null or empty")
                .IsNotNullOrEmpty(Email,"User email","User email is null or empty")
                .IsEmail(Email, "User email", "User email is not valid")
            ;            
            Contract.AddNotifications(Adress);

        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public Adress Adress { get; private set; }
    }
}
