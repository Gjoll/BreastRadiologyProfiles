using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    public enum ReviewStatus
    {
        NotReviewed,
        Preliminary,
        Completed
    };

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
            codeEditor.Load(fullPath);
        }

        public IntroDoc Intro(params String[] lines)
        {
            CodeBlockNested b = this.codeEditor.Blocks.Find("intro");
            if (b == null)
                throw new Exception($"intro block missing");

            foreach (String line in lines)
                b.AppendRaw($"<p>{line}</p>");

            return this;
        }


        public IntroDoc ReviewedStatus(ReviewStatus reviewStatus)
        {
            CodeBlockNested b = this.codeEditor.Blocks.Find("reviewStatus");
            if (b == null)
                throw new Exception($"reviewStatus block missing");

            b
                .AppendRaw($"<h3 id=\"reviewStatus\">Review Status</h3>")
                .AppendRaw($"<p><b>{reviewStatus}</b></p>")
                ;

            return this;
        }

        //public IntroDoc Paragraph(params String[] lines)
        //{
        //    this.Append("<p>");
        //    foreach (String line in lines)
        //        this.Append(line);
        //    this.Append("</p>");
        //    return this;
        //}

        //public IntroDoc List(params String[] items)
        //{
        //    this.Append("<ul>");
        //    foreach (var item in items)
        //        this.Append($"    <li>{item}</li>");
        //    this.Append("</ul>");
        //    return this;
        //}

        //public IntroDoc List(ValueSet binding)
        //{
        //    this.Append("<ul>");
        //    foreach (var include in binding.Compose.Include)
        //    {
        //        switch (include)
        //        {
        //            case ValueSet.ConceptSetComponent compose:
        //                foreach (ValueSet.ConceptReferenceComponent concept in include.Concept)
        //                    this.Append($"    <li>{concept.Code} - {concept.Display}</li>");
        //                break;
        //            default:
        //                throw new NotImplementedException();
        //        }
        //    }
        //    this.Append("</ul>");
        //    return this;
        //}

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
