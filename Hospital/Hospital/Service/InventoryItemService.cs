/***********************************************************************
 * Module:  InventoryItemService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.InventoryItemService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class InventoryItemService
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
      
      public Hospital.Repository.InventoryItemRepository AddInventoryItem(Hospital.Model.InventoryItem inventoryItem)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.InventoryItemRepository inventoryItemRepository;
   
   }
}