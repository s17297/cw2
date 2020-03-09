using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.Models
{
    public class Student
    {
        //public string imie { get; set; }
        [XmlElement(ElementName = "InneNazwa")] public string imie { get; set; }
        //public string nazwisko { get; set; }

        [XmlAttribute(AttributeName = "InnaNazwa")] public string nazwisko { get; set; }
        //public string email { get; set; }
        [XmlAttribute(AttributeName = "InnaNazwa")] public string email { get; set; }


    }
}
