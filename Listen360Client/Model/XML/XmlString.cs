using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model.Xml
{
    public class XmlString
    {

        [XmlAttribute(AttributeName = "nil")]
        public string Nil { get; set; }
        [XmlText]
        public string Value { get; set; }

    }
}
