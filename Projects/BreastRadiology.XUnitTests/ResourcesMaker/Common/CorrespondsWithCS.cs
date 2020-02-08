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
                            //+ Codes
                            new ConceptDef()
                                .SetCode("Aspiration")
                                .SetDisplay("Aspiration")
                                .SetDefinition("[PR] Aspiration")
                                .MammoId("391")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 287572003 | Diagnostic aspiration of " +
                                    "breast cyst (Procedure)")
                                .SetUMLS("A medical procedure that removes something from an " +
                                    "area of the body. These substances can be air, body " +
                                    "fluids, or bone fragments.https://medlineplus.gov/ency/article/002216.htm")
                            ,
                            new ConceptDef()
                                .SetCode("Biopsy")
                                .SetDisplay("Biopsy")
                                .SetDefinition("[PR] Biopsy")
                                .MammoId("392")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 122548005 | Biopsy of breast (Procedure)")
                                .SetUMLS("The Mammogram and Biopsy correspond with each other.")
                            ,
                            new ConceptDef()
                                .SetCode("Concern")
                                .SetDisplay("Concern")
                                .SetDefinition("[PR] Concern")
                                .MammoId("327")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetUMLS("The test corresponds with the concern.")
                            ,
                            new ConceptDef()
                                .SetCode("Ductogram")
                                .SetDisplay("Ductogram")
                                .SetDefinition("[PR] Ductogram")
                                .MammoId("324")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 420131003 | Fluoroscopic mammary ductography " +
                                    "(Procedure)")
                                .SetUMLS("A ductogram, also called a galactogram, is a special " +
                                    "type of mammogram used for imaging the breast ducts. " +
                                    "It can aid in diagnosing the cause of abnormal nipple " +
                                    "discharges.Ductography (also called galactography " +
                                    "or ductogalactography) is a special type of contrast " +
                                    "enhanced mammography used for imaging the breast " +
                                    "ducts. Ductography can aid in diagnosing the cause " +
                                    "of an abnormal nipple discharge and is valuable in " +
                                    "diagnosing intraductal papillomas and other conditions.https://www.imaginis.com/mammography/ductogram-galactogram-imaging-the-breast-ducts")
                            ,
                            new ConceptDef()
                                .SetCode("IncidentalFinding")
                                .SetDisplay("Incidental finding")
                                .SetDefinition("[PR] Incidental finding")
                                .MammoId("79")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetUMLS("A medical finding that wasn't the abnormality of " +
                                    "the original  mammogram, MRI, nuclear medicine, or " +
                                    "ultrasound was intended to find.")
                            ,
                            new ConceptDef()
                                .SetCode("Mammo")
                                .SetDisplay("Mammo")
                                .SetDefinition("[PR] Mammo")
                                .MammoId("10")
                                .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetUMLS("The original MRI, Nuclear Medicine, or Ultrasound " +
                                    "corresponds with the findings on the Mammogram.")
                            ,
                            new ConceptDef()
                                .SetCode("MRI")
                                .SetDisplay("MRI")
                                .SetDefinition("[PR] MRI")
                                .MammoId("272")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 241615005 | Magnetic resonance imaging " +
                                    "of breast (Procedure)")
                                .SetUMLS("The original Mammogram, Nuclear Medicine, or Ultrasound " +
                                    "corresponds with the findings on the MRI.")
                            ,
                            new ConceptDef()
                                .SetCode("NippleDischarge")
                                .SetDisplay("Nipple discharge")
                                .SetDefinition("[PR] Nipple discharge")
                                .MammoId("318")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 162166009 | Nipple discharge present " +
                                    "(Disorder) | [0/0] | N64.52 |")
                                .SetUMLS("The findings on the Mammogram and/or Ultrasound, " +
                                    "correspond with the nipple discharge.")
                            ,
                            new ConceptDef()
                                .SetCode("OutsideExam")
                                .SetDisplay("Outside exam")
                                .SetDefinition("[PR] Outside exam")
                                .MammoId("451")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("Previous exam at another clinic that took place separate " +
                                    "from current exam.")
                            ,
                            new ConceptDef()
                                .SetCode("Pain")
                                .SetDisplay("Pain")
                                .SetDefinition("[PR] Pain")
                                .MammoId("271")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetUMLS("Mammogram, MRI, Nuclear Medicine, or ultrasound corresponds " +
                                    "with the pain the patient is experiencing.")
                            ,
                            new ConceptDef()
                                .SetCode("Palpated")
                                .SetDisplay("Palpated")
                                .SetDefinition("[PR] Palpated")
                                .MammoId("8")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetUMLS("The Mammogram, Ultrasound, Nuclear Medicine, MRI " +
                                    "correspond with the palpated (physical exam to touch) " +
                                    "lump.")
                            ,
                            new ConceptDef()
                                .SetCode("PostOperative")
                                .SetDisplay("Post operative")
                                .SetDefinition("[PR] Post operative")
                                .MammoId("325")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("BodyStructure | 312285003 | Post-surgical breast " +
                                    "structure")
                                .SetUMLS("The Mammogram corresponds with the post operative " +
                                    "results of the breast incision.")
                            ,
                            new ConceptDef()
                                .SetCode("PreviousBiopsy")
                                .SetDisplay("Previous biopsy")
                                .SetDefinition("[PR] Previous biopsy")
                                .MammoId("330")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 122548005 | Biopsy of breast (Procedure)")
                                .SetUMLS("The previous biopsy results correspond with the MRI " +
                                    "and/or Ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("PriorExam")
                                .SetDisplay("Prior exam")
                                .SetDefinition("[PR] Prior exam")
                                .MammoId("450")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("The prior exam of the breast, corresponds with the " +
                                    "results of the Mammogram.")
                            ,
                            new ConceptDef()
                                .SetCode("Redness")
                                .SetDisplay("Redness")
                                .SetDefinition("[PR] Redness")
                                .MammoId("326")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("The redness in the breast, corresponds with the results " +
                                    "of the Mammogram and/or Ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("Scinti")
                                .SetDisplay("Scinti")
                                .SetDefinition("[PR] Scinti")
                                .MammoId("323")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("The initial Mammogram corresponds with the Scinti " +
                                    "results.  Scintigraphy definition is - a diagnostic " +
                                    "technique in which a two-dimensional picture of internal " +
                                    "body tissue is produced through the detection of " +
                                    "radiation emitted by a radioactive substance administered " +
                                    "into the body.")
                            ,
                            new ConceptDef()
                                .SetCode("size<Mammo")
                                .SetDisplay("size < mammo")
                                .SetDefinition("[PR] size < mammo")
                                .MammoId("274")
                                .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("size<MRI")
                                .SetDisplay("size < MRI")
                                .SetDefinition("[PR] size < MRI")
                                .MammoId("276")
                                .ValidModalities(Modalities.MG)
                            ,
                            new ConceptDef()
                                .SetCode("size<Palp")
                                .SetDisplay("size < palp")
                                .SetDefinition("[PR] size < palp")
                                .MammoId("278")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("size<US")
                                .SetDisplay("size < US")
                                .SetDefinition("[PR] size < US")
                                .MammoId("320.276")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("size>Mammo")
                                .SetDisplay("size > mammo")
                                .SetDefinition("[PR] size > mammo")
                                .MammoId("273")
                                .ValidModalities(Modalities.MRI | Modalities.NM | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("size>MRI")
                                .SetDisplay("size > MRI")
                                .SetDefinition("[PR] size > MRI")
                                .MammoId("275")
                                .ValidModalities(Modalities.MG)
                            ,
                            new ConceptDef()
                                .SetCode("size>Palp")
                                .SetDisplay("size > palp")
                                .SetDefinition("[PR] size > palp")
                                .MammoId("277")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("SkinMarker")
                                .SetDisplay("Skin marker")
                                .SetDefinition("[PR] Skin marker")
                                .MammoId("328")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("PhysicalObject | 706314007 | Imaging lesion localization " +
                                    "marker (Object)")
                            ,
                            new ConceptDef()
                                .SetCode("Surgery")
                                .SetDisplay("Surgery")
                                .SetDefinition("[PR] Surgery")
                                .MammoId("393")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 274331003 | Surgical biopsy of breast " +
                                    "(Procedure)")
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalSite")
                                .SetDisplay("Surgical site")
                                .SetDefinition("[PR] Surgical site")
                                .MammoId("329")
                                .ValidModalities(Modalities.MRI)
                                .SetUMLS("The MRI information corresponds with the surgical " +
                                    "site.")
                            ,
                            new ConceptDef()
                                .SetCode("Tenderness")
                                .SetDisplay("Tenderness")
                                .SetDefinition("[PR] Tenderness")
                                .MammoId("322")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("ClinicalFinding | 290080002 | Localized tenderness " +
                                    "of breast (Finding) | [0/0] | N64.4")
                                .SetUMLS("The mammogram results correspond with where the patient " +
                                    "feels tenderness.")
                            ,
                            new ConceptDef()
                                .SetCode("TriggerPoint")
                                .SetDisplay("Trigger point")
                                .SetDefinition("[PR] Trigger point")
                                .MammoId("319")
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("BodyStructure | 134190002 | Trigger point (BodyStructure)")
                                .SetUMLS("The results of the Ultrasound correspond with where " +
                                    "the trigger point is around the tumor/lesion. The " +
                                    "trigger point is the point where the site of the " +
                                    "pain is.")
                            ,
                            new ConceptDef()
                                .SetCode("US")
                                .SetDisplay("US")
                                .SetDefinition("[PR] US")
                                .MammoId("270")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetUMLS("The results of the MRI, Mammogram and/or Nuclear " +
                                    "Medicine exam, correspond with this Ultrasound.")
                            //- Codes
                        })
            );
    }
}
