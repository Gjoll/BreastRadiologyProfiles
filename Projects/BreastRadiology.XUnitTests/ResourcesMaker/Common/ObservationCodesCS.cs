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
        /*

Observation SectionFindingsRightBreast
         */
        const String ObservationCodesName = "ObservationCodes";
        String ObservationCodesUrl => this.CodeSystemUrl(ObservationCodesName);

        Coding ObservationCodeMGFinding => new Coding(this.ObservationCodesUrl, "mgFindingObservationObservation");
        Coding ObservationCodeAbnormalityCyst => new Coding(this.ObservationCodesUrl, "abnormalityCyst");
        Coding ObservationCodeAssociatedFeatures => new Coding(this.ObservationCodesUrl, "associatedFeaturesObservation");
        Coding ObservationCodeMGAbnormalityArchitecturalDistortion => new Coding(this.ObservationCodesUrl, "mgAbnormalityArchitecturalDistortionObservation");
        Coding ObservationCodeConsistentWith => new Coding(this.ObservationCodesUrl, "consistentWithObservation");
        Coding ObservationCodeMGAbnormalityCalcification => new Coding(this.ObservationCodesUrl, "mgAbnormalityCalcificationObservation");
        Coding ObservationCodeObservedFeature => new Coding(this.ObservationCodesUrl, "featureObservation");
        Coding ObservationCodeAbnormalityDuct => new Coding(this.ObservationCodesUrl, "abnormalityDuctObservation");
        Coding ObservationCodeAbnormalityForeignObject => new Coding(this.ObservationCodesUrl, "abnormalityForeignObjectObservation");
        Coding ObservationCodeAbnormalityLymphNode => new Coding(this.ObservationCodesUrl, "abnormalityLymphNodeObservation");
        Coding ObservationCodeAbnormalityMass => new Coding(this.ObservationCodesUrl, "abnormalityMassObservation");
        Coding ObservationCodeAbnormalityFibroadenoma => new Coding(this.ObservationCodesUrl, "abnormalityFibroadenomaObservation");
        Coding ObservationCodeMGAbnormalityAsymmetry => new Coding(this.ObservationCodesUrl, "mgAbnormalityAsymmetryObservation");
        Coding ObservationCodeMGAbnormalityDensity => new Coding(this.ObservationCodesUrl, "mgAbnormalityDensityObservation");
        Coding ObservationCodeMGAbnormalityFatNecrosis => new Coding(this.ObservationCodesUrl, "mgAbnormalityFatNecrosisObservation");
        Coding ObservationCodeMGBreastDensity => new Coding(this.ObservationCodesUrl, "mgBreastDensityObservation");
        Coding ObservationCodeMRIFinding => new Coding(this.ObservationCodesUrl, "mriFindingObservation");
        Coding ObservationCodeNMFinding => new Coding(this.ObservationCodesUrl, "nmFindingObservation");
        Coding ObservationCodeUSFinding => new Coding(this.ObservationCodesUrl, "usFindingObservation");
        Coding ObservationCodeFindingsRightBreast => new Coding(this.ObservationCodesUrl, "findingsRightBreastObservation");
        Coding ObservationCodeFindingsLeftBreast => new Coding(this.ObservationCodesUrl, "findingsLeftBreastObservation");

        CSTaskVar CodesCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        ObservationCodesName,
                        "Observation Codes CodeSystem",
                        "Observation Codes/ValueSet",
                        "Observation Codes code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeMGFinding)
                                .SetDefinition("Observation.code to uniquely identifies an MGFinding observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeAbnormalityCyst)
                                .SetDefinition("Observation.code to uniquely identifies an AbnormalityCyst observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeAssociatedFeatures)
                                .SetDefinition("Observation.code to uniquely identifies an AssociatedFeatures observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeMGAbnormalityArchitecturalDistortion)
                                .SetDefinition("Observation.code to uniquely identifies an MGAbnormalityArchitecturalDistortion observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeConsistentWith)
                                .SetDefinition("Observation.code to uniquely identifies a ConsistentWith observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeMGAbnormalityCalcification)
                                .SetDefinition("Observation.code to uniquely identifies an MGAbnormalityCalcification observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeObservedFeature)
                                .SetDefinition("Observation.code to uniquely identifies an ObservedFeature observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeAbnormalityDuct)
                                .SetDefinition("Observation.code to uniquely identifies an ObservationCodeAbnormalityDuct observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeAbnormalityForeignObject)
                                .SetDefinition("Observation.code to uniquely identifies an AbnormalityForeignObject observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeAbnormalityLymphNode)
                                .SetDefinition("Observation.code to uniquely identifies an AbnormalityLymphNode observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeAbnormalityMass)
                                .SetDefinition("Observation.code to uniquely identifies an AbnormalityMass observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeAbnormalityFibroadenoma)
                                .SetDefinition("Observation.code to uniquely identifies an AbnormalityFibroadenoma observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeMGAbnormalityAsymmetry)
                                .SetDefinition("Observation.code to uniquely identifies an MGAbnormalityAsymmetry observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeMGAbnormalityDensity)
                                .SetDefinition("Observation.code to uniquely identifies an MGAbnormalityDensity observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeMGAbnormalityFatNecrosis)
                                .SetDefinition("Observation.code to uniquely identifies an MGAbnormalityFatNecrosis observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeMGBreastDensity)
                                .SetDefinition("Observation.code to uniquely identifies an MGBreastDensity observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeMRIFinding)
                                .SetDefinition("Observation.code to uniquely identifies an MRIFinding observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeNMFinding)
                                .SetDefinition("Observation.code to uniquely identifies an NMFinding observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeUSFinding)
                                .SetDefinition("Observation.code to uniquely identifies a USFinding observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeFindingsLeftBreast)
                                .SetDefinition("Observation.code to uniquely identifies a SectionFindingsLeftBreast observation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ObservationCodeFindingsRightBreast)
                                .SetDefinition("Observation.code to uniquely identifies a SectionFindingsRightBreast observation")
                                ,
                       })
             );
    }
}
