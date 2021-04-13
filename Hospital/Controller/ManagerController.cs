/***********************************************************************
 * Module:  ManagerController.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Controller.ManagerController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class ManagerController
   {
      public Hospital.Model.Employee GetManagerInfo()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<InventoryItem> GetAllInventoryItems()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.InventoryItem CreateNewInventoryItem(Hospital.Model.InventoryItem newItem)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteInventoryItem(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.InventoryItem UpdateInventoryItem(Hospital.Model.InventoryItem item)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Employee> GetAllEmployees()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Employee CreateNewEmployee(Hospital.Model.Employee newEmployee)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteEmployee(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Employee UpdateEmployee(Hospital.Model.Employee employee)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Doctor CreateNewDoctor(Hospital.Model.Doctor newDoctor)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Doctor> GetAllDoctors()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ItemInRoom PutItemInRoom(int itemId, int sourceRoomId, int quantity)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.ReservedItem ScheduleItemInRoom()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Renovation CreateNewRenovation(Hospital.Model.Renovation newRenovation)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Renovation EndRenovation(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Room> GetAllRooms()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Room CreateNewRoom(Hospital.Model.Room newRoom)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteRoom(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Room UpdateRoom(Hospital.Model.Room room)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Renovation> GetAllRenovations()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<WorkHours> GetAllWorkHours()
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.WorkHours CreateNewWorkHours(Hospital.Model.WorkHours newWorkHours)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.WorkHours UpdateWorkHours(Hospital.Model.WorkHours workHours)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteWorkHoursForDoctor(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.InventoryItem OrderInventoryItems(int id, int quantity)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Drug CreateNewDrug(Hospital.Model.Drug newDrug)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Drug UpdateDrug(Hospital.Model.Drug drug)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Drug> GetAllPendingDrugs()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteDrug(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Drug> GetAllApprovedDrugs()
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.DrugService drugService;
      public Hospital.Service.DoctorService doctorService;
      public Hospital.Service.EmployeeService employeeService;
      public Hospital.Service.ItemInRoomService itemInRoomService;
      public Hospital.Service.InventoryItemService inventoryItemService;
      public Hospital.Service.ReservedItemService reservedItemService;
      public Hospital.Service.RenovationService renovationService;
      public Hospital.Service.RoomService roomService;
      public Hospital.Service.WorkHoursService workHoursService;
   
   }
}