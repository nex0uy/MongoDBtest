using System.Text.Json;
using _4__Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace _3__DataAccess;

public class DataAccess
{
    private IMongoClient _client;
    private IMongoDatabase _database;
    private IMongoCollection<Persona> _collection;

    public DataAccess()
    {
        _client = new MongoClient("mongodb://practico-bd:xrouOGofCBHCUfBATEixUVgvwfm4RhtST5tEjKsKR9PDmmjXrfIAQ1HDLflpmPhYzIzsYGgatCBFACDbXA2CuA%3D%3D@practico-bd.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@practico-bd@");
        _database = _client.GetDatabase("bd_2023");
        _collection = _database.GetCollection<Persona>("personas_C_Gonzalez");
    }

    public List<Persona> GetAll()
    { 
        return _collection.Find(new BsonDocument()).ToList(); ;
    }

    public bool ExistsByCedula(string cedula)
    {
        var filter = Builders<Persona>.Filter.Eq("cedula", cedula);
        return _collection.Find(filter).Any();
    }

    public List<Persona> GetByRole(string role)
    {
        var filter = Builders<Persona>.Filter.Eq("rol", role);
        var personas = _collection.Find(filter).ToList();
        return personas.Count > 0 ? personas : null;
    }


    public string? GetRoleByCedula(string cedula)
    {
        var filter = Builders<Persona>.Filter.Eq("cedula", cedula);
        var persona = _collection.Find(filter).FirstOrDefault();

        return persona != null ? persona.rol : null;
    }

    public void UpdateRole(string cedula, string newRole)
    {
        var filter = Builders<Persona>.Filter.Eq("cedula", cedula);
        var update = Builders<Persona>.Update.Set("rol", newRole);

        _collection.UpdateOne(filter, update);
    }

    public void DeleteByCedula(string cedula)
    {
        var filter = Builders<Persona>.Filter.Eq("cedula", cedula);
        _collection.DeleteOne(filter);
    }

}


