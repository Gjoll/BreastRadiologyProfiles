using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IServiceRequestBase : IResourceBase
    {
    }

    public class ServiceRequestBase : ResourceBase, IServiceRequestBase
    {
        public ServiceRequest Resource => (ServiceRequest)this.resource;

        public ServiceRequestBase(ServiceRequest resource) : base(resource)
        {
        }

        public ServiceRequestBase() : base()
        {
        }

        public override void SetResource(Base r) => this.resource = (ServiceRequest)r;
    }
}
