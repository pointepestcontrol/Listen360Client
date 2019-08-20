using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model.Xml
{
    [XmlRoot(ElementName = "surveys")]
    public class SurveyCollection
    {
        [XmlElement(ElementName = "survey")]
        public List<Survey> Survey { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}
