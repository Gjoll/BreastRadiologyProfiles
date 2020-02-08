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
    partial class ResourcesMaker
    {

        VSTaskVar ShapeVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "ShapeVS",
                        "Shape ValueSet",
                        "Shape/ValueSet",
                        "Shape value set.",
                        Group_CommonCodesVS,
                        Self.ShapeCS.Value()
                    )
            );


        CSTaskVar ShapeCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ShapeCS",
                     "Shape CodeSystem",
                     "Shape/CodeSystem",
                     "Shape values code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                        //+ Codes
                        //- Codes
                     })
                 );
    }
}



















































