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
using ExcelDataReader;
using System.Data;
using System.Globalization;

namespace BreastRadiology.XUnitTests
{
    [TestClass]
    public sealed class BuildFragments : IDisposable
    {
        const String BaseDirName = "BreastRadiologyProfiles";

        String BaseDir
        {
            get
            {
                if (this.baseDirFull == null)
                    this.baseDirFull = DirHelper.FindParentDir(BaseDirName);
                return this.baseDirFull;
            }
        }
        String baseDirFull;

        String cacheDir;
        String contentDir;
        String guideDir;

        String graphicsDir;
        String fragmentDir;
        String resourcesDir;
        String pageDir;
        String pageTemplateDir;
        String mergedDir;

        FileCleaner fc = null;

        public void Dispose()
        {
            this.fc?.Dispose();
        }

        public BuildFragments()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Encoding enc1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252);

            this.cacheDir = Path.Combine(this.BaseDir, "Cache");
            this.contentDir = Path.Combine(this.BaseDir, "IG", "Content");
            this.guideDir = Path.Combine(this.BaseDir, "IG", "Guide");

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
            if (msg.Contains(" does not resolve", new System.StringComparison()))
                return true;

            this.Message("Warn", className, method, msg);
            return true;
        }
        private bool StatusInfo(string className, string method, string msg)
        {
            //if (msg.Contains(" does not resolve", new System.StringComparison()))
            //    return true;

            //if (msg.Contains("http://www.fragment.com", new System.StringComparison()))
            //    return true;

            //if (msg.Contains("Unknown Code System", new System.StringComparison()))
            //    return true;

            //this.Message("Info", className, method, msg);
            return true;
        }
        private bool StatusErrors(string className, string method, string msg)
        {
            if (msg.Contains(" does not resolve", new System.StringComparison()))
                return true;
            if (msg.Contains("Unknown Code System", new System.StringComparison()))
                return true;

            this.Message("Error", className, method, msg);
            return true;
        }

        [TestMethod]
        public void B1_BuildFragments()
        {
            DateTime start = DateTime.Now;
            Trace.WriteLine("Starting A_BuildFragments");
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
            TimeSpan span = DateTime.Now - start;
            Trace.WriteLine($"Ending A_BuildFragments [{(Int32)span.TotalSeconds}]");
        }

        [TestMethod]
        public void B2_BuildResources()
        {
            DateTime start = DateTime.Now;
            Trace.WriteLine("Starting B_BuildResources");
            bool saveMergedFiles = true;

            try
            {
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
                preFhir.BreakOnElementId = "Extension.extension:laterality.url";
                preFhir.BreakOnTitle = "BreastBodyLocationExtension";
                preFhir.Process();
                preFhir.SaveResources(this.resourcesDir);

                if (preFhir.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    preFhir.FormatErrorMessages(sb);
                    Trace.WriteLine(sb.ToString());
                    Debug.Assert(false);
                }
            }
            catch (Exception err)
            {
                Trace.WriteLine(err.Message);
                Assert.IsTrue(false);
            }

            TimeSpan span = DateTime.Now - start;
            Trace.WriteLine($"Ending B_BuildResources [{(Int32)span.TotalSeconds}]");
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
        public void SDCheckInputResources()
        {
            SDChecker fv = new SDChecker();
            fv.StatusErrors += this.StatusErrors;
            fv.StatusInfo += this.StatusInfo;
            fv.StatusWarnings += this.StatusWarnings;
            fv.CheckDir(this.resourcesDir, "*.json");
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

        [TestMethod]
        public void B3_PatchIntroDocs()
        {
            DateTime start = DateTime.Now;
            Trace.WriteLine("Starting A_BuildFragments");
            try
            {
                ResourceMap map = new ResourceMap();
                map.AddDir(this.resourcesDir, "*.json");

                IntroDocPatcher docPatcher = new IntroDocPatcher(this.pageDir);
                docPatcher.StatusErrors += this.StatusErrors;
                docPatcher.StatusInfo += this.StatusInfo;
                docPatcher.StatusWarnings += this.StatusWarnings;
                docPatcher.AddResourceDir(this.resourcesDir);
                docPatcher.AddFragDir(this.fragmentDir);
                docPatcher.Patch();
                if (docPatcher.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    docPatcher.FormatErrorMessages(sb);
                    Trace.WriteLine(sb.ToString());
                    Debug.Assert(false);
                }
            }
            catch (Exception err)
            {
                Trace.WriteLine(err.Message);
                Assert.IsTrue(false);
            }
            TimeSpan span = DateTime.Now - start;
            Trace.WriteLine($"Ending A_BuildFragments [{(Int32)span.TotalSeconds}]");
        }

        [TestMethod]
        public void B4_BuildGraphics()
        {
            DateTime start = DateTime.Now;
            Trace.WriteLine("Starting C_BuildGraphics");
            try
            {
                if (Directory.Exists(this.graphicsDir) == false)
                    Directory.CreateDirectory(this.graphicsDir);
                {
                    ResourceMap map = new ResourceMap();
                    map.AddDir(this.resourcesDir, "*.json");
                    {
                        FocusMapMaker focusMapMaker = new FocusMapMaker(this.fc, map, this.graphicsDir, this.pageDir);
                        focusMapMaker.Create();
                    }
                    {
                        ResourceMapMaker resourceMapMaker = new ResourceMapMaker(this.fc, map);
                        resourceMapMaker.Create(ResourcesMaker.CreateUrl("BreastRadComposition"),
                            Path.Combine(this.graphicsDir, "ProfileOverview.svg"));
                    }
                    {
                        ResourceMapMaker resourceMapMaker = new ResourceMapMaker(this.fc, map);
                        resourceMapMaker.Create(ResourcesMaker.CreateUrl("MGFinding"),
                            Path.Combine(this.graphicsDir, "MgFindings.svg"));
                    }
                    {
                        ResourceMapMaker resourceMapMaker = new ResourceMapMaker(this.fc, map);
                        resourceMapMaker.Create(ResourcesMaker.CreateUrl("MRIFinding"),
                            Path.Combine(this.graphicsDir, "MRIFindings.svg"));
                    }
                    {
                        ResourceMapMaker resourceMapMaker = new ResourceMapMaker(this.fc, map);
                        resourceMapMaker.Create(ResourcesMaker.CreateUrl("NMFinding"),
                            Path.Combine(this.graphicsDir, "NMFindings.svg"));
                    }
                    {
                        ResourceMapMaker resourceMapMaker = new ResourceMapMaker(this.fc, map);
                        resourceMapMaker.Create(ResourcesMaker.CreateUrl("USFinding"),
                            Path.Combine(this.graphicsDir, "USFindings.svg"));
                    }
                }

                {
                    ResourceMap map = new ResourceMap();
                    map.AddDir(this.fragmentDir, "*.json");

                    FragmentMapMaker fragmentMapMaker = new FragmentMapMaker(this.fc, map, this.graphicsDir, this.pageDir, this.pageTemplateDir);
                    fragmentMapMaker.Create();
                }

            }
            catch (Exception err)
            {
                Trace.WriteLine(err.Message);
                Assert.IsTrue(false);
            }
            TimeSpan span = DateTime.Now - start;
            Trace.WriteLine($"Ending C_BuildGraphics [{(Int32)span.TotalSeconds}]");
        }

        [TestMethod]
        public void B5_BuildIG()
        {
            DateTime start = DateTime.Now;
            Trace.WriteLine("Starting D_BuildIG");
            try
            {
                String outputDir = Path.Combine(this.guideDir, "input");
                if (Directory.Exists(outputDir) == false)
                    Directory.CreateDirectory(outputDir);

                IGBuilder p = new IGBuilder(this.fc, outputDir);
                p.StatusErrors += this.StatusErrors;
                p.StatusInfo += this.StatusInfo;
                p.StatusWarnings += this.StatusWarnings;
                p.Start(Path.Combine(this.contentDir, "IGBreastRad.xml"));

                p.AddGrouping($"{ResourcesMaker.Group_BaseResources}", "Main Resources", "This section contains the main top level resources that are used in a Breast Radiology Report.");

                p.AddGrouping($"{ResourcesMaker.Group_CommonResources}", "Common Resources", "This section contains resources that are commonly used throughout a Breast Radiology Report");
                p.AddGrouping($"{ResourcesMaker.Group_CommonCodesVS}", "Common ValueSets ", "This section contains value sets that are commonly used throughout a Breast Radiology Report");
                p.AddGrouping($"{ResourcesMaker.Group_CommonCodesCS}", "Common CodeSystems", "This section contains code systems that are commonly used throughout a Breast Radiology Report");

                p.AddGrouping($"{ResourcesMaker.Group_MGResources}", "Mammography Resources", "This section contains resources used specifically in a Mammography exam");
                p.AddGrouping($"{ResourcesMaker.Group_MGCodesVS}", "Mammography ValueSets", "This section contains value sets used specifically in a Mammography exam");
                p.AddGrouping($"{ResourcesMaker.Group_MGCodesCS}", "Mammography CodeSystems", "This section contains code systems used specifically in a Mammography exam");

                p.AddGrouping($"{ResourcesMaker.Group_MRIResources}", "MRI Resources", "This section contains resources used specifically in a MRI exam");
                p.AddGrouping($"{ResourcesMaker.Group_MRICodesVS}", "MRI ValueSets", "This section contains value sets used specifically in a MRI exam");
                p.AddGrouping($"{ResourcesMaker.Group_MRICodesCS}", "MRI CodeSystems", "This section contains code systems used specifically in a MRI exam");

                p.AddGrouping($"{ResourcesMaker.Group_USResources}", "Ultra-Sound Resources", "This section contains resources used specifically in a Ultra-Sound exam");
                p.AddGrouping($"{ResourcesMaker.Group_USCodesVS}", "Ultra-Sound ValueSets", "This section contains value sets used specifically in a Ultra-Sound exam");
                p.AddGrouping($"{ResourcesMaker.Group_USCodesCS}", "Ultra-Sound CodeSystems", "This section contains code systems used specifically in a Ultra-Sound exam");

                p.AddGrouping($"{ResourcesMaker.Group_NMResources}", "Nuclear Medicine Resources", "This section contains resources used specifically in a Nuclear Medicine exam");
                p.AddGrouping($"{ResourcesMaker.Group_NMCodesVS}", "Nuclear Medicine ValueSets", "This section contains value sets used specifically in a Nuclear Medicine exam");
                p.AddGrouping($"{ResourcesMaker.Group_NMCodesCS}", "Nuclear Medicine CodeSystems", "This section contains code systems used specifically in a Nuclear Medicine exam");

                p.AddGrouping($"{ResourcesMaker.Group_AimResources}", "AIM Resources", "This section contains resources used specifically by AIM");
                p.AddGrouping($"{ResourcesMaker.Group_AimCodesVS}", "AIM ValueSets", "This section contains value sets used specifically by AIM");
                p.AddGrouping($"{ResourcesMaker.Group_AimCodesCS}", "AIM CodeSystems", "This section contains code systems used specifically by AIM");

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
            TimeSpan span = DateTime.Now - start;
            Trace.WriteLine($"Ending D_BuildIG [{(Int32)span.TotalSeconds}]");
        }

        [TestMethod]
        public void B6_RunPublisher()
        {
            DateTime start = DateTime.Now;
            Trace.WriteLine("Starting F_RunPublisher");
            try
            {
                String executingDir = Path.Combine(DirHelper.FindParentDir("BreastRadiologyProfiles"),
                    "IG",
                    "guide");
                String jarPath = Path.Combine(executingDir, "input-cache", "org.hl7.fhir.publisher.jar");
                String igPath = Path.Combine(executingDir, "ig.ini");
                if (File.Exists(jarPath) == false)
                    throw new Exception($"Missing publisher jar '{jarPath}'");

                IGPublisher p = new IGPublisher();
                p.StatusErrors += this.StatusErrors;
                p.StatusInfo += this.StatusInfo;
                p.StatusWarnings += this.StatusWarnings;
                p.Publish(executingDir, jarPath, igPath);

                if (p.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    p.FormatErrorMessages(sb);
                    Trace.WriteLine(sb.ToString());
                    Debug.Assert(false);
                }
            }
            catch (Exception err)
            {
                Trace.WriteLine(err.Message);
                Assert.IsTrue(false);
            }
            TimeSpan span = DateTime.Now - start;
            Trace.WriteLine($"Ending F_RunPublisher[{(Int32)span.TotalSeconds}]");
        }



        [TestMethod]
        public void A1_Build()
        {
            using (this.fc = new FileCleaner())
            {
                this.fc?.Add(this.graphicsDir, "*.svg");
                this.fc?.Add(this.pageDir, "*.xml");
                this.fc?.Add(this.fragmentDir, "*.json");
                this.fc?.Add(this.resourcesDir, "*.json");

                this.B1_BuildFragments();
                this.B2_BuildResources();
                this.B3_PatchIntroDocs();
                this.B4_BuildGraphics();
                this.B5_BuildIG();
            }
        }

        [TestMethod]
        public void A2_BuildAndPublish()
        {
            this.A1_Build();
            this.B6_RunPublisher();
        }


        [TestMethod]
        public void TestFile()
        {
            FhirStructureDefinitions.Create(this.cacheDir);
            FhirStructureDefinitions.Self.StoreFhirElements();

            FhirJsonParser parser = new FhirJsonParser();
            StructureDefinition sd = parser.Parse<StructureDefinition>(
                File.ReadAllText(@"C:\Development\HL7\BreastRadiologyProfiles\IG\Content\Fragments\StructureDefinition-BreastBodyLocationExtension.json"));

            sd.Snapshot = null;
            SnapshotCreator.Create(sd);
            sd.Extension = null;
            sd.Context = null;
            sd.SaveJson(@"c:\Temp\test.json");
        }

        [TestMethod]
        public void MergeOneFile()
        {
            DateTime start = DateTime.Now;
            bool saveMergedFiles = true;

            try
            {
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
                preFhir.BreakOnElementId = "Extension.extension:laterality.url";
                preFhir.BreakOnTitle = "BreastBodyLocationExtension";
                preFhir.ProcessOne(this.fragmentDir, "BreastBodyLocationExtension");
                preFhir.SaveResources(this.resourcesDir);

                if (preFhir.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    preFhir.FormatErrorMessages(sb);
                    Trace.WriteLine(sb.ToString());
                    Debug.Assert(false);
                }
            }
            catch (Exception err)
            {
                Trace.WriteLine(err.Message);
                Assert.IsTrue(false);
            }

            TimeSpan span = DateTime.Now - start;
            Trace.WriteLine($"Ending B_BuildResources [{(Int32)span.TotalSeconds}]");
        }
    }
}
