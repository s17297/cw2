using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.Models
{
    public class Student
    {
        [XmlAttribute(AttributeName = "eska")] public string eska { get; set; }
        [XmlElement(ElementName = "fName")] public string imie { get; set; }
        [XmlElement(ElementName = "lName")] public string nazwisko { get; set; }
        [XmlElement(ElementName = "email")] public string email { get; set; }
        [XmlElement(ElementName = "dOfBirth")] public string dataUrodzenia { get; set; }
        [XmlElement(ElementName = "mothersName")] public string imieMatki { get; set; }
        [XmlElement(ElementName = "fathersName")] public string imieOjca { get; set; }
        [XmlElement(ElementName = "mode")] public string trybStudiow { get; set; }
        [XmlElement(ElementName = "name")] public string kierunek { get; set; }

    }
}
