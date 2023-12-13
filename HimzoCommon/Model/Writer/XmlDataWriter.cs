using System.Xml.Serialization;

namespace HimzoCommon.Model.Writer
{
    public class XmlDataWriter : IDataWriter
    {
        private void CreateDirIfNotExisting(string path)
        {
            string directory = new FileInfo(path).Directory.FullName;
            bool exists = Directory.Exists(directory);
            if (!exists)
            {
                Directory.CreateDirectory(path);
            }
        }
        public void Write<T>(string path, T data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            CreateDirIfNotExisting(path);
            StreamWriter file = new StreamWriter(path);
            serializer.Serialize(file, data);
            file.Close();
        }
    }
}
