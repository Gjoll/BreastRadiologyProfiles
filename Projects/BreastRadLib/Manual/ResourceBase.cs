using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IResourceBase : IBaseBase
    {
    }

    public abstract class ResourceBase<T> : BaseBase<T>, IResourceBase
        where T : Resource, new()
    {
        public override String Id
        {
            get => this.resource.Id;
            set => this.resource.Id = value;
        }

        public ResourceBase(T resource) : base(resource)
        {
        }

        public ResourceBase() : base()
        {
            this.resource = new T();
        }
    }
}
