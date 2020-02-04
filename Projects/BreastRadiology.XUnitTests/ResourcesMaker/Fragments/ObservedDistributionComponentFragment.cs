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
        SDTaskVar ObservedDistributionComponentFragment = new SDTaskVar(
               (out StructureDefinition s) =>
                   {
                       SDefEditor e = Self.CreateFragment("ObservedDistributionFragment",
                               "ObservedDistribution Fragment",
                               "ObservedDistribution Fragment",
                               Global.ObservationUrl)
                           .Description("Fragment that adds 'Observed Distribution' components to Observation.",
                               new Markdown()
                           )
                           ;
                       s = e.SDef;

                       e.StartComponentSliceing();
                       {
                           e.ComponentSliceCodeableConcept("obsDistribution",
                               Self.ComponentSliceCodeObservedDistribution.ToCodeableConcept(),
                               Self.ObservedDistributionVS.Value(),
                               BindingStrength.Required,
                               0,
                               "*",
                               "Observed distribution of abnormalities",
                               new Markdown()
                                   .Paragraph($"This slice contains an optional description of the distribution of a ",
                                              "group of abnormalities. ",
                                               $"The value of this component is a codeable concept chosen from the {Self.ObservedDistributionVS.Value().Name} valueset.")
                               );
                       }
                       {
                           ValueSet binding = Self.UnitsOfLengthVS.Value();
                           String sliceName = "obsDistRegionSize";
                           e.SliceComponentSize(sliceName,
                               Self.ComponentSliceCodeObservedSize.ToCodeableConcept(),
                               binding,
                               0,
                               "3",
                               out ElementTreeSlice slice);

                           ElementDefinition sliceDef = slice.ElementDefinition
                               .SetShort($"Observed Distribution Region Size component")
                               .SetDefinition(new Markdown()
                                    .Paragraph($"This component slice contains the size of an region inside of which there ",
                                               $"is a distribution of abnormalities.",
                                               $"There may be one, two, or three values indicating a size of",
                                               $"one dimension (length), two dimensions (area), or three dimensions (volume).",
                                               $"Each dimension can be a quantity (i.e. 5), or a range (1 to 5).",
                                               $"If the lower bound of the range is set but not the upper bound, then the size is {{lower bound}} or greater.",
                                               $"If the upper bound of the range is set but not the lower bound, then the size is {{upper bound}} or less.")
                                    )
                               .SetComment(componentDefinition)
                               ;

                           e.AddComponentLink($"Observed Distribution Region Size",
                               new SDefEditor.Cardinality(slice.ElementDefinition),
                               Global.ElementAnchor(sliceDef),
                               "Quantity or Range",
                               binding.Url);
                       }
                   });


        CSTaskVar ObservedDistributionCS = new CSTaskVar(
              (out CodeSystem cs) =>
                  cs = Self.CreateCodeSystem(
                      "ObservedDistributionCS",
                      "Observed Distribution CodeSystem",
                      "Observed/Distribution/CodeSystem",
                      "Observed Distribution in an abnormality code system.",
                      Group_CommonCodesCS,
                      new ConceptDef[]
                      {
                         new ConceptDef()
                             .SetCode("Diffuse")
                             .SetDisplay("Diffuse (historically, \"scattered\")")
                             .BiRadsDef("These are calcifications that are distributed randomly throughout the breast. ",
                                        "Punctate and amorphous calcifications in this distribution are almost always benign, ",
                                        "especially if bilateral."),
                         new ConceptDef()
                             .SetCode("Regional")
                             .SetDisplay("Regional")
                             .BiRadsDef("This descriptor is used for numerous calcifications ",
                                        "that occupy a large portion of breast tissue ",
                                        "(more than 2 cm in greatest dimension), not conforming to a duct distribution. ",
                                        "Since this distribution may involve most of a quadrant or even more than a ",
                                        "single quadrant, malignancy is less likely. ",
                                        "However, overall evaluation of regional calcifications must include particle ",
                                        "shape (morphology) as well as distribution."),
                         new ConceptDef()
                             .SetCode("Grouped")
                             .SetDisplay("Grouped (historically, \"clustered\")")
                             .BiRadsDef("This term should be used when relatively few calcifications occupy a ",
                                        "small portion of breast tissue. ",
                                        "The lower limit for use of this descriptor is usually when 5 calcifications ",
                                        "are grouped within 1 cm of each other or when a definable pattern is identified. ",
                                        "The upper limit for use of this descriptor is when larger numbers of ",
                                        "calcifications are grouped within 2 cm of each other.)"),
                         new ConceptDef()
                             .SetCode("Linear")
                             .SetDisplay("Linear")
                             .BiRadsDef("These are calcifications arrayed in a line. ",
                                        "This distribution may elevate suspicion for malignancy, ",
                                        "as it suggests deposits in a duct. ",
                                        "Note that both vascular and large rod-like calcifications ",
                                        "also are usually linear in distribution, but that these typically ",
                                        "benign calcifications have a characteristically benign morphology.)"),
                         new ConceptDef()
                             .SetCode("Segmental")
                             .SetDisplay("Segmental")
                             .BiRadsDef("Calcifications in a segmental distribution are of concern because ",
                                        "they suggest deposits in a duct or ducts and their branches, raising the possibility ",
                                        "of extensive or multifocal breast cancer in a lobe or segment of the breast. ",
                                        "Although benign causes of segmental calcifications exist (e.g. large rod-like), ",
                                        "the smooth, rod-like morphology and large size of benign calcifications ",
                                        "distinguish them from finer, more pleomorphic or heterogeneous malignant calcifications. ",
                                        "A segmental distribution may elevate the degree of suspicion for calcifications such as ",
                                        "punctate or amorphous forms.")
                      }));

        VSTaskVar ObservedDistributionVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ObservedDistributionVS",
                    "Observed Distribution ValueSet",
                    "Observed Distribution/ValueSet",
                    "Observed Distribution of an abnormality value set.",
                    Group_CommonCodesVS,
                    Self.ObservedDistributionCS.Value()
                    )
            );
}
}
