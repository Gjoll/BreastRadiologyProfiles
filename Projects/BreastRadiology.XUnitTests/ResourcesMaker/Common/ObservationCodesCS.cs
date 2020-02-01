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
        String ObservationCodesUrl => CodeSystemUrl("ObservationCodesUrl");

        Coding ObservationCodeObservedItemGroup => new Coding(ObservationCodesUrl, "observedItemGroupObservation");
        Coding ObservationCodeObservedItemRegion => new Coding(ObservationCodesUrl, "observedItemRegionObservationObservation");

        Coding ObservationCodeMGFinding => new Coding(ObservationCodesUrl, "mgFindingObservationObservation");
        Coding ObservationCodeAbnormalityCyst => new Coding(ObservationCodesUrl, "abnormalityCyst");
        Coding ObservationCodeAssociatedFeatures => new Coding(ObservationCodesUrl, "associatedFeaturesObservation");
        Coding ObservationCodeMGAbnormalityArchitecturalDistortion => new Coding(ObservationCodesUrl, "mgAbnormalityArchitecturalDistortionObservation");
        Coding ObservationCodeConsistentWith => new Coding(ObservationCodesUrl, "consistentWithObservation");
        Coding ObservationCodeMGAbnormalityCalcification => new Coding(ObservationCodesUrl, "mgAbnormalityCalcificationObservation");
        Coding ObservationCodeObservedFeature => new Coding(ObservationCodesUrl, "featureObservation");
        Coding ObservationCodeAbnormalityDuct => new Coding(ObservationCodesUrl, "abnormalityDuctObservation");
        Coding ObservationCodeAbnormalityForeignObject => new Coding(ObservationCodesUrl, "abnormalityForeignObjectObservation");
        Coding ObservationCodeAbnormalityLymphNode => new Coding(ObservationCodesUrl, "abnormalityLymphNodeObservation");
        Coding ObservationCodeAbnormalityMass => new Coding(ObservationCodesUrl, "abnormalityMassObservation");
        Coding ObservationCodeAbnormalityFibroadenoma => new Coding(ObservationCodesUrl, "abnormalityFibroadenomaObservation");
        Coding ObservationCodeMGAbnormalityAsymmetry => new Coding(ObservationCodesUrl, "mgAbnormalityAsymmetryObservation");
        Coding ObservationCodeMGAbnormalityDensity => new Coding(ObservationCodesUrl, "mgAbnormalityDensityObservation");
        Coding ObservationCodeMGAbnormalityFatNecrosis => new Coding(ObservationCodesUrl, "mgAbnormalityFatNecrosisObservation");
        Coding ObservationCodeMGBreastDensity => new Coding(ObservationCodesUrl, "mgBreastDensityObservation");
        Coding ObservationCodeMRIFinding => new Coding(ObservationCodesUrl, "mriFindingObservation");
        Coding ObservationCodeNMFinding => new Coding(ObservationCodesUrl, "nmFindingObservation");
        Coding ObservationCodeUSFinding => new Coding(ObservationCodesUrl, "usFindingObservation");
        Coding ObservationCodeFindingsRightBreast => new Coding(ObservationCodesUrl, "findingsRightBreastObservation");
        Coding ObservationCodeFindingsLeftBreast => new Coding(ObservationCodesUrl, "findingsLeftBreastObservation");

        CSTaskVar CodesCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "Codes",
                        "Component Slice Codes CodeSystem",
                        "Codes/ValueSet",
                        "Component Slice Codes code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef(Self.ObservationCodeObservedItemGroup,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an ObservedItemGroup observation")
                                ),
                            new ConceptDef(Self.ObservationCodeObservedItemRegion,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an ObservedItemRegion observation")
                                ),
                            new ConceptDef(Self.ObservationCodeMGFinding,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an MGFinding observation")
                                ),
                            new ConceptDef(Self.ObservationCodeAbnormalityCyst,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an AbnormalityCyst observation")
                                ),
                            new ConceptDef(Self.ObservationCodeAssociatedFeatures,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an AssociatedFeatures observation")
                                ),
                            new ConceptDef(Self.ObservationCodeMGAbnormalityArchitecturalDistortion,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an MGAbnormalityArchitecturalDistortion observation")
                                ),
                            new ConceptDef(Self.ObservationCodeConsistentWith,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies a ConsistentWith observation")
                                ),
                            new ConceptDef(Self.ObservationCodeMGAbnormalityCalcification,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an MGAbnormalityCalcification observation")
                                ),
                            new ConceptDef(Self.ObservationCodeObservedFeature,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an ObservedFeature observation")
                                ),
                            new ConceptDef(Self.ObservationCodeAbnormalityDuct,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an ObservationCodeAbnormalityDuct observation")
                                ),
                            new ConceptDef(Self.ObservationCodeAbnormalityForeignObject,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an AbnormalityForeignObject observation")
                                ),
                            new ConceptDef(Self.ObservationCodeAbnormalityLymphNode,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an AbnormalityLymphNode observation")
                                ),
                            new ConceptDef(Self.ObservationCodeAbnormalityMass,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an AbnormalityMass observation")
                                ),
                            new ConceptDef(Self.ObservationCodeAbnormalityFibroadenoma,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an AbnormalityFibroadenoma observation")
                                ),
                            new ConceptDef(Self.ObservationCodeMGAbnormalityAsymmetry,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an MGAbnormalityAsymmetry observation")
                                ),
                            new ConceptDef(Self.ObservationCodeMGAbnormalityDensity,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an MGAbnormalityDensity observation")
                                ),
                            new ConceptDef(Self.ObservationCodeMGAbnormalityFatNecrosis,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an MGAbnormalityFatNecrosis observation")
                                ),
                            new ConceptDef(Self.ObservationCodeMGBreastDensity,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an MGBreastDensity observation")
                                ),
                            new ConceptDef(Self.ObservationCodeMRIFinding,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an MRIFinding observation")
                                ),
                            new ConceptDef(Self.ObservationCodeNMFinding,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies an NMFinding observation")
                                ),
                            new ConceptDef(Self.ObservationCodeUSFinding,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies a USFinding observation")
                                ),
                            new ConceptDef(Self.ObservationCodeFindingsLeftBreast,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies a SectionFindingsLeftBreast observation")
                                ),
                            new ConceptDef(Self.ObservationCodeFindingsRightBreast,
                                new Definition()
                                    .Line("Observation.code to uniquely identifies a SectionFindingsRightBreast observation")
                                ),
                       })
             );
    }
}
