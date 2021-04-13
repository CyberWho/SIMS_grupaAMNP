/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.DoctorService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class DoctorService
   {
      public Hospital.Model.Doctor GetDoctorById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Doctor> GetAllDoctors()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Doctor> GetAllDoctorsBySpecializationId(int specializationId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteDoctorById(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Doctor UpdateDoctor(Hospital.Model.Doctor doctor)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Doctor AddDoctor(Hospital.Model.Doctor doctor)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.DoctorRepository doctorRepository;
   
   }
}