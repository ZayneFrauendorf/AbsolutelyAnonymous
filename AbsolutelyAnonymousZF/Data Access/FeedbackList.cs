using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsolutelyAnonymousZF.Data_Access
{
    public class FeedbackList
    {
        private IList<Course> feedbackCourses;
        public FeedbackList()
        {
            this.feedbackCourses = new List<Course>();
        }

        public IEnumerable<Course> FeedBackList
        {
            get
            {
                return this.feedbackCourses;
            }
        }

        public void AddQuery(Course aCourse)
        {

            this.feedbackCourses.Add(aCourse);
        }

        public IEnumerable<Course> GetAll()
        {
            return this.FeedBackList;
        }
    }
}
