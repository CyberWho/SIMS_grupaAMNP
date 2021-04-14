/***********************************************************************
 * Module:  ReservedItem.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Model.ReservedItem
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class ReservedItem
    {
        public int Id { get; set; }
        public DateTime ReservedDate { get; set; }

        public Room Room { get; set; }
        public ItemInRoom ItemInRoom { get; set; }

        public ReservedItem(int id, DateTime reservedDate, Room room, ItemInRoom itemInRoom)
        {
            Id = id;
            ReservedDate = reservedDate;
            Room = room;
            ItemInRoom = itemInRoom;
        }

        public ReservedItem()
        {
        }
    }
}