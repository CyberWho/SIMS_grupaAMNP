/***********************************************************************
 * Module:  ItemType.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.ItemType
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class ItemType
    {
        private string Type { get; set; }

        public System.Collections.ArrayList InventoryItem;

        public System.Collections.ArrayList GetInventoryItem()
        {
            if (InventoryItem == null)
                InventoryItem = new System.Collections.ArrayList();
            return InventoryItem;
        }

        public void SetInventoryItem(System.Collections.ArrayList newInventoryItem)
        {
            RemoveAllInventoryItem();
            foreach (InventoryItem oInventoryItem in newInventoryItem)
                AddInventoryItem(oInventoryItem);
        }

        public void AddInventoryItem(InventoryItem newInventoryItem)
        {
            if (newInventoryItem == null)
                return;
            if (this.InventoryItem == null)
                this.InventoryItem = new System.Collections.ArrayList();
            if (!this.InventoryItem.Contains(newInventoryItem))
            {
                this.InventoryItem.Add(newInventoryItem);
                newInventoryItem.SetItemType(this);
            }
        }

        public void RemoveInventoryItem(InventoryItem oldInventoryItem)
        {
            if (oldInventoryItem == null)
                return;
            if (this.InventoryItem != null)
                if (this.InventoryItem.Contains(oldInventoryItem))
                {
                    this.InventoryItem.Remove(oldInventoryItem);
                    oldInventoryItem.SetItemType((ItemType)null);
                }
        }

        public void RemoveAllInventoryItem()
        {
            if (InventoryItem != null)
            {
                System.Collections.ArrayList tmpInventoryItem = new System.Collections.ArrayList();
                foreach (InventoryItem oldInventoryItem in InventoryItem)
                    tmpInventoryItem.Add(oldInventoryItem);
                InventoryItem.Clear();
                foreach (InventoryItem oldInventoryItem in tmpInventoryItem)
                    oldInventoryItem.SetItemType((ItemType)null);
                tmpInventoryItem.Clear();
            }
        }


    }
}