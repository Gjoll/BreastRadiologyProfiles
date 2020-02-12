using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IExtensionBase : IBaseBase
    {
    }

    public class ExtensionBase : BaseBase, IExtensionBase
    {
        public Extension Resource => (Extension)this.resource;

        public override String Id
        {
            get => this.Resource.ElementId;
            set => this.Resource.ElementId = value;
        }

        public ExtensionBase(Extension resource) : base(resource)
        {
        }

        public ExtensionBase() : base()
        {
        }

        public override void SetResource(Base r) => this.resource = (Extension)r;
    }
}
