using FluentValidator;
using FluentValidator.Validation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Entities
{
    public class Entity:IContract
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public ValidationContract Contract { get; set; }

        public Entity()
        {
            id = ObjectId.GenerateNewId().ToString();
        }
    }
}
