/***********************************************************************
 * Module:  WorkHoursRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.WorkHoursRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class WorkHoursRepository
   {
      public Hospital.Model.WorkHours GetWorkHoursById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllApprovedWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteWorkHoursById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteAllWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.WorkHours UpdateWorkHours(Hospital.Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.WorkHours NewWorkHours(Hospital.Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllPendingWorkHoursByDoctorId(int doctorId)
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