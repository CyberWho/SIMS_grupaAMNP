/***********************************************************************
 * Module:  DoctorRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.DoctorRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using Hospital.Model;

namespace Hospital.Repository
{
   public class DoctorRepository
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
        public Hospital.Model.Doctor GetDoctorById(int id)
      {
         // TODO: implement
         return null;
      }

        public Doctor GetAppointmentDoctorById(int id)
        {
            setConnection();
            User docUser = new User();
            OracleCommand cmd1 = con.CreateCommand();
            cmd1.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR WHERE DOCTOR.ID =" + id;

            
            OracleDataReader a = cmd1.ExecuteReader();
            a.Read();
            docUser.Id = int.Parse(a.GetString(0));
            docUser.Username = a.GetString(1);
            docUser.Password = a.GetString(2);
            docUser.Name = a.GetString(3);
            docUser.Surname = a.GetString(4);
            docUser.PhoneNumber = a.GetString(5);
            docUser.EMail = a.GetString(6);
            int dId = a.GetInt32(7);
            int salary = a.GetInt32(8);
            int yearsOfService = a.GetInt32(9);
            int roleId = a.GetInt32(10);
            Role role = new Role();
            role.Id = roleId;
            role.RoleType = "DOCTOR";
            Doctor doctor = new Doctor(dId, salary, yearsOfService, docUser, role);
            doctor.Id = id;
            
            int roomdoc = a.GetInt32(12);
            int specId = a.GetInt32(13);
            con.Close();
            return doctor;
        }
      
      public System.Collections.ArrayList GetAllDoctors()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllDoctorsBySpecializationId(int specializationId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteDoctorById(int doctorId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Doctor UpdateDoctor(Hospital.Model.Doctor doctor)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Doctor NewDoctor(Hospital.Model.Doctor doctor)
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