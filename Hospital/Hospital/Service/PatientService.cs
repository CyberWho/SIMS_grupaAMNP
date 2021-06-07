/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.PatientService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;

namespace Hospital.Service
{
    public class PatientService
    {
        public IPatientRepo<Patient> patientRepository;

        public PatientService(IPatientRepo<Patient> iPatientRepo)
        {
            this.patientRepository = iPatientRepo;
        }
        public Patient GetPatientByUserId(int id)
        {
            return this.patientRepository.GetByUserId(id);
        }

        public Patient GetPatientById(int id)
        {
            return this.patientRepository.GetById(id);
        }

        public Patient GetPatientByPatientId(int id)
        {
            Patient patient = this.patientRepository.GetById(id);
            return patient;
        }
        public ObservableCollection<Patient> GetAllPatients()
        {
            return patientRepository.GetAll();
        }

        public bool CheckIfPatientHasBeenLogedByPatientId(int patientId)
        {
            return patientRepository.CheckIfPatientHasBeenLogedById(patientId);
        }

        public void UpdateHasBeenLogedByPatientId(int patientId)
        {
            patientRepository.UpdateHasBeenLogedById(patientId);
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