/***********************************************************************
 * Module:  ItemInRoomService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ItemInRoomService
 ***********************************************************************/

using Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Globals;

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

        public ObservableCollection<ItemInRoom> GetAllItemsInRoom()
        {
            return itemInRoomRepository.GetAllItemsInRoom();
        }

        public void ResetGotAllItemsInRoomFlag()
        {
            itemInRoomRepository.ResetGotAllItemsInRoomFlag();
        }

        public ObservableCollection<ItemInRoom> GetAllItemsInRoomByItemType(ItemType type) 
        {
            return itemInRoomRepository.GetAllItemsInRoomByItemType(type);
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
        public ItemInRoom MoveWholeItemNowToMainStorage(ItemInRoom itemInRoom)
        {
            Room mainStorage = roomRepository.GetRoomById(5);
            itemInRoom.room_id = (int)mainStorage.Id;
            itemInRoom.room.Id = mainStorage.Id;

            ItemInRoom itemInDestinationRoom = AlreadyExists(itemInRoom, (int)mainStorage.Id);
            if (itemInDestinationRoom != null)
            {
                itemInDestinationRoom.Quantity += itemInRoom.Quantity;
                itemInRoomRepository.DeleteItemInRoomById(itemInRoom.Id);
                return itemInRoomRepository.UpdateItemInRoom(itemInDestinationRoom);
            }
            else
            {
                return itemInRoomRepository.UpdateItemInRoom(itemInRoom);
            }
        }
        public bool MoveItem(ItemInRoom itemInRoom, Room destinationRoom, uint quantity)
        {
            /*if (IsExpendable(itemInRoom)) 
            {
                return MoveExpendable(itemInRoom, destinationRoom, quantity);
            }
            else
            {
                return 
            }*/
            
            return Move(itemInRoom, destinationRoom, quantity);
        }

        private bool Move(ItemInRoom itemInRoom, Room destinationRoom, uint quantity)
        {
            ItemInRoom itemInDestinationRoom = AlreadyExists(itemInRoom, (int)destinationRoom.Id);
            if (itemInDestinationRoom != null)
            {
                itemInDestinationRoom.Quantity += quantity;
                itemInRoomRepository.UpdateItemInRoom(itemInDestinationRoom);
                if(itemInRoom.Quantity == quantity)
                {
                    itemInRoomRepository.DeleteItemInRoomById(itemInRoom.Id);
                }
                else
                {
                    itemInRoom.Quantity -= quantity;
                    itemInRoomRepository.UpdateItemInRoom(itemInRoom);
                }
            }
            else
            {
                if (itemInRoom.Quantity == quantity)
                {
                    itemInRoom.room = destinationRoom;
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
                    ItemInRoom newItemInRoom = new ItemInRoom(itemInRoom)
                    {
                        Quantity = quantity,
                        room = destinationRoom
                    };
                    itemInRoomRepository.NewItemInRoom(newItemInRoom);
                }
            }
            return true;
        }


        private ItemInRoom AlreadyExists(ItemInRoom itemInRoom, int destinationRoomID)
        {
            foreach (ItemInRoom itemInDestinationRoom in itemInRoomRepository.GetAllItemsInRoomByRoomId(destinationRoomID))
            {
                if (itemInRoom.inventoryItem.Id == itemInDestinationRoom.inventoryItem.Id)
                {
                    Trace.WriteLine("Vec postoji ovaj item u sobi. Spajanje. (nadam se)");
                    return itemInDestinationRoom;
                }
            }
            return null;
        }
/*        private bool IsExpendable(ItemInRoom itemInRoom)
        {
            return itemInRoom.inventoryItem.Type == 0;
        }*/

        public ObservableCollection<ItemInRoom> LoadAllItems()
        {
            /*ObservableCollection<ItemInRoom> allItems = itemInRoomRepository.GetAllItemsInRoom();
            ObservableCollection<ItemInRoom> mergedItems = new ObservableCollection<ItemInRoom>();
            mergedItems.Add(allItems[0]);

            foreach (ItemInRoom item in allItems)
            {
                int count = 0;
                do
                { 
                    if (mergedItems[count].inventoryItem.Name.Equals(item.inventoryItem.Name))
                    {
                        mergedItems[count].Quantity += item.Quantity;
                        break;
                    }
                    else
                    {
                        mergedItems.Add(item);
                    }
                    count++;
                } while (count != mergedItems.Count);
            }

            Trace.WriteLine("Retval count in Service class: " + mergedItems.Count.ToString());*/

            return itemInRoomRepository.GetAllItemsInRoom();
        }

        public ObservableCollection<ItemInRoom> SearchByName(string name)
        {
            return itemInRoomRepository.SearchByName(name);
        }


        public Repository.ItemInRoomRepository itemInRoomRepository = new Repository.ItemInRoomRepository();
        public Repository.RoomRepository roomRepository = new Repository.RoomRepository();
   
   }
}