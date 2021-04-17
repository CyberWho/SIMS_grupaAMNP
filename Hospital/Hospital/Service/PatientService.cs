/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.PatientService
 ***********************************************************************/

using System;
using Hospital.Model;

namespace Hospital.Service
{
   public class PatientService
   {
      public Hospital.Model.Patient GetPatientByUserId(int id)
      {
            Patient patient = new Patient();
            patient = patientRepository.GetPatientByUserId(id);
            return patient;
      }
      
      public Hospital.Model.Patient GetPatientById(int id)
        {
            return null;
        }

      public System.Collections.ArrayList GetAllPatients()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllPatientsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeletePatientById(int id)
      {
         // TODO: implement
         return false;
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
   
      public Hospital.Repository.PatientRepository patientRepository = new Repository.PatientRepository();
   
   }
}