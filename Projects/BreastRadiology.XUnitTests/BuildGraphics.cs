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
    public class BuildGraphics
    {
        const String baseDir = "BreastRadiology2020FebBallot";

        const String Overview = "Overview.svg";
        const String FindingsLeftBreast = "FindingsLeftBreast.svg";
        const String FindingsRightBreast = "FindingsRightBreast.svg";

        String OutputDir
        {
            get
            {
                String retVal = Path.Combine(DirHelper.FindParentDir(baseDir), "GeneratedGraphics");
                if (Directory.Exists(retVal) == false)
                    Directory.CreateDirectory(retVal);
                return retVal;
            }
        }

        [TestMethod]
        public void BuildOverviewGraphic()
        {
            float nodeWidth = 8;

            SvgEditor e = new SvgEditor();

            SENodeGroup rootGroup = new SENodeGroup("root");
            {
                SENode node = new SENode(nodeWidth, Color.LightGreen)
                    .AddTextLine("Breast")
                    .AddTextLine("Radiology")
                    .AddTextLine("Report")
                    ;
                rootGroup.Nodes.Add(node);
            }

            {
                float sectionNodeWidth = 12;
                {
                    SENodeGroup sectionFindingsGroup = rootGroup.AppendChild("findings");
                    SENode findingsNode = new SENode(sectionNodeWidth, Color.LightBlue)
                        .AddTextLine("Findings")
                        .AddTextLine("Section")
                        ;
                    sectionFindingsGroup.Nodes.Add(findingsNode);
                    {
                        SENodeGroup sectionFindingsRightGroup = sectionFindingsGroup.AppendChild("findings right");
                        {
                            SENode node = new SENode(sectionNodeWidth, Color.LightBlue, FindingsRightBreast)
                                .AddTextLine("Findings")
                                .AddTextLine("Right Breast")
                                .AddTextLine("Section")
                                ;
                            sectionFindingsRightGroup.Nodes.Add(node);
                        }
                        {
                            SENodeGroup sectionFindingsLeftGroup = sectionFindingsGroup.AppendChild("findings left");
                            {
                                SENode node = new SENode(sectionNodeWidth, Color.LightBlue, FindingsLeftBreast)
                                    .AddTextLine("Findings")
                                    .AddTextLine("Left Breast")
                                    .AddTextLine("Section")
                                    ;
                                sectionFindingsRightGroup.Nodes.Add(node);
                            }
                        }
                    }
                }
                {
                    SENodeGroup sectionImpressionsGroup = rootGroup.AppendChild("impressions");
                    SENode node = new SENode(sectionNodeWidth, Color.Coral)
                        .AddTextLine("Impressions")
                        .AddTextLine("Section")
                        ;
                    sectionImpressionsGroup.Nodes.Add(node);
                }

                {
                    SENodeGroup sectionRecommendationsGroup = rootGroup.AppendChild("recommendations");
                    SENode node = new SENode(sectionNodeWidth, Color.Coral)
                        .AddTextLine("Recommendations")
                        .AddTextLine("Section")
                        ;
                    sectionRecommendationsGroup.Nodes.Add(node);
                }

                {
                    SENodeGroup sectionRiskGroup = rootGroup.AppendChild("risk");
                    SENode node = new SENode(sectionNodeWidth, Color.Coral)
                        .AddTextLine("Patient Risk Section")
                        ;
                    sectionRiskGroup.Nodes.Add(node);
                }
                {
                    SENodeGroup sectionPriorGroup = rootGroup.AppendChild("prior");
                    SENode node = new SENode(sectionNodeWidth, Color.Coral)
                        .AddTextLine("Prior Studies")
                        ;
                    sectionPriorGroup.Nodes.Add(node);
                }
            }

            e.Render(rootGroup, true);
            e.Save(Path.Combine(this.OutputDir, Overview));
        }

        [TestMethod]
        public void BuildFindings()
        {
            this.BuildFindings("Left", FindingsLeftBreast);
            this.BuildFindings("Right", FindingsRightBreast);
        }


        [TestMethod]
        public void BuildAll()
        {
            this.BuildOverviewGraphic();
            this.BuildFindings();
        }

        public void BuildFindings(String name,
            String outputName)
        {
            SENodeGroup rootGroup;

            SENodeGroup AbnormalityType(String name)
            {
                float width = 12;
                SENodeGroup findingsGroup = new SENodeGroup(name);
                rootGroup.Children.Add(findingsGroup);

                SENode findingsNode = new SENode(width, Color.LightBlue)
                    .AddTextLine(name)
                    .AddTextLine("Abnormality")
                    .AddTextLine("Observation")
                    ;

                findingsGroup.Nodes.Add(findingsNode);

                SENodeGroup g = new SENodeGroup(name);
                findingsGroup.Children.Add(g);

                return g;
            }

            void AddTarget(SENodeGroup g, String name)
            {
                SENode targetNode = new SENode(14, Color.LightBlue)
                    .AddTextLine(name)
                    ;

                g.Nodes.Add(targetNode);
            }

            SvgEditor e = new SvgEditor();

            rootGroup = new SENodeGroup("root");
            {
                float nodeWidth = 8;
                SENode node = new SENode(nodeWidth, Color.LightGreen, Overview)
                    .AddTextLine("Findings")
                    .AddTextLine($"{name} Breast")
                    .AddTextLine("Section")
                    ;
                rootGroup.Nodes.Add(node);
            }

            {
                SENodeGroup g = AbnormalityType("Mammography");
                AddTarget(g, "Mammo Breast Density");
                AddTarget(g, "Mammo Mass");
                AddTarget(g, "Mammo Calcification");
                AddTarget(g, "Mammo Arch. Distortion");
                AddTarget(g, "Intra. Lymph Node");
                AddTarget(g, "Skin Lesion");
                AddTarget(g, "Solitary Dilated Duct");
            }

            {
                SENodeGroup g = AbnormalityType("MRI");
            }

            {
                SENodeGroup g = AbnormalityType("UltraSound");
            }

            e.Render(rootGroup, true);
            e.Save(Path.Combine(this.OutputDir, outputName));
        }

        [TestMethod]
        public void SVG()
        {
            float nodeWidth = 8;

            SvgEditor e = new SvgEditor();

            SENodeGroup group1 = new SENodeGroup("test");
            {
                SENode node = new SENode(nodeWidth, Color.LightBlue)
                    .AddTextLine("Node1.1 1", "http://www.google.com")
                    .AddTextLine("Node1.1 2")
                    .AddTextLine("Node1.1 3")
                    ;
                group1.Nodes.Add(node);
            }

            {
                SENode node = new SENode(nodeWidth, Color.Coral)
                    .AddTextLine("Node1.2 1")
                    ;
                group1.Nodes.Add(node);
            }

            {
                SENodeGroup group2 = new SENodeGroup("test2");
                {
                    SENode node = new SENode(nodeWidth, Color.LightBlue)
                        .AddTextLine("Node2.1 1", "http://www.google.com")
                        .AddTextLine("Node2.1 2")
                        .AddTextLine("Node2.1 3")
                        ;
                    group2.Nodes.Add(node);
                }
                {
                    SENode node = new SENode(nodeWidth, Color.Coral)
                        .AddTextLine("Node2.2 1")
                        ;
                    group2.Nodes.Add(node);
                }

                {
                    SENode node = new SENode(nodeWidth, Color.Coral)
                        .AddTextLine("Node2.3 1")
                        ;
                    group2.Nodes.Add(node);
                }
                group1.Children.Add(group2);
            }

            e.Render(group1, true);
            e.Save(Path.Combine(this.OutputDir, "Shapes.svg"));
        }
    }
}
