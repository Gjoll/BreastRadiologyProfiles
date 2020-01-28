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
                    Coding code)
                {
                    ElementTreeSlice slice = sliceElementDef.CreateSlice(sliceName);

                    CodeableConcept sectionCode = new CodeableConcept();
                    sectionCode.Coding.Add(Self.SectionCodeReport);

                    CreateElement(slice, "code").Single().Fixed(sectionCode);
                    CreateElement(slice, "title").Single().Fixed(new FhirString(title));
                    CreateElement(slice, "section").Zero();
                    CreateElement(slice, "focus").Zero();
                    return slice;
                }


                SDefEditor e = Self.CreateEditor("BreastRadComposition",
                     "Breast Radiology Composition",
                     "Breast/Radiology/Composition",
                     CompositionUrl,
                     Group_BaseResources,
                     "Resource")
                     .Description("Breast Radiology Composition",
                         new Markdown()
                             .Paragraph("This is the composition resource for the Breast Radiology Fhir Document.")
                             .Paragraph("A Fhir Document is a Bundle that contains a composition as the first entry and",
                                        "provides a single item (bundle) that contains all the resources that are a part of",
                                        "the Breat Radiology Diagnostic Report.")
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
                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "report",
                            "Breast Radiology Report",
                            Self.SectionCodeReport);
                        CreateElement(sectionSlice, "entry").Single().Type("Reference", null, new string[] { Self.BreastRadiologyReport.Value().Url });

                        sectionSlice.ElementDefinition
                            .Single()
                            .SetShort($"Report Section")
                            .SetDefinition(
                                new Markdown($"This section references the single required Breast Radiology Report'")
                                )
                            .MustSupport();
                        ;

                        e.AddComponentLinkTarget("Report",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            new String[] { Self.BreastRadiologyReport.Value().Url });
                    }
                }

                // Impressions Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "impressions",
                            "Clinical Impressions",
                            Self.SectionCodeReport);
                        CreateElement(sectionSlice, "entry").Single().Type("Reference", null, new string[] { ClinicalImpressionUrl });
                        sectionSlice.ElementDefinition
                            .ZeroToMany()
                            .SetShort($"Impressions Section")
                            .SetDefinition(
                                new Markdown($"This section contains references to the report impressions")
                                )
                            .MustSupport();
                        ;
                        e.AddComponentLinkTarget("Impressions",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            new string[] { ClinicalImpressionUrl });
                    }
                }

                // Findings Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "findings",
                            "Findings",
                            Self.SectionCodeReport);
                        CreateElement(sectionSlice, "entry").Single().Type("Reference", null, new string[] { ClinicalImpressionUrl });
                        sectionSlice.ElementDefinition
                            .ZeroToMany()
                            .SetShort($"Impressions Section")
                            .SetDefinition(
                                new Markdown($"This section contains references to the report impressions")
                                )
                            .MustSupport();
                        ;
                        e.AddComponentLinkTarget("Impressions",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            new string[] { ClinicalImpressionUrl });
                    }
                }

                // Related Resources Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "relatedResources",
                            "Related Resources",
                            Self.SectionCodeReport);
                        CreateElement(sectionSlice, "entry").Single().Type("Reference", null, new string[] { ResourceUrl });
                        sectionSlice.ElementDefinition
                            .ZeroToMany()
                            .Short("Related Clinical Resources Section")
                            .Definition("References to FHIR clinical resoruces used during the exam or referenced by this report.")
                            .MustSupport();
                        ;
                        e.AddComponentLinkTarget("Related Resources",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            new string[] { ResourceUrl });
                    }
                }
            });
    }
}
