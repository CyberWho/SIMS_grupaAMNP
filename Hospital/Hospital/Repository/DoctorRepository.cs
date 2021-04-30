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
        OracleConnection connection = null;
        private OracleCommand command;
        private OracleDataReader reader;
        RoomRepository roomRepository = new RoomRepository();
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            connection = new OracleConnection(conString);
            try
            {
                connection.Open();
                command = connection.CreateCommand();
            }
            catch (Exception exp)
            {

            }
        }
        public Doctor GetDoctorById(int id)
        {
            // TODO: implement
            return null;
        }

        public Doctor GetWorkHoursDoctorById(int id)
        {
            setConnection();
            command.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR WHERE DOCTOR.ID = :id AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            reader = command.ExecuteReader();
            reader.Read();
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
            connection.Close();
            return doctor;
        }

        public ObservableCollection<Doctor> GetAllGeneralPurposeDoctors()
        {
            setConnection();
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR WHERE DOCTOR.SPEC_ID = 1 AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
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
            connection.Close();
            return doctors;
        }

        public Doctor GetAppointmentDoctorById(int id)
        {
            setConnection();
            User docUser = new User();
            OracleCommand cmd1 = connection.CreateCommand();
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
            connection.Close();
            return doctor;
        }

        public System.Collections.ArrayList GetAllDoctors()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Doctor> GetAllDoctorsBySpecializationId(int specializationId)
        {
            setConnection();
            command.CommandText = "SELECT * FROM doctor WHERE spec_id = " + specializationId;
            reader = command.ExecuteReader();

            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();

            while (reader.Read())
            {
                int id = int.Parse(reader.GetString(0));
                int employee_id = int.Parse(reader.GetString(1));
                int room_id = int.Parse(reader.GetString(2));
                
                Doctor doctor = new
                    Doctor(
                        id, 
                        employee_id, 
                        room_id,
                        specializationId
                    );

                doctors.Add(doctor);
            }

            return doctors;
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