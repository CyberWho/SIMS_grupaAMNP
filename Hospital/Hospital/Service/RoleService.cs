/***********************************************************************
 * Module:  RoleService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.RoleService
 ***********************************************************************/

using System;
using Hospital.IRepository;
using Hospital.Model;

namespace Hospital.Service
{
   public class RoleService
   {
       public RoleService(IRoleRepo<Role> iRoleRepo)
       {
           roleRepository = iRoleRepo;
       }
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

      public IRoleRepo<Role> roleRepository;

   }
}