namespace AbsolutelyAnonymousZF.Data_Access
{
    using System.Collections.Generic;

    public interface IFeedbackList
    {
        IEnumerable<Course> FeedBackList { get; }

        IEnumerable<Course> GetAll();
    }
}