/***********************************************************************
 * Module:  Renovation.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Renovation
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Renovation
    {
        private DateTime StartDate { get; set; }
        public Room Room { get; set; }

        public RenovationType RenovationType;

        public int End()
        {
            // TODO: implement
            return 0;
        }

        public RenovationType GetRenovationType()
        {
            return RenovationType;
        }

        public void SetRenovationType(RenovationType newRenovationType)
        {
            if (this.RenovationType != newRenovationType)
            {
                if (this.RenovationType != null)
                {
                    RenovationType oldRenovationType = this.RenovationType;
                    this.RenovationType = null;
                    oldRenovationType.RemoveRenovation(this);
                }
                if (newRenovationType != null)
                {
                    this.RenovationType = newRenovationType;
                    this.RenovationType.AddRenovation(this);
                }
            }
        }


    }
}