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
                #region Local Methods
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
                        .DefaultValueExtension(code.ToCodeableConcept())
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
                #endregion
                SDefEditor e = Self.CreateEditor("BreastRadComposition",
                            "Breast Radiology Composition",
                            "Breast/Radiology/Composition",
                            Global.CompositionUrl,
                            Group_BaseResources,
                            "Resource")
                        .Description("Breast Radiology Composition",
                            new Markdown()
                                .Paragraph("This is the composition resource for the Breast Radiology FHIR Document.",
                                    "This resource is based on FHIR Composition resource.")
                                .Paragraph(
                                    "A FHIR Document is a Bundle that contains a composition as the first entry and ",
                                    "provides a single item (bundle) that contains all the resources that are a part of",
                                    "the Breast Radiology Diagnostic Report.")
                                .Paragraph("The composition object is an required part of the FHIR Document structure.",
                                    "One composition must exist, and it must be the first resource stored in the FHIR document bundle.")
                                .Paragraph("The other exam related resources are referenced through the ",
                                           "sections defined in this resource.")
                                .Paragraph("This composition creates the following sections.")
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
                        .AddFragRef(Self.HeaderFragment)
                    ;

                s = e.SDef;
                e.IntroDoc
                    .ReviewedStatus("KWA 3/19/20")
                    .ReviewedStatus("Needs review by Penrad")
                    .ReviewedStatus("Needs review by MRS")
                    .ReviewedStatus("Needs review by MagView")
                    .ReviewedStatus("Needs review by CIMI")
                    ;
                // fix Composition.type
                {
                    CodeableConcept code = new CodeableConcept(Global.Loinc, "42132-1", "US Breast screening");
                    e.Select("type")
                        .Pattern(code)
                        .DefaultValueExtension(code);
                }
                // Report Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[] {Self.BreastRadiologyReport.Value().Url};

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
                            .SetShort($"Report Section.")
                            .SetDefinition(
                                new Markdown()
                                    .Paragraph($"This section references the Breast Radiology Report'.")
                                    .Paragraph($"One and only one Breast Radiology Report must be included in this section.'.")
                            )
                            .MustSupport();
                        ;

                        e.AddComponentLink("Report",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            new SDefEditor.Cardinality(entry),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }

                // Impressions Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[] {Global.ClinicalImpressionUrl};

                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "impressions",
                            "Clinical Impressions",
                            Self.SectionCodeImpressions,
                            out ElementDefinition entry);
                        entry
                            .ZeroToMany()
                            .Type("Reference", null, targets)
                            .Short("Clinical Impression reference")
                            .Definition("Reference to the clinical impression(s).")
                            ;
                        sectionSlice.ElementDefinition
                            .ZeroToOne()
                            .SetShort($"Impressions Section.")
                            .SetDefinition(
                                new Markdown()
                                    .Paragraph(
                                        $"This section contains references to the report's clinical impressions.")
                            )
                            .MustSupport();
                        ;
                        e.AddComponentLink("Impressions",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            new SDefEditor.Cardinality(entry),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }

                // Findings Right Breast Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[] {Self.FindingsRightBreast.Value().Url};

                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "findingsRightBreast",
                            "Findings Right Breast",
                            Self.SectionCodeFindingsRightBreast,
                            out ElementDefinition entry);
                        entry
                            .ZeroToOne()
                            .Type("Reference", null, targets)
                            .Short("Finding Right breast reference")
                            .Definition("Reference to the finding for the right breast.")
                            ;
                        sectionSlice.ElementDefinition
                            .ZeroToOne()
                            .SetShort($"Findings Section Right Breast.")
                            .SetDefinition(
                                new Markdown()
                                    .Paragraph(
                                        $"This section contains references to the report's findings for the right breast.")
                            )
                            .MustSupport();
                        ;
                        e.AddComponentLink("Findings Right Breast",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            new SDefEditor.Cardinality(entry),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }

                // Findings Left Breast Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[] {Self.FindingsLeftBreast.Value().Url};

                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "findingsLeftBreast",
                            "Findings Left Breast",
                            Self.SectionCodeFindingsLeftBreast,
                            out ElementDefinition entry);
                        entry
                            .ZeroToOne()
                            .Type("Reference", null, targets)
                            .Short("Finding left breast reference")
                            .Definition("Reference to the finding for the left breast.")
                            ;
                        sectionSlice.ElementDefinition
                            .ZeroToOne()
                            .SetShort($"Findings Section Left Breast.")
                            .SetDefinition(
                                new Markdown()
                                    .Paragraph(
                                        $"This section contains references to the report's findings for the left breast.")
                            )
                            .MustSupport();
                        ;
                        e.AddComponentLink("Findings Left Breast",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            new SDefEditor.Cardinality(entry),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }

                // Related Resources Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[] {Global.ResourceUrl};

                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "relatedResources",
                            "Related Resources",
                            Self.SectionCodeRelatedResources,
                            out ElementDefinition entry);
                        entry
                            .ZeroToMany()
                            .Type("Reference", null, targets)
                            .Short("Related Resource reference")
                            .Definition("Reference to the related resource.")
                            ;
                        sectionSlice.ElementDefinition
                            .ZeroToOne()
                            .Short("Related Clinical Resources Section")
                            .Definition(
                                "References to FHIR clinical resources used during the exam or referenced by this report.")
                            .MustSupport();
                        ;
                        e.AddComponentLink("Related Resources",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            new SDefEditor.Cardinality(entry),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }

                // Recommendations Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[]
                        {
                            Global.MedicationRequestUrl, Global.ServiceRequestUrl,
                            Self.ServiceRecommendation.Value().Url
                        };

                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "recommendations",
                            "Recommendations",
                            Self.SectionCodeRecommendations,
                            out ElementDefinition entry);
                        entry
                            .ZeroToMany()
                            .Type("Reference", null, targets)
                            .Short("Recommendation reference")
                            .Definition("Reference to the recommended action.")
                            ;
                        sectionSlice.ElementDefinition
                            .ZeroToOne()
                            .Short("Recommendations Section")
                            .Definition(
                                "This section contains references to recommended actions taken in response to the observations and findings of this report.")
                            .MustSupport();
                        ;
                        e.AddComponentLink("Recommendations",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            new SDefEditor.Cardinality(entry),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }

                // Admin Section
                {
                    ElementTreeNode sliceElementDef = StartSectionSlicing(e);
                    {
                        String[] targets = new string[] { Global.ResourceUrl };

                        ElementTreeSlice sectionSlice = SliceSection(sliceElementDef,
                            "admin",
                            "Admin",
                            Self.SectionCodeAdmin,
                            out ElementDefinition entry);
                        entry
                            .ZeroToMany()
                            .Type("Reference", null, targets)
                            .Short("Administrative section")
                            .Definition("References to all administrative resources go here.")
                            ;
                        sectionSlice.ElementDefinition
                            .ZeroToOne()
                            .Short("Administrative section")
                            .Definition(
                                "References to all administrative resources go here.")
                            .MustSupport();
                        ;
                        e.AddComponentLink("Admin",
                            new SDefEditor.Cardinality(sectionSlice.ElementDefinition),
                            new SDefEditor.Cardinality(entry),
                            Global.ElementAnchor(sectionSlice.ElementDefinition),
                            "Section",
                            targets);
                    }
                }

            });
    }
}