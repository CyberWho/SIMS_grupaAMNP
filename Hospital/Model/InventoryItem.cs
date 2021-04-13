/***********************************************************************
 * Module:  InventoryItem.cs
 * Author:  Pedja
 * Purpose: Definition of the Class InventoryItem
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public uint Price { get; set; }
        public string Unit { get; set; }

        public ItemType Type { get; set; }


        public Boolean PutInRoom()
        {
            // TODO: implement
            return null;
        }

        public Boolean Order()
        {
            // TODO: implement
            return null;


        }
    }