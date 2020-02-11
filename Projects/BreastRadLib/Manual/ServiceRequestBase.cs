using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IServiceRequestBase : IResourceBase
    {
    }

    public class ServiceRequestBase : ResourceBase<ServiceRequest>, IServiceRequestBase
    {
    }
}
