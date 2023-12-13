using System.Xml.Serialization;

namespace HimzoCommon.Reader
{
    public class XmlDataReader : IDataReader
    {
        public T Read<T>(string path)
        {
            StreamReader? reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(path);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
