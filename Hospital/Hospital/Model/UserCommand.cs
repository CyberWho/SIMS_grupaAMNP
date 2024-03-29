﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Controller;

namespace Hospital.Model
{
    public class UserCommand : ICommand
    {
        private User _user;
        private Action _action;
        
        public UserCommand(User user, Action action)
        {
            _user = user;
            _action = action;
            ExecuteAction();
        }

        public void ExecuteAction()
        {
            switch (_action)
            {
                case Action.ADD:
                    _user.CreateNewUser();
                    break;
                case Action.DELETE:
                    _user.DeleteUser();
                    break;
                case Action.UPDATE:
                    _user.UpdateUser();
                    break;
            }
        }
    }
}
