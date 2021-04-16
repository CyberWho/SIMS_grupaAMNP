/***********************************************************************
 * Module:  RenovationController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.RenovationController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class RenovationController
   {
      public System.Array<Renovation> GetAllRenovations()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Renovation GetRenovationById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Renovation> GetRenovationByRoomId(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteRenovationById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteRenovationByRoomId(int roomId)
      {
         // TODO: implement
         return null;
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
   
      public Hospital.Service.RenovationService renovationService;
   
   }
}