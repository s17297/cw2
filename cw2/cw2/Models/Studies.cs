using System;
using System.Xml.Serialization;

namespace cw2.Models
{
    [Serializable]
    [XmlTypeAttribute(typeName: "studies")]
    public class Studies
    {

        [XmlElement(ElementName = "mode")] public string trybStudiow { get; set; }
        [XmlElement(ElementName = "name")] public string kierunek { get; set; }


    }
}
