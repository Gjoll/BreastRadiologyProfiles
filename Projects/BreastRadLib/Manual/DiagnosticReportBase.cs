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

        public override void SetResource(Base r) => this.resource = (DiagnosticReport)r;
    }
}
