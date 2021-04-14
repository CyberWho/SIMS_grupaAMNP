/***********************************************************************
 * Module:  Adress.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Adress
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Address
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public City City { get; set; }

        public Address(int id, string name, City city)
        {
            Id = id;
            Name = name;
            City = city;
        }

        public Address()
        {
        }
    }
}