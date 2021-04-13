/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.PatientService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class PatientService
   {
      public Hospital.Model.Patient GetPatientById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Patient> GetAllPatients()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Patient> GetAllPatientsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeletePatientById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Patient UpdatePatient(Hospital.Model.Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Patient RegisterPatient(Hospital.Model.Patient patient)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.PatientRepository patientRepository;
   
   }
}