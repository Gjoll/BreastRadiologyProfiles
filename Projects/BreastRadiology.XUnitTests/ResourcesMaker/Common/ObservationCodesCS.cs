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
        String ObservationCodesUrl => this.CodeSystemUrl("ObservationCodesUrl");

        Coding ObservationCodeObservedItemGroup => new Coding(this.ObservationCodesUrl, "observedItemGroupObservation");
        Coding ObservationCodeObservedItemRegion => new Coding(this.ObservationCodesUrl, "observedItemRegionObservationObservation");

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
