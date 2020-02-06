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
        CSTaskVar ObservedChangesCS = new CSTaskVar(
              (out CodeSystem cs) =>
                  cs = Self.CreateCodeSystem(
                      "ObservedChangesCS",
                      "Observed Changes CodeSystem",
                      "Observed/Change/CodeSystem",
                      "Observed changes in an abnormality code system.",
                      Group_CommonCodesCS,
                      new ConceptDef[]
                      {
                         //+ Codes
                         new ConceptDef()
                             .SetCode("DecreaseInCalcifications")
                             .SetDisplay("Decrease in calcifications")
                             .SetDefinition("[PR] Decrease in calcifications")
                             .MammoId("484")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01727")
                             .SetSnomedCode("129727007")
                             .SetSnomedDescription("ClinicalFinding | Decrease in number of calcifications " +
                                 "since previous mammogram (Finding)")
                             .SetUMLS("C1268655")
                         ,
                         new ConceptDef()
                             .SetCode("DecreaseInNumber")
                             .SetDisplay("Decrease in number")
                             .SetDefinition("[PR] Decrease in number")
                             .MammoId("482")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("ClinicalFinding | 42915007 | Abnormal decrease in " +
                                 "number (Finding)")
                         ,
                         new ConceptDef()
                             .SetCode("DecreaseInSize")
                             .SetDisplay("Decrease in size")
                             .SetDefinition("[PR] Decrease in size")
                             .MammoId("78")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                             .SetDicom("M-02530")
                             .SetSnomedCode("19776001")
                             .SetSnomedDescription("ClinicalFinding | 19776001 | Decreased size (Finding)")
                             .SetUMLS("C0332511")
                         ,
                         new ConceptDef()
                             .SetCode("IncreaseInCalcifications")
                             .SetDisplay("Increase in calcifications")
                             .SetDefinition("[PR] Increase in calcifications")
                             .MammoId("483")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01726")
                             .SetSnomedCode("129726003")
                             .SetSnomedDescription("ClinicalFinding | Increase in number of calcifications " +
                                 "since previous mammogram (Finding)")
                             .SetUMLS("C1268654")
                         ,
                         new ConceptDef()
                             .SetCode("IncreaseInNumber")
                             .SetDisplay("Increase in number")
                             .SetDefinition("[PR] Increase in number")
                             .MammoId("481")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("ClinicalFinding | 61515005 | Abnormal increase in " +
                                 "number (Finding)")
                         ,
                         new ConceptDef()
                             .SetCode("IncreaseInSize")
                             .SetDisplay("Increase in size")
                             .SetDefinition("[PR] Increase in size")
                             .MammoId("77")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                             .SetDicom("M-02520")
                             .SetSnomedCode("15454001")
                             .SetSnomedDescription("ClinicalFinding | 15454001 | Increased size (Finding)")
                             .SetUMLS("C0332509")
                         ,
                         new ConceptDef()
                             .SetCode("LessProminent")
                             .SetDisplay("Less prominent")
                             .SetDefinition("[PR] Less prominent")
                             .MammoId("293")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                             .SetDicom("F-01728")
                             .SetSnomedCode("129728002")
                             .SetSnomedDescription("ClinicalFinding | 129728002 | Finding less well defined " +
                                 "since previous mammogram (Finding)")
                             .SetUMLS("C1268656")
                         ,
                         new ConceptDef()
                             .SetCode("MoreProminent")
                             .SetDisplay("More prominent")
                             .SetDefinition("[PR] More prominent")
                             .MammoId("294")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                             .SetDicom("F-01729")
                             .SetSnomedCode("129729005")
                             .SetSnomedDescription("ClinicalFinding | 129729005 | Finding more defined " +
                                 "since previous mammogram (Finding)")
                             .SetUMLS("C1268657")
                         ,
                         new ConceptDef()
                             .SetCode("New")
                             .SetDisplay("New")
                             .SetDefinition("[PR] New")
                             .MammoId("75")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                             .SetDicom("F-01721")
                             .SetSnomedCode("129721008")
                             .SetSnomedDescription("ClinicalFinding | 129721008 | New finding since previous " +
                                 "mammogram (Finding)")
                             .SetUMLS("C1268649")
                         ,
                         new ConceptDef()
                             .SetCode("NoLongerSeen")
                             .SetDisplay("No longer seen")
                             .SetDefinition("[PR] No longer seen")
                             .MammoId("296")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                         ,
                         new ConceptDef()
                             .SetCode("NotSignificantChanged")
                             .SetDisplay("Not significant changed")
                             .SetDefinition("[PR] Not significant changed")
                             .MammoId("76")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                             .SetDicom("F-01723")
                             .SetSnomedCode("129723006")
                             .SetSnomedDescription("ClinicalFinding | 129723006 | No significant change " +
                                 "since previous mammogram (Finding)")
                             .SetUMLS("C1268651")
                         ,
                         new ConceptDef()
                             .SetCode("PartiallyRemoved")
                             .SetDisplay("Partially removed")
                             .SetDefinition("[PR] Partially removed")
                             .MammoId("295")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01722")
                             .SetSnomedCode("129722001")
                             .SetSnomedDescription("ClinicalFinding | 129722001 | Finding partially removed " +
                                 "since previous mammogram (Finding)")
                             .SetUMLS("C1268650")
                         ,
                         new ConceptDef()
                             .SetCode("RepresentsChange")
                             .SetDisplay("Represents change")
                             .SetDefinition("[PR] Represents change")
                             .MammoId("298")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                         ,
                         new ConceptDef()
                             .SetCode("Stable")
                             .SetDisplay("Stable")
                             .SetDefinition("[PR] Stable")
                             .MammoId("297")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                         //- Codes
                      }));

        VSTaskVar ObservedChangesVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ObservedChangesVS",
                    "Observed Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in an abnormality value set.",
                    Group_CommonCodesVS,
                    Self.ObservedChangesCS.Value()
                    )
            );
    }
}
