/***********************************************************************
 * Module:  DrugStatus.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Model.DrugStatus
 ***********************************************************************/

namespace Hospital.Model
{
    /// Pending - upravnik je uneo lek i poslat je zahtev lekaru za approval
    public enum DrugStatus
   {
      APPROVED,
      REJECTED,
      PENDING
   
   }
}