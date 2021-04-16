/***********************************************************************
 * Module:  ItemInRoomController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.ItemInRoomController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class ItemInRoomController
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
   
      public Hospital.Service.ItemInRoomService itemInRoomService;
   
   }
}