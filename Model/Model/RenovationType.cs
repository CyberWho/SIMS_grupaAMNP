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
      public System.Collections.ArrayList renovation;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetRenovation()
      {
         if (renovation == null)
            renovation = new System.Collections.ArrayList();
         return renovation;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetRenovation(System.Collections.ArrayList newRenovation)
      {
         RemoveAllRenovation();
         foreach (Renovation oRenovation in newRenovation)
            AddRenovation(oRenovation);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
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
      
      /// <pdGenerated>default Remove</pdGenerated>
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
      
      /// <pdGenerated>default removeAll</pdGenerated>
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
   
      private string Type;
   
   }
}