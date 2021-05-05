/***********************************************************************
 * Module:  RoleService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.RoleService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class RoleService
   {
      public Model.Role GetRoleById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Role GetRoleByRole(String role)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllRoles()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteRoleById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Model.Role UpdateRole(Model.Role role)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Role AddRole(Model.Role role)
      {
         // TODO: implement
         return null;
      }
   
      public Repository.RoleRepository roleRepository;
   
   }
}