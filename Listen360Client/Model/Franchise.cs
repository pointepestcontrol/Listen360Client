using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    [XmlRoot(ElementName ="franchise")]
    public class Franchise : Organization
    {
        [XmlElement(ElementName = "locale")]
        public string Locale { get; set; }

        [XmlElement(ElementName = "marketing-radius-miles")]
        public XmlInt MarketingRadiusMiles { get; set; }

        [XmlElement(ElementName = "operating-radius-miles")]
        public XmlInt OperatingRadiusMiles { get; set; }

        [XmlElement(ElementName = "root-id")]
        public XmlLong RootId { get; set; }
    }
}
