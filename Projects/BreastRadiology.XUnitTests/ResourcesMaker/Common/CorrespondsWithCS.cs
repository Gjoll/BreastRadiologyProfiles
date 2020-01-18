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
                            //+ Aspiration
                            new ConceptDef()
                                .SetCode("Aspiration")
                                .SetDisplay("Aspiration")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Aspiration")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- Aspiration
                            // SNOMED Description: Procedure | 122548005 | Biopsy of breast (Procedure)
                            //+ Biopsy
                            new ConceptDef()
                                .SetCode("Biopsy")
                                .SetDisplay("Biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Biopsy
                            //+ Concern
                            new ConceptDef()
                                .SetCode("Concern")
                                .SetDisplay("Concern")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Concern")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- Concern
                            // SNOMED Description: Procedure | 420131003 | Fluoroscopic mammary ductography (Procedure) 
                            //+ Ductogram
                            new ConceptDef()
                                .SetCode("Ductogram")
                                .SetDisplay("Ductogram")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ductogram")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Ductogram
                            //+ IncidentalFinding
                            new ConceptDef()
                                .SetCode("IncidentalFinding")
                                .SetDisplay("Incidental finding")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Incidental finding")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- IncidentalFinding
                            //+ Mammogram
                            new ConceptDef()
                                .SetCode("Mammogram")
                                .SetDisplay("Mammogram")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram")
                                    .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- Mammogram
                            // SNOMED Description: Procedure | 241615005 | Magnetic resonance imaging of breast (Procedure)
                            //+ MRI
                            new ConceptDef()
                                .SetCode("MRI")
                                .SetDisplay("MRI")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MRI")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- MRI
                            // SNOMED Description: ClinicalFinding | 162166009 | Nipple discharge present (Disorder) | [0/0] | N64.52 |
                            //+ NippleDischarge
                            new ConceptDef()
                                .SetCode("NippleDischarge")
                                .SetDisplay("Nipple discharge")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Nipple discharge")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- NippleDischarge
                            //+ OutsideExam
                            new ConceptDef()
                                .SetCode("OutsideExam")
                                .SetDisplay("Outside exam")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Outside exam")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- OutsideExam
                            //+ Pain
                            new ConceptDef()
                                .SetCode("Pain")
                                .SetDisplay("Pain")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Pain")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- Pain
                            //+ Palpated
                            new ConceptDef()
                                .SetCode("Palpated")
                                .SetDisplay("Palpated")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Palpated")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- Palpated
                            // SNOMED Description: BodyStructure | 312285003 | Post-surgical breast structure
                            //+ Post-operative
                            new ConceptDef()
                                .SetCode("Post-operative")
                                .SetDisplay("Post-operative")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Post-operative")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Post-operative
                            // SNOMED Description: Procedure | 122548005 | Biopsy of breast (Procedure)
                            //+ PreviousBiopsy
                            new ConceptDef()
                                .SetCode("PreviousBiopsy")
                                .SetDisplay("Previous biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Previous biopsy")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- PreviousBiopsy
                            //+ PriorExam
                            new ConceptDef()
                                .SetCode("PriorExam")
                                .SetDisplay("Prior exam")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Prior exam")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- PriorExam
                            //+ Redness
                            new ConceptDef()
                                .SetCode("Redness")
                                .SetDisplay("Redness")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Redness")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- Redness
                            //+ Scinti
                            new ConceptDef()
                                .SetCode("Scinti")
                                .SetDisplay("Scinti")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scinti")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Scinti
                            //+ size<Mammo
                            new ConceptDef()
                                .SetCode("size<Mammo")
                                .SetDisplay("size < mammo")
                                .SetDefinition(new Definition()
                                    .Line("[PR] size < mammo")
                                    .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- size<Mammo
                            //+ size<MRI
                            new ConceptDef()
                                .SetCode("size<MRI")
                                .SetDisplay("size < MRI")
                                .SetDefinition(new Definition()
                                    .Line("[PR] size < MRI")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- size<MRI
                            //+ size<Palp
                            new ConceptDef()
                                .SetCode("size<Palp")
                                .SetDisplay("size < palp")
                                .SetDefinition(new Definition()
                                    .Line("[PR] size < palp")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- size<Palp
                            //+ size<US
                            new ConceptDef()
                                .SetCode("size<US")
                                .SetDisplay("size < US")
                                .SetDefinition(new Definition()
                                    .Line("[PR] size < US")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- size<US
                            //+ size>Mammo
                            new ConceptDef()
                                .SetCode("size>Mammo")
                                .SetDisplay("size > mammo")
                                .SetDefinition(new Definition()
                                    .Line("[PR] size > mammo")
                                    .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- size>Mammo
                            //+ size>MRI
                            new ConceptDef()
                                .SetCode("size>MRI")
                                .SetDisplay("size > MRI")
                                .SetDefinition(new Definition()
                                    .Line("[PR] size > MRI")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- size>MRI
                            //+ size>Palp
                            new ConceptDef()
                                .SetCode("size>Palp")
                                .SetDisplay("size > palp")
                                .SetDefinition(new Definition()
                                    .Line("[PR] size > palp")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- size>Palp
                            //+ size>US
                            new ConceptDef()
                                .SetCode("size>US")
                                .SetDisplay("size > US")
                                .SetDefinition(new Definition()
                                    .Line("[PR] size > US")
                                    .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- size>US
                            // SNOMED Description: PhysicalObject | 706314007 | Imaging lesion localization marker (Object) 
                            //+ SkinMarker
                            new ConceptDef()
                                .SetCode("SkinMarker")
                                .SetDisplay("Skin marker")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Skin marker")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- SkinMarker
                            // SNOMED Description: Procedure | 274331003 | Surgical biopsy of breast (Procedure)
                            //+ Surgery
                            new ConceptDef()
                                .SetCode("Surgery")
                                .SetDisplay("Surgery")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgery")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Surgery
                            //+ SurgicalSite
                            new ConceptDef()
                                .SetCode("SurgicalSite")
                                .SetDisplay("Surgical site")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical site")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- SurgicalSite
                            // SNOMED Description: ClinicalFinding | 290080002 | Localized tenderness of breast (Finding) | [0/0] | N64.4 
                            //+ Tenderness
                            new ConceptDef()
                                .SetCode("Tenderness")
                                .SetDisplay("Tenderness")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Tenderness")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Tenderness
                            // SNOMED Description: BodyStructure | 134190002 | Trigger point (BodyStructure)
                            //+ TriggerPoint
                            new ConceptDef()
                                .SetCode("TriggerPoint")
                                .SetDisplay("Trigger point")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Trigger point")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- TriggerPoint
                            //+ US
                            new ConceptDef()
                                .SetCode("US")
                                .SetDisplay("US")
                                .SetDefinition(new Definition()
                                    .Line("[PR] US")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                            //- US
                            //- CorrespondsWithCS
                        })
            );
    }
}
