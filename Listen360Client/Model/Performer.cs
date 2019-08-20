using System;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class Performer
    {
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
        public long Id { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Name { get; set; }
        public long OrganizationId { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string _Type { get; set; }

        public Performer()
        {

        }

        public Performer(Listen360Client.Model.Xml.Performer xml)
        {
            Country = xml.Country.Value;
            CreatedAt = xml.CreatedAt.Value;
            Email = xml.Email.Value;
            Id = xml.Id.Value;
            MobilePhoneNumber = xml.MobilePhoneNumber.Value;
            Name = xml.Name;
            OrganizationId = xml.OrganizationId.Value;
            Reference = xml.Reference.Value;
            Status = xml.Status.Value;
            Type = xml.Type.Value;
            _Type = xml._Type;
        }
    }
}