using System.Xml.Serialization;

namespace Listen360Client.Model.Xml
{
    [XmlRoot(ElementName = "job")]
    public class Job
    {
        [XmlElement(ElementName = "commenced-at")]
        public XmlDate CommencedAt { get; set; }
        [XmlElement(ElementName = "completed-at")]
        public XmlDate CompletedAt { get; set; }
        [XmlElement(ElementName = "created-at")]
        public XmlDate CreatedAt { get; set; }
        [XmlElement(ElementName = "currency")]
        public XmlString Currency { get; set; }
        [XmlElement(ElementName = "customer-id")]
        public XmlLong CustomerId { get; set; }
        [XmlElement(ElementName = "id")]
        public XmlLong Id { get; set; }
        [XmlElement(ElementName = "organization-id")]
        public XmlLong OrganizationId { get; set; }
        [XmlElement(ElementName = "reference")]
        public XmlString Reference { get; set; }
        [XmlElement(ElementName = "status")]
        public XmlString Status { get; set; }
        [XmlElement(ElementName = "updated-at")]
        public XmlDate UpdatedAt { get; set; }
        [XmlElement(ElementName = "value")]
        public XmlDecimal Value { get; set; }
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
        [XmlElement(ElementName = "performers")]
        public PerformerCollection Performers { get; set; }
    }
}