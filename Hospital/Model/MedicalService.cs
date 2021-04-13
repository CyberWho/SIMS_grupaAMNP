/***********************************************************************
 * Module:  MedicalService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.MedicalService
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class MedicalService
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public String NameOfMedicalService { get; set; }

    }
}