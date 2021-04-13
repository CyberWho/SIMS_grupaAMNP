/***********************************************************************
 * Module:  ClinicalTreatment.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.ClinicalTreatment
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class ClinicalTreatment
   {
      public int Id;
      public DateTime StartTime;
      public DateTime EndTime;
      
      public Room room;
      public HealthRecord healthRecord;
   
   }
}