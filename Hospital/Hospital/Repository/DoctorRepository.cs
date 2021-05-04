using System;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Hospital.Repository
{
    public class DoctorRepository
    {
        OracleConnection connection = null;
        RoomRepository roomRepository = new RoomRepository();
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
                Trace.WriteLine(exp.ToString());
            }
        }
        public Doctor GetDoctorById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR,SPECIALIZATION WHERE DOCTOR.ID = :id AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID AND DOCTOR.SPEC_ID = SPECIALIZATION.ID";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            User doctorUser = new User();
            doctorUser.Id = int.Parse(reader.GetString(0));
            doctorUser.Username = reader.GetString(1);
            doctorUser.Password = reader.GetString(2);
            doctorUser.Name = reader.GetString(3);
            doctorUser.Surname = reader.GetString(4);
            doctorUser.PhoneNumber = reader.GetString(5);
            doctorUser.EMail = reader.GetString(6);
            int dId = reader.GetInt32(7);
            int salary = reader.GetInt32(8);
            int yearsOfService = reader.GetInt32(9);
            int roleId = reader.GetInt32(11);
            Role role = new Role();
            role.Id = roleId;
            role.RoleType = "DOCTOR";
            Doctor doctor = new Doctor(dId, salary, yearsOfService, doctorUser, role);
            doctor.Id = reader.GetInt32(12);
            Room room = new Room();
            doctor.room = room;
            doctor.room.Id = reader.GetInt32(14);
            Specialization specialization = new Specialization();
            doctor.specialization = specialization;
            doctor.specialization.Type = reader.GetString(17);
            connection.Close();
            return doctor;

            
        }

        public Doctor GetWorkHoursDoctorById(int id)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR WHERE DOCTOR.ID = :id AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            User docUser = new User();
            docUser.Id = int.Parse(reader.GetString(0));
            docUser.Username = reader.GetString(1);
            docUser.Password = reader.GetString(2);
            docUser.Name = reader.GetString(3);
            docUser.Surname = reader.GetString(4);
            docUser.PhoneNumber = reader.GetString(5);
            docUser.EMail = reader.GetString(6);
            int doctorId = reader.GetInt32(7);
            int salary = reader.GetInt32(8);
            int yearsOfService = reader.GetInt32(9);
            int roleId = reader.GetInt32(11);
            Role role = new Role();
            role.Id = roleId;
            role.RoleType = "DOCTOR";
            Doctor doctor = new Doctor(doctorId, salary, yearsOfService, docUser, role);
            doctor.Id = reader.GetInt32(12);
            Room room = new Room();
            doctor.room = room;
            doctor.room.Id = reader.GetInt32(14);
            connection.Close();
            return doctor;
        }

        public ObservableCollection<Doctor> GetAllGeneralPurposeDoctors()
        {
            setConnection();
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR WHERE DOCTOR.SPEC_ID = 1 AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User doctorUser = new User();
                doctorUser.Id = int.Parse(reader.GetString(0));
                doctorUser.Username = reader.GetString(1);
                doctorUser.Password = reader.GetString(2);
                doctorUser.Name = reader.GetString(3);
                doctorUser.Surname = reader.GetString(4);
                doctorUser.PhoneNumber = reader.GetString(5);
                doctorUser.EMail = reader.GetString(6);
                int doctorId = reader.GetInt32(7);
                int salary = reader.GetInt32(8);
                int yearsOfService = reader.GetInt32(9);
                int roleId = reader.GetInt32(11);
                Role role = new Role();
                role.Id = roleId;
                role.RoleType = "DOCTOR";
                Doctor doctor = new Doctor(doctorId, salary, yearsOfService, doctorUser, role);
                doctor.Id = reader.GetInt32(12);
                Room room = new Room();
                doctor.room = room;
                doctor.room.Id = reader.GetInt32(14);
                
                int specializationId = reader.GetInt32(15);
                doctors.Add(doctor);

            }
            connection.Close();
            return doctors;
        }

        public Doctor GetAppointmentDoctorById(int id)
        {
            setConnection();
            User doctorUser = new User();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR WHERE DOCTOR.ID =" + id + "AND USERS.ID = EMPLOYEE.USER_ID AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID";


            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            doctorUser.Id = int.Parse(reader.GetString(0));
            doctorUser.Username = reader.GetString(1);
            doctorUser.Password = reader.GetString(2);
            doctorUser.Name = reader.GetString(3);
            doctorUser.Surname = reader.GetString(4);
            doctorUser.PhoneNumber = reader.GetString(5);
            doctorUser.EMail = reader.GetString(6);
            int doctorId = reader.GetInt32(7);
            int salary = reader.GetInt32(8);
            int yearsOfService = reader.GetInt32(9);
            int roleId = reader.GetInt32(10);
            Role role = new Role();
            role.Id = roleId;
            role.RoleType = "DOCTOR";
            Doctor doctor = new Doctor(doctorId, salary, yearsOfService, doctorUser, role);
            doctor.Id = id;
            doctor.User = doctorUser;
            int roomdoc = reader.GetInt32(14);
            int specializationcId = reader.GetInt32(15);
            connection.Close();
            return doctor;
        }

        public ObservableCollection<Doctor> GetAllDoctors()
        {
            setConnection();
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DOCTOR";
            OracleDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Doctor doctor = GetDoctorById(reader.GetInt32(0));
                doctors.Add(doctor);
            }
            return doctors;
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

        public Doctor UpdateDoctor(Doctor doctor)
        {
            // TODO: implement
            return null;
        }

        public Doctor NewDoctor(Doctor doctor)
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