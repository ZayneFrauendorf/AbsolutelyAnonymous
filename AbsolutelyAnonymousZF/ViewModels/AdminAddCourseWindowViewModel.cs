namespace AbsolutelyAnonymousZF.ViewModels
{
    using System.Security.Policy;
    using System.Windows;
    using System.Windows.Input;

    using AbsolutelyAnonymousZF.Data_Access;

    public class AdminAddCourseWindowViewModel : BaseViewModel
    {
        private readonly ICourseList courseList;

        private Course course;

        public AdminAddCourseWindowViewModel(ICourseList courseList)
        {
            this.courseList = courseList;
        }

        private string cName;

        public string CName
        {
            get { return cName; }
            set
            {
                cName = value;
                this.OnPropertyChanged(nameof(CName));
            }
        }

        private string cKey;

        public string CKey
        {
            get { return cKey; }
            set { cKey = value;
                this.OnPropertyChanged(nameof(this.CKey)); }
        }

        public Course Course
        {
            get
            {
                return this.course;
            }

            set
            {
                this.course = value;
                this.OnPropertyChanged(nameof(this.Course));
            }
        }

        private ICommand addCourseCommand;


        public ICommand AddCourseCommand
        {
            get
            {
                if (this.addCourseCommand == null)
                {
                    this.addCourseCommand = new RelayCommand(param => this.AddCourse(), param => CanAddCourse);
                }
                return this.addCourseCommand;
            }
        }

        public void AddCourse()
        {
            if (this.Course == null)
            {
                var newCourse = new Course(this.CName, this.CKey);
                if (string.IsNullOrEmpty(newCourse.CourseKey) || string.IsNullOrEmpty(newCourse.CourseName))
                {
                    MessageBox.Show("Please enter the appropriate details");
                }
                else
                { 
                    this.courseList.AddCourse(newCourse);
                    this.courseList.Save();
                    this.CName = null;
                    this.CKey = null;
                    MessageBox.Show("Added");
                }
            }

        }

        public bool CanAddCourse
        {
            get
            {
                return true;
            }
        }
    }
}