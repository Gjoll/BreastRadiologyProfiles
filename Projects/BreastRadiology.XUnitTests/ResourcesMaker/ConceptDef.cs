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
                sb.Append(this.definitionText);
                if (String.IsNullOrEmpty(this.modalities) == false)
                    sb.AppendLine(this.modalities);
                return sb.ToString();
            }
        }
        String modalities { get; set; }

        String definitionText;

        public ConceptDef()
        {
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

        public ConceptDef SetDefinition(Definition def)
        {
            this.definitionText = def.ToString();
            return this;
        }

        public ConceptDef(Coding code, Definition definition)
        {
            this.Code = code.Code;
            this.Display = code.Display;
            this.definitionText = definition.ToString();
        }

        public ConceptDef(String code, String display, Definition definition)
        {
            String definitionStr = definition.ToString();
            if (String.IsNullOrWhiteSpace(code) == true)
                throw new Exception("Empty code");
            if (String.IsNullOrWhiteSpace(display) == true)
                throw new Exception("Empty Display");
            if (String.IsNullOrWhiteSpace(definitionStr) == true)
                throw new Exception("Empty definition");
            this.Code = code;
            this.Display = display;
            this.definitionText = definitionStr;
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
        public ConceptDef MammoId(String id)
        {
            if (MammoIDDescriptions.Self.TryGet(id, out MammoIDDescriptions.Description description) == false)
                return this;
            //$this.CiteStart(description.Source);
            //foreach (String line in description.Text)
            //    this.Line(line);
            //this.CiteEnd();
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
