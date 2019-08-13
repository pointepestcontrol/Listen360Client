using System.Xml.Serialization;

namespace Listen360Client.Model
{
    [XmlRoot(ElementName = "franchisor")]
    public class Franchisor : Organization
    {
        [XmlElement(ElementName = "average-job-value")]
        public XmlDecimal AverageJobValue { get; set; }
        [XmlElement(ElementName = "customer-lifetime")]
        public XmlInt Customerlifetime { get; set; }
        [XmlElement(ElementName = "customer-lifetime-interval")]
        public string CustomerLifetimeInterval { get; set; }
        [XmlElement(ElementName = "franchise-royalty-percentage")]
        public XmlDecimal FranchiseRoyaltyPercentage { get; set; }
        [XmlElement(ElementName = "locale")]
        public string Locale { get; set; }
        [XmlElement(ElementName = "jobs-performed-per-interval")]
        public XmlInt JobsPerformedPerInterval { get; set; }
        [XmlElement(ElementName = "marketing-radius-miles")]
        public XmlInt MarketingRadiusMiles { get; set; }

        [XmlElement(ElementName = "operating-radius-miles")]
        public XmlInt OperatingRadiusMiles { get; set; }
        [XmlElement(ElementName = "recurring-jobs-interval")]
        public string RecurringJobsInterval { get; set; }
        [XmlElement(ElementName = "root-id")]
        public XmlLong RootId { get; set; }
    }
}