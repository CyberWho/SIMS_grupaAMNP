/***********************************************************************
 * Module:  RenovationType.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.RenovationType
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class RenovationType
    {
        private string Type { get; set; }

        public System.Collections.ArrayList renovation;

        public System.Collections.ArrayList GetRenovation()
        {
            if (renovation == null)
                renovation = new System.Collections.ArrayList();
            return renovation;
        }

        public void SetRenovation(System.Collections.ArrayList newRenovation)
        {
            RemoveAllRenovation();
            foreach (Renovation oRenovation in newRenovation)
                AddRenovation(oRenovation);
        }

        public void AddRenovation(Renovation newRenovation)
        {
            if (newRenovation == null)
                return;
            if (this.renovation == null)
                this.renovation = new System.Collections.ArrayList();
            if (!this.renovation.Contains(newRenovation))
            {
                this.renovation.Add(newRenovation);
                newRenovation.SetRenovationType(this);
            }
        }

        public void RemoveRenovation(Renovation oldRenovation)
        {
            if (oldRenovation == null)
                return;
            if (this.renovation != null)
                if (this.renovation.Contains(oldRenovation))
                {
                    this.renovation.Remove(oldRenovation);
                    oldRenovation.SetRenovationType((RenovationType)null);
                }
        }

        public void RemoveAllRenovation()
        {
            if (renovation != null)
            {
                System.Collections.ArrayList tmpRenovation = new System.Collections.ArrayList();
                foreach (Renovation oldRenovation in renovation)
                    tmpRenovation.Add(oldRenovation);
                renovation.Clear();
                foreach (Renovation oldRenovation in tmpRenovation)
                    oldRenovation.SetRenovationType((RenovationType)null);
                tmpRenovation.Clear();
            }
        }


    }
}