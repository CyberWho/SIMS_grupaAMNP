/***********************************************************************
 * Module:  PatientRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.PatientRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class PatientRepository
   {
      public Hospital.Model.Patient GetPatientById(int id)
      {
         // TODO: implement
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
      
      public Hospital.Model.Patient NewPatient(Hospital.Model.Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
   
   }
}