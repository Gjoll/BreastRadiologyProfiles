using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IExtensionBase : IResourceBase
    {
    }

    public class ExtensionBase : BaseBase<Extension>, IExtensionBase
    {
        public override String Id
        {
            get => this.resource.ElementId;
            set => this.resource.ElementId = value;
        }
    }
}
