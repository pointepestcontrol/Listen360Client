using System;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class Technician
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

        public Technician()
        {

        }

        public Technician(Listen360Client.Model.Xml.Technician xml)
        {
            Id = xml.Id.Value;
            Country = xml.Country.Value;
            CreatedAt = xml.CreatedAt.Value;
            Email = xml.Email.Value;
            MobilePhoneNumber = xml.MobilePhoneNumber.Value;
            Name = xml.Name.Value;
            OrganizationId = xml.OrganizationId.Value;
            Reference = xml.Reference.Value;
            Status = xml.Status.Value;
            Type = xml.Type.Value;
        }
    }
}