/***********************************************************************
 * Module:  SecretaryController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.SecretaryController
 ***********************************************************************/

using System;
using Hospital.Model;

namespace Hospital.Controller
{
   public class SecretaryController
   {
      public Hospital.Model.Employee GetSecretaryInfo(Hospital.Model.Employee secretary)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllHealthRecords()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.HealthRecord FindHealthRecordByJMBG(String jmbg)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Employee FindHealthRecordByUsername(String username)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.HealthRecord SendHealthRecord(Hospital.Model.HealthRecord healthRecord)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Appointment ScheduleUrgentAppointment(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteHealthRecord(Hospital.Model.HealthRecord healthRecord)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.HealthRecord UpdateHealthRecord(Hospital.Model.HealthRecord healthRecord)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.HealthRecord CreateNewHealthRecord(Hospital.Model.HealthRecord healthRecord)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Patient CreateNewPatient(Hospital.Model.Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeletePatient(Hospital.Model.Patient patient)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Patient UpdatePatient(Hospital.Model.Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.User CreateGuestAccount(Hospital.Model.User user)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Appointment ScheduleNewAppointment(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean CancelAppointment(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Appointment UpdateAppointment(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllPatientAppointments()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllSystemNotifications()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.SystemNotification CreateNewSystemNotification(Hospital.Model.SystemNotification systemNotification)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteSystemNotification(Hospital.Model.SystemNotification systemNotification)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.SystemNotification ModifySystemNotification(Hospital.Model.SystemNotification systemNotification)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Patient PromoteToRegularPatient(Hospital.Model.User user)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Address AddNewAddress(Hospital.Model.Address address)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.City AddNewCity(Hospital.Model.City city)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.AddressService addressService;
      public Hospital.Service.CityService cityService;
      public Hospital.Service.AppointmentService appointmentService;
      public Hospital.Service.DoctorService doctorService;
      public Hospital.Service.HealthRecordService healthRecordService;
      public Hospital.Service.PatientService patientService;
      public Hospital.Service.SystemNotificationService systemNotificationService;
      public Hospital.Service.UserService userService;
   
   }
}