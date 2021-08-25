using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MailSender
{
    public class XmlFileManager
    {
        public static void XmlDataWriter(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();
        }

        //Userdata xml reader
        public static Settings XmlUserDataReader(string filename)
        {
            Settings obj = new Settings();
            XmlSerializer xs = new XmlSerializer(typeof(Settings));
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            obj = (Settings)xs.Deserialize(reader);
            reader.Close();
            return obj;
        }
    }
}
