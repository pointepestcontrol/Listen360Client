using System;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class Organization
    {
        public long Id { get; set; }
        public OrganizationType Type { get; set; }
        public long ParentId { get; set; }
        public string Name { get; set; }
        public string ExternalName { get; set; }
        public string Email { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public string Streetaddress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Website { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int NetPromoterScore { get; set; }
        public long TotalReviews { get; set; }
        public float ZeroToTenRating { get; set; }
        public float OneToFiveRating { get; set; }

        public Organization()
        {

        }

        internal Organization(Listen360Client.Model.Xml.Organization xml)
        {
            Id = xml.Id.Value;
            if(!Enum.TryParse(xml.Type, out OrganizationType type))
            {
                throw new Exception();
            }
            Type = type;
            ParentId = xml.ParentId.Value;
            Name = xml.Name;
            ExternalName = xml.ExternalName;
            Email = xml.Email.Value;
            Reference = xml.Reference;
            Status = xml.Status;
            Streetaddress = xml.Streetaddress;
            City = xml.City;
            Region = xml.Region;
            Postalcode = xml.Postalcode;
            Country = xml.Country;
            Timezone = xml.Timezone;
            PhoneNumber = xml.PhoneNumber.Value;
            Latitude = xml.Latitude.Value;
            Longitude = xml.Longitude.Value;
            Website = xml.Website;
            CreatedAt = xml.CreatedAt.Value;
            UpdatedAt = xml.UpdatedAt.Value;
            NetPromoterScore = xml.NetPromoterScore.Value;
            TotalReviews = xml.TotalReviews.Value;
            ZeroToTenRating = xml.ZeroToTenRating.Value;
            OneToFiveRating = xml.OneToFiveRating.Value;
        }
    }
}