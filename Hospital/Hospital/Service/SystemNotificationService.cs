/***********************************************************************
 * Module:  SystemNotificationService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.SystemNotificationService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class SystemNotificationService
    {
        private ISystemNotificationRepo<SystemNotification> systemNotificationRepository;

        public SystemNotificationService()
        {
            systemNotificationRepository = new SystemNotificationRepository();
        }

        public ObservableCollection<SystemNotification> GetAllSystemWideSystemNotifications()
        {
            return this.systemNotificationRepository.GetAllSystemWideSystemNotifications();
        }

        public SystemNotification GetSystemNotificationById(int id)
        {
            return this.systemNotificationRepository.GetById(id);
        }

        public ObservableCollection<SystemNotification> GetAllSystemNotificationsByUserId(int userId)
        {
            return systemNotificationRepository.GetAllByUserId(userId);
        }

        public Boolean DeleteSystemNotificationById(int id)
        {
            return this.systemNotificationRepository.DeleteById(id);
        }

        public Boolean DeleteAllSystemNotificationsByUserId(int userId)
        {
            // TODO: implement
            return false;
        }

        public SystemNotification UpdateSystemNotification(SystemNotification systemNotification)
        {
            return this.systemNotificationRepository.Update(systemNotification);
        }

        public SystemNotification AddSystemNotification(SystemNotification systemNotification)
        {
            return this.systemNotificationRepository.Add(systemNotification);
        }


    }
}