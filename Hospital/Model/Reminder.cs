/***********************************************************************
 * Module:  Reminder.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Reminder
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class Reminder
   {
      public int Id;
      public String Name;
      public String Description;
      public DateTime AlarmTime;
      
      public Patient patient;
   
   }
}