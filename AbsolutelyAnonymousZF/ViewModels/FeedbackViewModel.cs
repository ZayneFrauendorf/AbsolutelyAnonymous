namespace AbsolutelyAnonymousZF.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;

    using AbsolutelyAnonymousZF.Data_Access;

    public class FeedbackViewModel : BaseViewModel
    {
        private readonly MonitorViewModel monitorViewModel;

        private readonly IQueryList queryList;

        private Query selectedItem;

        private ObservableCollection<Query> filteredQueries;

        public FeedbackViewModel(IQueryList queryList, MonitorViewModel monitorViewModel)
        {
            this.queryList = queryList;
            this.monitorViewModel = monitorViewModel;
            this.filteredQueries = new ObservableCollection<Query>();
        }

        public ObservableCollection<Query> FilteredQueries
        {
            get
            {
                //if (this.filteredQueries.Count == 0)
                //{
                     this.GetFilteredQueries(this.monitorViewModel.SelectedCourses);
                //}
                return this.filteredQueries;
            }
            private set
            {
                this.filteredQueries = value;
            }
        }

        public Query SelectedItem
        {
            get
            {
                return this.selectedItem;
            }

            set
            {
                this.selectedItem = value;              
                if (value != null)
                {
                    var reallyDelete = this.ConfirmDeletion();
                    if (reallyDelete == MessageBoxResult.Yes)
                    {
                        var query = FilteredQueries.FirstOrDefault(p => p.Qid == value.Qid);
                        FilteredQueries.Remove(query);

                        this.queryList.Delete(value.Qid);
                        this.queryList.Save();
                    }            
                }
                this.OnPropertyChanged(nameof(this.SelectedItem));
            }
        }

        private MessageBoxResult ConfirmDeletion()
        {
            var result = MessageBox.Show("Do you want to delete this?", "Confirm Deletion", MessageBoxButton.YesNo);
            return result;
        }

        private void GetFilteredQueries(IEnumerable<string> courses)
        {
            var result = new List<Query>();
            var allQueries = this.queryList.GetAll();
            foreach (var course in courses)
            {
                result.AddRange(allQueries.Where(p => p.Course.CourseName == course));
            }
            filteredQueries.Clear();
            foreach (var item in result)
            {
                filteredQueries.Add(item);
            }
        }
    }
}