namespace AbsolutelyAnonymousZF.Data_Access
{
    using System.Collections.Generic;

    public interface IQueryList : IListBase
    {
        IEnumerable<Query> GetAll();

        void AddQuery(Query query);

        void Delete(int id);
    }
}