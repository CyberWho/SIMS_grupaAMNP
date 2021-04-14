/***********************************************************************
 * Module:  SystemNotification.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.SystemNotification
 ***********************************************************************/

using System;
using System.Collections;

namespace Hospital.Model
{
    public class SystemNotification
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public System.Collections.ArrayList user;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetUser()
        {
            if (user == null)
                user = new System.Collections.ArrayList();
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
                this.user = new System.Collections.ArrayList();
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

        public SystemNotification(int id, string name, string description, ArrayList user)
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