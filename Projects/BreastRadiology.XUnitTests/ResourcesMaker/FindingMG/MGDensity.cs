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
                    new ConceptDef()
                        .SetCode("HighDensity ", "High Density")
                        .BiRadsDef("X-ray attenuation of the mass is greater than the expected attenuation of an equal volume of",
                                   "fibroglandular breast tissue."),
                    new ConceptDef()
                        .SetCode("EqualDensity", "Equal Density")
                        .BiRadsDef("(historically, \"isodense\")",
                                   "X-ray attenuation of the mass is the same as the expected attenuation of an equal volume of",
                                   "fibroglandular breast tissue."),
                    new ConceptDef()
                        .SetCode("LowDensity", "Low Density")
                        .BiRadsDef("X-ray attenuation of the mass is less than the expected attenuation of an equal volume of",
                                   "fibroglandular breast tissue. A low density mass may be a group of microcysts. If such a finding",
                                   "is identified at mammography, it may very well not be malignant but appropriately may",
                                   "be worked up."),
                    new ConceptDef()
                        .SetCode("FatContaining", "Fat Containing")
                        .BiRadsDef("This includes all masses containing fat, such as oil cyst, lipoma or galactocele, as well as mixed",
                                   "density masses such as hamartoma. A fat-containing mass will almost always represent a",
                                   "benign mass.")
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
