/***********************************************************************
 * Module:  AddressRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AddressRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using Hospital.Model;

namespace Hospital.Repository
{
   public class AddressRepository
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

        public Hospital.Model.Address GetAddressById(int id)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM address, city, state WHERE address.id = " + id + " AND address.CITY_ID = city.ID AND city.STATE_ID = state.ID";
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            State state = new State
            {
                Id = int.Parse(reader.GetString(8)),
                Name = reader.GetString(9)
            };

            City city = new City
            {
                Id = int.Parse(reader.GetString(4)),
                Name = reader.GetString(5),
                PostalCode = reader.GetString(6),
                State = state
            };

            Address address = new Address
            {
                Id = int.Parse(reader.GetString(0)),
                Name = reader.GetString(1),

                City = city
            };
            con.Close();
            return address;
      }
      
      public Boolean DeleteAddressById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Address UpdateAddress(Hospital.Model.Address address)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Address NewAddress(Hospital.Model.Address address)
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