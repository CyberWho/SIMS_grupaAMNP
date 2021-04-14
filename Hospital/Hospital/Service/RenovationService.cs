/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.RenovationService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class RenovationService
   {
      public System.Collections.ArrayList GetAllRenovations()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Renovation GetRenovationById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetRenovationByRoomId(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteRenovationById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteRenovationByRoomId(int roomId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Renovation UpdateRenovation(Hospital.Model.Renovation renovation)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Renovation AddRenovation(Hospital.Model.Renovation renovation)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Renovation ChangeStartDate(Hospital.Model.Renovation renovation, DateTime newStartDate)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.RenovationRepository renovationRepository;
   
   }
}