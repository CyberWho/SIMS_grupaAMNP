/***********************************************************************
 * Module:  PatientController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.PatientController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class PatientController
    {
        public PatientService patientService = new PatientService();

        public Patient GetPatientByUserId(int id)
        {
            return this.patientService.GetPatientByUserId(id);
        }
        public Hospital.Model.Patient GetPatientById(int id)
        {
            return this.patientService.GetPatientById(id);
        }

        public Hospital.Model.Patient GetPatientByPatientId(int id)
        {
            Patient patient = this.patientService.GetPatientByPatientId(id);
            return patient;
        }

        public ObservableCollection<Patient> GetAllPatients()
        {
            return patientService.GetAllPatients();
        }

        public ObservableCollection<Patient> GetAllPatientsByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeletePatientById(int id)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.Patient UpdatePatient(Hospital.Model.Patient patient)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Patient RegisterPatient(Hospital.Model.Patient patient)
        {
            // TODO: implement
            return null;
        }


    }
}