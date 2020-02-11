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
    }
}
