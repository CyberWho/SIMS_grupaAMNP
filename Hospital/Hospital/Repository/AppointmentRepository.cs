/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AppointmentRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
   public class AppointmentRepository
   {
        OracleConnection con = null;
        RoomRepository roomRepository = new RoomRepository();
        PatientRepository patientRepository = new PatientRepository();
        DoctorRepository doctorRepository = new DoctorRepository();
        TimeSlotRepository timeSlotRepository = new TimeSlotRepository();

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
        public Hospital.Model.Appointment GetAppointmentById(int id)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM APPOINTMENT WHERE ID = :id";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
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
                appointment.Type = AppointmentType.EXAMINATION;
            }
            else
            {
                if (apptypeid == 1)
                {
                    appointment.Type = AppointmentType.OPERATION;
                }
                else
                {
                    appointment.Type = AppointmentType.REFERRAL;
                }
            }
            if(appstatid == 0)
            {
                appointment.Status = AppointmentStatus.FINISHED;
            } else
            {
                if(appstatid == 1)
                {
                    appointment.Status = AppointmentStatus.RESERVED;
                } else
                {
                    appointment.Status = AppointmentStatus.DIDNTCOME;
                }
            }
            Room room = new Room();
            room = roomRepository.GetAppointmentRoomById(roomId);

            appointment.room = room;
            Patient patient = new Patient();
            patient = patientRepository.GetPatientById(patId);
            appointment.patient = patient;

            Doctor doctor = new Doctor();
            doctor = doctorRepository.GetAppointmentDoctorById(doctorId);
            appointment.doctor = doctor;
            con.Close();
            return appointment;
      }
      
      public ObservableCollection<Appointment> GetAllReservedAppointments()
      {
            
       
            return null;
      }
      
      public System.Collections.ArrayList GetAllReservedAppointmentsWeekly()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllAppointmentsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Appointment> GetAllByAppointmentsPatientId(int patientId)
      {
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM APPOINTMENT WHERE PATIENT_ID = :patient_id AND APPSTAT_ID = 1";
            cmd.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
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
            con.Close();
            return appointments;
        }

            public Boolean DeleteAppointmentById(int id)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            Appointment appointment = new Appointment();
             appointment =  GetAppointmentById(id);
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(appointment.StartTime, appointment.doctor.Id);
            timeSlotRepository.FreeTimeSlot(timeSlot);
            
            
            cmd.CommandText = "delete from appointment where id = :id";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return true;
      }
      
      public Boolean DeleteAppointmentByPatientId(int patientId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Appointment UpdateAppointmentStartTime(Hospital.Model.Appointment appointment,DateTime startTime)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(appointment.StartTime, appointment.doctor.Id);
            timeSlotRepository.FreeTimeSlot(timeSlot);
            TimeSlot newTimeSlot = new TimeSlot();
            newTimeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(startTime, appointment.doctor.Id);
            timeSlotRepository.TakeTimeSlot(newTimeSlot);
            cmd.CommandText = "UPDATE APPOINTMENT SET DATE_TIME = :DATE_TIME WHERE ID = :ID";
            cmd.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = startTime;
            cmd.Parameters.Add("ID", OracleDbType.Int32).Value = appointment.Id.ToString();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return appointment;
      }
      
       public Hospital.Model.Appointment UpdateAppointmentRoom(Hospital.Model.Appointment appointment,Hospital.Model.Room room)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE APPOINTMENT SET ROOOM_ID = :ROOM_ID WHERE ID = :ID";
            cmd.Parameters.Add("ROOM_ID", OracleDbType.Date).Value = room.Id.ToString();
            cmd.Parameters.Add("ID", OracleDbType.Int32).Value = appointment.Id.ToString();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return appointment;
           
        }

      public Hospital.Model.Appointment UpdateAppointmentStatus(Hospital.Model.Appointment appointment,Hospital.Model.AppointmentStatus appointmentStatus)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE APPOINTMENT SET APPOINTMENT_STATUS = :APPOINTMENT_STATUS WHERE ID = :ID";
            cmd.Parameters.Add("APPOINTMENT_STATUS", OracleDbType.Date).Value = appointmentStatus.ToString();
            cmd.Parameters.Add("ID", OracleDbType.Int32).Value = appointment.Id.ToString();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return null;
        }

      public Hospital.Model.Appointment NewAppointment(Hospital.Model.Appointment appointment)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();

            TimeSlot newTimeSlot = new TimeSlot();
            newTimeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(appointment.StartTime, appointment.doctor.Id);
            timeSlotRepository.TakeTimeSlot(newTimeSlot);

            cmd.CommandText = "INSERT INTO APPOINTMENT (ID,DURATIONS_MINS,DATE_TIME,ROOM_ID,PATIENT_ID,DOCTOR_ID,APPTYPE_ID,APPSTAT_ID) VALUES (:ID,30,:DATE_TIME,:ROOM_ID,:PATIENT_ID,:DOCTOR_ID,1,1)";

            int id = GetLastId();
            int next_id = id + 1;
            cmd.Parameters.Add("ID", OracleDbType.Int32).Value = next_id.ToString();
            cmd.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = appointment.StartTime;
            cmd.Parameters.Add("ROOM_ID", OracleDbType.Int32).Value = appointment.room.Id.ToString();
            cmd.Parameters.Add("PATIENT_ID", OracleDbType.Int32).Value = appointment.patient.Id.ToString();
            cmd.Parameters.Add("DOCTOR_ID", OracleDbType.Int32).Value = appointment.doctor.Id.ToString();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return appointment;
      }
      
      public int GetLastId()
      {
            setConnection();
            int id = 0;
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT MAX(ID) FROM APPOINTMENT";
            OracleDataReader reader = cmd.ExecuteReader();
            reader = cmd.ExecuteReader();
            reader.Read();
            id = int.Parse(reader.GetString(0));
            con.Close();
            return id;
      }
   
   }
}