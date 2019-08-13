using System.Xml.Serialization;

namespace Listen360Client.Model
{
    [XmlRoot(ElementName = "membership")]
    public class Membership
    {
        [XmlElement(ElementName = "accepted-at")]
        public XmlDate AcceptedAt { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "created-at")]
        public XmlDate CreatedAt { get; set; }
        [XmlElement(ElementName = "email")]
        public XmlString Email { get; set; }
        [XmlElement(ElementName = "first-name")]
        public XmlString FirstName { get; set; }
        [XmlElement(ElementName = "id")]
        public XmlLong Id { get; set; }
        [XmlElement(ElementName = "invited-by-id")]
        public XmlLong InvitedById { get; set; }
        [XmlElement(ElementName = "last-name")]
        public XmlString LastName { get; set; }
        [XmlElement(ElementName = "mobile-phone-number")]
        public XmlString MobilePhoneNumber { get; set; }
        [XmlElement(ElementName = "organization-id")]
        public XmlLong OrganizationId { get; set; }
        [XmlElement(ElementName = "revoked-at")]
        public XmlDate RevokedAt { get; set; }
        [XmlElement(ElementName = "role")]
        public XmlString Role { get; set; }
        [XmlElement(ElementName = "status")]
        public XmlString Status { get; set; }
        [XmlElement(ElementName = "user-id")]
        public XmlLong UserId { get; set; }
    }
}