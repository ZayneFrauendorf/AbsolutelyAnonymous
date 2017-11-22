namespace AbsolutelyAnonymousZF.ViewModels
{
    using System.Collections.Generic;

    using AbsolutelyAnonymousZF.Data_Access;

    public class ListViewModel
    {
        private readonly IQueryList queryList;

        public ListViewModel(IQueryList queryList)
        {
            this.queryList = queryList;
        }

        public IEnumerable<Query> AllQueries
        {
            get
            {
               return this.queryList.GetAll(); 
            }
        }
    }
}