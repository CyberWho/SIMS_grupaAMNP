/***********************************************************************
 * Module:  CityRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.CityRepository
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Hospital.IRepository;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.Repository
{
    public class CityRepository : ICityRepo<City>
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
                Trace.WriteLine(exp.ToString());
            }
        }

        public City GetById(int id)
        {
            setConnection();
            City city = new City();
            OracleCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM CITY WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            city.Id = id;
            city.Name = reader.GetString(1);
            city.PostalCode = reader.GetString(2);

            int state_id = int.Parse(reader.GetString(3));

            con.Close();
            city.State = new StateRepository().GetById(state_id);
            return city;
        }
        
      
      public City Add(City city)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<City> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public City Update(City t)
        {
            throw new NotImplementedException();
        }
    }
}