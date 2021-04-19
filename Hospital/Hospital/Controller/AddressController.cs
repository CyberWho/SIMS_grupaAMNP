/***********************************************************************
 * Module:  AddressController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AddressController
 ***********************************************************************/

using System;

using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
   public class AddressController
    {
        public AddressService addressService = new AddressService();
       
        public Address GetAddressByPatientId(int id)
        {
            return this.addressService.GetAddressByPatientId(id);
        }

        public Hospital.Model.Address AddAddress(Hospital.Model.Address address)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Address GetAddressById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAddressById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Address UpdateAddress(Hospital.Model.Address address)
      {
         // TODO: implement
         return null;
      }
   
   
   }
}