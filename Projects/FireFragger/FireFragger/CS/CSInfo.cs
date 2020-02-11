using FhirKhit.Tools;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FireFragger
{
    class CSInfo
    {
        public CodeSystem CodeSystem;
        public CodeEditor ClassCode { get; }

        public CSInfo()
        {
            ClassCode = new CodeEditor();
            this.ClassCode.Load(Path.Combine("Templates", "ValueSet.txt"));
        }
    };
}
