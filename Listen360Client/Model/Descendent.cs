using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class Descendent : Organization
    {
        public Descendent()
        {

        }

        internal Descendent(Listen360Client.Model.Xml.Descendent xml) : base(xml)
        {

        }
    }
}
