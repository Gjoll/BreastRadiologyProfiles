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
        VSTaskVar NotPreviouslySeenVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "NotPreviouslySeenVS",
                        "NotPreviouslySeen ValueSet",
                        "NotPreviouslySeen/ValueSet",
                        "NotPreviouslySeen value set.",
                        Group_MGCodesVS,
                        Self.NotPreviouslySeenCS.Value()
                    )
            );

        CSTaskVar NotPreviouslySeenCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "NotPreviouslySeenCodeSystemCS",
                        "Not Previously Seen CodeSystem",
                        "NotPreviouslySeen/CodeSystem",
                        "NotPreviouslySeen code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            //+ NotPreviouslySeenCS
                            //+ ClinicalExam
                            new ConceptDef()
                                .SetCode("ClinicalExam")
                                .SetDisplay("Clinical exam")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Clinical exam")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- ClinicalExam
                            // SNOMED Description: Procedure | 420131003 | Fluoroscopic mammary ductography (Procedure) 
                            //+ Ductogram
                            new ConceptDef()
                                .SetCode("Ductogram")
                                .SetDisplay("Ductogram")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ductogram")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- Ductogram
                            //+ Mammogram
                            new ConceptDef()
                                .SetCode("Mammogram")
                                .SetDisplay("Mammogram")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
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
                            //+ OutsideExam
                            new ConceptDef()
                                .SetCode("OutsideExam")
                                .SetDisplay("Outside exam")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Outside exam")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- OutsideExam
                            //+ Scintimammography
                            new ConceptDef()
                                .SetCode("Scintimammography")
                                .SetDisplay("Scintimammography")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scintimammography")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- Scintimammography
                            // SNOMED Description: Procedure | 47079000 | Ultrasonography of breast (Procedure)
                            //+ Ultrasound
                            new ConceptDef()
                                .SetCode("Ultrasound")
                                .SetDisplay("Ultrasound")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                            //- Ultrasound
                            //- NotPreviouslySeenCS
                        })
            );
    }
}
