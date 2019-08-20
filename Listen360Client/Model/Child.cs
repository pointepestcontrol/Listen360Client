using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class Child : Organization
    {
        public Child()
        {

        }

        internal Child(Listen360Client.Model.Xml.Child xml) : base (xml)
        {

        }
    }
}