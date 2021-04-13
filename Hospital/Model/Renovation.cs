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
      public Boolean End()
      {
         // TODO: implement
         return null;
      }
   
      public int Id;
      public DateTime StartDate;
      public RenovationType Type;
      
      public Room room;
   
   }
}