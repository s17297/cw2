using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using cw2.Models;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Dane/dane.csv";
            Console.WriteLine("Hello World!");

            //wczytywanie
            var fi = new FileInfo(path);
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            //stream.Dispose

            //xml
            var list = new List<Student>();
            var st = new Student
            {
                imie = "jan",
                nazwisko = "kowalski",
                email = "d@onet.pl"

            };
            list.Add(st);
            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, list);
                writer.Dispose();
        }
    }
}
