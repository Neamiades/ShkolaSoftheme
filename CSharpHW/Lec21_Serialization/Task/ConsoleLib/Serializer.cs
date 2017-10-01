using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleLib
{
    static class Serializer
    {
        public static void Serialize(List<Book> data, SerializeType type, string toFile)
        {
            var extn = GetExtn(type);
            using (FileStream fs = new FileStream($"{toFile}.{extn}", FileMode.Create))
            {
                switch (type)
                {
                    case SerializeType.Binary:
                        new BinaryFormatter().Serialize(fs, data);
                        return;
                    case SerializeType.Xml:
                        new XmlSerializer(typeof(List<Book>)).Serialize(fs, data);
                        return;
                    case SerializeType.Json:
                        new DataContractJsonSerializer(typeof(List<Book>)).WriteObject(fs, data);
                        return;
                    case SerializeType.Protobuf:
                        ProtoBuf.Serializer.Serialize(fs, data);
                        return;
                    default:
                        throw new ArgumentException("Wrong data type");
                }
            }
        }

        public static List<Book> Deserialize(SerializeType type, string fromFile)
        {
            var extn = GetExtn(type);
            using (FileStream fs = new FileStream($"{fromFile}.{extn}", FileMode.OpenOrCreate))
            {
                switch (type)
                {
                    case SerializeType.Binary:
                        return (List<Book>)new BinaryFormatter().Deserialize(fs);
                    case SerializeType.Xml:
                        return (List<Book>)new XmlSerializer(typeof(List<Book>)).Deserialize(fs);
                    case SerializeType.Json:
                        return (List<Book>)new DataContractJsonSerializer(typeof(List<Book>)).ReadObject(fs);
                    case SerializeType.Protobuf:
                        return ProtoBuf.Serializer.Deserialize<List<Book>>(fs);
                    default:
                        throw new ArgumentException("Wrong data type");
                }
            }
        }

        private static string GetExtn(SerializeType type)
        {
            return type == SerializeType.Binary ? "dat"
                : type == SerializeType.Json    ? "json"
                : type == SerializeType.Xml     ? "xml"
                : "bin";
        }
    }
}
