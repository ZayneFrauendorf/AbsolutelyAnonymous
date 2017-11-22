namespace AbsolutelyAnonymousZF
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    using AbsolutelyAnonymousZF.Data_Access;

    public class CourseList : ListBase, ICourseList
    {
        public CourseList() : base("courses.bin")
        {
            this.Courses = new Dictionary<string, Course>();
            var data = this.LoadFromStorage<KeyValuePair<string, Course>>();
            foreach (var item in data)
            {
                Courses.Add(item.Key, item.Value);
            }
        }

        public void AddCourse(Course aCourse)
        {
            this.Courses.Add(aCourse.CourseKey, aCourse);
        }

        public Dictionary<string, Course> Courses { get; }

        public IEnumerable<KeyValuePair<string, Course>> GetAll()
        {
            return this.Courses;
        }

        public override void Save()
        {
            base.Save(this.Courses);
        }

        protected override IList<T> LoadFromStorage<T>()
        {
            var location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", this.FileName);
            var result = new Dictionary<string, Course>();

            var serializer = new BinaryFormatter();
            if (File.Exists(location))
            {
                using (var stream = File.OpenRead(location))
                {
                    if (stream.Length > 0)
                    {
                        result = (Dictionary<string, Course>)serializer.Deserialize(stream);
                    }
                }
            }
            return (IList<T>)result.ToList();
        }
    }
}