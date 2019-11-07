using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace FhirKhit.BreastRadiology.XUnitTests
{
    public partial class ResourcesMaker : ConverterBase
    {
        String AbMammoCalcifications(String calcType,
            String calcDistribution)
        {
            return this.CreateObservationSection(
                "BreastRadMammoCalcifications",
                "Breast Radiology Mammography Calcifications Observation",
                new Markdown()
                    .Paragraph("Breast Radiology Mammography Calcifications Observation")
                    .Paragraph("This observation has the following two member observations")
                    .List("Calcification Type", "Calcification Distribution")
                )
                .SliceByUrl("hasMember",
                    new ObservationTarget[]
                    {
                            new ObservationTarget(calcType, 1, "1"),
                            new ObservationTarget(calcDistribution, 1, "1")
                    })
                .ApplyBreastBodyLocation(this.breastBodyLocation, false)
                .SDef.Url;
        }
    }
}
