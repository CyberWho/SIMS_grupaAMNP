/***********************************************************************
 * Module:  DoctorController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.DoctorController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
    public class DoctorController
    {
        public Hospital.Model.Doctor GetDoctorById(int id)
        {
            return doctorService.GetDoctorById(id);
        }
        public Doctor GetWorkHoursDoctorById(int id)
        {
            Doctor doctor = new Doctor();
            doctor = doctorService.GetWorkHoursDoctorById(id);
            return doctor;
        }


        public ObservableCollection<Doctor> GetAllDoctors()
        {
            return doctorService.GetAllDoctors();
        }

        public ObservableCollection<Doctor> GetAllDoctorsBySpecializationId(int specializationId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Doctor> GetAllGeneralPurposeDoctors()
        {
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            doctors = doctorService.GetAllGeneralPurposeDoctors();
            return doctors;
        }
        public Boolean DeleteDoctorById(int doctorId)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.Doctor UpdateDoctor(Hospital.Model.Doctor doctor)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Doctor AddDoctor(Hospital.Model.Doctor doctor)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Service.DoctorService doctorService = new Service.DoctorService();

    }
}