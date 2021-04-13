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
        private int Id { get; set; }
        private int Name { get; set; }
        private uint Price { get; set; }
        private string Unit { get; set; }

        public ItemType ItemType;

        public Boolean PutInRoom()
        {
            // TODO: implement
            return false;
        }

        public Boolean Order()
        {
            // TODO: implement
            return false;
        }

        public ItemType GetItemType()
        {
            return ItemType;
        }

        public void SetItemType(ItemType newItemType)
        {
            if (this.ItemType != newItemType)
            {
                if (this.ItemType != null)
                {
                    ItemType oldItemType = this.ItemType;
                    this.ItemType = null;
                    oldItemType.RemoveInventoryItem(this);
                }
                if (newItemType != null)
                {
                    this.ItemType = newItemType;
                    this.ItemType.AddInventoryItem(this);
                }
            }
        }


    }
}