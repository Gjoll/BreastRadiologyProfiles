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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        CSTaskVar AbnormalityDuctCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "AbnormalityDuctTypeCS",
                        "Duct Type CodeSystem",
                         "Duct Type/CodeSystem",
                        "Duct abnormality types code system.",
                         Group_CommonCodesCS,
                        new ConceptDef[]
                         {
                            //+ Type
                            //+ DuctDilatedATLASSolitaryDilatedDuct
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DuctDilatedATLASSolitaryDilatedDuct")
                                .SetDisplay("Duct dilated ATLAS solitary dilated duct")
                                .SetDefinition("[PR] Duct dilated ATLAS solitary dilated duct")
                                .MammoId("694.602")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("The mammographic finding of solitary dilated duct " +
                                    "is rare and poorly understood. There are anecdotal " +
                                    "reports of solitary dilated duct as the only mammographic " +
                                    "finding of underlying malignancy [1–10], indicating " +
                                    "its potential importance in the early detection of " +
                                    "breast cancer. However, some investigators have estimated " +
                                    "that the finding of solitary dilated duct has a very " +
                                    "low risk of malignancy [3, 9], supporting its assessment " +
                                    "as a benign (BI-RADS category 2) or probably benign " +
                                    "(BI-RADS category 3) lesion [11]. Solitary dilated " +
                                    "duct also has been reported to coexist with more " +
                                    "suspicious mammographic findings [6, 10], but in " +
                                    "such cases the associated mass, grouped microcalcifications, " +
                                    "architectural distortion, or developing asymmetry " +
                                    "would itself have a sufficiently high likelihood " +
                                    "of malignancy to prompt a suspicious (BI-RADS category " +
                                    "4) assessment.Solitary dilated duct is described " +
                                    "and illustrated in the current edition of the BI-RADS " +
                                    "atlas as the first of four mammographic findings " +
                                    "classified as \"special cases\" [12]. The accompanying " +
                                    "text states that \"if unassociated with other suspicious " +
                                    "clinical or mammographic findings, it is usually " +
                                    "of minor clinical significance\" [12]. Insofar as this " +
                                    "statement is made under the imprimatur of the widely " +
                                    "read BI-RADS atlas, it is likely to influence those " +
                                    "practicing radiologists without much, if any, personal " +
                                    "experience who encounter the rare finding of solitary " +
                                    "dilated duct. However, to our knowledge, to date " +
                                    "there is no large clinical series indicating the " +
                                    "positive predictive value for malignancy of solitary " +
                                    "dilated duct. The goal of this largescale study is " +
                                    "to report the clinical and pathologic outcomes for " +
                                    "the isolated finding of solitary dilated duct identified " +
                                    "at screening or diagnostic mammography.Read More: " +
                                    "https://www.ajronline.org/doi/full/10.2214/AJR.09.2944")
                            //- AutoGen
                            ,
                            //- DuctDilatedATLASSolitaryDilatedDuct
                            //+ DuctEctasia
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DuctEctasia")
                                .SetDisplay("Duct ectasia")
                                .SetDefinition("[PR] Duct ectasia")
                                .MammoId("693.614")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 22049009 | Mammary duct ectasia " +
                                    "(Disorder) | [0/0] | N60.49")
                                .SetUMLS("A noncancerous condition that results in clogged " +
                                    "ducts around your nipple. While it sometimes causes " +
                                    "pain, irritation and discharge, it's generally not " +
                                    "a cause for concern. If left untreated, it can eventually " +
                                    "obliterate the breast duct.")
                            //- AutoGen
                            
                            //- DuctEctasia
                            //- Type
                         }
                     )
                 );


        VSTaskVar AbnormalityDuctVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                   "AbnormalityDuctTypeVS",
                   "Duct ValueSet",
                    "Duct/ValueSet",
                   "Duct node abnormality types value set.",
                    Group_CommonCodesVS,
                    Self.AbnormalityDuctCS.Value()
                    )
            );


        SDTaskVar AbnormalityDuct = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.AbnormalityDuctVS.Value();
                SDefEditor e = Self.CreateEditor("AbnormalityDuct",
                        "Duct",
                        "Duct",
                        Global.ObservationUrl,
                        $"{Group_CommonResources}/AbnormalityDuct",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .AddFragRef(Self.ObservedDistributionComponentFragment.Value())
                    .AddFragRef(Self.ObservedSizeComponentFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                    .Description("Duct Observation",
                        new Markdown()
                    )
                    ;

                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeAbnormalityDuct.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference(sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("ductType",
                    Self.ComponentSliceCodeAbnormalityDuctType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "Duct Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the duct type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
