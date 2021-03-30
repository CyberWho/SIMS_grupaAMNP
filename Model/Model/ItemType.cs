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
      public System.Collections.ArrayList inventoryItem;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetInventoryItem()
      {
         if (inventoryItem == null)
            inventoryItem = new System.Collections.ArrayList();
         return inventoryItem;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetInventoryItem(System.Collections.ArrayList newInventoryItem)
      {
         RemoveAllInventoryItem();
         foreach (InventoryItem oInventoryItem in newInventoryItem)
            AddInventoryItem(oInventoryItem);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddInventoryItem(InventoryItem newInventoryItem)
      {
         if (newInventoryItem == null)
            return;
         if (this.inventoryItem == null)
            this.inventoryItem = new System.Collections.ArrayList();
         if (!this.inventoryItem.Contains(newInventoryItem))
         {
            this.inventoryItem.Add(newInventoryItem);
            newInventoryItem.SetItemType(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveInventoryItem(InventoryItem oldInventoryItem)
      {
         if (oldInventoryItem == null)
            return;
         if (this.inventoryItem != null)
            if (this.inventoryItem.Contains(oldInventoryItem))
            {
               this.inventoryItem.Remove(oldInventoryItem);
               oldInventoryItem.SetItemType((ItemType)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllInventoryItem()
      {
         if (inventoryItem != null)
         {
            System.Collections.ArrayList tmpInventoryItem = new System.Collections.ArrayList();
            foreach (InventoryItem oldInventoryItem in inventoryItem)
               tmpInventoryItem.Add(oldInventoryItem);
            inventoryItem.Clear();
            foreach (InventoryItem oldInventoryItem in tmpInventoryItem)
               oldInventoryItem.SetItemType((ItemType)null);
            tmpInventoryItem.Clear();
         }
      }
   
      private string Type;
   
   }
}