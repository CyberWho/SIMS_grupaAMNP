using System;
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
        private UserAction _userAction;
        
        public UserCommand(User user, UserAction userAction)
        {
            _user = user;
            _userAction = userAction;
            ExecuteAction();
        }

        public void ExecuteAction()
        {
            switch (_userAction)
            {
                case UserAction.ADD:
                    _user.CreateNewUser();
                    break;
                case UserAction.DELETE:
                    _user.DeleteUser();
                    break;
                case UserAction.UPDATE:
                    _user.UpdateUser();
                    break;
            }
        }
    }
}
