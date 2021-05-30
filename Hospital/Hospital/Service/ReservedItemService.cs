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
      public ReservedItem GetReservedItemById(int id)
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
      
      public ReservedItem UpdateReservedItem(ReservedItem reservedItem)
      {
         // TODO: implement
         return null;
      }
      
      public ReservedItem AddReservedItem(ReservedItem reservedItem)
      {
         return reservedItemRepository.NewReservedItem(reservedItem);
      }
      
      public ReservedItem ChangeReservedDate(ReservedItem reservedItem, DateTime newReservedDate)
      {
         // TODO: implement
         return null;
      }

        public ItemInRoom MoveReservedItem(ReservedItem reservedItem)
        {
            bool Success = itemInRoomService.MoveItem(reservedItem.ItemInRoom, reservedItem.Room, reservedItem.ItemInRoom.Quantity);

            if (Success)
            {
                return reservedItem.ItemInRoom;
            }

            return null;
        }

        public ReservedItemRepository reservedItemRepository = new ReservedItemRepository();
        public ItemInRoomService itemInRoomService = new ItemInRoomService();
   
   }
}