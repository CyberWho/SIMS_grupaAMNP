/***********************************************************************
 * Module:  Adress.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Adress
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int city_id { get; set; }
        public String Name { get; set; }

        public City City { get; set; }

        public Address(int id, string name, City city)
        {
            Id = id;
            Name = name;
            City = city;
        }
        public Address(int id, int city_id, string name)
        {
            Id = id;
            this.city_id = city_id;
            Name = name;
            City = null;
        }

        public Address()
        {
        }
    }
}