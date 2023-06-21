namespace _2__BusinessLogic;

using System;
using System.Collections.Generic;
using System.Text.Json;
using _3__DataAccess;
using _4__Models;
using MongoDB.Bson;

public class BusinessLogic
{
    private DataAccess _dataAccess;

    public BusinessLogic()
    {
        _dataAccess = new DataAccess();
    }

    public List<Persona> GetPersonas()
    {
        return _dataAccess.GetAll();
    }

    public bool ExistsPersonaByCedula(string cedula)
    {
        return _dataAccess.ExistsByCedula(cedula);
    }

    public List<Persona> GetPersonasByRole(string role)
    {
        return _dataAccess.GetByRole(role);
    }


    public string? GetRoleByCedula(string cedula)
    {
        return _dataAccess.GetRoleByCedula(cedula);
    }

    public void ChangeRole(string cedula, string newRole)
    {
        _dataAccess.UpdateRole(cedula, newRole);
    }

    public void DeletePersonaByCedula(string cedula)
    {
        _dataAccess.DeleteByCedula(cedula);
    }


}



