using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IDiagnosticReportBase : IResourceBase
    {
    }

    public class DiagnosticReportBase : ResourceBase, IDiagnosticReportBase
    {
        public DiagnosticReport Resource => (DiagnosticReport)this.resource;

        public DiagnosticReportBase(DiagnosticReport resource) : base(resource)
        {
        }

        public DiagnosticReportBase() : base()
        {
        }

        /// <summary>
        /// Set the fhir resource to the indicated value.
        /// </summary>
        /// <param name="resource"></param>
        public override void SetResource(Base resource)
        {
            DiagnosticReport r = resource as DiagnosticReport;
            if (r == null)
                throw new Exception("resource must be of type DiagnosticReport");
            this.resource = r;
        }
    }
}
