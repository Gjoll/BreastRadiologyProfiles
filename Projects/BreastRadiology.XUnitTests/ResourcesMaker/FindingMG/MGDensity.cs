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
        //# TODO: get from gg
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
                    new ConceptDef("HighDensity ",
                        "High Density",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("X-ray attenuation of the mass is greater than the expected attenuation of an equal volume of")
                            .Text("fibroglandular breast tissue.")
                        .CiteEnd()
                        ),
                    new ConceptDef("EqualDensity",
                        "Equal Density",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("(historically, \"isodense\")")
                            .Text("X-ray attenuation of the mass is the same as the expected attenuation of an equal volume of")
                            .Text("fibroglandular breast tissue.")
                        .CiteEnd()
                        ),
                    new ConceptDef("LowDensity",
                        "Low Density",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("X-ray attenuation of the mass is less than the expected attenuation of an equal volume of")
                            .Text("fibroglandular breast tissue. A low density mass may be a group of microcysts. If such a finding")
                            .Text("is identified at mammography, it may very well not be malignant but appropriately may")
                            .Text("be worked up.")
                        .CiteEnd()
                        ),
                    new ConceptDef("FatContaining",
                        "Fat Containing",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("This includes all masses containing fat, such as oil cyst, lipoma or galactocele, as well as mixed")
                            .Text("density masses such as hamartoma. A fat-containing mass will almost always represent a")
                            .Text("benign mass.")
                        .CiteEnd()
                        )
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
