namespace AbsolutelyAnonymousZF.ViewModels
{
    using System;
    using System.Windows;

    using AbsolutelyAnonymousZF.Data_Access;
    using AbsolutelyAnonymousZF.Views;

    public class AdminViewModel :BaseViewModel
    {
        private readonly ICourseList courseList;

        private readonly IAdminList adminList;

 
        private int selectedIndex = -1;

        public AdminViewModel(ICourseList courseList, IAdminList adminList)
        {
            this.courseList = courseList;
            this.adminList = adminList;
        }

        private string selectedAction;

        public string SelectedAction
        {
            get { return selectedAction; }
            set
            {
                selectedAction = value;
                if (!this.IsLoggedIn())
                {
                    MessageBox.Show("Not logged in");
                }
                else
                {
                    if (this.selectedAction == "Add Course")
                    {
                        this.ShowAdminDialog();
                    }
                    else
                    {
                        if (this.selectedAction == "Add User")
                        {
                            this.ShowUserDialog();
                        }
                    }       
                          
                }
                this.OnPropertyChanged(nameof(SelectedAction));
                
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }
            set
            {
                this.selectedIndex = value;
                this.OnPropertyChanged(nameof(this.SelectedIndex));
                this.OnPropertyChanged(nameof(this.SelectedAction));
            }
        }

        public void ShowAdminDialog()
        {
            var view = new AdminAddCourseWindow();
            var viewModel = new AdminAddCourseWindowViewModel(this.courseList);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        public void ShowUserDialog()
        {
            var view = new AdminAddUserWindow();
            var viewModel = new AdminAddUserWindowViewModel(this.adminList);
            view.DataContext = viewModel;
            view.ShowDialog();
        }

        public bool IsLoggedIn()
        {
            
            var allAdmins = this.adminList.GetAll();
            foreach (var admin in allAdmins)
            {
                if (admin.Password == this.Password && this.Password != null)
                {
                    return true;
                }            
            }
            return false;
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.OnPropertyChanged(nameof(Password));
                    this.OnPasswordChange(value);
                }
            }   
        }

        public event EventHandler<PasswordEventArgs> PasswordChange;

        protected virtual void OnPasswordChange(String password)
        {
            this.PasswordChange?.Invoke(this, new PasswordEventArgs { Password = password });
        }

    }
}