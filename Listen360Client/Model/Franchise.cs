using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class Franchise : Organization
    {
        public long RootId { get; set; }
        public string Locale { get; set; }
        public int MarketingRadiusMiles { get; set; }
        public int OperatingRadiusMiles { get; set; }

        public Franchise()
        {

        }

        internal Franchise(Model.Xml.Franchise xml) : base (xml)
        {
            RootId = xml.RootId.Value;
            Locale = xml.Locale;
            MarketingRadiusMiles = xml.MarketingRadiusMiles.Value;
            OperatingRadiusMiles = xml.OperatingRadiusMiles.Value;
        }
    }
}
