/***********************************************************************
 * Module:  WorkHoursService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.WorkHoursService
 ***********************************************************************/

using System;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
   public class WorkHoursService
   {
       private TimeSlotRepository timeSlotRepository = new TimeSlotRepository();

      public Hospital.Model.WorkHours AddWorkHours(Hospital.Model.WorkHours workHours)
      {
          WorkHours newWH = this.workHoursRepository.NewWorkHours(workHours);
          this.timeSlotRepository.generateTimeSlots(newWH.Id);
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
   
      public Hospital.Repository.WorkHoursRepository workHoursRepository = new WorkHoursRepository();
   
   }
}