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
        public int Id { get; set;}
        public uint Quantity { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public Room Room;

        public Room GetRoom()
        {
            return Room;
        }

        public void SetRoom(Room newRoom)
        {
            if (this.Room != newRoom)
            {
                if (this.Room != null)
                {
                    Room oldRoom = this.Room;
                    this.Room = null;
                    oldRoom.RemoveItemInRoom(this);
                }
                if (newRoom != null)
                {
                    this.Room = newRoom;
                    this.Room.AddItemInRoom(this);
                }
            }
        }

    }
}