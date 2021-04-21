/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.PatientService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository;
using System;
using Hospital.Model;

namespace Hospital.Service
{
    public class PatientService
    {
        public PatientRepository patientRepository = new PatientRepository();

        public Patient GetPatientByUserId(int id)
        {
            return this.patientRepository.GetPatientByUserId(id);
        }

        public Patient GetPatientById(int id)
        {
            return this.patientRepository.GetPatientById(id);
        }

        public System.Collections.ArrayList GetAllPatients()
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllPatientsByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeletePatientById(int id)
        {
            // TODO: implement
            return false;
        }

        public Patient UpdatePatient(Patient patient)
        {
            // TODO: implement
            return null;
        }

        public Patient RegisterPatient(Patient patient)
        {
            // TODO: implement
            return null;
        }


    }
}