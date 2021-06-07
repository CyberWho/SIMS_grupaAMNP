/***********************************************************************
 * Module:  AllergyTypeController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AllergyTypeController
 ***********************************************************************/

using System;
using Hospital.Model;
using System.Collections.ObjectModel;
using Hospital.Repository;

namespace Hospital.Controller
{
    public class AllergyTypeController
    {
        public Service.AllergyTypeService allergyTypeService = new Service.AllergyTypeService(new AllergyTypeRepository());

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

        public AllergyType UpdateAllergyType(int allergyType)
        {
            // TODO: implement
            return null;
        }

        public AllergyType AddAllergyType(AllergyType allergyType)
        {
            // TODO: implement
            return null;
        }
        public AllergyType GetAllergyTypeByType(string type)
        {
            return this.allergyTypeService.GetAllergyTypeByType(type);
        }
        public ObservableCollection<AllergyType> GetAllMissingAllergyTypesByUserId(int userId)
        {
            return this.allergyTypeService.GetAllMissingAllergyTypesByUserId(userId);
        }
        public ObservableCollection<AllergyType> GetAllTypesByHealthRecordId(int id)
        {
            return this.allergyTypeService.GetAllTypesByHealthRecordId(id);
        }
        public AllergyType GetAllergyTypeById(int id)
        {
            return this.allergyTypeService.GetAllergyTypeById(id);
        }


    }
}