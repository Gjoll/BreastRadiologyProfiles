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

        /// <summary>
        /// Set the fhir resource to the indicated value.
        /// </summary>
        /// <param name="resource"></param>
        public override void SetResource(Base resource)
        {
            ServiceRequest r = resource as ServiceRequest;
            if (r == null)
                throw new Exception("resource must be of type ServiceRequest");
            this.resource = r;
        }
    }
}
