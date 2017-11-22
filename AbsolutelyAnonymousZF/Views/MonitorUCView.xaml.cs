namespace AbsolutelyAnonymousZF.Views
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    using AbsolutelyAnonymousZF.ViewModels;

    /// <summary>
    ///     Interaction logic for MonitorUCView.xaml
    /// </summary>
    public partial class MonitorUCView : UserControl
    {
        public MonitorViewModel ViewModel
        {
            get
            {
                return DataContext as MonitorViewModel;
            }
            set
            {
                DataContext = value;
                this.PasswordBox.Password = value.Password;
            }
        }

        public MonitorUCView()
        {
            this.InitializeComponent();

            //this.DataContextChanged += HandleDataContextChange;
        }

        //private void HandleDataContextChange(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    INotifyPropertyChanged dataContext = e.NewValue as INotifyPropertyChanged;
        //    if (dataContext == null) return;

        //    dataContext.PropertyChanged += HandlePropertyChanged;
        //}

        //private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == "Password")
        //    {
        //        var dataContext = DataContext as MonitorViewModel;
        //        if (this.PasswordBox.Password != dataContext?.Password)
        //        {
        //            this.PasswordBox.Password = dataContext?.Password ?? this.PasswordBox.Password;
        //        }
        //    }
        //}

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MonitorViewModel;
            if (viewModel == null) return;

            if (viewModel.Password == this.PasswordBox.Password) return;
            viewModel.Password = this.PasswordBox.Password;
        }
    }
}