using System.Collections.Generic;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    [XmlRoot(ElementName = "descendents")]
    public class DescendentCollection
    {
        [XmlElement(ElementName = "descendent")]
        public List<Descendent> Descendents { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}