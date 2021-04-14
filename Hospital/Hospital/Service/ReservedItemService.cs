/***********************************************************************
 * Module:  ReservedItemService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ReservedItemService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class ReservedItemService
   {
      public Hospital.Model.ReservedItem GetReservedItemById(int id)
      {
         // TODO: implement
         return null;
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
      
      public Hospital.Model.ReservedItem UpdateReservedItem(Hospital.Model.ReservedItem reservedItem)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReservedItem AddReservedItem(Hospital.Model.ReservedItem reservedItem)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReservedItem ChangeReservedDate(Hospital.Model.ReservedItem reservedItem, DateTime newReservedDate)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.ReservedItemRepository reservedItemRepository;
   
   }
}