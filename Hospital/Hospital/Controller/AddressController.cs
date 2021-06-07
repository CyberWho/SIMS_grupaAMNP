/***********************************************************************
 * Module:  AddressController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AddressController
 ***********************************************************************/

using System;
using Hospital.Model;
using Hospital.Repository;
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

        public Address AddAddress(Address address)
      {
         // TODO: implement
         return null;
      }
      
      public Address GetAddressById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAddressById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Address UpdateAddress(Address address)
      {
         // TODO: implement
         return null;
      }
   
   
   }
}