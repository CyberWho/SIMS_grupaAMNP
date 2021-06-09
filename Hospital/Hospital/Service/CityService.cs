/***********************************************************************
 * Module:  CityService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.CityService
 ***********************************************************************/

using System;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
   public class CityService
   {
       private ICityRepo<City> cityRepository;

       public CityService(ICityRepo<City> iCityRepo)
       {
           this.cityRepository = iCityRepo;
       }
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

   }
}