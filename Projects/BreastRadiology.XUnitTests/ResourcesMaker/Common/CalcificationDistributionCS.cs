using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        CSTaskVar CalcificationDistributionCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                    "CalcificationDistributionCS",
                    "Calcification Distribution CodeSystem",
                    "Calcification/Distribution/CodeSystem",
                    "Calcification Distribution in an abnormality code system.",
                    Group_CommonCodesCS,
                    new ConceptDef[]
                    {
                        //+ Codes
                        new ConceptDef()
                            .SetCode("ClusteredDistribution")
                            .SetDisplay("Clustered distribution")
                            .MammoId("751")
                            .ValidModalities(Modalities.MG)
                            .SetSnomedDescription("ClinicalFinding | 129769006 | Radiographic calcification " +
                                "with clustered distribution (Finding)")
                            .SetUMLS("Grouped (historically, \"clustered\") This term should " +
                                "be used when relatively few calcifications occupy " +
                                "a small portion of breasttissue. ",
                                "The lower limit for use of this descriptor is usually " +
                                "when 5 calcifications are groupedwithin 1 cm of each " +
                                "other or when a definable pattern is identified. ",
                                "The upper limit for useof this descriptor is when " +
                                "larger numbers of calcifications are grouped within " +
                                "2 cm of eachother. ",
                                "###ACRMG#73")
                        ,
                        new ConceptDef()
                            .SetCode("DiffuseDistribution")
                            .SetDisplay("Diffuse distribution")
                            .MammoId("752")
                            .ValidModalities(Modalities.MG)
                            .SetDicom("F-01770")
                            .SetSnomedDescription("ClinicalFinding | 129764001 | Radiographic calcification " +
                                "with diffuse distribution (Finding)")
                            .SetACR("Diffuse (historically, \"scattered\"). ",
                                "These are calcifications that are distributed randomly " +
                                "throughout the breast. ",
                                " Punctate and amorphous calcifications in this distribution " +
                                "are almost always benign, especially if bilateral.")
                        ,
                        new ConceptDef()
                            .SetCode("GroupedDistribution")
                            .SetDisplay("Grouped distribution")
                            .MammoId("753")
                            .ValidModalities(Modalities.MG)
                            .SetDicom("F-01772")
                            .SetSnomedDescription("ClinicalFinding | 129766004 | Radiographic calcification " +
                                "with grouped distribution (Finding)")
                            .SetACR("This term should be used when relatively few calcifications " +
                                "occupy a small portion of breast tissue. ",
                                "The lower limit for use of this descriptor is usually " +
                                "when 5 calcifications are grouped within 1 cm of " +
                                "each other or when a definable pattern is identified. ",
                                "The upper limit for use of this descriptor is when " +
                                "larger numbers of calcifications are grouped within " +
                                "2 cm of each other.)")
                        ,
                        new ConceptDef()
                            .SetCode("LinearDistribution")
                            .SetDisplay("Linear distribution")
                            .MammoId("754")
                            .ValidModalities(Modalities.MG)
                            .SetDicom("F-01771")
                            .SetSnomedDescription("ClinicalFinding | 129765000 | Radiographic calcification " +
                                "with linear distribution (Finding)")
                            .SetACR("These are calcifications arrayed in a line. ",
                                "This distribution may elevate suspicion for malignancy, " +
                                "as it suggests deposits in a duct. ",
                                "Note that both vascular and large rod-like calcifications " +
                                "also are usually linear in distribution, but that " +
                                "these typically benign calcifications have a characteristically " +
                                "benign morphology.)")
                        ,
                        new ConceptDef()
                            .SetCode("RegionalDistribution")
                            .SetDisplay("Regional distribution")
                            .MammoId("755")
                            .ValidModalities(Modalities.MG)
                            .SetDicom("F-01773")
                            .SetSnomedDescription("ClinicalFinding | 129767008 | Radiographic calcification " +
                                "with regional distribution (Finding)")
                            .SetACR("This descriptor is used for numerous calcifications " +
                                "that occupy a large portion of breast tissue (more " +
                                "than 2 cm in greatest dimension), not conforming " +
                                "to a duct distribution. ",
                                "Since this distribution may involve most of a quadrant " +
                                "or even more than a single quadrant, malignancy is " +
                                "less likely. ",
                                "However, overall evaluation of regional calcifications " +
                                "must include particle shape (morphology) as well " +
                                "as distribution.")
                        ,
                        new ConceptDef()
                            .SetCode("ScatteredDistribution")
                            .SetDisplay("Scattered distribution")
                            .MammoId("756")
                            .ValidModalities(Modalities.MG)
                            .SetSnomedDescription("not found")
                            .SetUMLS("Scattered distributions are also called diffuse distributions. ",
                                "These are calcifications that are distributed randomly " +
                                "throughout the breast. ",
                                "Punctate andamorphous calcifications in this distribution " +
                                "are almost always benign, especially if bilateral " +
                                "(in both breasts). ",
                                "###ACRMG#70")
                        ,
                        new ConceptDef()
                            .SetCode("SegmentalDistribution")
                            .SetDisplay("Segmental distribution")
                            .MammoId("757")
                            .ValidModalities(Modalities.MG)
                            .SetDicom("F-01774")
                            .SetSnomedCode("129768003")
                            .SetSnomedDescription("ClinicalFinding | 129768003 | Radiographic calcification " +
                                "with segmental distribution (Finding)")
                            .SetACR("Calcifications in a segmental distribution are of " +
                                "concern because they suggest deposits in a duct or " +
                                "ducts and their branches, raising the possibility " +
                                "of extensive or multifocal breast cancer in a lobe " +
                                "or segment of the breast. ",
                                "Although benign causes of segmental calcifications " +
                                "exist (e.g. ",
                                "large rod-like), the smooth, rod-like morphology " +
                                "and large size of benign calcifications distinguish " +
                                "them from finer, more pleomorphic or heterogeneous " +
                                "malignant calcifications. ",
                                "A segmental distribution may elevate the degree of " +
                                "suspicion for calcifications such as punctate or " +
                                "amorphous forms.")
                        //- Codes
                    }));

        VSTaskVar CalcificationDistributionVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "CalcificationDistributionVS",
                    "Calcification Distribution ValueSet",
                    "Calcification Distribution/ValueSet",
                    "Calcification Distribution of an abnormality value set.",
                    Group_CommonCodesVS,
                    Self.CalcificationDistributionCS.Value()
                )
        );
    }
}
