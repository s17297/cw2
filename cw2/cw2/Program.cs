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

            var list = new List<Student>();
            //wczytywanie
            int licz = 0;
            var fi = new FileInfo(path);
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] kolumny = line.Split(',');
                    if (kolumny.Length == 9) {
                        licz++;
                    }
                    //Console.WriteLine(line);
                    var st = new Student
                    {
                        imie = kolumny[0],
                        nazwisko = kolumny[1],
                        email = kolumny[6],
                        dataUrodzenia = kolumny[5],
                        imieMatki = kolumny[7],
                        imieOjca = kolumny[8],
                        trybStudiow = kolumny[3],
                        kierunek = kolumny[2],
                        eska = "s" + kolumny[4]
                    };
                    list.Add(st);
                    Console.WriteLine(kolumny[8]);
                }
                Console.WriteLine(licz);
            }
            //stream.Dispose

            //xml


            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, list);
            writer.Dispose();
        
        }
    }
}
