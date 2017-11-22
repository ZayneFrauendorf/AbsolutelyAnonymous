namespace AbsolutelyAnonymousZF.Data_Access
{
    using System.Collections.Generic;

    public interface ICourseList : IListBase
    {
        IEnumerable<KeyValuePair<string, Course>> GetAll();
        Dictionary<string, Course> Courses { get; }
        void AddCourse(Course aCourse);
    }
}