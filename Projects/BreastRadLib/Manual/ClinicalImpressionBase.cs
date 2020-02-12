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

        public override void SetResource(Base r) => this.resource = (ClinicalImpression) r;
    }
}
