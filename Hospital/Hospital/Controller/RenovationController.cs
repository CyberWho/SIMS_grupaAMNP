/***********************************************************************
 * Module:  RenovationController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.RenovationController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class RenovationController
   {
      public ObservableCollection<Renovation> GetAllRenovations()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Renovation GetRenovationById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Renovation> GetRenovationByRoomId(int roomId)
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
   
      public Hospital.Service.RenovationService renovationService;
   
   }
}