using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using Hospital.IRepository;

namespace Hospital.Repository
{
    public class DoctorRepository : IDoctorRepo<Doctor>
    {
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
                Trace.WriteLine(exp.ToString());
            }
        }
        public Doctor GetById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DOCTOR WHERE DOCTOR.ID = :userId";
            command.Parameters.Add("userId", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            var doctor = ParseDoctor(reader);

            connection.Close();
            connection.Dispose();
           
            return doctor;

            
        }

        public Hospital.Model.Doctor GetByUserId(int userId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM USERS,EMPLOYEE,DOCTOR,SPECIALIZATION WHERE USERS.ID = :userId AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID AND DOCTOR.SPEC_ID = SPECIALIZATION.ID";
            command.Parameters.Add("userId", OracleDbType.Int32).Value = userId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            User doctorUser = new UserRepository().GetById(reader.GetInt32(0));
            Employee employee = new EmployeesRepository().GetById(reader.GetInt32(7));
            Specialization specialization = new SpecializationRepository().GetById(reader.GetInt32(15));
            Doctor doctor = new Doctor(employee.Id,employee.Salary,employee.YearsOfService,doctorUser,employee.role,specialization);
            doctor.User = doctorUser;
            doctor.role = employee.role;
            doctor.specialization = specialization;
            doctor.Id = reader.GetInt32(12);
            connection.Close();
            return doctor;


        }

        private static Doctor ParseDoctor(OracleDataReader reader)
        {
           Employee employee = new EmployeesRepository().GetById(reader.GetInt32(1));
           Room room = new RoomRepository().GetRoomById(reader.GetInt32(2));
           Specialization specialization = new SpecializationRepository().GetById(reader.GetInt32(3));
           Doctor doctor = new Doctor(employee.Id,employee.Salary,employee.YearsOfService,employee.User,employee.role,specialization,room);
           doctor.Id = reader.GetInt32(0);
           return doctor;
        }


        public Doctor GetWorkHoursDoctorById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DOCTOR WHERE DOCTOR.ID = :userId";
            command.Parameters.Add("userId", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            var doctor = ParseDoctor(reader);
            connection.Close();
            connection.Dispose();
            
            return doctor;
        }

        public ObservableCollection<Doctor> GetAllGeneralPurposeDoctors()
        {
            setConnection();
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DOCTOR WHERE DOCTOR.SPEC_ID = 1";
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var doctor = ParseDoctor(reader);
                doctors.Add(doctor);
            }

            connection.Close();
            connection.Dispose();
            
            return doctors;
        }

       

        public Doctor GetAppointmentDoctorById(int id)
        {
            setConnection();
            User doctorUser = new User();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DOCTOR WHERE DOCTOR.ID =" + id;


            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            var doctor = ParseDoctor(reader);

            connection.Close();
            connection.Dispose();
            return doctor;
        }

        public ObservableCollection<Doctor> GetAll()
        {
            setConnection();
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DOCTOR";
            OracleDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Doctor doctor = ParseDoctor(reader);
                
                
                doctors.Add(doctor);
            }
            connection.Close();
            connection.Dispose();
            
            return doctors;
        }

        public ObservableCollection<Doctor> GetAllBySpecializationId(int specializationId)
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

        public Boolean DeleteById(int doctorId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM doctor WHERE userId = " + doctorId;

            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                connection.Dispose();

                return true;
            }
            connection.Close();
            connection.Dispose();

            return false;
        }

        public Doctor Update(Doctor doctor)
        {


            return null;
        }

        public ObservableCollection<Doctor> SearchByNameAndSurname(string identifyString)
        {
            setConnection();
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText =
                "SELECT * FROM DOCTOR,EMPLOYEE,USERS WHERE DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID and users.name like '%" + identifyString + "%' UNION SELECT * FROM DOCTOR,EMPLOYEE,USERS WHERE DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID and users.surname like '%" + identifyString +"%'";

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var doctor = GetById(reader.GetInt32(0));
                doctors.Add(doctor);
            }
            
            connection.Close();
            return doctors;

        }

        #region marko_kt5
        public Doctor NewDoctor(Doctor doctor)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO doctor (userId, employee_id, room_id, spec_id)  VALUES (:userId, :employee_id, :room_id, :spec_id)";

            int id = GetLastId() + 1;

            doctor.Id = id;

            command.Parameters.Add("userId", OracleDbType.Int32).Value = doctor.Id;
            command.Parameters.Add("employee_id", OracleDbType.Int32).Value = doctor.employee_id;
            command.Parameters.Add("room_id", OracleDbType.Int32).Value = doctor.room_id;
            command.Parameters.Add("spec_id", OracleDbType.Int32).Value = doctor.specialization_id;

            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                connection.Dispose();

                return doctor;
            }

            connection.Close();
            connection.Dispose();

            return null;
        }
        #endregion
        //nikad nije referencirano
        /*    private Doctor getAllData(Doctor doctor)
        {
            if (doctor.specialization_id == 0) doctor.specialization_id = doctor.specialization.userId;
            else if (doctor.specialization == null) doctor.specialization.userId = doctor.specialization_id;

            if (doctor.room_id == 0) doctor.room_id = (int)doctor.room.Id;


            return doctor;
        }*/

        // marko kt5
        public List<int> GetAllUsedRoomsId()
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT room_id FROM doctor";
            OracleDataReader reader = command.ExecuteReader();

            List<int> usedRooms = new List<int>();

            while (reader.Read())
            {
                usedRooms.Add(int.Parse(reader.GetString(0)));
            }

            return usedRooms;
        }

        public int GetLastId()
        {
            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(userId) FROM doctor";
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int last_id = int.Parse(reader.GetString(0));

            connection.Close();
            connection.Dispose();

            return last_id;
        }

        public Doctor Add(Doctor t)
        {
            throw new NotImplementedException();
        }

    }
}