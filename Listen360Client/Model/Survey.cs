using System.Xml.Serialization;

namespace Listen360Client.Model
{
    [XmlRoot(ElementName = "survey")]
    public class Survey
    {
        [XmlElement(ElementName = "censored")]
        public XmlBool Censored { get; set; }
        [XmlElement(ElementName = "completed-at")]
        public XmlDate CompletedAt { get; set; }
        [XmlElement(ElementName = "flagged-for-follow-up")]
        public XmlBool FlaggedForFollowup { get; set; }
        [XmlElement(ElementName = "has-notes")]
        public XmlBool HasNotes { get; set; }
        [XmlElement(ElementName = "invited-at")]
        public XmlDate InvitedAt { get; set; }
        [XmlElement(ElementName = "net-promoter-label")]
        public XmlString NetPromoterLabel { get; set; }
        [XmlElement(ElementName = "organization-id")]
        public XmlLong OrganizationId { get; set; }
        [XmlElement(ElementName = "public-response")]
        public XmlString PublicResponse { get; set; }
        [XmlElement(ElementName = "recommendation-likelihood")]
        public XmlInt RecommendationLikelihood { get; set; }
        [XmlElement(ElementName = "updated-at")]
        public XmlDate UpdatedAt { get; set; }
        [XmlElement(ElementName = "unique-id")]
        public XmlLong UniqueId { get; set; }
        [XmlElement(ElementName = "job-reference")]
        public XmlString JobReference { get; set; }
        [XmlElement(ElementName = "organization-reference")]
        public XmlString OrganizationReference { get; set; }
        [XmlElement(ElementName = "customer-reference")]
        public XmlString CustomerReference { get; set; }
        [XmlElement(ElementName = "customer-full-name")]
        public XmlString CustomerFullName { get; set; }
        [XmlElement(ElementName = "customer-work-email")]
        public XmlString CustomerWorkEmail { get; set; }
        [XmlElement(ElementName = "customer-work-city")]
        public XmlString CustomerWorkCity { get; set; }
        [XmlElement(ElementName = "customer-work-region")]
        public XmlString CustomerWorkRegion { get; set; }
        [XmlElement(ElementName = "organization-name")]
        public XmlString OrganizationName { get; set; }
        [XmlElement(ElementName = "public-reviewer-name")]
        public XmlString PublicReviewerName { get; set; }
        [XmlElement(ElementName = "public-display-comments")]
        public XmlString PublicDisplayComments { get; set; }
        [XmlElement(ElementName = "public-display-customer-location")]
        public XmlString PublicDisplayCustomerLocation { get; set; }
        [XmlElement(ElementName = "notes")]
        public XmlString Notes { get; set; }
        [XmlElement(ElementName = "comments")]
        public XmlString Comments { get; set; }
    }
}