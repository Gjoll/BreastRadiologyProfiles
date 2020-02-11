using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IResourceBase : IBaseBase
    {
    }

    public abstract class ResourceBase : BaseBase, IResourceBase
    {
        DomainResource domainResource => (DomainResource)this.resource;

        public override String Id
        {
            get => this.domainResource.Id;
            set => this.domainResource.Id = value;
        }

        public ResourceBase(DomainResource resource) : base(resource)
        {
        }
    }
}
