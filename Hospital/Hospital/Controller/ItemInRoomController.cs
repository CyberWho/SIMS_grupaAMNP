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
        public ItemInRoom GetItemInRoomById(int id)
        {
            return itemInRoomService.GetItemInRoomById(id);
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoomByRoomId(int id)
        {
            return itemInRoomService.GetAllItemsInRoomByRoomId(id);
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoom()
        {
            return itemInRoomService.GetAllItemsInRoom();
        }

        public void ResetGotAllItemsInRoomFlag()
        {
            itemInRoomService.ResetGotAllItemsInRoomFlag();
        }
        public ObservableCollection<ItemInRoom> GetAllItemsInRoomByItemType(ItemType type)
        {
            return itemInRoomService.GetAllItemsInRoomByItemType(type);
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

        public ItemInRoom UpdateQuantity(ItemInRoom itemInRoom, uint newQuantity)
        {
            // TODO: implement
            return null;
        }
      
        public ItemInRoom AddItemInRoom(ItemInRoom itemInRoom)
        {
           // TODO: implement
           return null;
        }

        public ItemInRoom MoveWholeItemNow(ItemInRoom itemInRoom, Room destinationRoom)
        {
            return itemInRoomService.MoveWholeItemNowToMainStorage(itemInRoom);
        }
        public Boolean MoveItem(ItemInRoom itemInRoom, Room destinationRoom, uint quantity, DateTime? dateTime)
        {
            return itemInRoomService.MoveItem(itemInRoom, destinationRoom, quantity, dateTime);
        } 

        public ObservableCollection<ItemInRoom> LoadAllItems()
        {
           return itemInRoomService.LoadAllItems();
        }

        public ObservableCollection<ItemInRoom> SearchByName(string name)
        {
            return itemInRoomService.SearchByName(name);
        }

      public Service.ItemInRoomService itemInRoomService = new Service.ItemInRoomService();
   
   }
}