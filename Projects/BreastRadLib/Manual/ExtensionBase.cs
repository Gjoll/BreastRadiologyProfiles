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

        /// <summary>
        /// Set the fhir resource to the indicated value.
        /// </summary>
        /// <param name="resource"></param>
        public override void SetResource(Base resource)
        {
            Extension r = resource as Extension;
            if (r == null)
                throw new Exception("resource must be of type Extension");
            this.resource = r;
        }
    }
}
