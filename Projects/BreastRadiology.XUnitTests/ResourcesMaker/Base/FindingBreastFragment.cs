using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using PreFhir;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        SDTaskVar FindingBreastFragment = new SDTaskVar(
               (out StructureDefinition s) =>
                   {
                       SDefEditor e = Self.CreateFragment("FindingBreastFragment",
                                           "Finding Breast Fragment",
                                           "Finding/Breast/Fragment",
                                           ObservationUrl)
                           .Description("Fragment definition for finding section of left or right breast",
                               new Markdown()
                               .Paragraph("This fragment defines the elements of a finding section of a left or right breast.")
                            )
                           .AddFragRef(Self.HeaderFragment.Value())
                           .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                           ;
                       s = e.SDef;

                       e.IntroDoc
                           .ReviewedStatus("NOONE", "")
                           ;
                       {
                           ValueSet binding = Self.BiRadsAssessmentCategoriesVS.Value();
                           ElementDefinition valueXDef = e.Select("value[x]")
                               .ZeroToOne()
                               .Type("CodeableConcept")
                               .Binding(binding, BindingStrength.Required)
                               .MustSupport()
                               ;

                           e.AddComponentLinkVS("Finding Value",
                               new SDefEditor.Cardinality(valueXDef),
                               Global.ElementAnchor(valueXDef), 
                               "CodeableConcept", 
                               binding.Url);
                       }
                       ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);

                       {
                           ElementTreeSlice slice = e.SliceTargetReference( sliceElementDef, Self.FindingMammo.Value(), 0, "*");
                           slice.ElementDefinition.MustSupport();
                       }
                       {
                           ElementTreeSlice slice = e.SliceTargetReference( sliceElementDef, Self.FindingMri.Value(), 0, "*");
                           slice.ElementDefinition.MustSupport();
                       }
                       {
                           ElementTreeSlice slice = e.SliceTargetReference( sliceElementDef, Self.FindingNM.Value(), 0, "*");
                           slice.ElementDefinition.MustSupport();
                       }
                       {
                           ElementTreeSlice slice = e.SliceTargetReference( sliceElementDef, Self.FindingUltraSound.Value(), 0, "*");
                           slice.ElementDefinition.MustSupport();
                       }
                   });
    }
}
