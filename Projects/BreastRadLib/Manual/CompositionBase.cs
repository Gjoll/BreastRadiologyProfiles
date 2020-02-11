using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface ICompositionBase : IResourceBase
    {
    }

    public class CompositionBase : ResourceBase, ICompositionBase
    {
        public Composition Resource => (Composition)this.resource;

        public CompositionBase(Composition resource) : base(resource)
        {
        }

        protected void ClearSection()
        {
        }

        protected void ReadSection<T>(Coding code, Int32 min, Int32 max, List<T> items)
            where T : IBaseBase
        {
            throw new NotImplementedException();
        }

        protected T ReadSection<T>(Coding code)
            where T : IBaseBase
        {
            throw new NotImplementedException();
        }

        protected void WriteSection<T>(String title, Coding code, Int32 min, Int32 max, T item)
            where T : IBaseBase
        {
            throw new NotImplementedException();
        }

        protected void WriteSection<T>(String title, Coding code, Int32 min, Int32 max, List<T> items)
            where T : IBaseBase
        {
            throw new NotImplementedException();
        }
    }
}
