using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreastRadLib
{
    public interface IResourceBase : IBaseBase
    {
    }

    public class ResourceBase : BaseBase, IResourceBase
    {
        DomainResource domainResource => (DomainResource)this.resource;
        String profileUrl;

        public override String Id
        {
            get => this.domainResource.Id;
            set => this.domainResource.Id = value;
        }

        public ResourceBase() : base()
        {
        }

        public ResourceBase(DomainResource resource) : base(resource)
        {
        }

        /// <summary>
        /// Set the fhir resource to the indicated value.
        /// </summary>
        /// <param name="resource"></param>
        public override void SetResource(Base resource)
        {
            Resource r = resource as Resource;
            if (r == null)
                throw new Exception("resource must be of type Resource");
            this.resource = r;
        }

        protected void SetProfileUrl(String profileUrl)
        {
            this.profileUrl = profileUrl;
            List<String> metaProfiles = this.domainResource.Meta.Profile.ToList();
            if (metaProfiles.Contains(profileUrl) == false)
                metaProfiles.Add(profileUrl);
            this.domainResource.Meta.Profile = metaProfiles;
        }
    }
}
