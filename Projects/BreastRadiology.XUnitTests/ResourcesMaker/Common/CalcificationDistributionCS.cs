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
                        //+ BranchingDistribution
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("BranchingDistribution")
                            .SetDisplay("Branching distribution")
                            .SetDefinition("[PR] Branching distribution")
                            .MammoId("703")
                            .ValidModalities(Modalities.MG)
                            .SetSnomedDescription("ClinicalFinding | 129762002 | Fine, linear, branching " +
                                "(casting) radiographic calcification (Finding)")
                            .SetUMLS("These are calcifications arranged in a line or showing " +
                                "a branching pattern, suggesting deposits in a duct. " +
                                "They tend to be distributed in a linear manner.")
                        //- AutoGen
                        ,
                        //- BranchingDistribution
                        //+ ClusteredDistribution
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("ClusteredDistribution")
                            .SetDisplay("Clustered distribution")
                            .SetDefinition("[PR] Clustered distribution")
                            .MammoId("751")
                            .ValidModalities(Modalities.MG)
                            .SetSnomedDescription("ClinicalFinding | 129769006 | Radiographic calcification " +
                                "with clustered distribution (Finding)")
                            .SetUMLS("Clustered Distribution is in regards to a type of " +
                                "calcification with at least 5 calcifications occupying " +
                                "a small volume of tissue.")
                        //- AutoGen
                        ,
                        //- ClusteredDistribution
                        //+ DiffuseDistribution
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("DiffuseDistribution")
                            .SetDisplay("Diffuse distribution")
                            .SetDefinition("[PR] Diffuse distribution")
                            .MammoId("752")
                            .ValidModalities(Modalities.MG)
                            .SetDicom("F-01770")
                            .SetSnomedDescription("ClinicalFinding | 129764001 | Radiographic calcification " +
                                "with diffuse distribution (Finding)")
                            .SetUMLS("C1268689")
                        //- AutoGen
                            .BiRadsDef("Diffuse (historically, \"scattered\"). These are calcifications that are distributed randomly throughout the breast. ",
                                "Punctate and amorphous calcifications in this distribution are almost always benign, ",
                                "especially if bilateral.")
                        ,
                        //- DiffuseDistribution
                        //+ GroupedDistribution
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("GroupedDistribution")
                            .SetDisplay("Grouped distribution")
                            .SetDefinition("[PR] Grouped distribution")
                            .MammoId("753")
                            .ValidModalities(Modalities.MG)
                            .SetDicom("F-01772")
                            .SetSnomedDescription("ClinicalFinding | 129766004 | Radiographic calcification " +
                                "with grouped distribution (Finding)")
                            .SetUMLS("C1268691")
                        //- AutoGen
                            .BiRadsDef("This term should be used when relatively few calcifications occupy a ",
                                "small portion of breast tissue. ",
                                "The lower limit for use of this descriptor is usually when 5 calcifications ",
                                "are grouped within 1 cm of each other or when a definable pattern is identified. ",
                                "The upper limit for use of this descriptor is when larger numbers of ",
                                "calcifications are grouped within 2 cm of each other.)")
                        ,
                        //- GroupedDistribution
                        //+ LinearDistribution
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("LinearDistribution")
                            .SetDisplay("Linear distribution")
                            .SetDefinition("[PR] Linear distribution")
                            .MammoId("754")
                            .ValidModalities(Modalities.MG)
                            .SetDicom("F-01771")
                            .SetSnomedDescription("ClinicalFinding | 129765000 | Radiographic calcification " +
                                "with linear distribution (Finding)")
                            .SetUMLS("C1268690")
                        //- AutoGen
                            .BiRadsDef("These are calcifications arrayed in a line. ",
                                "This distribution may elevate suspicion for malignancy, ",
                                "as it suggests deposits in a duct. ",
                                "Note that both vascular and large rod-like calcifications ",
                                "also are usually linear in distribution, but that these typically ",
                                "benign calcifications have a characteristically benign morphology.)")
                        ,
                        //- LinearDistribution
                        //+ RegionalDistribution
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("RegionalDistribution")
                            .SetDisplay("Regional distribution")
                            .SetDefinition("[PR] Regional distribution")
                            .MammoId("755")
                            .ValidModalities(Modalities.MG)
                            .SetDicom("F-01773")
                            .SetSnomedDescription("ClinicalFinding | 129767008 | Radiographic calcification " +
                                "with regional distribution (Finding)")
                            .SetUMLS("C1268692")
                        //- AutoGen
                            .BiRadsDef("This descriptor is used for numerous calcifications ",
                                "that occupy a large portion of breast tissue ",
                                "(more than 2 cm in greatest dimension), not conforming to a duct distribution. ",
                                "Since this distribution may involve most of a quadrant or even more than a ",
                                "single quadrant, malignancy is less likely. ",
                                "However, overall evaluation of regional calcifications must include particle ",
                                "shape (morphology) as well as distribution.")
                        ,
                        //- RegionalDistribution
                        //+ ScatteredDistribution
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("ScatteredDistribution")
                            .SetDisplay("Scattered distribution")
                            .SetDefinition("[PR] Scattered distribution")
                            .MammoId("756")
                            .ValidModalities(Modalities.MG)
                            .SetSnomedDescription("not found")
                            .SetComment("not found")
                            .SetUMLS("Refers to a type of calcification of the breast. " +
                                "Scattered calcifications or multiple similar appearing " +
                                "clusters of calcifications throughout the whole breast.")
                        //- AutoGen
                        ,
                        //- ScatteredDistribution
                        //+ SegmentalDistribution
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("SegmentalDistribution")
                            .SetDisplay("Segmental distribution")
                            .SetDefinition("[PR] Segmental distribution")
                            .MammoId("757")
                            .ValidModalities(Modalities.MG)
                            .SetDicom("F-01774")
                            .SetSnomedCode("129768003")
                            .SetSnomedDescription("ClinicalFinding | 129768003 | Radiographic calcification " +
                                "with segmental distribution (Finding)")
                            .SetUMLS("C1268693")
                        //- AutoGen
                            .BiRadsDef("Calcifications in a segmental distribution are of concern because ",
                                "they suggest deposits in a duct or ducts and their branches, raising the possibility ",
                                "of extensive or multifocal breast cancer in a lobe or segment of the breast. ",
                                "Although benign causes of segmental calcifications exist (e.g. large rod-like), ",
                                "the smooth, rod-like morphology and large size of benign calcifications ",
                                "distinguish them from finer, more pleomorphic or heterogeneous malignant calcifications. ",
                                "A segmental distribution may elevate the degree of suspicion for calcifications such as ",
                                "punctate or amorphous forms.")
                        
                        //- SegmentalDistribution
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
