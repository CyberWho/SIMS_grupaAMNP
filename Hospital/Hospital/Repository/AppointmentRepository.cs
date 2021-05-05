/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AppointmentRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using Hospital.Model;
using System.Diagnostics;

namespace Hospital.Repository
{
    public class AppointmentRepository
    {
        RoomRepository roomRepository = new RoomRepository();
        PatientRepository patientRepository = new PatientRepository();
        DoctorRepository doctorRepository = new DoctorRepository();
        TimeSlotRepository timeSlotRepository = new TimeSlotRepository();
        SystemNotificationRepository systemNotificationRepository = new SystemNotificationRepository();
        private EmployeesRepository employeesRepository = new EmployeesRepository();
        private UserRepository userRepository = new UserRepository();


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

        public Appointment GetAppointmentByDoctorIdAndTime(Doctor doctor, DateTime time)
        {
            setConnection();

            // 4/21/2021 9:00:00 AM 2

            int doctor_id = doctor.Id;
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM appointment WHERE doctor_id = :doctor_id AND date_time = :date_time";
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctor_id;
            command.Parameters.Add("date_time", OracleDbType.Date).Value = time;

            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            int appointment_id = int.Parse(reader.GetString(0));

            connection.Close();
            connection.Dispose();

            return this.GetAppointmentById(appointment_id);
        }


        public Appointment GetAppointmentById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM APPOINTMENT WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            Appointment appointment = new Appointment();
            appointment.Id = reader.GetInt32(0);
            appointment.DurationInMinutes = reader.GetInt32(1);
            appointment.StartTime = reader.GetDateTime(2);
            int roomId = reader.GetInt32(3);
            int patientId = reader.GetInt32(4);
            int doctorId = reader.GetInt32(5);
            int apptypeid = reader.GetInt32(6);
            int appstatid = reader.GetInt32(7);

            switch (apptypeid)
            {
                case 0:
                    appointment.Type = AppointmentType.EXAMINATION;
                    break;
                case 1:
                    appointment.Type = AppointmentType.OPERATION;
                    break;
                case 2:
                    appointment.Type = AppointmentType.REFERRAL;
                    break;
            }

            switch (appstatid)
            {
                case 0:
                    appointment.Status = AppointmentStatus.FINISHED;
                    break;
                case 1:
                    appointment.Status = AppointmentStatus.RESERVED;
                    break;
                case 2:
                    appointment.Status = AppointmentStatus.DIDNTCOME;
                    break;
            }

            Room room = roomRepository.GetAppointmentRoomById(roomId);

            appointment.room = room;

            Patient patient = patientRepository.GetPatientById(patientId);
            appointment.patient = patient;

            Doctor doctor = doctorRepository.GetAppointmentDoctorById(doctorId);
            appointment.doctor = doctor;

            connection.Close();
            connection.Dispose();

            return appointment;
        }

        public ObservableCollection<Appointment> GetAllReservedAppointments()
        {
            setConnection();

            int id = (int)AppointmentStatus.RESERVED;

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM appointment WHERE appstat_id = " + id;
            OracleDataReader reader = command.ExecuteReader();

            connection.Close();
            connection.Dispose();

            return null;
        }

        public System.Collections.ArrayList GetAllReservedAppointmentsWeekly()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Appointment> GetAllAppointmentsByDoctorId(int doctorId)
        {
            ObservableCollection<Appointment> appointmnets = new ObservableCollection<Appointment>();

            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select * from appointment, patient where appointment.PATIENT_ID = patient.ID and doctor_id =" + doctorId;
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AppointmentType appointmentType = AppointmentType.EXAMINATION;
                AppointmentStatus appointmentStatus = AppointmentStatus.DIDNTCOME;
                switch (reader.GetInt32(6))
                {
                    case 1:
                        appointmentType = AppointmentType.EXAMINATION;
                        break;
                    case 2:
                        appointmentType = AppointmentType.OPERATION;
                        break;
                    case 3:
                        appointmentType = AppointmentType.REFERRAL;
                        break;
                }

                switch (reader.GetInt32(7))
                {
                    case 0:
                        appointmentStatus = AppointmentStatus.DIDNTCOME;
                        break;
                    case 1:
                        appointmentStatus = AppointmentStatus.FINISHED;
                        break;
                    case 2:
                        appointmentStatus = AppointmentStatus.RESERVED;
                        break;
                }
                int appointment_id = int.Parse(reader.GetString(0));
                int duration = int.Parse(reader.GetString(1));
                DateTime time = reader.GetDateTime(2);
                int doctor_id = int.Parse(reader.GetString(5));
                int patient_id = int.Parse(reader.GetString(4));
                int room_id = int.Parse(reader.GetString(3));
                Appointment ap = new Appointment(appointment_id, duration, time, appointmentType,
                   appointmentStatus, doctor_id, patient_id, room_id);
                appointmnets.Add(ap);
            }

            connection.Close();
            connection.Dispose();

            return appointmnets;
        }

        public ObservableCollection<Appointment> GetAllReservedAppointmentsByPatientId(int patientId)
        {
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM APPOINTMENT WHERE PATIENT_ID = :patient_id AND APPSTAT_ID = 1";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.Id = reader.GetInt32(0);
                appointment.DurationInMinutes = reader.GetInt32(1);
                appointment.StartTime = reader.GetDateTime(2);
                int roomId = reader.GetInt32(3);
                int patId = reader.GetInt32(4);
                int doctorId = reader.GetInt32(5);
                int apptypeid = reader.GetInt32(6);
                int appstatid = reader.GetInt32(7);
                if (apptypeid == 0)
                {
                    appointment.Type = AppointmentType.OPERATION;
                }
                else
                {
                    if (apptypeid == 1)
                    {
                        appointment.Type = AppointmentType.EXAMINATION;
                    }
                    else
                    {
                        appointment.Type = AppointmentType.REFERRAL;
                    }
                }
                appointment.Status = AppointmentStatus.RESERVED;

                Room room = new Room();
                room = roomRepository.GetAppointmentRoomById(roomId);

                appointment.room = room;
                Patient patient = new Patient();
                patient = patientRepository.GetPatientById(patientId);
                appointment.patient = patient;

                Doctor doctor = new Doctor();
                doctor = doctorRepository.GetAppointmentDoctorById(doctorId);
                appointment.doctor = doctor;
                appointments.Add(appointment);

            }

            connection.Close();
            connection.Dispose();

            return appointments;
        }

        public Boolean DeleteAppointmentById(int id)
        {
            Appointment appointment = new Appointment();
            appointment = GetAppointmentById(id);

            appointment.doctor.employee_id = employeesRepository.GetEmployeeByUserId(appointment.doctor.User.Id).Id;

            setConnection();
            OracleCommand command = connection.CreateCommand();

            for (int i = 0; i < appointment.DurationInMinutes / 30; i++)
            {
                TimeSlot timeSlot = new TimeSlot();
                timeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(
                    appointment.StartTime.AddMinutes(30 * i), appointment.doctor.Id);
                timeSlotRepository.FreeTimeSlot(timeSlot);
            }



            command.CommandText = "delete from appointment where id = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            if (command.ExecuteNonQuery() > 0)
            {
                NotifyPatient(appointment, "Obrisan termin");
                NotifyDoctor(appointment, "Obrisan termin");
                connection.Close();
                connection.Dispose();
                return true;
            }

            connection.Close();
            connection.Dispose();

            return false;
        }
        private void NotifyPatient(Appointment app, String Name)
        {
            SystemNotification systemNotification = new SystemNotification();
            systemNotification.user_id = app.patient.user_id;
            systemNotification.Name = Name;

            Employee employee = this.employeesRepository.GetEmployeeByUserId(app.doctor.User.Id);

            int doctor_user_id = this.employeesRepository.GetUserIdByEmployeeId(employee.Id);
            User doctorUser = this.userRepository.GetUserById(doctor_user_id);
            String desc = Name + " zakazan za: " + app.StartTime + " kod lekara " + doctorUser.Name + " " + doctorUser.Surname;
            systemNotification.Description = desc;

            this.systemNotificationRepository.NewSystemNotification(systemNotification);
        }
        private void NotifyDoctor(Appointment app, String Name)
        {
            SystemNotification systemNotification = new SystemNotification();
            int user_id = this.employeesRepository.GetUserIdByEmployeeId(app.doctor.employee_id);
            systemNotification.user_id = user_id;
            systemNotification.Name = Name;
            String desc = Name + " zakazan za: " + app.StartTime + " za pacijenta " + app.patient.User.Name + " " + app.patient.User.Surname;
            systemNotification.Description = desc;

            this.systemNotificationRepository.NewSystemNotification(systemNotification);
        }

        public Boolean DeleteAllReservedAppointmentsByPatientId(int patientId)
        {
            setConnection();
            
            ObservableCollection<Appointment> appointments = GetAllReservedAppointmentsByPatientId(patientId);
            foreach(Appointment appointment in appointments)
            {
                if(appointment.Type == AppointmentType.OPERATION)
                {
                    continue;
                }
                DeleteAppointmentById(appointment.Id);
            }
            connection.Close();
            return true;
        }

        public Appointment UpdateAppointmentStartTime(Appointment appointment, DateTime startTime)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(appointment.StartTime, appointment.doctor.Id);
            timeSlotRepository.FreeTimeSlot(timeSlot);
            TimeSlot newTimeSlot = new TimeSlot();
            newTimeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(startTime, appointment.doctor.Id);
            timeSlotRepository.TakeTimeSlot(newTimeSlot);
            appointment.doctor = this.doctorRepository.GetDoctorById(appointment.doctor.Id);
            command.CommandText = "UPDATE APPOINTMENT SET DATE_TIME = :DATE_TIME WHERE ID = :ID";
            command.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = startTime;
            command.Parameters.Add("ID", OracleDbType.Int32).Value = appointment.Id.ToString();


            if (command.ExecuteNonQuery() > 0)
            {
                NotifyPatient(appointment, "Izmenjen termin");
                NotifyDoctor(appointment, "Izmenjen termin");

                connection.Close();
                connection.Dispose();

                return appointment;
            }

            connection.Close();
            connection.Dispose();

            return appointment;
        }

        public Appointment UpdateAppointmentRoom(Appointment appointment, Room room)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE APPOINTMENT SET ROOOM_ID = :ROOM_ID WHERE ID = :ID";
            command.Parameters.Add("ROOM_ID", OracleDbType.Date).Value = room.Id.ToString();
            command.Parameters.Add("ID", OracleDbType.Int32).Value = appointment.Id.ToString();


            if (command.ExecuteNonQuery() > 0)
            {
                NotifyPatient(appointment, "Izmenjen termin");
                NotifyDoctor(appointment, "Izmenjen termin");

                connection.Close();
                connection.Dispose();

                return appointment;
            }

            connection.Close();
            connection.Dispose();

            return appointment;

        }

        public Boolean CheckForAppointmentsByPatientIdAndDoctorId(int patientId, int doctorId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM APPOINTMENT WHERE PATIENT_ID = :patient_id AND DOCTOR_ID = :doctor_id AND APPSTAT_ID != 1";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.GetInt32(0) != 0)
            {
                return true;
            }
            connection.Close();
            return false;
        }
        public Boolean CheckForAnyAppointmentsByPatientId(int patientId)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM APPOINTMENT WHERE PATIENT_ID = :patient_id AND APPSTAT_ID != 1";
            cmd.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.GetInt32(0) != 0)
            {
                connection.Close();
                connection.Dispose();
                return true;
            }
            connection.Close();
            connection.Dispose();
            return false;
        }

        public Appointment UpdateAppointmentStatus(Appointment appointment, AppointmentStatus appointmentStatus)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE APPOINTMENT SET APPOINTMENT_STATUS = :APPOINTMENT_STATUS WHERE ID = :ID";
            command.Parameters.Add("APPOINTMENT_STATUS", OracleDbType.Date).Value = appointmentStatus.ToString();
            command.Parameters.Add("ID", OracleDbType.Int32).Value = appointment.Id.ToString();
            int a = command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
            return null;
        }

        public Appointment NewAppointment(Appointment appointment)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();

            TimeSlot newTimeSlot = new TimeSlot();
            newTimeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(appointment.StartTime, appointment.doctor.Id);
            timeSlotRepository.TakeTimeSlot(newTimeSlot);
            int appointment_type_id = -1;

            switch (appointment.Type)
            {
                case AppointmentType.EXAMINATION:
                    appointment_type_id = 1;
                    break;

                case AppointmentType.OPERATION:
                    appointment_type_id = 2;
                    break;
                case AppointmentType.REFERRAL:
                    appointment_type_id = 3;
                    break;
            }


            command.CommandText = "INSERT INTO APPOINTMENT (ID,DURATIONS_MINS,DATE_TIME,ROOM_ID,PATIENT_ID,DOCTOR_ID,APPTYPE_ID,APPSTAT_ID) VALUES (:ID,"+appointment.DurationInMinutes+",:DATE_TIME,:ROOM_ID,:PATIENT_ID,:DOCTOR_ID,"+ appointment_type_id + ",1)";

            int id = GetLastId();
            int next_id = id + 1;
            command.Parameters.Add("ID", OracleDbType.Int32).Value = next_id.ToString();
            command.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = appointment.StartTime;

            appointment.Doctor_Id = appointment.doctor.Id;

            if (appointment.room == null)
            {
                command.Parameters.Add("room_id", OracleDbType.Int32).Value = appointment.Room_Id.ToString();
            }
            else
            {
                command.Parameters.Add("ROOM_ID", OracleDbType.Int32).Value = appointment.room.Id.ToString();
            }

            command.Parameters.Add("PATIENT_ID", OracleDbType.Int32).Value = appointment.Patient_Id.ToString();
            command.Parameters.Add("DOCTOR_ID", OracleDbType.Int32).Value = appointment.Doctor_Id.ToString();

            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                connection.Dispose();

                appointment.Id = next_id;
                appointment.doctor = this.doctorRepository.GetDoctorById(appointment.Doctor_Id);
                appointment.patient = this.patientRepository.GetPatientById(appointment.Patient_Id);

                NotifyDoctor(appointment, "Kreiran termin");
                NotifyPatient(appointment, "Kreiran termin");

                return appointment;
            }

            connection.Close();
            connection.Dispose();

            return appointment;

        }

        public int GetLastId()
        {
            setConnection();
            int id = 0;
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(ID) FROM APPOINTMENT";
            OracleDataReader reader = command.ExecuteReader();
            reader = command.ExecuteReader();
            reader.Read();
            id = int.Parse(reader.GetString(0));

            connection.Close();
            connection.Dispose();

            return id;
        }

        public ObservableCollection<Appointment> getOccupiedDateTimesForDoctorPatienRoom(int doc_id, int patient_id, int room_id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select * from appointment where " +
                                  "patient_id =" + patient_id +
                                  "or room_id =" + room_id + "or doctor_id = " + doc_id;
            OracleDataReader reader = command.ExecuteReader();
            reader = command.ExecuteReader();

            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();

            while (reader.Read())
            {
                Appointment ap = new Appointment();
                ap.Id = reader.GetInt32(0);
                ap.DurationInMinutes = reader.GetInt32(1);
                ap.StartTime = reader.GetDateTime(2);
                appointments.Add(ap);
            }
            connection.Close();
            connection.Dispose();
            return appointments;
        }

    }
}