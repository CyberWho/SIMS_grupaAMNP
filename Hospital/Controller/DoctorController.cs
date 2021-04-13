/***********************************************************************
 * Module:  DoctorController.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Controller.DoctorController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class DoctorController
   {
      public Hospital.Model.HealthRecord FindHealthRecordByJMBG(String patientJMBG)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Employee FindHealthRecordByUsername(String patientUsername)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.HealthRecord GetHealthRecord(Hospital.Model.Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Anamnesis CreateNewAnamesis(Hospital.Model.Anamnesis anamnesis)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.MedicalTreatment CreateNewMedicalTreatment(Hospital.Model.MedicalTreatment medicalTreatment)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Perscription CreateNewPerscription(Hospital.Model.Perscription perscription)
      {
         // TODO: implement
         return null;
      }
      
      public ReferralForSpecialist CreateNewReferral(Hospital.Model.ReferralForSpecialist referral)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Appointment ScheduleNewExamination(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean CancelAppointment(int appointmentId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Appointment ScheduleNewOperation(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Appointment ModifyAppointment(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Drug ApproveDrug(int drugId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Drug DisapproveDrug(int drugId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Drug> GetAllPendingDrugs()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Drug> GetAllApprovedDrugs()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.WorkHours ApproveWorkHours(Hospital.Model.WorkHours workhours)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<WorkHours> GetAllPendingWorkHours(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public int CreateNewReferralForHospital(Hospital.Model.ReferralForClinicalTreatment referral)
      {
         // TODO: implement
         return 0;
      }
      
      public System.Array<ItemInRoom> GetAllItemInRoom(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ItemInRoom SpendItemInRoom(Hospital.Model.ItemInRoom itemInRoom, int amount)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<InventoryItem> GetAllExpendableInventoryItems()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Room> FindExpendableItemInRoom(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Room> FindPersistantItemInRoom(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Appointment> DoctorSchedule(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Doctor GetDoctorInfo(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Allergy> GetAllAllergiesForPatient(int patientId)
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
      public Hospital.Service.InventoryItemService inventoryItemService;
      public Hospital.Service.ItemInRoomService itemInRoomService;
      public Hospital.Service.PatientService patientService;
      public Hospital.Service.MedicalTreatmentService medicalTreatmentService;
      public Hospital.Service.PerscriptionService perscriptionService;
      public Hospital.Service.ReferralForSpecialistService referralForSpecialistService;
      public Hospital.Service.ReferralForClinicalTreatmentService referralForClinicalTreatmentService;
      public Hospital.Service.RoomService roomService;
      public Hospital.Service.WorkHoursService workHoursService;
   
   }
}