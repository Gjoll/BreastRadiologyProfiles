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
        StringBuilder sb = new StringBuilder();
        String outputPath;

        public IntroDoc(String outputPath)
        {
            this.outputPath = outputPath;
            this.sb
                .AppendLine("<div xmlns=\"http://www.w3.org/1999/xhtml\"")
                .AppendLine("    xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"")
                .AppendLine("    xsi:schemaLocation=\"http://hl7.org/fhir ../../src-generated/schemas/fhir-single.xsd\">")
                ;
        }

        public IntroDoc Header3(String header,
            String anchor)
        {
            this
                .Append($"<a name=\"{anchor}\"> </a>")
                .Append($"<h3 id=\"{anchor}\">{header}</h3>")
                ;
            return this;
        }

        public IntroDoc AddSvgImage(SDefEditor e)
        {
            this.AddSvgImage(FocusMapMaker.FocusMapName(e.SDef.Url.LastUriPart()));
            return this;
        }

        public IntroDoc AddSvgImage(String svgFileName)
        {
            this
                .Append($"<object data=\"{svgFileName}\" type=\"image/svg+xml\">")
                .Append($"    <img src=\"{svgFileName}\" alt=\"image/svg+xml\" />")
                .Append($"</object>")
                ;

            return this;
        }

        public IntroDoc Refinement(ValueSet vs, String name)
        {
            this
                .Header3("Refinement", "refinement")
                .Paragraph($"The type of this {name} may be further refined to be one of the following {name} sub-types:")
                .List(vs)
                ;
            return this;
        }

        public IntroDoc ObservationSection(String name, String article = "a")
        {
            this.Paragraph(
                $"This Observation profile is {article} '{name}' section.",
                $"Information about the finding is contained in the observations",
                $"referenced by this resource's hasMember field."
                );
            return this;
        }

        public IntroDoc Observation(String name, String article = "a")
        {
            this.Paragraph(
                $"This Observation profile is {article} {name} observation.",
                $"It is referenced by a parent Observation, and contains details of the " +
                $"{name} observation in this resource (generally in component fields) and in" +
                $"seperate observatiosn referenced by this resources hasMember field."
                );
            return this;
        }


        public IntroDoc ReviewedStatus(ReviewStatus reviewStatus)
        {
            this
                .Append($"<h3 id=\"reviewStatus\">Review Status</h3>")
                .Append($"<p><b>{reviewStatus}</b></p>")
                ;
            return this;
        }


        public IntroDoc Introduction(String purpose)
        {
            return this
                .Header3("Introduction", "intro")
                .Paragraph(purpose)
                ;
        }

        public IntroDoc IntroGeneral(String purpose)
        {
            return this.Introduction(purpose);
        }

        public IntroDoc IntroFragment(String purpose)
        {
            return this.Introduction(purpose);
        }

        public IntroDoc IntroExtension(String name, String purpose)
        {
            return this.Introduction($"{name} Extension Resource used to {purpose}.");
        }

        public IntroDoc IntroValueSet(ValueSet binding)
        {
            this.Introduction($"Value set {binding.Name}");
            this.AddSvgImage(FocusMapMaker.FocusMapName(binding.Name));
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
            this
                .Paragraph(
                    $"This resource is an leaf-node observation of a {leafNode}.",
                    $"It is referenced by a parent Observation."
                )
                ;
            return this;
        }

        public IntroDoc Append(String line)
        {
            this.sb.AppendLine($"    {line}");
            return this;
        }

        public IntroDoc Paragraph(params String[] lines)
        {
            this.Append("<p>");
            foreach (String line in lines)
                this.Append(line);
            this.Append("</p>");
            return this;
        }

        public IntroDoc List(params String[] items)
        {
            this.Append("<ul>");
            foreach (var item in items)
                this.Append($"    <li>{item}</li>");
            this.Append("</ul>");
            return this;
        }

        public IntroDoc List(ValueSet binding)
        {
            this.Append("<ul>");
            foreach (var include in binding.Compose.Include)
            {
                switch (include)
                {
                    case ValueSet.ConceptSetComponent compose:
                        foreach (ValueSet.ConceptReferenceComponent concept in include.Concept)
                            this.Append($"    <li>{concept.Code} - {concept.Display}</li>");
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            this.Append("</ul>");
            return this;
        }

        public String Render()
        {
            this.Append("</div>");
            return this.sb.ToString();
        }

        public String Save()
        {
            String introHtml = this.Render();
            File.WriteAllText(this.outputPath, introHtml);
            return this.outputPath;
        }
    }
}
