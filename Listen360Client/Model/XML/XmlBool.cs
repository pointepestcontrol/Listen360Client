using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model.Xml
{
    public class XmlBool
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "nil")]
        public string Nil { get; set; }
        [XmlText]
        public bool Value { get; set; }
    }
}
