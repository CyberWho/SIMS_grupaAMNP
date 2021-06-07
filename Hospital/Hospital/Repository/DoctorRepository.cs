using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;

namespace Hospital.Repository
{
    public class DoctorRepository
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
        public Doctor GetDoctorById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DOCTOR WHERE DOCTOR.ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            var doctor = ParseDoctor(reader);

            connection.Close();
            connection.Dispose();
           
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
            User doctorUser = new UserRepository().GetById(reader.GetInt32(0));
            Employee employee = new EmployeesRepository().GetEmployeeById(reader.GetInt32(7));
            Specialization specialization = new SpecializationRepository().GetSpecializationById(reader.GetInt32(15));
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
           Employee employee = new EmployeesRepository().GetEmployeeById(reader.GetInt32(1));
           Room room = new RoomRepository().GetRoomById(reader.GetInt32(2));
           Specialization specialization = new SpecializationRepository().GetSpecializationById(reader.GetInt32(3));
           Doctor doctor = new Doctor(employee.Id,employee.Salary,employee.YearsOfService,employee.User,employee.role,specialization,room);
           doctor.Id = reader.GetInt32(0);
           return doctor;
        }


        public Doctor GetWorkHoursDoctorById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM DOCTOR WHERE DOCTOR.ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
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

        public ObservableCollection<Doctor> GetAllDoctors()
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
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM doctor WHERE id = " + doctorId;

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

        public Doctor UpdateDoctor(Doctor doctor)
        {


            return null;
        }

        public ObservableCollection<Doctor> SearchDoctorByNameAndSurname(string identifyString)
        {
            setConnection();
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText =
                "SELECT * FROM DOCTOR,EMPLOYEE,USERS WHERE DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID and users.name like '%" + identifyString + "%' UNION SELECT * FROM DOCTOR,EMPLOYEE,USERS WHERE DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID and users.surname like '%" + identifyString +"%'";

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var doctor = GetDoctorById(reader.GetInt32(0));
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
            command.CommandText = "INSERT INTO doctor (id, employee_id, room_id, spec_id)  VALUES (:id, :employee_id, :room_id, :spec_id)";

            int id = GetLastId() + 1;

            doctor.Id = id;

            command.Parameters.Add("id", OracleDbType.Int32).Value = doctor.Id;
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

        private Doctor getAllData(Doctor doctor)
        {
            if (doctor.specialization_id == 0) doctor.specialization_id = doctor.specialization.id;
            else if (doctor.specialization == null) doctor.specialization.id = doctor.specialization_id;

            if (doctor.room_id == 0) doctor.room_id = doctor.room.Id;


            return doctor;
        }

        // marko kt5
        public List<int> getAllUsedRoomsId()
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
            command.CommandText = "SELECT MAX(id) FROM doctor";
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int last_id = int.Parse(reader.GetString(0));

            connection.Close();
            connection.Dispose();

            return last_id;
        }

    }
}