using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public static class ResourceFactory
    {
        public static BaseBase CreateBreastRadProfileResource(String profile)
        {
            switch (profile)
            {
                //+ Profile
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/usfinding":                                               // CSBuilder.cs:165
                    return new USFinding();                                                                                                 // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/tumorsatellite":                                          // CSBuilder.cs:165
                    return new TumorSatellite();                                                                                            // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/servicerecommendation":                                   // CSBuilder.cs:165
                    return new ServiceRecommendation();                                                                                     // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/sectionfindingsrightbreast":                              // CSBuilder.cs:165
                    return new SectionFindingsRightBreast();                                                                                // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/sectionfindingsleftbreast":                               // CSBuilder.cs:165
                    return new SectionFindingsLeftBreast();                                                                                 // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/observedfeature":                                         // CSBuilder.cs:165
                    return new ObservedFeature();                                                                                           // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/nmfinding":                                               // CSBuilder.cs:165
                    return new NMFinding();                                                                                                 // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/mrifinding":                                              // CSBuilder.cs:165
                    return new MRIFinding();                                                                                                // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/mgfinding":                                               // CSBuilder.cs:165
                    return new MGFinding();                                                                                                 // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/mgbreastdensity":                                         // CSBuilder.cs:165
                    return new MGBreastDensity();                                                                                           // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/mgabnormalityfatnecrosis":                                // CSBuilder.cs:165
                    return new MGAbnormalityFatNecrosis();                                                                                  // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/mgabnormalitydensity":                                    // CSBuilder.cs:165
                    return new MGAbnormalityDensity();                                                                                      // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/mgabnormalitycalcification":                              // CSBuilder.cs:165
                    return new MGAbnormalityCalcification();                                                                                // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/mgabnormalityasymmetry":                                  // CSBuilder.cs:165
                    return new MGAbnormalityAsymmetry();                                                                                    // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/mgabnormalityarchitecturaldistortion":                    // CSBuilder.cs:165
                    return new MGAbnormalityArchitecturalDistortion();                                                                      // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/consistentwith":                                          // CSBuilder.cs:165
                    return new ConsistentWith();                                                                                            // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/breastradreport":                                         // CSBuilder.cs:165
                    return new BreastRadReport();                                                                                           // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/breastradcomposition":                                    // CSBuilder.cs:165
                    return new BreastRadComposition();                                                                                      // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/breastbodylocationextension":                             // CSBuilder.cs:165
                    return new BreastBodyLocationExtension();                                                                               // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/bodydistancefromextension":                               // CSBuilder.cs:165
                    return new BodyDistanceFromExtension();                                                                                 // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/associatedfeatures":                                      // CSBuilder.cs:165
                    return new AssociatedFeatures();                                                                                        // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/abnormalitymass":                                         // CSBuilder.cs:165
                    return new AbnormalityMass();                                                                                           // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/abnormalitylymphnode":                                    // CSBuilder.cs:165
                    return new AbnormalityLymphNode();                                                                                      // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/abnormalityforeignobject":                                // CSBuilder.cs:165
                    return new AbnormalityForeignObject();                                                                                  // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/abnormalityfibroadenoma":                                 // CSBuilder.cs:165
                    return new AbnormalityFibroadenoma();                                                                                   // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/abnormalityduct":                                         // CSBuilder.cs:165
                    return new AbnormalityDuct();                                                                                           // CSBuilder.cs:166
                case "http://hl7.org/fhir/us/breast-radiology/structuredefinition/abnormalitycyst":                                         // CSBuilder.cs:165
                    return new AbnormalityCyst();                                                                                           // CSBuilder.cs:166
                //- Profile
            }
            return null;
        }
    }
}
