/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
   public class SystemNotificationsController
   {
      public SystemNotificationService systemNotificationService = new SystemNotificationService();
   
      public SystemNotification GetSystemNotificationById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<SystemNotification> GetAllSystemNotificationsByUserId(int userId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteSystemNotificationById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteAllSystemNotificationsByUserId(int userId)
      {
         // TODO: implement
         return false;
      }
      
      public SystemNotification UpdateSystemNotification(SystemNotification systemNotification)
      {
         // TODO: implement
         return null;
      }
      
      public SystemNotification AddSystemNotification(SystemNotification systemNotification)
      {
          return this.systemNotificationService.AddSystemNotification(systemNotification);
      }
   
   
   }
}