using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Listen360Client.Model
{
    public class Division : Organization
    {
        public Division()
        {

        }

        internal Division(Model.Xml.Division xml) : base(xml)
        {

        }
    }
}
