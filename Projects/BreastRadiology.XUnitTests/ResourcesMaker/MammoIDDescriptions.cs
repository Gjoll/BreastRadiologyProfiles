using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    public class MammoIDDescriptions
    {
        public class Description
        {
            public String Text;
            public String Source;
        }

        Dictionary<String, Description> descriptions = new Dictionary<string, Description>();

        public void Add(String id, String source, String text)
        {
            Description d = new Description()
            {
                Text = text,
                Source = source
            };
            this.descriptions.Add(id, d);
        }

        public MammoIDDescriptions()
        {
            this.descriptions = new Dictionary<string, Description>();
            //+ Data
            //- Data
        }
    }
}
