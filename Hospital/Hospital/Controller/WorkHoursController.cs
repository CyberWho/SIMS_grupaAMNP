/***********************************************************************
 * Module:  WorkHoursController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.WorkHoursController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class WorkHoursController
   {
      public WorkHours AddWorkHours(WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public WorkHours UpdateWorkHours(WorkHours workHours)
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
      
      public WorkHours ApproveWorkHours(WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public WorkHours DisapproveWorkHours(WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<WorkHours> GetAllWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<WorkHours> GetWorkHoursById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<WorkHours> GetAllApprovedWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<WorkHours> GetAllPendingWorkHoursByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
   
      public Service.WorkHoursService workHoursService;
   
   }
}