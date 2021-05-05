/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
   public class ReservedItemController
   {
      public ReservedItem GetReservedItemById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<ReservedItem> GetAllReservedItemsByRoomId(int roomId)
      {
         // TODO: implement
         return null;
      }

      public ObservableCollection<ReservedItem> getAllReservedItems()
      {
          return new ReservedItemService().GetAllReservedItems();
      }
      
      public ObservableCollection<ReservedItem> GetAllReservedItemsByItemInRoomId(int itemInRoomId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReservedItemById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteAllReservedItemsByRoomId(int roomId)
      {
            // TODO: implement
            return false;
      }
      
      public Boolean DeleteAllReservedItemsByItemInRoomId(int itemInRoomId)
      {
         // TODO: implement
         return false;
      }
      
      public ReservedItem UpdateReservedItem(ReservedItem reservedItem)
      {
         // TODO: implement
         return null;
      }
      
      public ReservedItem AddReservedItem(ReservedItem reservedItem)
      {
         return reservedItemService.AddReservedItem(reservedItem);
      }
      
      public ReservedItem ChangeReservedDate(ReservedItem reservedItem, DateTime newReservedDate)
      {
         // TODO: implement
         return null;
      }
   
      public Service.ReservedItemService reservedItemService = new Service.ReservedItemService();
   
   }
}