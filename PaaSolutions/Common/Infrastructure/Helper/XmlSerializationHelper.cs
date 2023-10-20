using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Common.Infrastructure.Helper
{
    public static class XmlSerializationHelper
    {
        public static string Serialize<T>(T value)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.NewLineHandling = NewLineHandling.Entitize;
            StringWriter stringWriter = new StringWriter();
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
            {
                xmlSerializer.Serialize(xmlWriter, value);
            }
            return stringWriter.GetStringBuilder().ToString();
        }

        public static T Deserialize<T>(string rawValue)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(rawValue);
            T value = (T)xmlSerializer.Deserialize(stringReader);
            return value;
        }
    }
}
