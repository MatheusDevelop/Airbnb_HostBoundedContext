using FluentValidator;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Entities
{
    public class Entity:Notifiable
    {
        
        [Key]
        public Guid id { get; set; }
        public Entity()
        {
            id = Guid.NewGuid();
        }
    }
}
