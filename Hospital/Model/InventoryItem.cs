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
   
      public int Id;
      public int Name;
      public uint Price;
      public string Unit;
      public ItemType Type;
   
   }
}