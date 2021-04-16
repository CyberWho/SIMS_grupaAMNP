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
      public Hospital.Model.InventoryItem GetInventoryItemById(int id)
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
   
      public Hospital.Service.InventoryItemService inventoryItemService;
   
   }
}