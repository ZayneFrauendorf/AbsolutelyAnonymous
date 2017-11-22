namespace AbsolutelyAnonymousZF
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Course
    {
        public Course(string name, string key)
        {
            this.CourseName = name;
            this.CourseKey = key;
        }

        public string CourseKey { get; set; }

        public string CourseName { get; set; }

        public override string ToString()
        {
            return this.CourseName;
        }
    }
}