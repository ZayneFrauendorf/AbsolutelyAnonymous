namespace AbsolutelyAnonymousZF.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using AbsolutelyAnonymousZF.Annotations;

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}