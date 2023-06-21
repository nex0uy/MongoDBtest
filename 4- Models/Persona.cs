namespace _4__Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

public class Persona
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string genero { get; set; }
    public string cedula { get; set; }
    public string rol { get; set; }
    public List<string> materias { get; set; }
}


