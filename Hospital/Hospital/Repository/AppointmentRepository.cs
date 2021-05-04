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
            
            switch(apptypeid)
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
            
            switch(appstatid)
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
            return appointment;
        }

        public ObservableCollection<Appointment> GetAllReservedAppointments()
        {
            setConnection();

            int id = (int) AppointmentStatus.RESERVED;

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM appointment WHERE appstat_id = " + id;
            OracleDataReader reader = command.ExecuteReader();



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
                    case 0:
                        appointmentType = AppointmentType.EXAMINATION;
                        break;
                    case 1:
                        appointmentType = AppointmentType.OPERATION;
                        break;
                    case 2:
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
            return appointments;
        }

        public Boolean DeleteAppointmentById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            Appointment appointment = new Appointment();
            appointment = GetAppointmentById(id);
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(appointment.StartTime, appointment.doctor.Id);
            timeSlotRepository.FreeTimeSlot(timeSlot);

            command.CommandText = "delete from appointment where id = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            if (command.ExecuteNonQuery() > 0)
            {
                ObavestiPacijenta(appointment, "Obrisan termin");
                ObavestiLekara(appointment, "Obrisan termin");
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }
        private void ObavestiPacijenta(Appointment app, String Name)
        {
            SystemNotification systemNotification = new SystemNotification();
            systemNotification.user_id = app.patient.user_id;
            systemNotification.Name = Name;
            String desc = Name + " zakazan za: " + app.StartTime.ToString() + " kod lekara " + app.doctor.User.Name + " " + app.doctor.User.Surname;
            systemNotification.Description = desc;

            this.systemNotificationRepository.NewSystemNotification(systemNotification);
        }
        private void ObavestiLekara(Appointment app, String Name)
        {
            SystemNotification systemNotification = new SystemNotification();
            systemNotification.user_id = app.doctor.User.Id;
            systemNotification.Name = Name;
            String desc = Name + " zakazan za: " + app.StartTime.ToString() + " za pacijenta " + app.patient.User.Name + " " + app.patient.User.Surname;
            systemNotification.Description = desc;

            this.systemNotificationRepository.NewSystemNotification(systemNotification);
        }

        public Boolean DeleteAppointmentByPatientId(int patientId)
        {
            setConnection();
            
            ObservableCollection<Appointment> appointments = GetAllReservedAppointmentsByPatientId(patientId);
            foreach(Appointment appointment in appointments)
            {
                DeleteAppointmentById(appointment.Id);
            }
            connection.Close();
            return false;
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
            command.CommandText = "UPDATE APPOINTMENT SET DATE_TIME = :DATE_TIME WHERE ID = :ID";
            command.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = startTime;
            command.Parameters.Add("ID", OracleDbType.Int32).Value = appointment.Id.ToString();
            

            if (command.ExecuteNonQuery() > 0)
            {
                ObavestiPacijenta(appointment, "Izmenjen termin");
                ObavestiLekara(appointment, "Izmenjen termin");
                connection.Close();
                return appointment;
            }

            connection.Close();
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
                ObavestiPacijenta(appointment, "Izmenjen termin");
                ObavestiLekara(appointment, "Izmenjen termin");
                connection.Close();
                return appointment;
            }

            connection.Close();
            return appointment;
           
        }

        public Boolean CheckForAppointmentsByPatientIdAndDoctorId(int patientId,int doctorId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM APPOINTMENT WHERE PATIENT_ID = :patient_id AND DOCTOR_ID = :doctor_id AND APPSTAT_ID != 1";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            if(reader.GetInt32(0) != 0)
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
                return true;
            }
            connection.Close();
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
            return null;
        }

        public Appointment NewAppointment(Appointment appointment)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();

            TimeSlot newTimeSlot = new TimeSlot();
            newTimeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(appointment.StartTime, appointment.doctor.Id);
            timeSlotRepository.TakeTimeSlot(newTimeSlot);

            command.CommandText = "INSERT INTO APPOINTMENT (ID,DURATIONS_MINS,DATE_TIME,ROOM_ID,PATIENT_ID,DOCTOR_ID,APPTYPE_ID,APPSTAT_ID) VALUES (:ID,30,:DATE_TIME,:ROOM_ID,:PATIENT_ID,:DOCTOR_ID,1,1)";

            int id = GetLastId();
            int next_id = id + 1;
            command.Parameters.Add("ID", OracleDbType.Int32).Value = next_id.ToString();
            command.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = appointment.StartTime;
            command.Parameters.Add("ROOM_ID", OracleDbType.Int32).Value = appointment.room.Id.ToString();
            command.Parameters.Add("PATIENT_ID", OracleDbType.Int32).Value = appointment.patient.Id.ToString();
            command.Parameters.Add("DOCTOR_ID", OracleDbType.Int32).Value = appointment.doctor.Id.ToString();
            command.ExecuteNonQuery();
            connection.Close();
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
            return id;
      }
   
   }
}