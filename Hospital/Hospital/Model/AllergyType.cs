/***********************************************************************
 * Module:  AllergyType.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Model.AllergyType
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class AllergyType : IEntity
    {
        public int Id { get; set; }
        public String Type { get; set; }

        public AllergyType(int id, string type)
        {
            Id = id;
            Type = type;
        }

        public AllergyType()
        {
        }
    }
}