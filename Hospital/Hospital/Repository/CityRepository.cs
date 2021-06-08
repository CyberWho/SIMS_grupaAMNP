/***********************************************************************
 * Module:  CityRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.CityRepository
 ***********************************************************************/

using System;
using System.Diagnostics;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.Repository
{
    public class CityRepository
    {
        public City GetCityById(int id)
        {
            
            City city = new City();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM CITY WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            city.Id = id;
            city.Name = reader.GetString(1);
            city.PostalCode = reader.GetString(2);

            int state_id = int.Parse(reader.GetString(3));

            city.State = new StateRepository().GetStateById(state_id);
            return city;
        }

        public City GetCityByName(String name)
        {
            // TODO: implement
            return null;
        }

        public City NewCity(City city)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAll()
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllByStateId()
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}