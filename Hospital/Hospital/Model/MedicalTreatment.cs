/***********************************************************************
 * Module:  MedicalTreatment.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.MedicalTreatment
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   /// Period: 2 (na svaka dva sata treba da se pije lek)
   public class MedicalTreatment
   {
      public int Id { get; set; }
      public int Period { get; set; }
      public DateTime StartTime { get; set; }
      public DateTime EndTime { get; set; }
      public String Description { get; set; }
      
      public Drug Drug { get; set; }
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
               oldAnamnesis.RemoveMedicalTreatments(this);
            }
            if (newAnamnesis != null)
            {
               this.anamnesis = newAnamnesis;
               this.anamnesis.AddMedicalTreatments(this);
            }
         }
      }
   
   }
}