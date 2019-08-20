using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model.Xml
{
    [XmlRoot(ElementName = "memberships")]
    public class MembershipCollection
    {
        [XmlElement(ElementName = "membership")]
        public List<Membership> Memberships { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}
