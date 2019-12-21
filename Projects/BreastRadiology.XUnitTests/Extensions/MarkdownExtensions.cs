using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    public static class MarkdownExtensions
    {
        /// <summary>
        /// Preformatted markdown
        /// </summary>
        /// <returns></returns>
        public static Markdown BlockQuote(this Markdown md, params string[] lines)
        {
            foreach (String line in lines)
                md.Value += $"{line}\n";
            return md;
        }

        public static Markdown BiradHeader(this Markdown md)
        {
            md.Value += "";
            return md;
        }

        public static Markdown BiradFooter(this Markdown md)
        {
            md.Value += $"-- {ResourcesMaker.BiRadCitation} \n";
            return md;
        }

        public static Markdown MissingObservation(this Markdown md, String articleAndName, String term = ".")
        {
            md
                .Paragraph($"If this observation is present, and dataAbsentReason is empty, then {articleAndName} was observed.")
                .Paragraph($"If this observation is present, and dataAbsentReason is not empty, then {articleAndName} " +
                           $"was not observed and dataAbsentReason contains the reason why{term}")
            ;
            return md;
        }
    }
}
