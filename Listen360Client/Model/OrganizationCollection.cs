using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    [XmlRoot(ElementName = "organizations")]
    public class OrganizationCollection
    {
        [XmlElement(ElementName = "organization")]
        public List<Organization> Organizations { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}
