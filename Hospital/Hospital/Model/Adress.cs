/***********************************************************************
 * Module:  Adress.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Adress
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Adress
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String PostalCode { get; set; }
        public City City { get; set; }

    }
}