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
      public Role GetRoleById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Role GetRoleByRole(String role)
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
      
      public Role UpdateRole(Role role)
      {
         // TODO: implement
         return null;
      }
      
      public Role AddRole(Role role)
      {
         // TODO: implement
         return null;
      }
   
      public Service.RoleService roleService;
   
   }
}