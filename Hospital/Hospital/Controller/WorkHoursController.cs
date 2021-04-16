/***********************************************************************
 * Module:  WorkHoursController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.WorkHoursController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class WorkHoursController
   {
      public Hospital.Model.WorkHours AddWorkHours(Hospital.Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.WorkHours UpdateWorkHours(Hospital.Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteWorkHoursById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.WorkHours ApproveWorkHours(Hospital.Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.WorkHours DisapproveWorkHours(Hospital.Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<WorkHours> GetAllWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<WorkHours> GetWorkHoursById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<WorkHours> GetAllApprovedWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<WorkHours> GetAllPendingWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.WorkHoursService workHoursService;
   
   }
}