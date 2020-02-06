using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
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

                if (ResourcesMaker.Self.Data.SelectRow(this.mammoId) == true)
                {
                    String[] description = ResourcesMaker.Self.Data.UMLS.Split('\n');
                    AppendDefLines(description);
                }

                if (this.biRadsText != null)
                {
                    sb.AppendLine($"[{ResourcesMaker.BiRadCitation}]");
                    AppendDefLines(this.biRadsText);
                }

                if (String.IsNullOrEmpty(this.modalities) == false)
                    sb.AppendLine(this.modalities);
                return sb.ToString();
            }
        }
        String modalities { get; set; }

        String[] definitionText;
        String[] biRadsText;
        String mammoId = null;

        public ConceptDef()
        {
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
            //if (String.IsNullOrEmpty((this.mammoId)))
            //{
            //    ResourcesMaker.Self.ConversionWarn("ConceptDef",
            //        "BiRadsDef",
            //        "ACR text with no MammoId!");
            //}
            //else
            //    ResourcesMaker.Self.Data.BreastData.PatchACRText(this.mammoId, lines);
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

        public ConceptDef SetUMLS(String value)
        {
            return this;
        }

    }
}
