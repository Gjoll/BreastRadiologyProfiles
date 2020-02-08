using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    class ConceptDef
    {
        public String Code { get; set; }
        public String Display { get; set; }
        public String Definition
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                void AppendDefLines(String[] lines)
                {
                    if (lines == null)
                        return;
                    foreach (String line in lines)
                        sb.AppendLine(line);
                }

                AppendDefLines(this.definitionText);

                //if (ResourcesMaker.Self.Data.SelectRow(this.mammoId) == true)
                //{
                //    String[] description = ResourcesMaker.Self.Data.UMLS.Split('\n');
                //    AppendDefLines(description);
                //}

                if (this.umlsText!= null)
                {
                    string text = this.FormatUmls(this.umlsText.ToList());
                    sb.AppendLine(text);
                }
                else if (this.biRadsText != null)
                {
                    AppendDefLines(this.biRadsText);
                    sb.AppendLine($"[{ResourcesMaker.BiRadCitation}]");
                }

                if (String.IsNullOrEmpty(this.modalities) == false)
                    sb.AppendLine(this.modalities);
                return sb.ToString();
            }
        }
        String modalities { get; set; }

        String[] definitionText;
        String[] biRadsText;
        String[] umlsText;
        String mammoId = null;

        public ConceptDef()
        {
        }

        private String FormatUmls(List<String> lines)
        {
            StringBuilder sb = new StringBuilder();
            void CopyLines(Int32 count)
            {
                for (Int32 i = 0; i < count; i++)
                    sb.AppendLine(lines[i]);
            }

            if (lines.Count > 0)
                while ((lines.Count > 0) && String.IsNullOrWhiteSpace(lines[^1]))
                    lines.RemoveAt(lines.Count - 1);
            if (lines.Count == 0)
                return "";

            String lastLine = lines[^1];
            if (lastLine.StartsWith("###") == false)
            {
                CopyLines(lines.Count);
                return sb.ToString();
            }

            void AcrCitation(String name, String page)
            {
                sb.Append($"-- {name}");
                if (String.IsNullOrEmpty(page) == false)
                    sb.Append($"#{page}");
                sb.AppendLine("");
            }

            CopyLines(lines.Count - 1);
            lastLine = lastLine.Substring(3);
            Int32 index = lastLine.IndexOf('#');
            String citationType = lastLine.Substring(0, index);
            String page = lastLine.Substring(index + 1);
            switch (citationType)
            {
                case "URL":
                    String hRef = lastLine.Substring(index + 1);
                    sb.Append($"-- {hRef}");
                    break;
                case "ACRUS":
                    AcrCitation("Breast Imaging Reporting and Data System—Mammography, Fifth Edition", page);
                    break;
                case "ACRMG":
                    AcrCitation("Breast Imaging Reporting and Data System—Ultrasound, Second Edition", page);
                    break;
            }
            return sb.ToString();
        }

        public ConceptDef SetCode(String code, String display)
        {
            this.Code = code;
            this.Display = display;
            return this;
        }

        public ConceptDef SetCode(Coding code)
        {
            this.Code = code.Code;
            this.Display = code.Display;

            return this;
        }

        public ConceptDef SetCode(String value)
        {
            this.Code = value;
            return this;
        }

        public ConceptDef SetDisplay(String value)
        {
            this.Display = value;
            return this;
        }

        public ConceptDef SetDefinition(params String[] def)
        {
            this.definitionText = def;
            return this;
        }

        public ConceptDef ValidModalities(Modalities modalities)
        {
            StringBuilder sb = new StringBuilder();
            void Add(Modalities flag)
            {
                if ((modalities & flag) == flag)
                    sb.Append($" {flag.ToString()}");
            }

            sb.Append("Valid for the following modalities:");
            Add(Modalities.MG);
            Add(Modalities.US);
            Add(Modalities.MRI);
            Add(Modalities.NM);
            sb.AppendLine(".");
            this.modalities = sb.ToString();
            return this;
        }

        public ConceptDef SetDicom(String value)
        {
            return this;
        }
        public ConceptDef SetACR(params String[] lines)
        {

            this.biRadsText = lines;
            return this;
        }

        public ConceptDef MammoId(String id)
        {
            this.mammoId = id;
            return this;
        }

        public ConceptDef SetSnomedCode(String value)
        {
            return this;
        }

        public ConceptDef SetOneToMany(String value)
        {
            return this;
        }

        public ConceptDef SetSnomedDescription(String value)
        {
            return this;
        }

        public ConceptDef SetICD10(String value)
        {
            return this;
        }

        public ConceptDef SetComment(String value)
        {
            return this;
        }

        public ConceptDef SetUMLS(params String[] value)
        {
            this.umlsText = value;
            return this;
        }
    }
}
