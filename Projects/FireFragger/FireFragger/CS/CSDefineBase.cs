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
    class CSDefineBase
    {
        protected CSBuilder csBuilder;
        protected FragInfo fragBase;

        protected CodeBlockNested ClassFields => fragBase.ClassEditor.Blocks.Find("Fields", false);
        protected CodeBlockNested ClassConstructor => fragBase.ClassEditor.Blocks.Find("Constructor", false);
        protected CodeBlockNested ClassMethods => fragBase.ClassEditor.Blocks.Find("Methods", false);
        protected CodeBlockNested ClassWriteCode => fragBase.ClassEditor.Blocks.Find("WriteCode", false);
        protected CodeBlockNested ClassReadCode => fragBase.ClassEditor.Blocks.Find("ReadCode", false);

        protected CodeBlockNested InterfaceFields => fragBase.InterfaceEditor.Blocks.Find("Fields", false);
        protected CodeBlockNested InterfaceMethods => fragBase.InterfaceEditor.Blocks.Find("Methods", false);

        protected delegate void VisitFragment(FragInfo fi, Int32 level);

        protected void VisitFragments(VisitFragment vi,
            FragInfo fragBase)
        {
            HashSet<FragInfo> visitedFrags = new HashSet<FragInfo>();

            void Visit(VisitFragment vi,
                FragInfo fi,
                Int32 level)
            {
                if (visitedFrags.Contains(fi))
                    return;
                vi(fi, level);
                visitedFrags.Add(fi);
                foreach (FragInfo refFrag in fragBase.ReferencedFragments)
                    Visit(vi, refFrag, level + 1);
            }

            Visit(vi, fragBase, 0);
        }

        protected String[] References(ElementTreeNode entryNode)
        {
            List<ElementDefinition.TypeRefComponent> types = entryNode.ElementDefinition.Type;
            if (types.Count != 1)
                throw new Exception($"SingleReference. Invalid type count. Epected 1, got {types.Count}.");

            ElementDefinition.TypeRefComponent type = types[0];
            if (type.Code != "Reference")
                throw new Exception($"SingleReference. Invalid type code. Expected 'Reference', got {type.Code}.");
            List<String> retVal = new List<string>();
            foreach (String targetProfile in type.TargetProfile)
                retVal.Add(targetProfile);
            return retVal.ToArray();
        }

        public CSDefineBase(CSBuilder csBuilder,
                    FragInfo fragBase)
        {
            this.csBuilder = csBuilder;
            this.fragBase = fragBase;
        }

        protected void MergeFragments()
        {
            foreach (FragInfo fiRef in this.fragBase.ReferencedFragments)
                MergeFragment(fiRef);
        }

        protected void MergeFragment(FragInfo fi)
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
                    cbm.Merge(this.InterfaceFields);
                    cbm.Merge(this.InterfaceMethods);
                }
                if (fi.ClassEditor != null)
                {
                    CodeBlockMerger cbm = new CodeBlockMerger(fragBase.ClassEditor);
                    cbm.Merge(this.ClassFields);
                    cbm.Merge(this.ClassMethods);
                }
            }
        }

    }
}
