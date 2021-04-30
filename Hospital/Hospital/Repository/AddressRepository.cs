/***********************************************************************
 * Module:  AddressRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AddressRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;

namespace Hospital.Repository
{
    public class AddressRepository
    {
        
        CityRepository cityRepository = new CityRepository();

        OracleConnection connection = null;
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            connection = new OracleConnection(conString);
            try
            {
                connection.Open();

            }
            catch (Exception exp)
            {

            }
        }


        public Address GetAddressByPatientId(int id)
        {
            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT address_id FROM patient WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            return this.GetAddressById(int.Parse(reader.GetString(0)));
        }

        public Address GetAddressById(int id)
        {
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM address WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            Address address = new Address
            {
                Id = int.Parse(reader.GetString(0)),
                Name = reader.GetString(1),
                city_id = int.Parse(reader.GetString(2)),
                City = cityRepository.GetCityById(reader.GetInt32(2))
            };

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