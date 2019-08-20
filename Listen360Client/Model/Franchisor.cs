using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class Franchisor : Organization
    {
        public long RootId { get; set; }
        public string Locale { get; set; }
        public decimal AverageJobValue { get; set; }
        public int Customerlifetime { get; set; }
        public string CustomerLifetimeInterval { get; set; }
        public decimal FranchiseRoyaltyPercentage { get; set; }
        public int JobsPerformedPerInterval { get; set; }
        public int MarketingRadiusMiles { get; set; }
        public int OperatingRadiusMiles { get; set; }
        public string RecurringJobsInterval { get; set; }

        public Franchisor()
        {

        }
        internal Franchisor(Listen360Client.Model.Xml.Franchisor xml) : base (xml)
        {
            RootId = xml.RootId.Value;
            Locale = xml.Locale;
            AverageJobValue = xml.AverageJobValue.Value;
            Customerlifetime = xml.Customerlifetime.Value;
            CustomerLifetimeInterval = xml.CustomerLifetimeInterval;
            FranchiseRoyaltyPercentage = xml.FranchiseRoyaltyPercentage.Value;
            JobsPerformedPerInterval = xml.JobsPerformedPerInterval.Value;
            MarketingRadiusMiles = xml.MarketingRadiusMiles.Value;
            OperatingRadiusMiles = xml.OperatingRadiusMiles.Value;
            RecurringJobsInterval = xml.RecurringJobsInterval;
        }

    }
}