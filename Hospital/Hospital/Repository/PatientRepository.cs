/***********************************************************************
 * Module:  PatientRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.PatientRepository
 ***********************************************************************/

using System;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
   public class PatientRepository
   {
        OracleConnection con = null;
        AddressRepository addressRepository = new AddressRepository();

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

        public Hospital.Model.Patient GetPatientById(int id)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM USERS,PATIENT WHERE USERS.ID = :id AND USERS.ID = PATIENT.USER_ID";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            User user = new User();
            user.Id = int.Parse(reader.GetString(0));
            user.Username = reader.GetString(1);
            user.Password = reader.GetString(2);
            user.Name = reader.GetString(3);
            user.Surname = reader.GetString(4);
            user.PhoneNumber = reader.GetString(5);
            user.EMail = reader.GetString(6);

            Patient patient = new Patient();
            patient.User = user;
            patient.Id = int.Parse(reader.GetString(7));
            patient.JMBG = reader.GetString(8);
            patient.DateOfBirth = reader.GetDateTime(9);
            int addressId = reader.GetInt32(10);
            
            //Address address = addressRepository.GetAddressById(addressId);
            //patient.Address = address;
            con.Close();
            return patient;

        }
        public Hospital.Model.Patient GetPatientByUserId(int id)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM USERS,PATIENT WHERE USERS.ID = :id AND USERS.ID = PATIENT.USER_ID";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            User user = new User();
            user.Id = int.Parse(reader.GetString(0));
            user.Username = reader.GetString(1);
            user.Password = reader.GetString(2);
            user.Name = reader.GetString(3);
            user.Surname = reader.GetString(4);
            user.PhoneNumber = reader.GetString(5);
            user.EMail = reader.GetString(6);

            Patient patient = new Patient();
            patient.User = user;
            patient.Id = int.Parse(reader.GetString(7));
            patient.JMBG = reader.GetString(8);
            patient.DateOfBirth = reader.GetDateTime(9);
            int addressId = reader.GetInt32(10);
            
            Address address = addressRepository.GetAddressById(addressId);
            /*cmd.CommandText = "SELECT * FROM address, city, state WHERE address.id = " + id + " AND address.CITY_ID = city.ID AND city.STATE_ID = state.ID";
            reader = cmd.ExecuteReader();
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
            };*/
            patient.Address = address;
            con.Close();
            return patient;
           
      }
      
      public System.Collections.ArrayList GetAllPatients()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllPatientsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeletePatientById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Patient UpdatePatient(Hospital.Model.Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Patient NewPatient(Hospital.Model.Patient patient)
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