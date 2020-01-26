using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public class HasMemberList<T>
        where T : class
    {
        Int32 min;
        Int32 max;
        List<T> items = new List<T>();

        public HasMemberList(Int32 min, Int32 max)
        {
    
        }
    }
}
