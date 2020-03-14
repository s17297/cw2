using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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
            string logtxt = null;


            Boolean checkStream(int len, string[] tab)
            {
                Boolean check = false;

                if (len != 9) {
                    check = true;
                }
                foreach (var kolumna in tab)
                {
                    if (kolumna == null || kolumna == "")
                    {
                        check = true;
                    }

                }

                if (!tab[6].Contains('@'))
                {
                    check = true;
                }

                Regex reg = new Regex("\\d{4}-\\d{2}-\\d{2}");
                Match match = reg.Match(tab[5]);
                if (!match.Success)
                {
                    check = true;
                }

                return check;
            }



            //FileStream logWriter = new FileStream(@"log.txt", FileMode.Create);
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] kolumny = line.Split(',');
                    if (checkStream(kolumny.Length, kolumny)==false)
                    {
                        licz++;

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
                        Console.WriteLine(licz);
                    }
                    else
                    {
                        logtxt += line + '\n';

                    }
                }
                Console.WriteLine(logtxt);
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
