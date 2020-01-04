using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using PreFhir;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    class IntroDocPatcher : ConverterBase
    {
        String resourceDir;
        String pageDir;

        public IntroDocPatcher(String resourceDir,
            String pageDir)
        {
            this.resourceDir = resourceDir;
            this.pageDir = pageDir;
        }

        public void Patch()
        {
            foreach (String filePath in Directory.GetFiles(resourceDir, "*.json"))
            {
                String fileName = Path.GetFileNameWithoutExtension(filePath);

                if (fileName.StartsWith("StructureDefinition-"))
                    this.PatchStructDef(filePath);
            }
        }

        public void PatchStructDef(String path)
        {
            FhirJsonParser parser = new FhirJsonParser();
            StructureDefinition sd = parser.Parse<StructureDefinition>(File.ReadAllText(path));

            Extension isFragmentExtension = sd.GetExtension(Global.IsFragmentExtensionUrl);
            if (isFragmentExtension != null)
            {
                PatchStructDefFragment(path, sd);
                return;
            }

            switch (sd.BaseDefinition)
            {
                case ResourcesMaker.ObservationUrl:
                    PatchStructDefObservation(path, sd);
                    break;
            }
        }

        public void PatchStructDefFragment(String path,
            StructureDefinition sd)
        {
        }

        public void PatchStructDefObservation(String path,
        StructureDefinition sd)
        {
            const String fcn = "PatchStructDefObservation";

            CodeEditorXml c = new CodeEditorXml();
            c.IgnoreMacrosInQuotedStrings = false;

            ElementTreeLoader l = new ElementTreeLoader(this);
            ElementTreeNode snapNode = l.Create(sd.Snapshot.Element);

            List<String> CollateComponents()
            {
                List<String> items = new List<String>();

                CodeBlockNested componentBlock = c.Blocks.Find("components");

                if (snapNode.TryGetElementNode("Observation.component", out ElementTreeNode node) == false)
                {
                    this.ConversionWarn(this.GetType().Name,
                    fcn,
                    $"Can't find Observation.component '{path}'");
                    return items;
                }

                if (node.Slices.Count <= 1)
                    return items;

                foreach (ElementTreeSlice slice in node.Slices.Skip(1))
                {
                    String shortDesc = slice.ElementDefinition.Short;
                    items.Add(shortDesc);
                }
                return items;
            }

            List<String> CollateHasMembers()
            {
                List<String> items = new List<String>();

                CodeBlockNested componentBlock = c.Blocks.Find("hasMembers");

                if (snapNode.TryGetElementNode("Observation.hasMember", out ElementTreeNode node) == false)
                {
                    this.ConversionWarn(this.GetType().Name,
                    fcn,
                    $"Can't find Observation.hasMember '{path}'");
                    return items;
                }

                if (node.Slices.Count <= 1)
                    return items;

                foreach (ElementTreeSlice slice in node.Slices.Skip(1))
                {
                    String shortDesc = slice.ElementDefinition.Short;
                    items.Add(shortDesc);
                }
                return items;
            }

            List<String> componentItems = CollateComponents();
            List<String> hasMembersItems = CollateHasMembers();

            c.TryAddUserMacro("ComponentList", componentItems);
            c.TryAddUserMacro("HasMemberList", hasMembersItems);

            String introName = Path.GetFileNameWithoutExtension(path);

            String introPath = Path.Combine(this.pageDir,
                $"{introName}-intro.xml");

            // Load and save will expand the macros.
            c.Load(introPath);

            CodeBlockNested componentBlock = c.Blocks.Find("components");
            if (componentBlock == null)
            {
                this.ConversionWarn(this.GetType().Name,
                fcn,
                $"Missing 'components' block in '{path}' ({componentItems.Count} components exist)");
                return;
            }

            CodeBlockNested hasMemberBlock = c.Blocks.Find("hasMember");
            if (hasMemberBlock == null)
            {
                this.ConversionWarn(this.GetType().Name,
                fcn,
                $"Missing 'hasMember' block in '{path}' ({hasMembersItems.Count} references exist)");
                return;
            }

            if (componentItems.Count == 0)
                componentBlock.Clear();
            if (hasMembersItems.Count == 0)
                hasMemberBlock.Clear();

            c.Save();
        }
    }
}
