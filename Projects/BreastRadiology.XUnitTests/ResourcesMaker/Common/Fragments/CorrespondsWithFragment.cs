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
        SDTaskVar CorrespondsWithFragment = new SDTaskVar(
               (out StructureDefinition s) =>
                   {
                       SDefEditor e = Self.CreateFragment("CorrespondsWithFragment",
                               "CorrespondsWith Fragment",
                               "CorrespondsWith Fragment",
                               ObservationUrl)
                           .Description("Observation 'Consistent With' Component Fragment",
                               new Markdown()
                           )
                           ;
                       s = e.SDef;

                       e.StartComponentSliceing();
                       e.ComponentSliceCodeableConcept("correspondsWith",
                           Self.CodeCorrespondsWith.ToCodeableConcept(),
                           Self.CorrespondsWithVS.Value(),
                           BindingStrength.Extensible,
                           0,
                           "*",
                           "Corresponds With",
                            new Markdown()
                                .Paragraph($"This slice contains zero or more components that defines what this observation correspomnds with.",
                                            $"The value of this component is a codeable concept chosen from the {Self.CorrespondsWithVS.Value().Name} valueset.")
                           );
                       e.IntroDoc
                           .ReviewedStatus(ReviewStatus.NotReviewed)
                           ;
                   });

        VSTaskVar CorrespondsWithVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "CorrespondsWithVS",
                        "CorrespondsWith ValueSet",
                        "CorrespondsWith/ValueSet",
                        "CorrespondsWith value set.",
                        Group_MGCodesVS,
                        Self.CorrespondsWithCS.Value()
                    )
            );


        CSTaskVar CorrespondsWithCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "CorrespondsWithCodeSystemCS",
                        "Consistent With CodeSystem",
                        "CorrespondsWith/CodeSystem",
                        "CorrespondsWith code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            //+ CorrespondsWithCS
                            // SNOMED Description: Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)
                            new ConceptDef("Aspiration",
                                "Aspiration",
                                new Definition()
                                    .Line("[PR] Aspiration")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 122548005 | Biopsy of breast (Procedure)
                            new ConceptDef("Biopsy",
                                "Biopsy",
                                new Definition()
                                    .Line("[PR] Biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Concern",
                                "Concern",
                                new Definition()
                                    .Line("[PR] Concern")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 420131003 | Fluoroscopic mammary ductography (Procedure) 
                            new ConceptDef("Ductogram",
                                "Ductogram",
                                new Definition()
                                    .Line("[PR] Ductogram")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("IncidentalFinding",
                                "Incidental finding",
                                new Definition()
                                    .Line("[PR] Incidental finding")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("Mammogram",
                                "Mammogram",
                                new Definition()
                                    .Line("[PR] Mammogram")
                                    .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241615005 | Magnetic resonance imaging of breast (Procedure)
                            new ConceptDef("MRI",
                                "MRI",
                                new Definition()
                                    .Line("[PR] MRI")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: ClinicalFinding | 162166009 | Nipple discharge present (Disorder) | [0/0] | N64.52 |
                            new ConceptDef("NippleDischarge",
                                "Nipple discharge",
                                new Definition()
                                    .Line("[PR] Nipple discharge")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("OutsideExam",
                                "Outside exam",
                                new Definition()
                                    .Line("[PR] Outside exam")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Pain",
                                "Pain",
                                new Definition()
                                    .Line("[PR] Pain")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("Palpated",
                                "Palpated",
                                new Definition()
                                    .Line("[PR] Palpated")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: BodyStructure | 312285003 | Post-surgical breast structure
                            new ConceptDef("Post-operative",
                                "Post-operative",
                                new Definition()
                                    .Line("[PR] Post-operative")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 122548005 | Biopsy of breast (Procedure)
                            new ConceptDef("PreviousBiopsy",
                                "Previous biopsy",
                                new Definition()
                                    .Line("[PR] Previous biopsy")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("PriorExam",
                                "Prior exam",
                                new Definition()
                                    .Line("[PR] Prior exam")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Redness",
                                "Redness",
                                new Definition()
                                    .Line("[PR] Redness")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("Scinti",
                                "Scinti",
                                new Definition()
                                    .Line("[PR] Scinti")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("size<Mammo",
                                "size < mammo",
                                new Definition()
                                    .Line("[PR] size < mammo")
                                    .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("size<MRI",
                                "size < MRI",
                                new Definition()
                                    .Line("[PR] size < MRI")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("size<Palp",
                                "size < palp",
                                new Definition()
                                    .Line("[PR] size < palp")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("size<US",
                                "size < US",
                                new Definition()
                                    .Line("[PR] size < US")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("size>Mammo",
                                "size > mammo",
                                new Definition()
                                    .Line("[PR] size > mammo")
                                    .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("size>MRI",
                                "size > MRI",
                                new Definition()
                                    .Line("[PR] size > MRI")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("size>Palp",
                                "size > palp",
                                new Definition()
                                    .Line("[PR] size > palp")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("size>US",
                                "size > US",
                                new Definition()
                                    .Line("[PR] size > US")
                                    .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: PhysicalObject | 706314007 | Imaging lesion localization marker (Object) 
                            new ConceptDef("SkinMarker",
                                "Skin marker",
                                new Definition()
                                    .Line("[PR] Skin marker")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 274331003 | Surgical biopsy of breast (Procedure)
                            new ConceptDef("Surgery",
                                "Surgery",
                                new Definition()
                                    .Line("[PR] Surgery")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("SurgicalSite",
                                "Surgical site",
                                new Definition()
                                    .Line("[PR] Surgical site")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            // SNOMED Description: ClinicalFinding | 290080002 | Localized tenderness of breast (Finding) | [0/0] | N64.4 
                            new ConceptDef("Tenderness",
                                "Tenderness",
                                new Definition()
                                    .Line("[PR] Tenderness")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: BodyStructure | 134190002 | Trigger point (BodyStructure)
                            new ConceptDef("TriggerPoint",
                                "Trigger point",
                                new Definition()
                                    .Line("[PR] Trigger point")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("US",
                                "US",
                                new Definition()
                                    .Line("[PR] US")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                            //- CorrespondsWithCS
                        })
            );
    }
}
