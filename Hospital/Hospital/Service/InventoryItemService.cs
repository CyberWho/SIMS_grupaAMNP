/***********************************************************************
 * Module:  InventoryItemService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.InventoryItemService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Service
{
    public class InventoryItemService
    {
        public Model.InventoryItem GetInventoryItemById(int id)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllInventoryItems()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<InventoryItem> GetAllInvenotryItemsByItemTypeId(int itemTypeId)
        {
            return inventoryItemRepository.GetAllInvenotryItemsByItemTypeId(itemTypeId);
        }

        public Boolean DeleteInventoryItemById(int id)
        {
            // TODO: implement
            return false;
        }

        public Model.InventoryItem UpdateInventoryItem(Model.InventoryItem inventoryItem)
        {
            // TODO: implement
            return null;
        }

        public Model.InventoryItem AddInventoryItem(Model.InventoryItem inventoryItem)
        {
            return inventoryItemRepository.NewInventoryItem(inventoryItem);
        }

        public Repository.InventoryItemRepository inventoryItemRepository = new Repository.InventoryItemRepository();

    }
}