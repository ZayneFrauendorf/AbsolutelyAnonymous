namespace AbsolutelyAnonymousZF.ViewModels
{
    using System.Windows.Controls;
    using System.Windows.Input;

    using AbsolutelyAnonymousZF.Views;

    public class MainWindowViewModel : BaseViewModel
    {
        private AboutViewModel aboutViewModel;

        private AdminList adminList;

        private AdminViewModel adminViewModel;

        private CourseList courseList;

        private UserControl currentView;

        private FeedbackViewModel feedbackViewModel;

        private ListViewModel listViewModel;

        private MonitorViewModel monitorViewModel;

        private QueryList queryList;

        private QueryViewModel queryViewModel;

        private ICommand showAboutUcCommand;

        private ICommand showAdminUcCommand;

        private ICommand showFeedbackUcCommand;

        private ICommand showListUcCommand;

        private ICommand showMonitorUcCommand;

        private ICommand showQueryUCCommand;

        public MainWindowViewModel()
        {
            this.CreateViewModelDependencies();
            this.CreateViewModels();
        }

        public bool CanShowAbout
        {
            get
            {
                return true;
            }
        }

        public bool CanShowAdmin
        {
            get
            {
                return true;
            }
        }

        public bool CanShowFeedback
        {
            get
            {
                return true;
            }
        }

        public bool CanShowList
        {
            get
            {
                return true;
            }
        }

        public UserControl CurrentView
        {
            get
            {
                return this.currentView;
            }

            set
            {
                this.currentView = value;
                this.OnPropertyChanged(nameof(this.CurrentView));
            }
        }

        public ICommand ShowAboutUcCommand
        {
            get
            {
                if (this.showAboutUcCommand == null)
                {
                    this.showAboutUcCommand = new RelayCommand(param => this.ShowAbout(), param => this.CanShowAbout);
                }

                return this.showAboutUcCommand;
            }
        }

        public ICommand ShowAdminUcCommand
        {
            get
            {
                if (this.showAdminUcCommand == null)
                {
                    this.showAdminUcCommand = new RelayCommand(param => this.ShowAdmin(), param => this.CanShowAdmin);
                }

                return this.showAdminUcCommand;
            }
        }

        public ICommand ShowFeedbackUcCommand
        {
            get
            {
                if (this.showFeedbackUcCommand == null)
                {
                    this.showFeedbackUcCommand = new RelayCommand(
                        param => this.ShowFeedback(), 
                        param => this.CanShowFeedback);
                }

                return this.showFeedbackUcCommand;
            }
        }

        public ICommand ShowListUcCommand
        {
            get
            {
                if (this.showListUcCommand == null)
                {
                    this.showListUcCommand = new RelayCommand(param => this.ShowList(), param => this.CanShowList);
                }

                return this.showListUcCommand;
            }
        }

        public ICommand ShowMonitorUcCommand
        {
            get
            {
                if (this.showMonitorUcCommand == null)
                {
                    this.showMonitorUcCommand = new RelayCommand(
                        param => this.ShowMonitor(), 
                        param => this.CanShowMonitor);
                }

                return this.showMonitorUcCommand;
            }
        }

        public ICommand ShowQueryUCCommand
        {
            get
            {
                if (this.showQueryUCCommand == null)
                {
                    this.showQueryUCCommand = new RelayCommand(param => this.ShowQuery(), param => this.CanShowQuery);
                }

                return this.showQueryUCCommand;
            }
        }

        private bool CanShowMonitor
        {
            get
            {
                return true;
            }
        }

        private bool CanShowQuery
        {
            get
            {
                return true;
            }
        }

        public void ShowAbout()
        {
            var view = new AboutUCView();
            view.DataContext = this.aboutViewModel;
            this.CurrentView = view;
        }

        public void ShowMonitor()
        {
            var view = new MonitorUCView();

            // var viewModel = new MonitorViewModel(new AdminList(), new CourseList());
            view.ViewModel = this.monitorViewModel;
            this.CurrentView = view;
        }

        public void ShowQuery()
        {
            var view = new QueryUCView();

            // var viewModel = new QueryViewModel(new QueryList(), new CourseList());
            view.DataContext = this.queryViewModel;
            this.CurrentView = view;
        }

        private void CreateViewModelDependencies()
        {
            this.adminList = new AdminList();
            this.courseList = new CourseList();
            this.queryList = new QueryList();
        }

        private void CreateViewModels()
        {
            this.aboutViewModel = new AboutViewModel();
            this.monitorViewModel = new MonitorViewModel(this.adminList, this.courseList);
            this.queryViewModel = new QueryViewModel(this.queryList, this.courseList);
            this.adminViewModel = new AdminViewModel(this.courseList, this.adminList);
            this.feedbackViewModel = new FeedbackViewModel(this.queryList, this.monitorViewModel);
            this.listViewModel = new ListViewModel(this.queryList);
        }

        private void ShowAdmin()
        {
            var view = new AdminUCView();

            // var viewModel = new AdminViewModel(new CourseList(), new AdminList());
            view.ViewModel = this.adminViewModel;
            this.CurrentView = view;
        }

        private void ShowFeedback()
        {
            var view = new FeedbackUCView();

            // var viewModel = new FeedbackViewModel(new QueryList());
            view.DataContext = this.feedbackViewModel;
            this.CurrentView = view;
        }

        private void ShowList()
        {
            var view = new ListUCView();

            // var viewModel = new ListViewModel(new QueryList());
            view.DataContext = this.listViewModel;
            this.CurrentView = view;
        }
    }
}