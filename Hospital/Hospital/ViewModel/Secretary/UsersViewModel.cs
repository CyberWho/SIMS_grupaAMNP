using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using Hospital.View.Secretary;

namespace Hospital.ViewModel.Secretary
{
    class UsersViewModel : BindableBase
    {
        private UserController userController = new UserController();

        public ObservableCollection<User> users { get; set; }
        private User selectedUser;
        
        private string fnText;
        private string lnText;

        public MyICommand AddCommand { get; set; }
        public MyICommand OpenUser { get; set; }

        public UsersViewModel()
        {
            loadUsers();
            this.AddCommand = new MyICommand(Add_user);
            this.OpenUser = new MyICommand(Open_user, Can_open);
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OpenUser.RaiseCanExecuteChanged();
            }
        }

        public void loadUsers()
        {
            this.users = this.userController.GetAllUsers();
        }
        private bool Can_open()
        {
            return this.selectedUser != null;
        }

        private void onDelete()
        {
            this.userController.DeleteUserByUsername(selectedUser.Username);
            users.Remove(selectedUser);
        }
        private void Open_user()
        {
            Window s = new UserProfileView(selectedUser);
            s.Show();
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
        #endregion

        private void Add_user()
        {
            Window s = new UserProfileView(null);
            s.Show();
        }

    }
}
