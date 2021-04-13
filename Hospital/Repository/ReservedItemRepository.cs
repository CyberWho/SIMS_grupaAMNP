/***********************************************************************
 * Module:  ReservedItemRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReservedItemRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class ReservedItemRepository
   {
      public Hospital.Model.ReservedItem GetReservedItemById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<ReservedItem> GetAllReservedItemsByRoomId(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<ReservedItem> GetAllReservedItemsByItemInRoomId(int itemInRoomId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReservedItemById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAllReservedItemsByRoomId(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAllReservedItemsByItemInRoomId(int itemInRoomId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReservedItem UpdateReservedItem(Hospital.Model.ReservedItem reservedItem)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReservedItem NewReservedItem(Hospital.Model.ReservedItem reservedItem)
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
   
   }
}