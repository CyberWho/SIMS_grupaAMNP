/***********************************************************************
 * Module:  State.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.State
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class State
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public State(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public State()
        {
        }
    }
}