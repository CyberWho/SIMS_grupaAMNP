/***********************************************************************
 * Module:  CityRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.CityRepository
 ***********************************************************************/

using System;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;

namespace Hospital.Repository
{
   public class CityRepository
   {
        OracleConnection con = null;
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            con = new OracleConnection(conString);
            try
            {
                con.Open();

            }
            catch (Exception exp)
            {

            }
        }

        public Hospital.Model.City GetCityById(int id)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM CITY WHERE ID = :id";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            City city = new City();
            city.Id = id;
            city.Name = reader.GetString(1);
            city.PostalCode = reader.GetString(2);
            city.State.Id = reader.GetInt32(3);
            con.Close();
            return city;
        }
      
      public Hospital.Model.City GetCityByName(String name)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.City NewCity(Hospital.Model.City city)
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