/***********************************************************************
 * Module:  SystemNotificationService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.SystemNotificationService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class SystemNotificationService
   {
      public Hospital.Model.SystemNotification GetSystemNotificationById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllSystemNotificationsByUserId(int userId)
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
   
      public Hospital.Repository.SystemNotificationRepository systemNotificationRepository;
   
   }
}