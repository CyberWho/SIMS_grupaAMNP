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
      public int End()
      {
         // TODO: implement
         return 0;
      }
   
      public Room room;
      public RenovationType renovationType;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public RenovationType GetRenovationType()
      {
         return renovationType;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newRenovationType</param>
      public void SetRenovationType(RenovationType newRenovationType)
      {
         if (this.renovationType != newRenovationType)
         {
            if (this.renovationType != null)
            {
               RenovationType oldRenovationType = this.renovationType;
               this.renovationType = null;
               oldRenovationType.RemoveRenovation(this);
            }
            if (newRenovationType != null)
            {
               this.renovationType = newRenovationType;
               this.renovationType.AddRenovation(this);
            }
         }
      }
   
      private DateTime StartDate;
   
   }
}