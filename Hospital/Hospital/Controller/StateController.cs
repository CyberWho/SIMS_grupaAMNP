/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using Hospital.Repository;
using Hospital.Service;

namespace Hospital.Controller
{
    public class StateController
   {
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

      public StateService stateService = new StateService();

   }
}