/***********************************************************************
 * Module:  City.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.City
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String PostalCode { get; set; }

        public State State { get; set; }

        public City(int id, string name, string postalCode, State state)
        {
            Id = id;
            Name = name;
            PostalCode = postalCode;
            State = state;
        }

        public City()
        {
        }
    }
}