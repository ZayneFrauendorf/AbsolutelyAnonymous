namespace AbsolutelyAnonymousZF.Data_Access
{
    using System.Collections.Generic;

    public interface IListBase
    {
        void Save<T>(IList<T> data);

        void Save();
    }
}