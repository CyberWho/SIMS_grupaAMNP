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
        public string Name { get; set; }
        public uint Price { get; set; }
        public string Unit { get; set; }
        public ItemType Type { get; set; }

        public InventoryItem(int id, string name, uint price, string unit, ItemType type)
        {
            Id = id;
            Name = name;
            Price = price;
            Unit = unit;
            Type = type;
        }

        public InventoryItem()
        {
        }
    }
}