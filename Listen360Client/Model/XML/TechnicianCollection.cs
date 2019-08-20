using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model.Xml
{
    [XmlRoot(ElementName = "technicians")]
    public class TechnicianCollection
    {
        [XmlElement(ElementName = "technician")]
        public List<Technician> Technicians { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}
