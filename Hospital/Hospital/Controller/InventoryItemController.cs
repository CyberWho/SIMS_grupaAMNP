/***********************************************************************
 * Module:  InventoryItemController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.InventoryItemController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class InventoryItemController
   {
      public InventoryItem GetInventoryItemById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<InventoryItem> GetAllInventoryItems()
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<InventoryItem> GetAllInvenotryItemsByItemTypeId(int itemTypeId)
      {
         return inventoryItemService.GetAllInvenotryItemsByItemTypeId(itemTypeId);
      }
      
      public Boolean DeleteInventoryItemById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public InventoryItem UpdateInventoryItem(InventoryItem inventoryItem)
      {
         // TODO: implement
         return null;
      }
      
      public InventoryItem AddInventoryItem(InventoryItem inventoryItem)
      {
         return inventoryItemService.AddInventoryItem(inventoryItem);
      }
   
      public Service.InventoryItemService inventoryItemService = new Service.InventoryItemService();
   
   }
}