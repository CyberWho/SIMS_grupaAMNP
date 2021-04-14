/***********************************************************************
 * Module:  PatientController.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Controller.PatientController
 ***********************************************************************/

using System;
using Hospital.Model;

namespace Hospital.Controller
{
   public class PatientController
   {
      public System.Collections.ArrayList GetAllPerscriptions()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Perscription GetPerscriptionById(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Patient GetPatientInfo(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Patient ModifyPatientInfo(String telephoneNumber, String email, Hospital.Model.Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllDoctors()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllDoctorsBySpecializationId(Hospital.Model.Specialization specialization)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Appointment ReserveAppointment(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllReservedAppointments()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Appointment UpdateAppointmentTime(int appointmentId, Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean CancelAppointment(int appointmentId)
      {
         // TODO: implement
         return false;
      }
      
      public System.Collections.ArrayList GetAppointmentRecomendation(int doctorId, int roomId, DateTime startTime, DateTime endTime)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllReminders()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Reminder CreateReminder(Hospital.Model.Reminder reminder)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReminder(int reminderId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Reminder ModifyReminder(Hospital.Model.Reminder reminder, int reminderId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetNotifications(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllMedicalTreatments(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.HealthRecord GetHealthRecord(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.MedicalTreatment GetMedicalTreatment(int medicalTreatmentId)
      {
         // TODO: implement
         return null;
      }
      
      public int GetMedicalTreatmentSchedule(int medicalTreatmentId)
      {
         // TODO: implement
         return 0;
      }
      
      public System.Collections.ArrayList GetAllActiveReferrals(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public ReferralForSpecialist UseReferral(int referralForSpecialistId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllDoctorsBySpecializationType(Hospital.Model.Specialization specializationType)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAppointmentRecomendations(DateTime desiredStartTime, DateTime desiredEndTime, int roomId, int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Drug GetMedicalTreatmentDrug(int medicalTreatmentId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllAnamnesis(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllAllergies(int patientId)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.AnamnesisService anamnesisService;
      public Hospital.Service.AllergyService allergyService;
      public Hospital.Service.AppointmentService appointmentService;
      public Hospital.Service.DrugService drugService;
      public Hospital.Service.DoctorService doctorService;
      public Hospital.Service.HealthRecordService healthRecordService;
      public Hospital.Service.PatientService patientService;
      public Hospital.Service.MedicalTreatmentService medicalTreatmentService;
      public Hospital.Service.PerscriptionService perscriptionService;
      public Hospital.Service.ReferralForSpecialistService referralForSpecialistService;
      public Hospital.Service.ReminderService reminderService;
   
   }
}