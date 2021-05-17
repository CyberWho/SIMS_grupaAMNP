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
        private RoomRepository roomRepository = new RoomRepository();
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
            var doctor = ParseDoctor(reader);

            connection.Close();
           
            return doctor;

            
        }

        public Hospital.Model.Doctor GetDoctorByUserId(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR,SPECIALIZATION WHERE USERS.ID = :id AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID AND DOCTOR.SPEC_ID = SPECIALIZATION.ID";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            var doctor = ParseDoctor(reader);
            connection.Close();
            return doctor;


        }

        private static Doctor ParseDoctor(OracleDataReader reader)
        {
            User doctorUser = new User(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6));
            Role role = new Role(reader.GetInt32(11),"DOCTOR");
            Doctor doctor = new Doctor(reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9), doctorUser, role);
            doctor.Id = reader.GetInt32(12);
            Room room = new RoomRepository().GetRoomById(reader.GetInt32(14));
            doctor.room = room;
            Specialization specialization = new Specialization(reader.GetInt32(15),reader.GetString(17));
            doctor.specialization = specialization;
            doctor.employee_id = reader.GetInt32(7);
            doctor.room_id = doctor.room.Id;
            doctor.specialization_id = doctor.specialization.id;
            return doctor;
        }

        public Doctor GetWorkHoursDoctorById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR WHERE DOCTOR.ID = :id AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            var doctor = ParseDoctorWithoutSpecialization(reader);
            connection.Close();
            connection.Dispose();
            
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
                var doctor = ParseDoctorWithoutSpecialization(reader);
                doctors.Add(doctor);
            }

            connection.Close();
            connection.Dispose();
            
            return doctors;
        }

        private Doctor ParseDoctorWithoutSpecialization(OracleDataReader reader)
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
            return doctor;
        }

        public Doctor GetAppointmentDoctorById(int id)
        {
            setConnection();
            User doctorUser = new User();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR WHERE DOCTOR.ID =" + id + "AND USERS.ID = EMPLOYEE.USER_ID AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID";


            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            var doctor = ParseDoctorWithoutSpecialization(reader);
            connection.Close();
            connection.Dispose();
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
                Doctor doctor = new Doctor();
                
                doctor.Id =   reader.GetInt32(0);
                doctors.Add(doctor);
            }
            connection.Close();
            connection.Dispose();
            for (int i = 0; i < doctors.Count; i++)
            {
                doctors[i] = GetDoctorById(doctors[i].Id);
            }
            return doctors;
        }

        public ObservableCollection<Doctor> GetAllDoctorsBySpecializationId(int specializationId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM doctor WHERE spec_id = " + specializationId;
            OracleDataReader reader = command.ExecuteReader();

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

            connection.Close();
            connection.Dispose();

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
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO doctor (id, employee_id, room_id, spec_id)  VALUES (:id, :employee_id, :room_id, :spec_id)";

            command.Parameters.Add("id", OracleDbType.Int32).Value = 5;
            command.Parameters.Add("employee_id", OracleDbType.Int32).Value = doctor.employee_id;
            command.Parameters.Add("room_id", OracleDbType.Int32).Value = doctor.room_id;
            command.Parameters.Add("spec_id", OracleDbType.Int32).Value = doctor.specialization_id;

            command.ExecuteNonQuery();


            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}