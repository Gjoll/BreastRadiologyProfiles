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
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        CSTaskVar MGDensityCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "MGDensityCS",
                     "Mammography Density CodeSystem",
                     "MG Density/CodeSystem",
                     "Mammography density code system.",
                     Group_MGCodesCS,
                     new ConceptDef[]
                     {
                         //+ Codes
                         //- Codes
                     })
             );


        VSTaskVar MGDensityVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "MGDensityVS",
                    "Mammography Density ValueSet",
                    "MG Density ValueSet",
                    "Mammography density codes value set.",
                    Group_MGCodesVS,
                    Self.MGDensityCS.Value())
                    );
    }
}
