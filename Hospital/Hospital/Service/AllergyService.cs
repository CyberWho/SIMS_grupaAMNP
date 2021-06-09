/***********************************************************************
 * Module:  AllergyService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AllergyService
 ***********************************************************************/

using Hospital.Model;
using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Repository;

namespace Hospital.Service
{
    public class AllergyService
    {
        private IAllergyRepo<Allergy> allergyRepository;

        public AllergyService(IAllergyRepo<Allergy> iAllergyRepo)
        {
            allergyRepository = iAllergyRepo;
        }
        public ObservableCollection<Allergy> GetAllAllergiesByUserId(int userId)
        {
            return this.allergyRepository.GetAllByUserId(userId);
        }
        public Boolean DeleteAllergyByUserIdAndAllergyTypeId(int userId, int atId)
        {
            return this.allergyRepository.DeleteByUserIdAndAllergyTypeId(userId, atId);
        }

        public Allergy AddAllergy(Allergy allergy)
        {
            return this.allergyRepository.Add(allergy);
        }

        public System.Collections.ArrayList GetAllergiesByTypeId(int allergyTypeId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Allergy> GetAllAllergiesByHealthRecordId(int healthRecordId)
        {
            return allergyRepository.GetAllByHealthRecordId(healthRecordId);
        }

        public Boolean DeleteAllergyById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllergiesByHealthRecordId(int healthRecordId)
        {
            // TODO: implement
            return false;
        }

        public Allergy UpdateAllergy(Allergy allergy)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllAllergies()
        {
            // TODO: implement
            return null;
        }


    }
}