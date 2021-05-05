/***********************************************************************
 * Module:  ReservedItemService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ReservedItemService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
   public class ReservedItemService
   {
      public Model.ReservedItem GetReservedItemById(int id)
      {
         // TODO: implement
         return null;
      }

      public ObservableCollection<ReservedItem> GetAllReservedItems()
      {
          return new ReservedItemRepository().GetAllReservedItems();
      }
      
      public System.Collections.ArrayList GetAllReservedItemsByRoomId(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllReservedItemsByItemInRoomId(int itemInRoomId)
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
      
      public Model.ReservedItem UpdateReservedItem(Model.ReservedItem reservedItem)
      {
         // TODO: implement
         return null;
      }
      
      public Model.ReservedItem AddReservedItem(Model.ReservedItem reservedItem)
      {
         return reservedItemRepository.NewReservedItem(reservedItem);
      }
      
      public Model.ReservedItem ChangeReservedDate(Model.ReservedItem reservedItem, DateTime newReservedDate)
      {
         // TODO: implement
         return null;
      }
   
      public Repository.ReservedItemRepository reservedItemRepository = new Repository.ReservedItemRepository();
   
   }
}