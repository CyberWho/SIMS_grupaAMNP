/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class SystemNotificationsController
   {
      public SystemNotification GetSystemNotificationById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<SystemNotification> GetAllSystemNotificationsByUserId(int userId)
      {

            return systemNotificationService.GetAllSystemNotificationsByUserId(userId);
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
         // TODO: implement
         return null;
      }

        public Service.SystemNotificationService systemNotificationService = new Service.SystemNotificationService();
   
   }
}