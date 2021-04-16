/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class RoleController
   {
      public Hospital.Model.Role GetRoleById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Role GetRoleByRole(String role)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Role> GetAllRoles()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteRoleById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Role UpdateRole(Hospital.Model.Role role)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Role AddRole(Hospital.Model.Role role)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.RoleService roleService;
   
   }
}