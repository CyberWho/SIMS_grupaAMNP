/***********************************************************************
 * Module:  StateService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.StateService
 ***********************************************************************/

using System;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
   public class StateService
   {
       public StateService()
       {
           this.stateRepository = new StateRepository();
       }
      public Model.State GetStateById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Model.State GetStateByName(String name)
      {
         // TODO: implement
         return null;
      }
      
      public Model.State AddState(Model.State state)
      {
         // TODO: implement
         return null;
      }

      private IStateRepo<State> stateRepository;

   }
}