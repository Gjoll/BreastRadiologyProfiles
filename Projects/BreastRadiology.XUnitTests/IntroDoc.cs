using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    /// <summary>
    /// Helper class for making xxx-intro.xml files.
    /// These files provide the html verbage for the introduction of a fhir class
    /// html page in the IG.
    /// </summary>
    class IntroDoc
    {
        public String OutputPath { get; set; }
        CodeEditorXml codeEditor;

        public IntroDoc()
        {
            this.codeEditor = new CodeEditorXml();
            this.codeEditor.IgnoreMacrosInQuotedStrings = false;
        }

        public bool TryAddUserMacro(String name, String value)
        {
            return this.codeEditor.TryAddUserMacro(name, value);
        }

        public void Load(String templateName,
            String outputPath)
        {
            this.OutputPath = outputPath;
            String fullPath = Path.Combine("IntroDocTemplates", $"{templateName}.template");
            this.codeEditor.Load(fullPath);
        }

        CodeBlockNested reviewStatusBlock = null;
        public IntroDoc ReviewedStatus(String reviewer, String dt)
        {
            if (this.reviewStatusBlock == null)
            {
                this.reviewStatusBlock = this.codeEditor.Blocks.Find("reviewStatus");
                if (this.reviewStatusBlock == null)
                    throw new Exception($"reviewStatus block missing");
                this.reviewStatusBlock
                    .AppendRaw($"<h3 id=\"reviewStatus\">Review Status</h3>")
                    .AppendRaw($"Comments and Suggested changes to this implementation guide can be made ")
                    .AppendRaw($"<a href=\"https://github.com/HL7/fhir-breast-radiology-ig/projects/1\">here</a>")
                    ;
            }
            this.reviewStatusBlock
                .AppendRaw($"<p><b>Reviewed by {reviewer} on {dt}</b></p>")
                ;

            return this;
        }

        public String Render()
        {
            return this.codeEditor.ToString();
        }

        public String Save()
        {
            String introHtml = this.Render();
            File.WriteAllText(this.OutputPath, introHtml);
            return this.OutputPath;
        }
    }
}
