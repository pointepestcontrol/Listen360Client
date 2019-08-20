using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class Job
    {
        public DateTime CommencedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Currency { get; set; }
        public long CustomerId { get; set; }
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal Value { get; set; }
        public ICollection<ChoiceLabel> CustomChoiceLabels { get; set; }
        public List<Performer> Performers { get; set; }

        public Job()
        {
            Performers = new List<Performer>();
            CustomChoiceLabels = new List<ChoiceLabel>();
        }
        public Job(Listen360Client.Model.Xml.Job xml) : this()
        {
            CommencedAt = xml.CommencedAt.Value;
            CompletedAt = xml.CompletedAt.Value;
            CreatedAt = xml.CreatedAt.Value;
            Currency = xml.Currency.Value;
            CustomerId = xml.CustomerId.Value;
            Id = xml.Id.Value;
            OrganizationId = xml.OrganizationId.Value;
            Reference = xml.Reference.Value;
            Status = xml.Status.Value;
            UpdatedAt = xml.UpdatedAt.Value;
            Value = xml.Value.Value;
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
            Performers.AddRange(xml.Performers.Performers.Select(p=>new Performer(p)));
        }
    }
}