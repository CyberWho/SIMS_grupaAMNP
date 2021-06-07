/***********************************************************************
 * Module:  CityController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.CityController
 ***********************************************************************/

using System;
using Hospital.Repository;
using Hospital.Service;

namespace Hospital.Controller
{
    public class CityController
   {
      public Model.City GetCityById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Model.City GetCityByName(String name)
      {
         // TODO: implement
         return null;
      }
      
      public Model.City AddCity(Model.City city)
      {
         // TODO: implement
         return null;
      }

      public Service.CityService cityService = new CityService(new CityRepository());

   }
}