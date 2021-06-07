/***********************************************************************
 * Module:  AddressService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AddressService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository;
using System;
using Hospital.IRepository;

namespace Hospital.Service
{
   public class AddressService
   {
       private IAddressRepo<Address> addressRepository;

       public AddressService()
       {
           this.addressRepository = new AddressRepository();
       }
        public Address GetAddressByPatientId(int id)
        {
            return this.addressRepository.GetByPatientId(id);
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