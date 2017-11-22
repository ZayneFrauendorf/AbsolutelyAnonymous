namespace AbsolutelyAnonymousZF.ViewModels
{
    using System.Windows;
    using System.Windows.Input;

    using AbsolutelyAnonymousZF.Data_Access;

    public class AdminAddUserWindowViewModel : BaseViewModel
    {
        private readonly IAdminList adminList;

        private ICommand addUserCommand;

        private Admin admin;

        private string password;

        private string userName;

        public AdminAddUserWindowViewModel(IAdminList adminList)
        {
            this.adminList = adminList;
        }

        public ICommand AddUserCommand
        {
            get
            {
                if (this.addUserCommand == null)
                {
                    this.addUserCommand = new RelayCommand(param => this.AddUser(), param => this.CanAddUser);
                }

                return this.addUserCommand;
            }
        }

        public Admin Admin
        {
            get
            {
                return this.admin;
            }

            set
            {
                this.admin = value;
                this.OnPropertyChanged(nameof(this.Admin));
            }
        }

        public bool CanAddUser
        {
            get
            {
                return true;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
                this.OnPropertyChanged(nameof(this.Password));
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                this.userName = value;
                this.OnPropertyChanged(nameof(this.UserName));
            }
        }

        public void AddUser()
        {
            if (this.Admin == null)
            {
                var newAdmin = new Admin(this.UserName, this.Password);
                if (string.IsNullOrEmpty(newAdmin.Username) || string.IsNullOrEmpty(newAdmin.Password))
                {
                    MessageBox.Show("Please enter the appropriate information");
                }
                else
                {
                    this.adminList.AddAdmin(newAdmin);
                    this.adminList.Save();
                    this.UserName = null;
                    this.Password = null;
                    MessageBox.Show("Added");

                }
            }
        }
    }
}