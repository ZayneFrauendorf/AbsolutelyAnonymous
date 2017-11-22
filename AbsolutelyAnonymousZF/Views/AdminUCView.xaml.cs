namespace AbsolutelyAnonymousZF.Views
{
    using System.Windows;
    using System.Windows.Controls;

    using AbsolutelyAnonymousZF.ViewModels;

    /// <summary>
    ///     Interaction logic for AdminUCView.xaml
    /// </summary>
    public partial class AdminUCView : UserControl
    {
        public AdminUCView()
        {
            this.InitializeComponent();
        }

        public AdminViewModel ViewModel
        {
            get
            {
                return DataContext as AdminViewModel;
            }
            set
            {
                DataContext = value;
                this.PasswordBox.Password = value.Password;
            }
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as AdminViewModel;
            if (viewModel == null) return;

            if (viewModel.Password == this.PasswordBox.Password) return;
            viewModel.Password = this.PasswordBox.Password;
        }
    }
}