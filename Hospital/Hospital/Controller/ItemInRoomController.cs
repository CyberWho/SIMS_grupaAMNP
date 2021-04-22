/***********************************************************************
 * Module:  ItemInRoomController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.ItemInRoomController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class ItemInRoomController
   {
        public Hospital.Model.ItemInRoom GetItemInRoomById(int id)
        {
            return itemInRoomService.GetItemInRoomById(id);
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoomByRoomId(int id)
        {
            return itemInRoomService.GetAllItemsInRoomByRoomId(id);
        }

        public Boolean DeleteItemInRoomById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllItemsInRoomByRoomId(int roomId)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.ItemInRoom UpdateQuantity(Hospital.Model.ItemInRoom itemInRoom, uint newQuantity)
        {
            // TODO: implement
            return null;
        }
      
        public Hospital.Model.ItemInRoom AddItemInRoom(Hospital.Model.ItemInRoom itemInRoom)
        {
           // TODO: implement
           return null;
        }
   
        public Boolean MoveItem(int itemInRoomID, int destinationRoomID, uint quantity, DateTime? dateTime)
        {
            return itemInRoomService.MoveItem(itemInRoomID, destinationRoomID, quantity, dateTime);
        } 

      public Hospital.Service.ItemInRoomService itemInRoomService = new Service.ItemInRoomService();
   
   }
}