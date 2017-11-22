namespace AbsolutelyAnonymousZF
{
    using System;

    [Serializable]
    public class Query
    {
        public Course Course { get; set; }

        public string Description { get; set; }

        public int Qid { get; set; }

        public Query(Course course, string description)
        {
            this.Course = course;
            this.Description = description;
        }
    }
}