/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.PatientService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.ObjectModel;

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

        public Patient GetPatientByPatientId(int id)
        {
            Patient patient = this.patientRepository.GetPatientByPatientId(id);
            return patient;
        }
        public ObservableCollection<Patient> GetAllPatients()
        {
            return patientRepository.GetAllPatients();
        }

        public bool CheckIfPatientHasBeenLogedByPatientId(int patientId)
        {
            return patientRepository.CheckIfPatientHasBeenLogedByPatientId(patientId);
        }

        public void UpdateHasBeenLogedByPatientId(int patientId)
        {
            patientRepository.UpdateHasBeenLogedByPatientId(patientId);
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