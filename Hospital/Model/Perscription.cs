/***********************************************************************
 * Module:  Perscription.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Perscription
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class Perscription
   {
      public int Id;
      public Boolean IsActive;
      public String Description;
      
      public Drug drug;
      public Anamnesis anamnesis;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Anamnesis GetAnamnesis()
      {
         return anamnesis;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newAnamnesis</param>
      public void SetAnamnesis(Anamnesis newAnamnesis)
      {
         if (this.anamnesis != newAnamnesis)
         {
            if (this.anamnesis != null)
            {
               Anamnesis oldAnamnesis = this.anamnesis;
               this.anamnesis = null;
               oldAnamnesis.RemovePerscriptions(this);
            }
            if (newAnamnesis != null)
            {
               this.anamnesis = newAnamnesis;
               this.anamnesis.AddPerscriptions(this);
            }
         }
      }
   
   }
}