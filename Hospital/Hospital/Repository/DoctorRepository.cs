/***********************************************************************
 * Module:  DoctorRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.DoctorRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class DoctorRepository
   {
      public Hospital.Model.Doctor GetDoctorById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllDoctors()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllDoctorsBySpecializationId(int specializationId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteDoctorById(int doctorId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Doctor UpdateDoctor(Hospital.Model.Doctor doctor)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Doctor NewDoctor(Hospital.Model.Doctor doctor)
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