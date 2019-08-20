using System.Xml.Serialization;

namespace Listen360Client.Model.Xml
{
    public class Organization
    {
        [XmlElement(ElementName = "city")]
        public string City { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "created-at")]
        public XmlDate CreatedAt { get; set; }
        [XmlElement(ElementName = "email")]
        public XmlString Email { get; set; }
        [XmlElement(ElementName = "external-name")]
        public string ExternalName { get; set; }
        [XmlElement(ElementName = "id")]
        public XmlLong Id { get; set; }
        [XmlElement(ElementName = "latitude")]
        public XmlDecimal Latitude { get; set; }
        [XmlElement(ElementName = "longitude")]
        public XmlDecimal Longitude { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "parent-id")]
        public XmlLong ParentId { get; set; }
        [XmlElement(ElementName = "phone-number")]
        public XmlString PhoneNumber { get; set; }
        [XmlElement(ElementName = "postal-code")]
        public string Postalcode { get; set; }
        [XmlElement(ElementName = "reference")]
        public string Reference { get; set; }
        [XmlElement(ElementName = "region")]
        public string Region { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "street-address")]
        public string Streetaddress { get; set; }
        [XmlElement(ElementName = "time-zone")]
        public string Timezone { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "updated-at")]
        public XmlDate UpdatedAt { get; set; }
        [XmlElement(ElementName = "website")]
        public string Website { get; set; }
        [XmlElement(ElementName = "net-promoter-score")]
        public XmlInt NetPromoterScore { get; set; }
        [XmlElement(ElementName = "total-reviews")]
        public XmlLong TotalReviews { get; set; }
        [XmlElement(ElementName = "zero-to-ten-rating")]
        public XmlFloat ZeroToTenRating { get; set; }
        [XmlElement(ElementName = "one-to-five-rating")]
        public XmlFloat OneToFiveRating { get; set; }
    }
}