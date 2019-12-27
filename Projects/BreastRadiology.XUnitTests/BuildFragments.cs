using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Specification.Source;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using PreFhir;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Model;
using System.Collections.Generic;
using BreastRadiology.XUnitTests;
using System.Drawing;

namespace BreastRadiology.XUnitTests
{
    [TestClass]
    public class BuildFragments
    {
        const String baseDir = "BreastRadiology2020FebBallot";

        String cacheDir;
        String contentDir;
        String guideDir;

        String graphicsDir;
        String fragmentDir;
        String resourcesDir;
        String pageDir;
        String pageTemplateDir;
        String mergedDir;


        public BuildFragments()
        {
            this.cacheDir = Path.Combine(DirHelper.FindParentDir(baseDir), "Cache");
            this.contentDir = Path.Combine(DirHelper.FindParentDir(baseDir), "IG", "Content");
            this.guideDir = Path.Combine(DirHelper.FindParentDir(baseDir), "IG", "Guide");

            this.graphicsDir = Path.Combine(this.contentDir, "Graphics");
            this.fragmentDir = Path.Combine(this.contentDir, "Fragments");
            this.resourcesDir = Path.Combine(this.contentDir, "Resources");
            this.pageDir = Path.Combine(this.contentDir, "Page");
            this.pageTemplateDir = Path.Combine(this.contentDir, "PageTemplate");
            this.mergedDir = Path.Combine(this.contentDir, "Merged");
        }

        private void Message(String import, string className, string method, string msg)
        {
            Trace.WriteLine($"[{import}] {className}.{method}: {msg}");
        }

        private bool StatusWarnings(string className, string method, string msg)
        {
            if (msg.Contains(" does not resolve"))
                return true;

            this.Message("Warn", className, method, msg);
            return true;
        }
        private bool StatusInfo(string className, string method, string msg)
        {
            if (msg.Contains(" does not resolve"))
                return true;

            this.Message("Info", className, method, msg);
            return true;
        }
        private bool StatusErrors(string className, string method, string msg)
        {
            if (msg.Contains(" does not resolve"))
                return true;

            this.Message("Error", className, method, msg);
            return true;
        }

        public void WriteCS(String dataFileName,
            String outputCodePath,
            String csBlockName)
        {
            String App(String s, String t, String sb)
            {
                if (String.IsNullOrEmpty(t) == true)
                    return s;

                // verify we have correct column.
                if (t != sb)
                    throw new Exception("Invalid value in App");

                if (String.IsNullOrEmpty(s) == false)
                    s += " ";
                s += t;
                return s;
            }
            String CodeValue(String value)
            {
                while (true)
                {
                    Int32 j = value.IndexOf(' ');
                    if (j < 0)
                        break;
                    String temp = value.Substring(0, j);
                    while (value[j] == ' ')
                        j += 1;
                    temp += Char.ToUpper(value[j]);
                    temp += value.Substring(j + 1);
                    value = temp;
                }
                return value;
            }

            String[] values = File.ReadAllLines(Path.Combine("DataFiles", dataFileName));
            CodeEditor editor = new CodeEditor();
            editor.Load(Path.Combine(DirHelper.FindParentDir("BreastRadiology.XUnitTests"),
                "ResourcesMaker",
                outputCodePath));
            CodeBlockNested concepts = editor.Blocks.Find(csBlockName);
            concepts.Clear();

            for (Int32 i = 0; i < values.Length; i++)
            {
                String value = values[i];
                // currently doesnt handle embedded \" and ',' chars.
                // gg doesnt appear to use theres, so this shoudl work, but if
                // is stops working, mnake parser more intelligent.
                if (value.Contains("\""))
                    throw new Exception("Complex CSV file found. Upgrade simple csv processor");
                String term = ",";
                if (i == values.Length - 1)
                    term = "";
                String[] parts = value.Split(',');
                String code = parts[7];
                String validWith = App("", parts[0], "MG");
                validWith = App(validWith, parts[1], "MRI");
                validWith = App(validWith, parts[2], "NM");
                validWith = App(validWith, parts[3], "US");
                concepts
                    .AppendLine($"new ConceptDef(\"{CodeValue(code)}\",")
                    .AppendLine($"    \"{code}\",")
                    .AppendLine($"    new Definition()")
                    .AppendLine($"        .Line(\"[PR] {code}\")")
                    .AppendLine($"        .Line(\"Valid with following Modalities: {validWith}\")")
                    .AppendLine($"    ){term}")
                    ;
            }

            editor.Save();
        }

        [TestMethod]
        public void WriteCode()
        {
            WriteCS("ConsistentWith.txt", @"Common\CommonConsistentWithCS.cs", "ConsistentWithCS");
            WriteCS("ConsistentWith.txt", @"Common\CommonConsistentWithCS.cs", "ConsistentWithQualifierCS");
        }

        [TestMethod]
        public void A_BuildFragments()
        {
            try
            {
                ResourcesMaker pc = new ResourcesMaker(this.fc, this.fragmentDir, this.pageDir, this.cacheDir);
                pc.StatusErrors += this.StatusErrors;
                pc.StatusInfo += this.StatusInfo;
                pc.StatusWarnings += this.StatusWarnings;
                pc.CreateResources();
                if (pc.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    pc.FormatErrorMessages(sb);
                    Trace.WriteLine(sb.ToString());
                    Debug.Assert(false);
                }
            }
            catch (Exception err)
            {
                Trace.WriteLine(err.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void B_BuildResources()
        {
            bool saveMergedFiles = false;

            try
            {
                DateTime start = DateTime.Now;
                if (Directory.Exists(this.resourcesDir) == false)
                    Directory.CreateDirectory(this.resourcesDir);

                if (saveMergedFiles)
                {
                    if (Directory.Exists(this.mergedDir) == false)
                        Directory.CreateDirectory(this.mergedDir);
                }
                else
                {
                    if (Directory.Exists(this.mergedDir) == true)
                        Directory.Delete(this.mergedDir, true);
                }

                PreFhirGenerator preFhir = new PreFhirGenerator(this.fc, this.cacheDir);
                preFhir.StatusErrors += this.StatusErrors;
                preFhir.StatusInfo += this.StatusInfo;
                preFhir.StatusWarnings += this.StatusWarnings;
                preFhir.AddDir(this.fragmentDir, "*.json");
                if (saveMergedFiles)
                    preFhir.MergedDir = this.mergedDir;
                preFhir.Process();
                preFhir.SaveResources(this.resourcesDir);

                if (preFhir.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    preFhir.FormatErrorMessages(sb);
                    Trace.WriteLine(sb.ToString());
                    Debug.Assert(false);
                }

                TimeSpan executionTime = DateTime.Now - start;
                Trace.WriteLine($"***** PreFhir execution Time {executionTime.ToString()}");
            }
            catch (Exception err)
            {
                Trace.WriteLine(err.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestBuildResource()
        {
            try
            {
                if (Directory.Exists(this.resourcesDir) == false)
                    Directory.CreateDirectory(this.resourcesDir);

                if (Directory.Exists(this.mergedDir) == false)
                    Directory.CreateDirectory(this.mergedDir);

                PreFhirGenerator preFhir = new PreFhirGenerator(this.fc, this.cacheDir);
                preFhir.StatusErrors += this.StatusErrors;
                preFhir.StatusInfo += this.StatusInfo;
                preFhir.StatusWarnings += this.StatusWarnings;
                preFhir.MergedDir = this.mergedDir;
                preFhir.ProcessOne(this.fragmentDir, "BreastRadUSMassMargin", true);
                preFhir.SaveResources(this.resourcesDir);
            }
            catch (Exception err)
            {
                Trace.WriteLine(err.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void ValidateOutputResources()
        {
            String rDir = Path.Combine(this.guideDir,
                "input",
                "resources");
            FhirValidator fv = new FhirValidator();
            fv.StatusErrors += this.StatusErrors;
            fv.StatusInfo += this.StatusInfo;
            fv.StatusWarnings += this.StatusWarnings;

            bool success = fv.ValidateDir(rDir, "*.json", "4.0.0");
            StringBuilder sb = new StringBuilder();
            //fv.FormatMessages(sb);
            //Trace.WriteLine(sb.ToString());
            Assert.IsTrue(success);
            Assert.IsTrue(fv.HasErrors == false);
            Trace.WriteLine("Validation complete");
        }

        [TestMethod]
        public void ValidateInputResources()
        {
            FhirValidator fv = new FhirValidator(Path.Combine(this.cacheDir, "validation.xml"));
            fv.StatusErrors += this.StatusErrors;
            fv.StatusInfo += this.StatusInfo;
            fv.StatusWarnings += this.StatusWarnings;
            bool success = fv.ValidateDir(this.resourcesDir, "*.json", "4.0.0");
            //StringBuilder sb = new StringBuilder();
            //fv.FormatMessages(sb);
            //Trace.WriteLine(sb.ToString());
            //Assert.IsTrue(success);
            Trace.WriteLine("Validation complete");
        }

        //[TestMethod]
        //public void Clean()
        //{
        //    ProfileCleanUp pc = new ProfileCleanUp();
        //    pc.Clean(resourcesDir);
        //}

        FileCleaner fc = null;

        [TestMethod]
        public void FullBuild()
        {
            fc = new FileCleaner();
            this.fc?.Add(this.graphicsDir, "*.svg");
            this.fc?.Add(this.pageDir, "*.xml");
            this.fc?.Add(this.fragmentDir, "*.json");
            this.fc?.Add(this.resourcesDir, "*.json");

            this.A_BuildFragments();
            this.B_BuildResources();
            this.C_BuildGraphics();
            this.D_BuildIG();

            this.fc?.DeleteUnMarkedFiles();
        }

        [TestMethod]
        public void C_BuildGraphics()
        {
            try
            {
                {
                    ResourceMap map = new ResourceMap();
                    map.AddDir(this.fragmentDir, "*.json");

                    FragmentMapMaker fragmentMapMaker = new FragmentMapMaker(this.fc, map, this.graphicsDir, this.pageDir, this.pageTemplateDir);
                    fragmentMapMaker.Create();
                }

                {
                    if (Directory.Exists(this.graphicsDir) == false)
                        Directory.CreateDirectory(this.graphicsDir);

                    ResourceMap map = new ResourceMap();
                    map.CreateMapNode(ResourcesMaker.ClinicalImpressionUrl,
                        new string[] { "Clinical", "Impression" },
                        "StructureDefinition",
                        "ClinicalImpression",
                        false);

                    map.CreateMapNode(ResourcesMaker.MedicationRequestUrl,
                        new string[] { "Medication", "Request" },
                        "StructureDefinition",
                        "MedicationRequest",
                        false);

                    map.CreateMapNode(ResourcesMaker.ServiceRequestUrl,
                        new string[] { "Service", "Request" },
                        "StructureDefinition",
                        "ServiceRequest",
                        false);

                    map.CreateMapNode(ResourcesMaker.RiskAssessmentUrl,
                        new string[] { "Risk", "Assessment" },
                        "StructureDefinition",
                        "RiskAssessment",
                        false);

                    map.AddDir(this.resourcesDir, "*.json");
                    {
                        ResourceMapMaker resourceMapMaker = new ResourceMapMaker(this.fc, map);
                        resourceMapMaker.AddLegendItem("DiagnosticReport", Color.LightGreen);
                        resourceMapMaker.AddLegendItem("Extension", Color.LightSalmon);
                        resourceMapMaker.AddLegendItem("Observation", Color.LightSkyBlue);
                        //resourceMapMaker.AddLegendItem("MedicationRequest", Color.LightPink);
                        resourceMapMaker.AddLegendItem("ServiceRequest", Color.LightBlue);
                        //resourceMapMaker.AddLegendItem("RiskAssessment", Color.LightGray);
                        //resourceMapMaker.AddLegendItem("ClinicalImpression", Color.LightGoldenrodYellow);
                        //resourceMapMaker.AddLegendItem("ImagingStudy", Color.LightCoral);

                        resourceMapMaker.Create(ResourcesMaker.CreateUrl("BreastRadReport"),
                            Path.Combine(this.graphicsDir, "ProfileOverview.svg"));
                    }

                    {
                        ResourceMapMaker resourceMapMaker = new ResourceMapMaker(this.fc, map);
                        resourceMapMaker.AddLegendItem("DiagnosticReport", Color.LightGreen);
                        resourceMapMaker.AddLegendItem("Extension", Color.LightSalmon);
                        resourceMapMaker.AddLegendItem("Observation", Color.LightSkyBlue);
                        resourceMapMaker.AddLegendItem("ImagingStudy", Color.LightCoral);

                        resourceMapMaker.Create(ResourcesMaker.CreateUrl("MGFinding"),
                            Path.Combine(this.graphicsDir, "MgFindings.svg"));
                    }

                    {
                        ResourceMapMaker resourceMapMaker = new ResourceMapMaker(this.fc, map);
                        resourceMapMaker.AddLegendItem("DiagnosticReport", Color.LightGreen);
                        resourceMapMaker.AddLegendItem("Extension", Color.LightSalmon);
                        resourceMapMaker.AddLegendItem("Observation", Color.LightSkyBlue);
                        resourceMapMaker.AddLegendItem("ImagingStudy", Color.LightCoral);

                        resourceMapMaker.Create(ResourcesMaker.CreateUrl("MRIFinding"),
                            Path.Combine(this.graphicsDir, "MRIFindings.svg"));
                    }

                    {
                        ResourceMapMaker resourceMapMaker = new ResourceMapMaker(this.fc, map);
                        resourceMapMaker.AddLegendItem("DiagnosticReport", Color.LightGreen);
                        resourceMapMaker.AddLegendItem("Extension", Color.LightSalmon);
                        resourceMapMaker.AddLegendItem("Observation", Color.LightSkyBlue);
                        resourceMapMaker.AddLegendItem("ImagingStudy", Color.LightCoral);

                        resourceMapMaker.Create(ResourcesMaker.CreateUrl("NMFinding"),
                            Path.Combine(this.graphicsDir, "NMFindings.svg"));
                    }

                    {
                        ResourceMapMaker resourceMapMaker = new ResourceMapMaker(this.fc, map);
                        resourceMapMaker.AddLegendItem("DiagnosticReport", Color.LightGreen);
                        resourceMapMaker.AddLegendItem("Extension", Color.LightSalmon);
                        resourceMapMaker.AddLegendItem("Observation", Color.LightSkyBlue);
                        resourceMapMaker.AddLegendItem("ImagingStudy", Color.LightCoral);

                        resourceMapMaker.Create(ResourcesMaker.CreateUrl("USFinding"),
                            Path.Combine(this.graphicsDir, "USFindings.svg"));
                    }

                    {
                        FocusMapMaker focusMapMaker = new FocusMapMaker(this.fc, map, this.graphicsDir, this.pageDir);
                        focusMapMaker.Create();
                    }
                }
            }
            catch (Exception err)
            {
                Trace.WriteLine(err.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void D_BuildIG()
        {
            try
            {
                String outputDir = Path.Combine(this.guideDir, "input");
                IGBuilder p = new IGBuilder(this.fc, outputDir);
                p.StatusErrors += this.StatusErrors;
                p.StatusInfo += this.StatusInfo;
                p.StatusWarnings += this.StatusWarnings;
                p.Start(Path.Combine(this.contentDir, "IGBreastRad.xml"));

                p.AddGrouping($"{ResourcesMaker.Group_BaseResources}", "Main Resources", "This section contains the main top level resources that are used in a Breast Radiology Report.");

                p.AddGrouping($"{ResourcesMaker.Group_CommonResources}", "Common Resources", "This section contains resources that are commonly used throughout a Breast Radiology Report");
                p.AddGrouping($"{ResourcesMaker.Group_CommonCodes}VS", "Common ValueSets ", "This section contains value sets that are commonly used throughout a Breast Radiology Report");
                p.AddGrouping($"{ResourcesMaker.Group_CommonCodes}CS", "Common CodeSystems", "This section contains code systems that are commonly used throughout a Breast Radiology Report");

                p.AddGrouping($"{ResourcesMaker.Group_MGResources}", "Mammography Resources", "This section contains resources used specifically in a Mammography exam");
                p.AddGrouping($"{ResourcesMaker.Group_MGCodes}VS", "Mammography ValueSets", "This section contains value sets used specifically in a Mammography exam");
                p.AddGrouping($"{ResourcesMaker.Group_MGCodes}CS", "Mammography CodeSystems", "This section contains code systems used specifically in a Mammography exam");

                p.AddGrouping($"{ResourcesMaker.Group_MRIResources}", "MRI Resources", "This section contains resources used specifically in a MRI exam");
                p.AddGrouping($"{ResourcesMaker.Group_MRICodes}VS", "MRI ValueSets", "This section contains value sets used specifically in a MRI exam");
                p.AddGrouping($"{ResourcesMaker.Group_MRICodes}CS", "MRI CodeSystems", "This section contains code systems used specifically in a MRI exam");

                p.AddGrouping($"{ResourcesMaker.Group_USResources}", "UltraSound Resources", "This section contains resources used specifically in a Ultra-Sound exam");
                p.AddGrouping($"{ResourcesMaker.Group_USCodes}VS", "UltraSound ValueSets", "This section contains value sets used specifically in a UltraSound exam");
                p.AddGrouping($"{ResourcesMaker.Group_USCodes}CS", "UltraSound CodeSystems", "This section contains code systems used specifically in a UltraSound exam");

                p.AddGrouping($"{ResourcesMaker.Group_AimResources}", "AIM Resources", "This section contains resources used specifically by AIM");
                p.AddGrouping($"{ResourcesMaker.Group_AimCodes}VS", "AIM ValueSets", "This section contains value sets used specifically by AIM");
                p.AddGrouping($"{ResourcesMaker.Group_AimCodes}CS", "AIM CodeSystems", "This section contains code systems used specifically by AIM");

                p.AddGrouping($"{ResourcesMaker.Group_Fragments}", "Fragments", "This section the fragments that are used to define the resources");

                p.AddGrouping($"{ResourcesMaker.Group_ExtensionResources}", "Extension", "Extension Resource Definitions");

                p.AddResources(this.resourcesDir);
                p.AddFragments(this.fragmentDir);
                p.AddPageContent(this.pageDir);
                p.AddPageContent(this.pageTemplateDir);
                p.AddImages(this.graphicsDir);
                p.SaveAll();

                //if (p.HasErrors)
                //{
                //    StringBuilder sb = new StringBuilder();
                //    p.FormatErrorMessages(sb);
                //    Trace.WriteLine(sb.ToString());
                //    Debug.Assert(false);
                //}
            }
            catch (Exception err)
            {
                Trace.WriteLine(err.Message);
                Assert.IsTrue(false);
            }
        }
    }
}
