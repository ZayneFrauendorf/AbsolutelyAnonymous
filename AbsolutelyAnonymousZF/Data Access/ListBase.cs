using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsolutelyAnonymousZF.Data_Access
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]
    public abstract class ListBase : IListBase
    {
        private readonly string fileName;

        protected ListBase(string fileName)
        {
            this.fileName = fileName;
        }

        protected string FileName
        {
            get
            {
                return this.fileName;
            }
        }

        public abstract void Save();

        protected virtual IList<T> LoadFromStorage<T>()
        {
            var location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
            var result = new List<T>();
            
            var serializer = new BinaryFormatter();
            if (File.Exists(location))
            {
                using (var stream = File.OpenRead(location))
                {
                    if (stream.Length > 0)
                    {
                        result= (List<T>)serializer.Deserialize(stream);
                    }
                }
            }
            return result;
        }

        protected void Save<T>(IEnumerable<T> data )
        {
            var location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }

            var fileLocation = Path.Combine(location, fileName);

            var serializer = new BinaryFormatter();

            using (var stream = File.OpenWrite(fileLocation))
            {
                serializer.Serialize(stream, data);
            }
        }

        void IListBase.Save<T>(IList<T> data)
        {
            throw new NotImplementedException();
        }
    }
}
