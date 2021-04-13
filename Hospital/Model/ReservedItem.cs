/***********************************************************************
 * Module:  ReservedItem.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Model.ReservedItem
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class ReservedItem
   {
      public int Id;
      public DateTime ReservedDate;
      
      public Room room;
      public ItemInRoom itemInRoom;
   
   }
}