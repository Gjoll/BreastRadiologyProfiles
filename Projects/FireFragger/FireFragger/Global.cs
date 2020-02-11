using System;
using System.Collections.Generic;
using System.Text;

namespace FireFragger
{
    class Global
    {
        public const String BaseFragmentUrl = "http://www.fragment.com/";
        public static String FragmentUrl = $"{BaseFragmentUrl}fragment";
        public static String IsFragmentExtensionUrl = $"{BaseFragmentUrl}isFragment";
        public static String IncompatibleFragmentUrl = $"{BaseFragmentUrl}incompatibleFragment";
        public static String GroupExtensionUrl = $"{BaseFragmentUrl}Group";

        public static String ResourceMapNameUrl = $"{BaseFragmentUrl}mapname";
        public static String ResourceMapLinkUrl = $"{BaseFragmentUrl}maplink";


        public const String ClinicalImpressionUrl = "http://hl7.org/fhir/StructureDefinition/ClinicalImpression";
        public const String CompositionUrl = "http://hl7.org/fhir/StructureDefinition/Composition";
        public const String DiagnosticReportUrl = "http://hl7.org/fhir/StructureDefinition/DiagnosticReport";
        public const String DomainResourceUrl = "http://hl7.org/fhir/StructureDefinition/DomainResource";
        public const String ExtensionUrl = "http://hl7.org/fhir/StructureDefinition/Extension";
        public const String ImagingStudyUrl = "http://hl7.org/fhir/StructureDefinition/ImagingStudy";
        public const String MedicationRequestUrl = "http://hl7.org/fhir/StructureDefinition/MedicationRequest";
        public const String ObservationUrl = "http://hl7.org/fhir/StructureDefinition/Observation";
        public const String ResourceUrl = "http://hl7.org/fhir/StructureDefinition/Resource";
        public const String RiskAssessmentUrl = "http://hl7.org/fhir/StructureDefinition/RiskAssessment";
        public const String ServiceRequestUrl = "http://hl7.org/fhir/StructureDefinition/ServiceRequest";
    }
}
