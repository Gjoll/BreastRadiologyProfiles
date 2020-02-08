using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        CSTaskVar CalcificationDistributionCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                    "CalcificationDistributionCS",
                    "Calcification Distribution CodeSystem",
                    "Calcification/Distribution/CodeSystem",
                    "Calcification Distribution in an abnormality code system.",
                    Group_CommonCodesCS,
                    new ConceptDef[]
                    {
                        //+ Codes
                        //- Codes
                    }));

        VSTaskVar CalcificationDistributionVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "CalcificationDistributionVS",
                    "Calcification Distribution ValueSet",
                    "Calcification Distribution/ValueSet",
                    "Calcification Distribution of an abnormality value set.",
                    Group_CommonCodesVS,
                    Self.CalcificationDistributionCS.Value()
                )
        );
    }
}
