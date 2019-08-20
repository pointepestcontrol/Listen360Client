using System.Collections.Generic;
using System.Xml.Serialization;

namespace Listen360Client.Model.Xml
{
    [XmlRoot(ElementName = "performers")]
    public class PerformerCollection
    {
        [XmlElement(ElementName = "performer")]
        public List<Performer> Performers { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}