/***********************************************************************
 * Module:  AllergyController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AllergyController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
    public class AllergyController
    {
        public Service.AllergyService allergyService = new Service.AllergyService();


        public ObservableCollection<Allergy> GetAllAllergiesByUserId(int userId)
        { 
            return this.allergyService.GetAllAllergiesByUserId(userId);
        }

        public Hospital.Model.Allergy AddAllergy(Hospital.Model.Allergy allergy)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Allergy> GetAllergiesByTypeId(int allergyTypeId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Allergy> GetAllAllergiesByHealthRecordId(int healthRecordId)
        {
            // TODO: implement
            return null;
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

        public Hospital.Model.Allergy UpdateAllergy(Hospital.Model.Allergy allergy)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Allergy> GetAllAllergies()
        {
            // TODO: implement
            return null;
        }

    }
}