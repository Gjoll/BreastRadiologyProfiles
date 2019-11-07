using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FhirKhit.BreastRadiology.XUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        String outputDir = Path.Combine(
            DirHelper.FindParentDir("BreastRadiology"),
            "IG",
            "Guide");
        String resourcesDir = Path.Combine(
            DirHelper.FindParentDir("BreastRadiology"),
            "IG",
            "Resources");

        String manualDir = Path.Combine(
            DirHelper.FindParentDir("BreastRadiology"),
            "IG",
            "ManualResources");

        [TestMethod]
        public void BuildResources()
        {
            ResourcesMaker pc = new ResourcesMaker(this.resourcesDir);
            pc.CreateResources();
        }

        [TestMethod]
        public void ValidateGen()
        {
            String rDir = Path.Combine(this.outputDir,
                "resources");
            FhirValidator fv = new FhirValidator();
            bool success = fv.ValidateDir(rDir, "*.json", "4.0.0");
            StringBuilder sb = new StringBuilder();
            fv.FormatMessages(sb);
            Trace.WriteLine(sb.ToString());
            Assert.IsTrue(success);
            Trace.WriteLine("Validation complete");
        }

        [TestMethod]
        public void Validate()
        {
            FhirValidator fv = new FhirValidator();
            bool success = fv.ValidateDir(this.resourcesDir, "*.json", "4.0.0");
            StringBuilder sb = new StringBuilder();
            fv.FormatMessages(sb);
            Trace.WriteLine(sb.ToString());
            Assert.IsTrue(success);
            Trace.WriteLine("Validation complete");
        }

        //[TestMethod]
        //public void Clean()
        //{
        //    ProfileCleanUp pc = new ProfileCleanUp();
        //    pc.Clean(resourcesDir);
        //}

        [TestMethod]
        public void FullBuild()
        {
            this.BuildResources();
            this.IGBuild();
        }

        [TestMethod]
        public void IGBuild()
        {
            IGBuilder p = new IGBuilder(this.outputDir);
            p.Start();
            p.AddResources(this.resourcesDir);
            p.AddResources(this.manualDir);
            p.SaveAll();
        }
    }
}
