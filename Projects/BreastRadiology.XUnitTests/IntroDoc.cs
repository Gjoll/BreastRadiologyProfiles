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
        String outputPath;
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
            this.outputPath = outputPath;
            String fullPath = Path.Combine("IntroDocTemplates", $"{templateName}.template");
            codeEditor.Load(fullPath);
        }

        //public IntroDoc Header3(String header,
        //    String anchor)
        //{
        //    this
        //        .Append($"<a name=\"{anchor}\"> </a>")
        //        .Append($"<h3 id=\"{anchor}\">{header}</h3>")
        //        ;
        //    return this;
        //}

        public IntroDoc Refinement(ValueSet vs, String name)
        {
            //this
            //    .Header3("Refinement", "refinement")
            //    .Paragraph($"The type of this {name} may be further refined to be one of the following {name} sub-types:")
            //    .List(vs)
            //    ;
            return this;
        }

        public IntroDoc ObservationSection(String name, String article = "a")
        {
            //$this.Paragraph(
            //    $"This Observation profile is {article} '{name}' section.",
            //    $"Information about the finding is contained in the observations",
            //    $"referenced by this resource's hasMember field."
            //    );
            return this;
        }

        public IntroDoc Observation(String name, String article = "a")
        {
            //$this.Paragraph(
            //    $"This Observation profile is {article} {name} observation.",
            //    $"It is referenced by a parent Observation, and contains details of the " +
            //    $"{name} observation in this resource (generally in component fields) and in" +
            //    $"seperate observatiosn referenced by this resources hasMember field."
            //    );
            return this;
        }


        public IntroDoc ReviewedStatus(ReviewStatus reviewStatus)
        {
            //$this
            //    .Append($"<h3 id=\"reviewStatus\">Review Status</h3>")
            //    .Append($"<p><b>{reviewStatus}</b></p>")
            //    ;
            return this;
        }


        public IntroDoc Introduction(String purpose)
        {
            CodeBlockNested intro = this.codeEditor.Blocks.Find("intro");
            if (intro == null)
                throw new Exception("Missing intro code block");
            CodeBlockNested introBody = intro.Find("body");
            introBody
                .AppendRaw("    <p>")
                .AppendRaw("    " + purpose)
                .AppendRaw("    </p>")
                ;
            return this;
        }

        public IntroDoc IntroGeneral(String purpose)
        {
            //return this.Introduction(purpose);
            return this;
        }

        public IntroDoc IntroFragment(String purpose)
        {
            //return this.Introduction(purpose);
            return this;
        }

        public IntroDoc IntroExtension(String name, String purpose)
        {
            //return this.Introduction($"{name} Extension Resource used to {purpose}.");
            return this;
        }

        public IntroDoc IntroValueSet(ValueSet binding)
        {
            this.Introduction($"Value set {binding.Name}");
            //$this.AddSvgImage(FocusMapMaker.FocusMapName(binding.Name));
            //this
            //    .Paragraph(
            //        $"This resource is a ValueSet."
            //    )
            //    .List(binding)
            //    ;
            return this;
        }


        public IntroDoc IntroCodedObservationLeafNode(String leafNode)
        {
            //$this
            //    .Paragraph(
            //        $"This resource is an leaf-node observation of a {leafNode}.",
            //        $"It is referenced by a parent Observation."
            //    )
            //    ;
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
            File.WriteAllText(this.outputPath, introHtml);
            return this.outputPath;
        }
    }
}
