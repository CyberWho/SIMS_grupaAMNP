/***********************************************************************
 * Module:  AllergyTypeService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AllergyTypeService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;


namespace Hospital.Service
{
    public class AllergyTypeService
    {
        public Hospital.Repository.AllergyTypeRepository allergyTypeRepository = new Repository.AllergyTypeRepository();



        public System.Collections.ArrayList GetAllAllergyTypes()
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

        public AllergyType GetAllergyTypeByType(string type)
        {
            return this.allergyTypeRepository.GetAllergyTypeByType(type);
        }
        public ObservableCollection<AllergyType> GetAllMissingAllergyTypesByUserId(int userId)
        {
            return this.allergyTypeRepository.GetAllMissingAllergyTypesByUserId(userId);
        }
        public ObservableCollection<AllergyType> GetAllTypesByHealthRecordId(int id)
        {
            return this.allergyTypeRepository.GetAllTypesByHealthRecordId(id);
        }
        public Hospital.Model.AllergyType GetAllergyTypeById(int id)
        {
            return this.allergyTypeRepository.GetAllergyTypeById(id);
        }


    }
}