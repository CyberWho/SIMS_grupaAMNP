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
   
      public ItemType itemType;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public ItemType GetItemType()
      {
         return itemType;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newItemType</param>
      public void SetItemType(ItemType newItemType)
      {
         if (this.itemType != newItemType)
         {
            if (this.itemType != null)
            {
               ItemType oldItemType = this.itemType;
               this.itemType = null;
               oldItemType.RemoveInventoryItem(this);
            }
            if (newItemType != null)
            {
               this.itemType = newItemType;
               this.itemType.AddInventoryItem(this);
            }
         }
      }
   
      private uint Id;
      private int Name;
      private uint Price;
      private string Unit;
   
   }
}