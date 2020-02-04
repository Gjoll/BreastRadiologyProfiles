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
                        Group_CommonCodesVS,
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
                            //+ Aspiration
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Aspiration")
                                .SetDisplay("Aspiration")
                                .SetDefinition("[PR] Aspiration")
                                .MammoId("391")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)")
                            //- AutoGen
                            //- Aspiration
                            ,
                            //+ Biopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Biopsy")
                                .SetDisplay("Biopsy")
                                .SetDefinition("[PR] Biopsy")
                                .MammoId("392")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 122548005 | Biopsy of breast (Procedure)")
                            //- AutoGen
                            //- Biopsy
                            ,
                            //+ Concern
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Concern")
                                .SetDisplay("Concern")
                                .SetDefinition("[PR] Concern")
                                .MammoId("327")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- Concern
                            ,
                            //+ Ductogram
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Ductogram")
                                .SetDisplay("Ductogram")
                                .SetDefinition("[PR] Ductogram")
                                .MammoId("324")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 420131003 | Fluoroscopic mammary ductography (Procedure)")
                            //- AutoGen
                            //- Ductogram
                            ,
                            //+ IncidentalFinding
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("IncidentalFinding")
                                .SetDisplay("Incidental finding")
                                .SetDefinition("[PR] Incidental finding")
                                .MammoId("79")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- IncidentalFinding
                            ,
                            //+ Mammogram
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Mammogram")
                                .SetDisplay("Mammogram")
                                .SetDefinition("[PR] Mammogram")
                                .MammoId("10")
                                .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- Mammogram
                            ,
                            //+ MRI
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MRI")
                                .SetDisplay("MRI")
                                .SetDefinition("[PR] MRI")
                                .MammoId("272")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 241615005 | Magnetic resonance imaging of breast (Procedure)")
                            //- AutoGen
                            //- MRI
                            ,
                            //+ NippleDischarge
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NippleDischarge")
                                .SetDisplay("Nipple discharge")
                                .SetDefinition("[PR] Nipple discharge")
                                .MammoId("318")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 162166009 | Nipple discharge present (Disorder) | [0/0] | N64.52 |")
                            //- AutoGen
                            //- NippleDischarge
                            ,
                            //+ OutsideExam
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("OutsideExam")
                                .SetDisplay("Outside exam")
                                .SetDefinition("[PR] Outside exam")
                                .MammoId("451")
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- OutsideExam
                            ,
                            //+ Pain
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Pain")
                                .SetDisplay("Pain")
                                .SetDefinition("[PR] Pain")
                                .MammoId("271")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- Pain
                            ,
                            //+ Palpated
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Palpated")
                                .SetDisplay("Palpated")
                                .SetDefinition("[PR] Palpated")
                                .MammoId("8")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- Palpated
                            ,
                            //+ Post-operative
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Post-operative")
                                .SetDisplay("Post-operative")
                                .SetDefinition("[PR] Post-operative")
                                .MammoId("325")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("BodyStructure | 312285003 | Post-surgical breast structure")
                            //- AutoGen
                            //- Post-operative
                            ,
                            //+ PreviousBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PreviousBiopsy")
                                .SetDisplay("Previous biopsy")
                                .SetDefinition("[PR] Previous biopsy")
                                .MammoId("330")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 122548005 | Biopsy of breast (Procedure)")
                            //- AutoGen
                            //- PreviousBiopsy
                            ,
                            //+ PriorExam
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PriorExam")
                                .SetDisplay("Prior exam")
                                .SetDefinition("[PR] Prior exam")
                                .MammoId("450")
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- PriorExam
                            ,
                            //+ Redness
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Redness")
                                .SetDisplay("Redness")
                                .SetDefinition("[PR] Redness")
                                .MammoId("326")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- Redness
                            ,
                            //+ Scinti
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Scinti")
                                .SetDisplay("Scinti")
                                .SetDefinition("[PR] Scinti")
                                .MammoId("323")
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- Scinti
                            ,
                            //+ size<Mammo
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("size<Mammo")
                                .SetDisplay("size < mammo")
                                .SetDefinition("[PR] size < mammo")
                                .MammoId("274")
                                .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- size<Mammo
                            ,
                            //+ size<MRI
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("size<MRI")
                                .SetDisplay("size < MRI")
                                .SetDefinition("[PR] size < MRI")
                                .MammoId("276")
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- size<MRI
                            ,
                            //+ size<Palp
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("size<Palp")
                                .SetDisplay("size < palp")
                                .SetDefinition("[PR] size < palp")
                                .MammoId("278")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- size<Palp
                            ,
                            //+ size<US
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("size<US")
                                .SetDisplay("size < US")
                                .SetDefinition("[PR] size < US")
                                .MammoId("320.276")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- size<US
                            ,
                            //+ size>Mammo
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("size>Mammo")
                                .SetDisplay("size > mammo")
                                .SetDefinition("[PR] size > mammo")
                                .MammoId("273")
                                .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- size>Mammo
                            ,
                            //+ size>MRI
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("size>MRI")
                                .SetDisplay("size > MRI")
                                .SetDefinition("[PR] size > MRI")
                                .MammoId("275")
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- size>MRI
                            ,
                            //+ size>Palp
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("size>Palp")
                                .SetDisplay("size > palp")
                                .SetDefinition("[PR] size > palp")
                                .MammoId("277")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- size>Palp
                            ,
                            //+ size>US
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("size>US")
                                .SetDisplay("size > US")
                                .SetDefinition("[PR] size > US")
                                .MammoId("275")
                                .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- size>US
                            ,
                            //+ SkinMarker
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinMarker")
                                .SetDisplay("Skin marker")
                                .SetDefinition("[PR] Skin marker")
                                .MammoId("328")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("PhysicalObject | 706314007 | Imaging lesion localization marker (Object)")
                            //- AutoGen
                            //- SkinMarker
                            ,
                            //+ Surgery
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Surgery")
                                .SetDisplay("Surgery")
                                .SetDefinition("[PR] Surgery")
                                .MammoId("393")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 274331003 | Surgical biopsy of breast (Procedure)")
                            //- AutoGen
                            //- Surgery
                            ,
                            //+ SurgicalSite
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalSite")
                                .SetDisplay("Surgical site")
                                .SetDefinition("[PR] Surgical site")
                                .MammoId("329")
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            //- SurgicalSite
                            ,
                            //+ Tenderness
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Tenderness")
                                .SetDisplay("Tenderness")
                                .SetDefinition("[PR] Tenderness")
                                .MammoId("322")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("ClinicalFinding | 290080002 | Localized tenderness of breast (Finding) | [0/0] | N64.4")
                            //- AutoGen
                            //- Tenderness
                            ,
                            //+ TriggerPoint
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("TriggerPoint")
                                .SetDisplay("Trigger point")
                                .SetDefinition("[PR] Trigger point")
                                .MammoId("319")
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("BodyStructure | 134190002 | Trigger point (BodyStructure)")
                            //- AutoGen
                            //- TriggerPoint
                            ,
                            //+ US
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("US")
                                .SetDisplay("US")
                                .SetDefinition("[PR] US")
                                .MammoId("270")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- US
                            
                            //- CorrespondsWithCS
                        })
            );
    }
}
