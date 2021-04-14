/***********************************************************************
 * Module:  InventoryItemRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.InventoryItemRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class InventoryItemRepository
   {
      public Hospital.Model.InventoryItem GetInventoryItemById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllInventoryItems()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllInvenotryItemsByItemTypeId(int itemTypeId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteInventoryItemById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.InventoryItem UpdateInventoryItem(Hospital.Model.InventoryItem inventoryItem)
      {
         // TODO: implement
         return null;
      }
      
      public InventoryItemRepository NewInventoryItem(Hospital.Model.InventoryItem inventoryItem)
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
   
   }
}