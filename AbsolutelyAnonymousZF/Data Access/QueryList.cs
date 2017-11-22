namespace AbsolutelyAnonymousZF
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    using AbsolutelyAnonymousZF.Data_Access;

    [Serializable]
    public class QueryList : ListBase, IQueryList
    {
        private IList<Query> queries;

        public QueryList() :base ("queries.bin")
        {
            this.queries = LoadFromStorage<Query>();
        }

        public IEnumerable<Query> Queries
        {
            get
            {
                return this.queries;
            }
        }

        public void AddQuery(Query aQuery)
        {
            var id = 0;
            if (this.queries.Count > 0)
            {
                id = this.queries.Max(p => p.Qid) + 1;
            }
            aQuery.Qid = id;
            this.queries.Add(aQuery);
        }

        public IEnumerable<Query> GetAll()
        {
            return this.Queries;
        }

        public override void Save()
        {
            base.Save(this.queries);
        }

        public void Delete(int id)
        {
            var query = this.queries.FirstOrDefault(p => p.Qid == id);
            if (query != null)
            {
                this.queries.Remove(query);
            }
        }
    }
}