using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface ICompositionBase : IResourceBase
    {
    }

    public class CompositionBase : ResourceBase<Composition>
    {
        protected void WriteSection<T>(String title, Coding code, Int32 min, Int32 max, T item)
        {
        }

        protected void WriteSection<T>(String title, Coding code, Int32 min, Int32 max, List<T> items)
        {
        }
    }
}
