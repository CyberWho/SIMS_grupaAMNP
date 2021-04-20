/***********************************************************************
 * Module:  SystemNotification.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.SystemNotification
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Hospital.Model
{
    public class SystemNotification
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public ObservableCollection<User> user;

        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<User> GetUser()
        {
            if (user == null)
                user = new ObservableCollection<User>();
            return user;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetUser(System.Collections.ArrayList newUser)
        {
            RemoveAllUser();
            foreach (User oUser in newUser)
                AddUser(oUser);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddUser(User newUser)
        {
            if (newUser == null)
                return;
            if (this.user == null)
                this.user = new ObservableCollection<User>();
            if (!this.user.Contains(newUser))
                this.user.Add(newUser);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveUser(User oldUser)
        {
            if (oldUser == null)
                return;
            if (this.user != null)
                if (this.user.Contains(oldUser))
                    this.user.Remove(oldUser);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllUser()
        {
            if (user != null)
                user.Clear();
        }

        public SystemNotification(int id, string name, string description, ObservableCollection<User> user)
        {
            Id = id;
            Name = name;
            Description = description;
            this.user = user;
        }

        public SystemNotification(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public SystemNotification()
        {
        }
    }
}