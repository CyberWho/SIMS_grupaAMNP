/***********************************************************************
 * Module:  RefferalForClinicalTreatmentController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.RefferalForClinicalTreatmentController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;

namespace Hospital.Controller
{
    public class RefferalForClinicalTreatmentController
    {
        public ObservableCollection<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatment()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatmentByPatientId(int patientId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatmentByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForClinicalTreatment> GetAllActiveReferralsForClinicalTreatmentByHealthRecordId(int healthRecordId)
        {
            return referralForClinicalTreatmentService.GetAllActiveReferralsForClinicalTreatmentByHealthRecordId(healthRecordId);
        }
        public ObservableCollection<ReferralForClinicalTreatment> GetAllReferralsForClinicalTreatmentByRoomId(int roomId)
        {
            // TODO: implement
            return null;
        }

        public ReferralForClinicalTreatment GetReferralForClinicalTreatmentById()
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteReferralForClinicalTreatmentById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteReferralForClinicalTreatmentByPatientId(int patientId)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteReferralForClinicalTreatmentByDoctorId(int doctorId)
        {
            // TODO: implement
            return false;
        }

        public ReferralForClinicalTreatment UpdateReferralForClinicalTreatment(ReferralForClinicalTreatment referralForClinicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public ReferralForClinicalTreatment AddReferralForClinicalTreatment(ReferralForClinicalTreatment referralForClinicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public ObservableCollection<ReferralForClinicalTreatment> GetAllActiveReferralsForClinicalTreatmentByPatientId(int patientId)
        {
            // TODO: implement
            return null;
        }

        public ReferralForClinicalTreatment DeactivateReferralForClinicalTreatment(ReferralForClinicalTreatment referralForClinicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public ReferralForClinicalTreatment ProlongReferralForClinicalTreatment(ReferralForClinicalTreatment referralForClinicalTreatment, DateTime newEndDate)
        {
            // TODO: implement
            return null;
        }

        public ReferralForClinicalTreatment ChangeRoomReferralForClinicalTreatment(ReferralForClinicalTreatment referralForClinicalTreatment, Room newRoom)
        {
            // TODO: implement
            return null;
        }

        public int GetMaxTakenBeds(int room_id, DateRange dateRange)
        {
            return referralForClinicalTreatmentService.GetMaxTakenBeds(room_id, dateRange);
        }

        public ClinicalTreatment createClinicalTreatment(ClinicalTreatment clinicalTreatment)
        {
            return referralForClinicalTreatmentService.createClinicalTreatment(clinicalTreatment);
        }


        public Service.ReferralForClinicalTreatmentService referralForClinicalTreatmentService = new ReferralForClinicalTreatmentService(new ReferralForClinicalTreatmentRepository());

    }
}