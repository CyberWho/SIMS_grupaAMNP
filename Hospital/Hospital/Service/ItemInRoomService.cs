/***********************************************************************
 * Module:  ItemInRoomService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ItemInRoomService
 ***********************************************************************/

using Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Hospital.Service
{
   public class ItemInRoomService
   {
        public ItemInRoom GetItemInRoomById(int id) { 
            return itemInRoomRepository.GetItemInRoomById(id);
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoomByRoomId(int id)
        {
            return itemInRoomRepository.GetAllItemsInRoomByRoomId(id);
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
            itemInRoom.Quantity = newQuantity;
            return itemInRoomRepository.UpdateItemInRoom(itemInRoom);
        }

        public ItemInRoom AddItemInRoom(ItemInRoom itemInRoom)
        {
            return itemInRoomRepository.NewItemInRoom(itemInRoom);
        }
        public Boolean MoveItem(int itemInRoomID, int destinationRoomID, uint quantity, DateTime? dateTime)
        {
            ItemInRoom itemInRoom = itemInRoomRepository.GetItemInRoomById(itemInRoomID);
            if (IsExpendable(dateTime)) 
            {
                return MoveExpendable(itemInRoom, destinationRoomID, quantity);
            }
            else
            {

            }
            
            return false;
        }

        private Boolean MoveExpendable(ItemInRoom itemInRoom, int destinationRoomID, uint quantity)
        {
            ItemInRoom itemInDestinationRoom = AlreadyExists(itemInRoom, destinationRoomID);
            if (itemInDestinationRoom != null)
            {
                itemInDestinationRoom.Quantity += quantity;
                itemInRoomRepository.UpdateItemInRoom(itemInDestinationRoom);
                itemInRoomRepository.DeleteItemInRoomById(itemInRoom.Id);
            }
            else
            {
                if (itemInRoom.Quantity == quantity)
                {
                    itemInRoom.room = roomRepository.GetRoomById(destinationRoomID);
                    itemInRoomRepository.UpdateItemInRoom(itemInRoom);
                }
                else if (itemInRoom.Quantity < quantity)
                {
                    return false;
                }
                else
                {
                    itemInRoom.Quantity -= quantity;
                    itemInRoomRepository.UpdateItemInRoom(itemInRoom);
                    ItemInRoom newItemInRoom = new ItemInRoom(itemInRoom);
                    newItemInRoom.Quantity = quantity;
                    newItemInRoom.room = roomRepository.GetRoomById(destinationRoomID);
                    itemInRoomRepository.NewItemInRoom(newItemInRoom);
                }
            }
            return true;
        }

        private ItemInRoom AlreadyExists(ItemInRoom itemInRoom, int destinationRoomID)
        {
            ObservableCollection<ItemInRoom> itemsInDestinationRoom = itemInRoomRepository.GetAllItemsInRoomByRoomId(destinationRoomID);
            foreach (ItemInRoom itemInDestinationRoom in itemsInDestinationRoom)
            {
                if (itemInRoom.inventoryItem.Id == itemInDestinationRoom.inventoryItem.Id)
                {
                    Trace.WriteLine("Vec postoji ovaj item u sobi. Spajanje. (nadam se)");
                    return itemInDestinationRoom;
                }
            }
            return null;
        }
        private Boolean IsExpendable(DateTime? dateTime)
        {
            return dateTime == null;
        }

        public Repository.ItemInRoomRepository itemInRoomRepository = new Repository.ItemInRoomRepository();
        public Repository.RoomRepository roomRepository = new Repository.RoomRepository();
   
   }
}