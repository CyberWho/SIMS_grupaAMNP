/***********************************************************************
 * Module:  DoctorController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.DoctorController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class DoctorController
   {
      public Hospital.Model.Doctor GetDoctorById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Doctor> GetAllDoctors()
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Doctor> GetAllDoctorsBySpecializationId(int specializationId)
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
      
      public Hospital.Model.Doctor AddDoctor(Hospital.Model.Doctor doctor)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.DoctorService doctorService;
   
   }
}