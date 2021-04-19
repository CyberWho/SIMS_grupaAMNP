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
using System.Collections.ObjectModel;
using Hospital.Repository;

namespace Hospital.Repository
{
   public class DoctorRepository
   {
        OracleConnection con = null;
        RoomRepository roomRepository = new RoomRepository();
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

        public ObservableCollection<Doctor> GetAllGeneralPurposeDoctors()
        {
            setConnection();
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR WHERE DOCTOR.SPEC_ID = 1 AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            OracleDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                User docUser = new User();
                docUser.Id = int.Parse(reader.GetString(0));
                docUser.Username = reader.GetString(1);
                docUser.Password = reader.GetString(2);
                docUser.Name = reader.GetString(3);
                docUser.Surname = reader.GetString(4);
                docUser.PhoneNumber = reader.GetString(5);
                docUser.EMail = reader.GetString(6);
                int dId = reader.GetInt32(7);
                int salary = reader.GetInt32(8);
                int yearsOfService = reader.GetInt32(9);
                int roleId = reader.GetInt32(11);
                Role role = new Role();
                role.Id = roleId;
                role.RoleType = "DOCTOR";
                Doctor doctor = new Doctor(dId, salary, yearsOfService, docUser, role);
                doctor.Id = reader.GetInt32(12);
                Room room = new Room();
                doctor.room = room;
                doctor.room.Id = reader.GetInt32(14);
                /*int roomdoc = reader.GetInt32(14);
                Room room = new Room();
                room = roomRepository.GetRoomById(roomdoc);

                doctor.room = room;*/
                int specId = reader.GetInt32(15);
                doctors.Add(doctor);

            }
            con.Close();
            return doctors;
        }

        public Doctor GetAppointmentDoctorById(int id)
        {
            setConnection();
            User docUser = new User();
            OracleCommand cmd1 = con.CreateCommand();
            cmd1.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR WHERE DOCTOR.ID =" + id + "AND USERS.ID = EMPLOYEE.USER_ID AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID";

            
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
            
            int roomdoc = a.GetInt32(14);
            int specId = a.GetInt32(15);
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