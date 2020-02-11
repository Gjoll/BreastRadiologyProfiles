using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace FireFragger
{
    /// <summary>
    /// Perform Observation specific build
    /// </summary>
    class CSDefineComposition : CSDefineBase
    {
        FragInfo fragBase;

        public CSDefineComposition(CSBuilder csBuilder) : base(csBuilder)
        {
        }
        
        void MergeFragment(FragInfo fi)
        {
            const String fcn = "MergeFragment";

            this.csBuilder.ConversionInfo(this.GetType().Name,
               fcn,
               $"Integrating fragment {fi.StructDef.Url.LastUriPart()}");
            if (fi != fragBase)
            {
                if (fi.InterfaceEditor != null)
                {
                    CodeBlockMerger cbm = new CodeBlockMerger(fragBase.InterfaceEditor);
                    cbm.Merge(fi.InterfaceEditor);
                }
                if (fi.ClassEditor != null)
                {
                    CodeBlockMerger cbm = new CodeBlockMerger(fragBase.ClassEditor);
                    cbm.Merge(fi.ClassEditor);
                }
            }
        }

        void DefineSections()
        {
            if (this.fragBase.DiffNodes.TryGetElementNode("Composition.section", out ElementTreeNode sectionNode) == false)
                return;

            foreach (ElementTreeSlice sectionSlice in sectionNode.Slices.Skip(1))
            {
                ElementTreeNode GetChild(String name)
                {
                    if (this.fragBase.DiffNodes.TryGetElementNode($"{sectionSlice.ElementDefinition.ElementId}.{name}", out ElementTreeNode n) == false)
                        throw new Exception($"Cant find child {name}");
                    return n;
                }
                ElementTreeNode titleNode = GetChild("title");
            }
        }

        public void Build(FragInfo fragBase)
        {
            const String fcn = "Build";

            this.csBuilder.ConversionInfo(this.GetType().Name,
               fcn,
               $"Building {fragBase.StructDef.Url.LastUriPart()}");

            this.fragBase = fragBase;
            foreach (FragInfo fiRef in this.fragBase.ReferencedFragments)
                MergeFragment(fiRef);

            DefineSections();
            this.csBuilder.ConversionInfo(this.GetType().Name,
               fcn,
               $"Completed {fragBase.StructDef.Url.LastUriPart()}");
        }
    }
}
