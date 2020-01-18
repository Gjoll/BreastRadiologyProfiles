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
        SDTaskVar CommonComponentsFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("CommonComponentsFragment",
                        "Common Components Fragment",
                        "Common Components Fragment",
                        ObservationUrl)
                    .Description("Common Components fragment",
                        new Markdown()
                            .Paragraph("Adds commonly used component slice values, including:")
                            .List("Changes", "Size")
                    )
                    .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
                    ;
                s = e.SDef;

                e.StartComponentSliceing();

                Self.ComponentSliceBiRads(e);

                e.ComponentSliceCodeableConcept("observedChanges",
                    Self.CodeObservedChanges.ToCodeableConcept(),
                    Self.ObservedChangesVS.Value(),
                    BindingStrength.Required,
                    0,
                    "*",
                    "Observed Change In Abnormality",
                    new Markdown()
                        .Paragraph($"This slice contains zero or more components that define observed changes in this abnormality.",
                                    $"The value of this component is a codeable concept chosen from the {Self.ObservedChangesVS.Value().Name} valueset.")
                    );


                {
                    const String sliceName = "observedSize";

                    ElementTreeSlice slice = e.AppendSlice("component", sliceName, 0, "1");
                    slice.ElementDefinition
                        .SetShort($"Observed Size component")
                        .SetDefinition(new Markdown($"This component slice contains the observedSize quantity"))
                        .SetComment(new Markdown($"This is one component of a group of components that comprise the observation."))
                        ;

                    // Fix component code
                    Self.FixComponentCode(slice, sliceName, Self.CodeObservedSize.ToCodeableConcept());
                    ElementTreeNode valueXNode = Self.FixComponentValueX(slice, sliceName, new string[] { "Quantity", "Range" });

                    {
                        Hl7.Fhir.Model.Quantity q = new Hl7.Fhir.Model.Quantity
                        {
                            System = "http://unitsofmeasure.org",
                            Code = "cm"
                        };

                        ElementDefinition valueX = new ElementDefinition
                        {
                            Path = $"{slice.ElementDefinition.Path}.value[x]",
                            ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:{sliceName}/quantity",
                            SliceName = $"{sliceName}/quantity",
                            Min = 0,
                            Max = "1"
                        }
                        .Pattern(q)
                        .Type("Quantity")
                        ;
                        valueXNode.CreateSlice($"{sliceName}/quantity", valueX);
                    }

                    {
                        Hl7.Fhir.Model.Range r = new Hl7.Fhir.Model.Range
                        {
                            Low = new SimpleQuantity
                            {
                                System = "http://unitsofmeasure.org",
                                Code = "cm"
                            },
                            High = new SimpleQuantity
                            {
                                System = "http://unitsofmeasure.org",
                                Code = "cm"
                            }
                        };
                        ElementDefinition valueX = new ElementDefinition
                        {
                            Path = $"{slice.ElementDefinition.Path}.value[x]",
                            ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:{sliceName}/range",
                            SliceName = $"{sliceName}/range",
                            Min = 0,
                            Max = "1"
                        }
                        .Pattern(r)
                        .Type("Range")
                        ;
                        valueXNode.CreateSlice($"{sliceName}/range", valueX);
                    }

                    e.AddComponentLink($"Observed Size^Quantity or Range");
                }
            });
    }
}
