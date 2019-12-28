using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    /// <summary>
    /// A group of element definitions that will be copied to the output 
    /// StructureDefinition as a group, in the order that they are included in this
    /// group.
    /// </summary>
    public class ElementDefGroup
    {
        /// <summary>
        /// Ordering index. This keeps elements being inserted into the
        /// differential in the same order as they were found int the snapshot.
        /// </summary>
        public Int32 Index { get; }

        /// <summary>
        /// Base element definition. Null if none..
        /// </summary>
        public ElementDefinition BaseElementDefinition { get; set; }

        /// <summary>
        /// This is the element that has a one for one match to one in the base definition.
        /// </summary>
        public ElementDefinition ElementDefinition { get; set; }

        public ElementDefGroup(Int32 index, ElementDefinition elementDef, ElementDefinition eBase)
        {
            this.Index = index;
            this.ElementDefinition = elementDef;
            this.BaseElementDefinition = eBase;
            if (eBase != null)
            {
                elementDef.Base = new ElementDefinition.BaseComponent
                {
                    Path = eBase.Path,
                    Min = eBase.Min,
                    Max = eBase.Max
                };
            }
        }
    }
}

