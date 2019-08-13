using System.Xml.Serialization;

namespace Listen360Client.Model
{
    [XmlRoot(ElementName = "technician")]
    public class Technician
    {
        [XmlElement(ElementName = "country")]
        public XmlString Country { get; set; }
        [XmlElement(ElementName = "created-at")]
        public XmlDate CreatedAt { get; set; }
        [XmlElement(ElementName = "email")]
        public XmlString Email { get; set; }
        [XmlElement(ElementName = "id")]
        public XmlLong Id { get; set; }
        [XmlElement(ElementName = "mobile-phone-number")]
        public XmlString MobilePhoneNumber { get; set; }
        [XmlElement(ElementName = "name")]
        public XmlString Name { get; set; }
        [XmlElement(ElementName = "organization-id")]
        public XmlLong OrganizationId { get; set; }
        [XmlElement(ElementName = "reference")]
        public XmlString Reference { get; set; }
        [XmlElement(ElementName = "status")]
        public XmlString Status { get; set; }
        [XmlElement(ElementName = "type")]
        public XmlString Type { get; set; }
    }
}