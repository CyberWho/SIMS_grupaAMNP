/***********************************************************************
 * Module:  ItemInRoom.cs
 * Author:  Pedja
 * Purpose: Definition of the Class ItemInRoom
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class ItemInRoom
    {
        public int Id { get; set; }
        public uint Quantity { get; set; }

        public Room room;

        /// <pdGenerated>default parent getter</pdGenerated>
        public Room GetRoom()
        {
            return room;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newRoom</param>
        public void SetRoom(Room newRoom)
        {
            if (this.room != newRoom)
            {
                if (this.room != null)
                {
                    Room oldRoom = this.room;
                    this.room = null;
                    oldRoom.RemoveItemInRoom(this);
                }
                if (newRoom != null)
                {
                    this.room = newRoom;
                    this.room.AddItemInRoom(this);
                }
            }
        }
        public InventoryItem inventoryItem;

        public ItemInRoom(int id, uint quantity, Room room, InventoryItem inventoryItem)
        {
            Id = id;
            Quantity = quantity;
            this.room = room;
            this.inventoryItem = inventoryItem;
        }

        public ItemInRoom()
        {
        }
    }
}