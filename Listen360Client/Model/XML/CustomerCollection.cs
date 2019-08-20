using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model.Xml
{
    [XmlRoot(ElementName = "customers")]
    public class CustomerCollection
    {
        [XmlElement(ElementName = "customer")]
        public List<Customer> Customers { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}
