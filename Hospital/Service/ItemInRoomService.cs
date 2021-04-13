/***********************************************************************
 * Module:  ItemInRoomService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ItemInRoomService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class ItemInRoomService
   {
      public Hospital.Model.ItemInRoom GetItemInRoomById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<ItemInRoom> GetAllItemsInRoomByRoomId()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteItemInRoomById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAllItemsInRoomByRoomId(int roomId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ItemInRoom UpdateQuantity(Hospital.Model.ItemInRoom itemInRoom, int newQuantity)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ItemInRoom AddItemInRoom(Hospital.Model.ItemInRoom itemInRoom)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.ItemInRoomRepository itemInRoomRepository;
   
   }
}