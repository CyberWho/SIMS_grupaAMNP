/***********************************************************************
 * Module:  City.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.City
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class City
   {
        public int Id { get; set; }

        public String Name { get; set; }
        public String PostalCode { get; set; }

        public State state { get; set; }

    }
}