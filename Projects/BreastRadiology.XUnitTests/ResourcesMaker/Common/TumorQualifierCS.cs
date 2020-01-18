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
        VSTaskVar TumorQualifierVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "TumorQualifierVS",
                        "TumorQualifier ValueSet",
                        "TumorQualifier/ValueSet",
                        "TumorQualifier value set.",
                        Group_MGCodesVS,
                        Self.TumorQualifierCS.Value()
                    )
            );

        CSTaskVar TumorQualifierCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "TumorQualifierCodeSystemCS",
                        "Tumor Qualifier CodeSystem",
                        "TumorQualifier/CodeSystem",
                        "TumorQualifier code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            //+ TumorQualifierCS
                            // SNOMED Description: ObservableEntity | 399687005 | Primary tumor site (Observable) 
                            //+ Index
                            new ConceptDef()
                                .SetCode("Index")
                                .SetDisplay("Index")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Index")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Index
                            // SNOMED Description: ObservableEntity | 399462009 | Secondary tumor site (Observable)
                            //+ Satellite
                            new ConceptDef()
                                .SetCode("Satellite")
                                .SetDisplay("Satellite")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Satellite")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                            //- Satellite
                            //- TumorQualifierCS
                        })
            );
    }
}
