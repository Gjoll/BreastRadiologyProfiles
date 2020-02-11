using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireFragger
{
    class FragInfo
    {
        public List<FragInfo> ReferencedFragments = new List<FragInfo>();
        public StructureDefinition StructDef;
        public CodeEditor InterfaceEditor;
        public CodeEditor ClassEditor;
        public ElementTreeNode DiffNodes;

        public String BaseDefinitionUrl => this.StructDef.BaseDefinition;
        public String BaseDefinitionName => this.BaseDefinitionUrl.LastUriPart();
    };
}
