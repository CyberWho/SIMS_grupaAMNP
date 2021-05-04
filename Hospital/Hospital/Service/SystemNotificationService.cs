/***********************************************************************
 * Module:  SystemNotificationService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.SystemNotificationService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Service
{
   public class SystemNotificationService
   {
      public SystemNotification GetSystemNotificationById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<SystemNotification> GetAllSystemNotificationsByUserId(int userId)
      {
            return systemNotificationRepository.GetAllSystemNotificationsByUserId(userId);
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
   
      public Repository.SystemNotificationRepository systemNotificationRepository = new Repository.SystemNotificationRepository();
   
   }
}