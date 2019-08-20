using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class Customer
    {
        public string CompanyName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public long Id { get; set; }
        public string LastName { get; set; }
        public bool LastSurveyBounced { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Name { get; set; }
        public long OrganizationId { get; set; }
        public bool PermitsContact { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Workcity { get; set; }
        public string WorkCountry { get; set; }
        public string WorkEmail { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string WorkpostalCode { get; set; }
        public string WorkRegion { get; set; }
        public string WorkStreet { get; set; }
        public virtual ICollection<ChoiceLabel> CustomChoiceLabels { get; set; }
        public string NetPromoterLabel { get; set; }

        public Customer()
        {
            CustomChoiceLabels = new List<ChoiceLabel>();
        }

        public Customer(Listen360Client.Model.Xml.Customer xml) : this()
        {
            CompanyName = xml.CompanyName.Value;
            CreatedAt = xml.CreatedAt.Value;
            FirstName = xml.FirstName.Value;
            FullName = xml.FullName.Value;
            Id = xml.Id.Value;
            LastName = xml.LastName.Value;
            LastSurveyBounced = xml.LastSurveyBounced.Value;
            MobilePhoneNumber = xml.MobilePhoneNumber.Value;
            Name = xml.Name.Value;
            OrganizationId = xml.OrganizationId.Value;
            PermitsContact = xml.PermitsContact.Value;
            Reference = xml.Reference.Value;
            Status = xml.Status.Value;
            Title = xml.Title.Value;
            UpdatedAt = xml.UpdatedAt.Value;
            Workcity = xml.Workcity.Value;
            WorkCountry = xml.WorkCountry.Value;
            WorkEmail = xml.WorkEmail.Value;
            WorkPhoneNumber = xml.WorkPhoneNumber.Value;
            WorkpostalCode = xml.WorkpostalCode.Value;
            WorkRegion = xml.WorkRegion.Value;
            WorkStreet = xml.WorkStreet.Value;
            NetPromoterLabel = xml.NetPromoterLabel.Value;
            CustomChoiceLabels.Add(new ChoiceLabel() { Ordinal = 1, Label = xml.CustomChoice1Label.Value });
            CustomChoiceLabels.Add(new ChoiceLabel() { Ordinal = 2, Label = xml.CustomChoice2Label.Value });
            CustomChoiceLabels.Add(new ChoiceLabel() { Ordinal = 3, Label = xml.CustomChoice3Label.Value });
            CustomChoiceLabels.Add(new ChoiceLabel() { Ordinal = 4, Label = xml.CustomChoice4Label.Value });
            CustomChoiceLabels.Add(new ChoiceLabel() { Ordinal = 5, Label = xml.CustomChoice5Label.Value });
            CustomChoiceLabels.Add(new ChoiceLabel() { Ordinal = 6, Label = xml.CustomChoice6Label.Value });
            CustomChoiceLabels.Add(new ChoiceLabel() { Ordinal = 7, Label = xml.CustomChoice7Label.Value });
            CustomChoiceLabels.Add(new ChoiceLabel() { Ordinal = 8, Label = xml.CustomChoice8Label.Value });
            CustomChoiceLabels.Add(new ChoiceLabel() { Ordinal = 9, Label = xml.CustomChoice9Label.Value });
            CustomChoiceLabels.Add(new ChoiceLabel() { Ordinal = 10, Label = xml.CustomChoice10Label.Value });
        }
    }
}