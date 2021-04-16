/***********************************************************************
 * Module:  InventoryItemController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.InventoryItemController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class InventoryItemController
   {
      public Hospital.Model.InventoryItem GetInventoryItemById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<InventoryItem> GetAllInventoryItems()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<InventoryItem> GetAllInvenotryItemsByItemTypeId(int itemTypeId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteInventoryItemById(int id)
      {
         // TODO: implement
         return null;
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
   
      public Hospital.Service.InventoryItemService inventoryItemService;
   
   }
}