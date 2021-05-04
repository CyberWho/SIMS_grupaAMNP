/***********************************************************************
 * Module:  WorkHoursService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.WorkHoursService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class WorkHoursService
   {
      public Model.WorkHours AddWorkHours(Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public Model.WorkHours UpdateWorkHours(Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteWorkHoursById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Model.WorkHours ApproveWorkHours(Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public Model.WorkHours DisapproveWorkHours(Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetWorkHoursById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllApprovedWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllPendingWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
   
      public Repository.WorkHoursRepository workHoursRepository;
   
   }
}