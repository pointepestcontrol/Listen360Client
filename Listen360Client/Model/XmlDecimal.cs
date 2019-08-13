using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class XmlDecimal
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "nil")]
        public bool Nil { get; set; }
        [XmlText(typeof(decimal))]
        public decimal Value { get; set; }
    }
}
