using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QuestBookCreator
{
    [Serializable()]
    class Memento
    {
        static string path="";

        public void saveProject(Project pr, string s)
        {
            path = s;
            saveProject(pr);
        }

        public void saveProject(Project pr)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            Stream st = File.Open(path, FileMode.Create);
            serializer.Serialize(st, pr);
        }


        public Project loadProject(Stream st)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            Project pr = (Project)deserializer.Deserialize(st);
            return pr;
        }

        public Memento(string p)
        {
            path = p;
        }

        public Memento()
        {
            path = "";
        }

        public bool hasPath()
        {
            if (path == "") return false;
            return true;
        }


    }
}
