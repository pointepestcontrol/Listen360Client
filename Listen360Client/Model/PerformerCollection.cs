using System.Xml.Serialization;

namespace Listen360Client.Model
{
    [XmlRoot(ElementName = "performers")]
    public class PerformerCollection
    {
        [XmlElement(ElementName = "performer")]
        public Performer Performers { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}