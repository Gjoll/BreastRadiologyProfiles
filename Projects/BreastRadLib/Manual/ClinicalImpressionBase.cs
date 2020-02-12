using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IImpressionBase : IResourceBase
    {
    }

    public class ClinicalImpressionBase : ResourceBase, IImpressionBase
    {
        public ClinicalImpression Resource => (ClinicalImpression)this.resource;

        public ClinicalImpressionBase(ClinicalImpression resource) : base(resource)
        {
        }
        public ClinicalImpressionBase() : base()
        {
        }

        /// <summary>
        /// Set the fhir resource to the indicated value.
        /// </summary>
        /// <param name="resource"></param>
        public override void SetResource(Base resource)
        {
            ClinicalImpression r = resource as ClinicalImpression;
            if (r == null)
                throw new Exception("resource must be of type ClinicalImpression");
            this.resource = r;
        }
    }
}
