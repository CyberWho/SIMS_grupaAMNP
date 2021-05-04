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
      
      public Renovation GetRenovationById(int id)
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
      
      public Renovation UpdateRenovation(Renovation renovation)
      {
         // TODO: implement
         return null;
      }
      
      public Renovation AddRenovation(Renovation renovation)
      {
         // TODO: implement
         return null;
      }
      
      public Renovation ChangeStartDate(Renovation renovation, DateTime newStartDate)
      {
         // TODO: implement
         return null;
      }
   
      public Service.RenovationService renovationService;
   
   }
}