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
                            new ConceptDef("ClinicalExam",
                                "Clinical exam",
                                new Definition()
                                    .Line("[PR] Clinical exam")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 420131003 | Fluoroscopic mammary ductography (Procedure) 
                            new ConceptDef("Ductogram",
                                "Ductogram",
                                new Definition()
                                    .Line("[PR] Ductogram")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("Mammogram",
                                "Mammogram",
                                new Definition()
                                    .Line("[PR] Mammogram")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241615005 | Magnetic resonance imaging of breast (Procedure)
                            new ConceptDef("MRI",
                                "MRI",
                                new Definition()
                                    .Line("[PR] MRI")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("OutsideExam",
                                "Outside exam",
                                new Definition()
                                    .Line("[PR] Outside exam")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Scintimammography",
                                "Scintimammography",
                                new Definition()
                                    .Line("[PR] Scintimammography")
                                    .ValidModalities(Modalities.NM)
                                ),
                            // SNOMED Description: Procedure | 47079000 | Ultrasonography of breast (Procedure)
                            new ConceptDef("Ultrasound",
                                "Ultrasound",
                                new Definition()
                                    .Line("[PR] Ultrasound")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                            //- NotPreviouslySeenCS
                        })
            );
    }
}
