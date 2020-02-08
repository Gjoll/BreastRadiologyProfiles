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
        VSTaskVar MarginVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "MarginVS",
                    "Margin ValueSet",
                    "MarginValueSet",
                    "Margin ValueSet.",
                    Group_CommonCodesVS,
                    Self.MarginCS.Value()
                    )
            );


        CSTaskVar MarginCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "MarginCS",
                     "MarginCodeSystem",
                     "Margin CodeSystem",
                     "Margin code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                     //+ Codes
                     //- Codes
                     })
                 );
    }
}
