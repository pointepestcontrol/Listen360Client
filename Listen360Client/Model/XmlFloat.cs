using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class XmlFloat
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public float Value { get; set; }
    }
}
