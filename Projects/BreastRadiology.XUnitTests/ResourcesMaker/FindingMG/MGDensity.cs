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
                    new ConceptDef("HighDensity ",
                        "High Density",
                        new Definition()
                        .CiteStart()
                            .Line("X-ray attenuation of the mass is greater than the expected attenuation of an equal volume of")
                            .Line("fibroglandular breast tissue.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("EqualDensity",
                        "Equal Density",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"isodense\")")
                            .Line("X-ray attenuation of the mass is the same as the expected attenuation of an equal volume of")
                            .Line("fibroglandular breast tissue.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("LowDensity",
                        "Low Density",
                        new Definition()
                        .CiteStart()
                            .Line("X-ray attenuation of the mass is less than the expected attenuation of an equal volume of")
                            .Line("fibroglandular breast tissue. A low density mass may be a group of microcysts. If such a finding")
                            .Line("is identified at mammography, it may very well not be malignant but appropriately may")
                            .Line("be worked up.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("FatContaining",
                        "Fat Containing",
                        new Definition()
                        .CiteStart()
                            .Line("This includes all masses containing fat, such as oil cyst, lipoma or galactocele, as well as mixed")
                            .Line("density masses such as hamartoma. A fat-containing mass will almost always represent a")
                            .Line("benign mass.")
                        .CiteEnd(BiRadCitation)
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
