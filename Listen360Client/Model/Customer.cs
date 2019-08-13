using System.Xml.Serialization;

namespace Listen360Client.Model
{
    [XmlRoot(ElementName = "customer")]
    public class Customer
    {
        [XmlElement(ElementName = "company-name")]
        public XmlString CompanyName { get; set; }
        [XmlElement(ElementName = "created-at")]
        public XmlDate CreatedAt { get; set; }
        [XmlElement(ElementName = "first-name")]
        public XmlString FirstName { get; set; }
        [XmlElement(ElementName = "full-name")]
        public XmlString FullName { get; set; }
        [XmlElement(ElementName = "id")]
        public XmlLong Id { get; set; }
        [XmlElement(ElementName = "last-name")]
        public XmlString LastName { get; set; }
        [XmlElement(ElementName = "last-survey-bounced")]
        public XmlBool LastSurveyBounced { get; set; }
        [XmlElement(ElementName = "mobile-phone-number")]
        public XmlString MobilePhoneNumber { get; set; }
        [XmlElement(ElementName = "name")]
        public XmlString Name { get; set; }
        [XmlElement(ElementName = "organization-id")]
        public XmlLong OrganizationId { get; set; }
        [XmlElement(ElementName = "permits-contact")]
        public XmlBool PermitsContact { get; set; }
        [XmlElement(ElementName = "reference")]
        public XmlString Reference { get; set; }
        [XmlElement(ElementName = "status")]
        public XmlString Status { get; set; }
        [XmlElement(ElementName = "title")]
        public XmlString Title { get; set; }
        [XmlElement(ElementName = "updated-at")]
        public XmlDate UpdatedAt { get; set; }
        [XmlElement(ElementName = "work-city")]
        public XmlString Workcity { get; set; }
        [XmlElement(ElementName = "work-country")]
        public XmlString WorkCountry { get; set; }
        [XmlElement(ElementName = "work-email")]
        public XmlString WorkEmail { get; set; }
        [XmlElement(ElementName = "work-phone-number")]
        public XmlString WorkPhoneNumber { get; set; }
        [XmlElement(ElementName = "work-postal-code")]
        public XmlString WorkpostalCode { get; set; }
        [XmlElement(ElementName = "work-region")]
        public XmlString WorkRegion { get; set; }
        [XmlElement(ElementName = "work-street")]
        public XmlString WorkStreet { get; set; }
        [XmlElement(ElementName = "custom-choice-1-label")]
        public XmlString CustomChoice1Label { get; set; }
        [XmlElement(ElementName = "custom-choice-2-label")]
        public XmlString CustomChoice2Label { get; set; }
        [XmlElement(ElementName = "custom-choice-3-label")]
        public XmlString CustomChoice3Label { get; set; }
        [XmlElement(ElementName = "custom-choice-4-label")]
        public XmlString CustomChoice4Label { get; set; }
        [XmlElement(ElementName = "custom-choice-5-label")]
        public XmlString CustomChoice5Label { get; set; }
        [XmlElement(ElementName = "custom-choice-6-label")]
        public XmlString CustomChoice6Label { get; set; }
        [XmlElement(ElementName = "custom-choice-7-label")]
        public XmlString CustomChoice7Label { get; set; }
        [XmlElement(ElementName = "custom-choice-8-label")]
        public XmlString CustomChoice8Label { get; set; }
        [XmlElement(ElementName = "custom-choice-9-label")]
        public XmlString CustomChoice9Label { get; set; }
        [XmlElement(ElementName = "custom-choice-10-label")]
        public XmlString CustomChoice10Label { get; set; }
        [XmlElement(ElementName = "net-promoter-label")]
        public XmlString NetPromoterLabel { get; set; }
    }
}