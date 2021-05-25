/***********************************************************************
 * Module:  DoctorController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.DoctorController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Hospital.Model;

namespace Hospital.Controller
{
    public class DoctorController
    {
        public Doctor GetDoctorById(int id)
        {
            return doctorService.GetDoctorById(id);
        }

        public Hospital.Model.Doctor GetDoctorByUserId(int id)
        {
            return doctorService.GetDoctorByUserId(id);
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
            return this.doctorService.GetAllDoctorsBySpecializationId(specializationId);
        }

        public ObservableCollection<Doctor> GetAllGeneralPurposeDoctors()
        {
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            doctors = doctorService.GetAllGeneralPurposeDoctors();
            return doctors;
        }
        public Boolean DeleteDoctorById(int doctorId)
        {
            return this.doctorService.DeleteDoctorById(doctorId);
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return this.doctorService.UpdateDoctor(doctor);
        }

        public Doctor AddDoctor(Doctor doctor, string specialization)
        {
            return this.doctorService.AddDoctor(doctor, specialization);
        }

        public Service.DoctorService doctorService = new Service.DoctorService();

    }
}