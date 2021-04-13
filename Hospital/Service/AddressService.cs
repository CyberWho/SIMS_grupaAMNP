/***********************************************************************
 * Module:  AddressService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AddressService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
    public class AddressService
    {
        public Hospital.Repository.AddressRepository addressRepository;


        public Hospital.Model.Address AddAddress(Hospital.Model.Address address)
        {
            // TODO: implement
            return addressRepository.NewAddrress(address);
        }

        public Hospital.Model.Address GetAddressById(int id)
        {
            // TODO: implement
            return addressRepository.GetAddressById(id);
        }

        public Boolean DeleteAddressById(int id)
        {
            // TODO: implement
            return addressRepository.DeleteAddressById(id);
        }

        public Hospital.Model.Address UpdateAddress(Hospital.Model.Address address)
        {
            // TODO: implement
            return null;
        }


    }
}