namespace AbsolutelyAnonymousZF.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using AbsolutelyAnonymousZF.Data_Access;

    public class MonitorViewModel : BaseViewModel
    {
        private readonly IAdminList adminList;

        private readonly ICourseList courseList;

        private ICommand applyCommand;

        private string courses;

        private string password;

        public MonitorViewModel(IAdminList adminList, ICourseList courseList)
        {
            this.adminList = adminList;
            this.courseList = courseList;
            this.ConfigureDefaultCourses();
            this.SelectedCourses = new List<string>();
        }

        public ICommand ApplyCommand
        {
            get
            {
                if (this.applyCommand == null)
                {
                    this.applyCommand = new RelayCommand(param => this.Apply(), param => this.CanApply);
                }

                return this.applyCommand;
            }
        }

        public bool CanApply
        {
            get
            {
                return true;
            }
        }

        public string Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
                this.OnPropertyChanged(nameof(this.Courses));
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
                if (this.password != value)
                {
                    this.password = value;
                    this.OnPropertyChanged(nameof(Password));
                    this.OnPasswordChange(value);
                }
            }
        }

        public event EventHandler<PasswordEventArgs> PasswordChange;

        public IEnumerable<string> SelectedCourses { get; private set; }

        public void Apply()
        {
            // parse the input eg comma delimited list 
            // verify the password 
            // store the input 
            List<string> tempCourses = new List<string>();
            var allAdmins = this.adminList.GetAll();
            foreach (var admin in allAdmins)
            {
                if (admin.Password == this.Password && this.Password != null)
                {
                    var courseArray = this.Courses.Split(',');
                    foreach (var course in courseArray)
                    {
                        var allCourses = this.courseList.GetAll();
                        foreach (var existingCourse in allCourses)
                        {
                            if (course.Trim().ToLower() == existingCourse.Value.CourseName.Trim().ToLower())
                            {
                                tempCourses.Add(existingCourse.Value.CourseName);
                            }
                        }
                    }
                    this.SelectedCourses = tempCourses;
                    MessageBox.Show("Logged in as Administrator tracking " + tempCourses.Count + " course(s)");
                    return;
                }
            }
            
            MessageBox.Show("Access Denied");   
             
                   
        }

        private void ConfigureDefaultCourses()
        {
            var courses = this.courseList.GetAll();
            var courseNames = courses.Select(p => p.Value.CourseName);
            var defaultCourses = string.Join(",", courseNames);
            this.Courses = defaultCourses;
        }

        protected virtual void OnPasswordChange(String password)
        {
            this.PasswordChange?.Invoke(this, new PasswordEventArgs { Password = password });
        }
    }

    public class PasswordEventArgs : EventArgs
    {
        public String Password { get; set; }
    }
}