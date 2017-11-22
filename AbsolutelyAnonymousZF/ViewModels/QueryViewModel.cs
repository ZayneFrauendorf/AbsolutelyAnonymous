namespace AbsolutelyAnonymousZF.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using AbsolutelyAnonymousZF.Data_Access;

    public class QueryViewModel : BaseViewModel
    {
        private readonly ICourseList courseListRepository;

        private ICommand addQueryCommand;

        private IEnumerable<KeyValuePair<string, Course>> courses;

        private Query model;

        private ICommand nextRequestCommand;

        private IQueryList repository;

        private Course selectedCourse;

        private int selectedIndex = -1;

        public QueryViewModel(IQueryList repository, ICourseList courseListRepository)
        {
            this.repository = repository;
            this.courseListRepository = courseListRepository;
        }

        public ICommand AddQueryCommand
        {
            get
            {
                // if (this.SelectedCourse.Value != null && this.Query != null)
                if (this.addQueryCommand == null)
                {
                    this.addQueryCommand = new RelayCommand(param => this.AddQuery(), param => this.CanAddQuery);
                }

                return this.addQueryCommand;
            }
        }

        public bool CanAddQuery
        {
            get
            {
                return true;
            }
        }

        public bool CanNextRequest
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<Course> Courses
        {
            get
            {
                if (this.courses == null)
                {
                    this.courses = this.courseListRepository.GetAll();
                }

                return this.courses.Select(course => course.Value);
            }
        }

        public Query Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
                this.OnPropertyChanged(nameof(this.Model));
            }
        }

        public ICommand NextRequestCommand
        {
            get
            {
                if (this.nextRequestCommand == null)
                {
                    this.nextRequestCommand = new RelayCommand(
                        param => this.NextRequest(), 
                        param => this.CanNextRequest);
                }

                return this.nextRequestCommand;
            }
        }

        private string query;
        public string Query
        {
            get
            {
                return this.query;
            }
            set
            {
                this.query = value;
                this.OnPropertyChanged(nameof(Query));
            }
        }

        public Course SelectedCourse
        {
            get
            {
                return this.selectedCourse;
            }

            set
            {
                this.selectedCourse = value;
                this.OnPropertyChanged(nameof(this.SelectedCourse));
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
                this.OnPropertyChanged(nameof(this.SelectedCourse));
            }
        }

        public void AddQuery()
        {
            if (this.SelectedCourse != null && this.Query != null)
            {
                var query = new Query(this.SelectedCourse, this.Query);
                this.repository.AddQuery(query);
                this.repository.Save();
                this.SelectedCourse = null;
                this.Query = null;
            }
            else
            {
                MessageBox.Show("Please ensure both fields are appropriately selected");
                return;
            }
        }

        public void NextRequest()
        {
            this.SelectedCourse = null;
            this.Query = null;
        }

        // public void GetFilteredFeedback()
        // {

        // }

        // public void RemoveQuery(int key)
        // {
        // this.query.Remove(key);

        // }
    }
}