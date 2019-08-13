using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    [XmlRoot(ElementName = "children")]
    public class ChildrenCollection
    {
        [XmlElement(ElementName = "child")]
        public List<Child> Children { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}