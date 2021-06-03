using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.ViewModel.Secretary
{
    class UsersViewModel : BindableBase
    {
        private UserController userController = new UserController();

        public ObservableCollection<User> users { get; set; }
        private User selectedUser;

        private string usernameText;
        private string fnText;
        private string lnText;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }

        public UsersViewModel()
        {
            loadUsers();
            DeleteCommand = new MyICommand(onDelete, canDelete);
            AddCommand = new MyICommand(onAdd);
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public void loadUsers()
        {
            this.users = this.userController.GetAllUsers();
        }

        private bool canDelete()
        {
            return SelectedUser != null;
        }

        private void onDelete()
        {
            this.userController.DeleteUserByUsername(selectedUser.Username);
            users.Remove(selectedUser);
        }

        #region binding attributes
        public string FNText
        {
            get { return fnText; }
            set
            {
                if (fnText != value)
                {
                    fnText = value;
                    OnPropertyChanged("FNText");
                }
            }
        }

        public string LNText
        {
            get { return lnText; }
            set
            {
                if (lnText != value)
                {
                    lnText = value;
                    OnPropertyChanged("LNText");
                }
            }
        }

        public string UNText
        {
            get { return usernameText; }
            set
            {
                if (usernameText != value)
                {
                    usernameText = value;
                    OnPropertyChanged("UNText");
                }
            }
        }
        #endregion

        private void onAdd()
        {
            users.Add(new User { Name = FNText, Surname = LNText });
        }

    }
}
