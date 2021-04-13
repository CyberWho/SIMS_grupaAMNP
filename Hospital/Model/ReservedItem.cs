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

        public Room room { get; set; }
        public ItemInRoom itemInRoom { get; set; }

    }
}