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
      public Hospital.Model.SystemNotification GetSystemNotificationById(int id)
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
      
      public Hospital.Model.SystemNotification UpdateSystemNotification(Hospital.Model.SystemNotification systemNotification)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.SystemNotification AddSystemNotification(Hospital.Model.SystemNotification systemNotification)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.SystemNotificationService systemNotificationService;
   
   }
}