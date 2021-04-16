/***********************************************************************
 * Module:  PatientController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.PatientController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class PatientController
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
   
      public Hospital.Service.PatientService patientService;
   
   }
}