/***********************************************************************
 * Module:  AddressRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AddressRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Diagnostics;

namespace Hospital.Repository
{
    public class AddressRepository
    {

        private CityRepository cityRepository = new CityRepository();


        public Address GetAddressByPatientId(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT address_id FROM patient WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int addressId = reader.GetInt32(0);
            var address = GetAddressById(addressId);
            return address;
        }

        public Address GetAddressById(int id)
        {
            

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM address WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            var address = new Address();
            address.Id = int.Parse(reader.GetString(0));
            address.Name = reader.GetString(1);
            address.city_id = int.Parse(reader.GetString(3));

            int city_id = reader.GetInt32(3);
            address.City = cityRepository.GetCityById(city_id);



            return address;
        }

        //Otvara drugu konekciju dok predhodna nije bila zatvorena
        private Address ParseAddress(OracleDataReader reader)
        {
            Address address = new Address
            {
                Id = int.Parse(reader.GetString(0)),
                Name = reader.GetString(1),
                city_id = int.Parse(reader.GetString(3)),
                City = cityRepository.GetCityById(reader.GetInt32(3))
            };
            return address;
        }

        public Boolean DeleteAddressById(int id)
        {
            // TODO: implement
            return false;
        }

        public Address UpdateAddress(Address address)
        {
            // TODO: implement
            return null;
        }

        public Address NewAddress(Address address)
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