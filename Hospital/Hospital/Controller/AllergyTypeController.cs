/***********************************************************************
 * Module:  AllergyTypeController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AllergyTypeController
 ***********************************************************************/

using System;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.Controller
{
    public class AllergyTypeController
    {
        public Hospital.Service.AllergyTypeService allergyTypeService = new Service.AllergyTypeService();

        public ObservableCollection<AllergyType> GetAllTypesByUserId(int userId)
        {
            return this.allergyTypeService.GetAllTypesByUserId(userId);
        }

        public ObservableCollection<AllergyType> GetAllAllergyTypes()
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteAllergieTypeById(int id)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.AllergyType UpdateAllergyType(int allergyType)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.AllergyType AddAllergyType(Hospital.Model.AllergyType allergyType)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.AllergyType GetAllergyTypeById(int id)
        {
            return this.allergyTypeService.GetAllergyTypeById(id);
        }


    }
}