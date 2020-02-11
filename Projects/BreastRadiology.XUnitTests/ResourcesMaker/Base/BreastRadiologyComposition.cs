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
        SDTaskVar BreastRadiologyDocument = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                // Start Section Sliceing
                ElementTreeNode StartSectionSlicing(SDefEditor e)
                {
                    ElementTreeNode sectionNode = e.Get("section");

                    ElementDefinition.SlicingComponent slicingComponent = new ElementDefinition.SlicingComponent
                    {
                        Rules = ElementDefinition.SlicingRules.Open
                    };

                    slicingComponent.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
                    {
                        Type = ElementDefinition.DiscriminatorType.Pattern,
                        Path = "code"
                    });

                    sectionNode.ApplySlicing(slicingComponent, false);
                    return sectionNode;
                }

                ElementDefinition CreateElement(ElementTreeSlice slice, String name)
                {
                    ElementDefinition e = new ElementDefinition
                    {
                        Path = $"{slice.ElementDefinition.Path}.{name}",
                        ElementId = $"{slice.ElementDefinition.ElementId}.{name}"
                    };

                    slice.CreateNode(e);
                    return e;
                }

                ElementTreeSlice SliceSection(ElementTreeNode sliceElementDef,
                    String sliceName,
                    String title,
                    Coding code,
                    out ElementDefinition entry)
                {
                    ElementTreeSlice slice = sliceElementDef.CreateSlice(sliceName);

                    CreateElement(slice, "title")
                        .Single()
                        .Fixed(new FhirString(title))
                        ;
                    CreateElement(slice, "code")
                        .Single()
                        .Pattern(code.ToCodeableConcept().ToPattern())
                        ;
                    CreateElement(slice, "focus")
                        .Zero()
                        ;
                    entry = CreateElement(slice, "entry")
                        ;

                    CreateElement(slice, "section")
                        .Zero()
                        ;
                    return slice;
                }

                SDefEditor e = Self.CreateEditor("BreastRadComposition",
                     "Breast Radiology Composition",
                     "Breast/Radiology/Composition",
                     Global.CompositionUrl,
                     Group_BaseResources,
                     "Resource")
                     .Description("Breast Radiology Composition",
                         new Markdown()
                             .Paragraph("This is the composition resource for the Breast Radiology Fhir Document.")
                             .Paragraph("A Fhir Document is a Bundle that contains a composition as the first entry and",
                                        "provides a single item (bundle) that contains all the resources that are a part of",
                                        "the Breast Radiology Diagnostic Report.")
                             .Paragraph("This composition creates the following sections that contain resources related to the document.")
                             .Paragraph("A. Report Section.",
                                        "This contains a single reference to the Breast Radiology Report",
                                        "All Breast Radiology Findings are referenced by the reports results element.")
                             .Paragraph("B. Impressions Section.",
                                        "All of the clinical impressions created for this exam are referenced in this section.")
                             .Paragraph("C. Recommendations Section.",
                                        "All of the service and medication recommendations created for this exam are referenced in this section.",
                                        "If a recommendation is in response to a particular observation or finding, then ",
                                        "the recommendations 'reasonReference' should contain a  reference to the pertinant observation or finding.")
                     )
                     .AddFragRef(Self.HeaderFragment.Value())
                     ;

                s = e.SDef;
                e.IntroDoc
                     .ReviewedStatus("NOONE", "")
                     ;

                // Report Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[] { Self.BreastRadiologyReport.Value().Url };

                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "report",
                            "Breast Radiology Report",
                            Self.SectionCodeReport,
                            out ElementDefinition entry);
                        entry
                            .Single()
                            .Type("Reference", null, targets)
                            .Short("Breast Radiology Report reference")
                            .Definition("Reference to the Breast Radiology Report.")
                            ;

                        sectionSlice.ElementDefinition
                            .Single()
                            .SetShort($"Report Section")
                            .SetDefinition(
                                new Markdown()
                                    .Paragraph($"This section references the single required Breast Radiology Report'.")
                                )
                            .MustSupport();
                        ;

                        e.AddComponentLink("Report",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }

                // Impressions Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[] { Global.ClinicalImpressionUrl };

                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "impressions",
                            "Clinical Impressions",
                            Self.SectionCodeImpressions,
                            out ElementDefinition entry);
                        entry
                            .Single()
                            .Type("Reference", null, targets)
                            .Short("Clinical Impression reference")
                            .Definition("Reference to the clinical impression.")
                            ;
                        sectionSlice.ElementDefinition
                            .ZeroToMany()
                            .SetShort($"Impressions Section")
                            .SetDefinition(
                                new Markdown()
                                    .Paragraph($"This section contains references to the report's clinical impressions.")
                                )
                            .MustSupport();
                        ;
                        e.AddComponentLink("Impressions",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }

                //// Findings Section
                //{
                //    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                //    {
                //        String[] targets = new string[] { ObservationUrl };

                //        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                //            "findings",
                //            "Findings",
                //            Self.SectionCodeFindings,
                //            out ElementDefinition entry);
                //        entry
                //            .Single()
                //            .Type("Reference", null, targets)
                //            .Short("Finding reference")
                //            .Definition("Reference to the finding.")
                //            ;
                //        sectionSlice.ElementDefinition
                //            .ZeroToMany()
                //            .SetShort($"Findings Section")
                //            .SetDefinition(
                //                new Markdown()
                //                    .Paragraph($"This section contains references to the report's findings.")
                //                )
                //            .MustSupport();
                //        ;
                //        e.AddComponentLinkTarget("Findings",
                //            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                //            Global.ElementAnchor(sectionSlice.ElementDefinition),
                //            "Section",
                //            targets);
                //    }
                //}

                // Related Resources Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[] { Global.ResourceUrl };

                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "relatedResources",
                            "Related Resources",
                            Self.SectionCodeRelatedResources,
                            out ElementDefinition entry);
                        entry
                            .Single()
                            .Type("Reference", null, targets)
                            .Short("Related Resource reference")
                            .Definition("Reference to the related resource.")
                            ;
                        sectionSlice.ElementDefinition
                            .ZeroToMany()
                            .Short("Related Clinical Resources Section")
                            .Definition("References to FHIR clinical resoruces used during the exam or referenced by this report.")
                            .MustSupport();
                        ;
                        e.AddComponentLink("Related Resources",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }

                // Recommendations Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[] { Global.MedicationRequestUrl, Global.ServiceRequestUrl, Self.ServiceRecommendation.Value().Url };

                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "recommendations",
                            "Recommendations",
                            Self.SectionCodeRecommendations,
                            out ElementDefinition entry);
                        entry
                            .Single()
                            .Type("Reference", null, targets)
                            .Short("Recommendation reference")
                            .Definition("Reference to the recommended action.")
                            ;
                        sectionSlice.ElementDefinition
                            .ZeroToMany()
                            .Short("Recommendations Section")
                            .Definition("This section contains references to recommended actions taken in response to the observations and findings of this report.")
                            .MustSupport();
                        ;
                        e.AddComponentLink("Recommendations",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }
            });
    }
}
