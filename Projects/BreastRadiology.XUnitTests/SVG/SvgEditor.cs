using SVGLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    class SvgEditor
    {
        const String ArrowStart = "arrowStart";
        const String ArrowEnd = "arrowEnd";

        const float ArrowEndSize = 0.5f;
        SvgDoc doc;
        SvgRoot root;

        public float screenX = -1;
        public float screenY = -1;
        public float BorderWidth { get; set; } = 0.125f;
        public float LineHeight { get; set; } = 1.25f;
        public float BorderMargin { get; set; } = 0.5f;
        public float NodeGapX { get; set; } = 2.0f;
        public float NodeGapY { get; set; } = 0.5f;
        public float RectRx { get; set; } = 0.25f;
        public float RectRy { get; set; } = 0.25f;

        String ToPx(float value) => $"{15 * value}";

        float maxWidth;
        float maxHeight;

        public SvgEditor()
        {
            this.doc = new SvgDoc();
            this.root = this.doc.CreateNewDocument();
            this.CreateArrowStart();
            this.CreateArrowEnd();
        }

        void CreateArrowEnd()
        {
            SvgMarker arrowEnd = this.doc.AddMarker();
            arrowEnd.RefX = $"{this.ToPx(ArrowEndSize)}";
            arrowEnd.RefY = $"{this.ToPx(ArrowEndSize / 2)}";
            arrowEnd.MarkerWidth = $"{this.ToPx(ArrowEndSize)}";
            arrowEnd.MarkerHeight = $"{this.ToPx(ArrowEndSize)}";
            arrowEnd.MarkerUnits = "px";
            arrowEnd.Id = ArrowEnd;

            SvgPolygon p = this.doc.AddPolygon(arrowEnd);
            p.Points = $"0 0 {this.ToPx(ArrowEndSize)} {this.ToPx(ArrowEndSize / 2)} 0 {this.ToPx(ArrowEndSize)}";
            p.StrokeWidth = "0";
            p.Fill = Color.Black;
            p.StrokeWidth = "0";
        }

        void CreateArrowStart()
        {
            float radius = 0.125f;

            SvgMarker arrowStart = this.doc.AddMarker();
            arrowStart.RefX = $"{this.ToPx(radius)}";
            arrowStart.RefY = $"{this.ToPx(radius)}";
            arrowStart.MarkerWidth = $"{this.ToPx(2 * radius)}";
            arrowStart.MarkerHeight = $"{this.ToPx(2 * radius)}";
            arrowStart.MarkerUnits = "px";
            arrowStart.Id = ArrowStart;

            SvgCircle c = this.doc.AddCircle(arrowStart);
            c.CX = $"{this.ToPx(radius)}";
            c.CY = $"{this.ToPx(radius)}";
            c.R = $"{this.ToPx(radius)}";
            c.Fill = Color.Black;
            c.StrokeWidth = "0";
        }

        public void Render(SENodeGroup group,
            bool lineFlag)
        {
            this.maxWidth = 0;
            this.maxHeight = 0;

            if (this.screenX == -1)
                this.screenX = this.BorderMargin;
            if (this.screenY == -1)
                this.screenY = this.BorderMargin;

            this.RenderGroup(group, this.screenX, this.screenY, lineFlag, out float width, out float height, out List<PointF> endConnectors);
            this.root.Width = $"{this.ToPx(this.maxWidth + this.NodeGapX)}";
            this.root.Height = $"{this.ToPx(this.maxHeight + this.NodeGapY)}";
            this.screenY = this.maxHeight + 4 * this.BorderMargin;
        }

        void CreateArrow(SvgGroup g,
            bool startMarker,
            bool endMarker,
            float xStart,
            float yStart,
            float xEnd,
            float yEnd)
        {
            SvgLine stub = this.doc.AddLine(g);
            stub.Stroke = Color.Black;
            stub.X1 = this.ToPx(xStart);
            stub.X2 = this.ToPx(xEnd);
            stub.Y1 = this.ToPx(yStart);
            stub.Y2 = this.ToPx(yEnd);
            stub.StrokeWidth = this.ToPx(this.BorderWidth);
            if (startMarker)
                stub.MarkerStart = $"url(#{ArrowStart})";
            if (endMarker)
                stub.MarkerEnd = $"url(#{ArrowEnd})";
        }

        void CreateLine(SvgGroup g, float x1, float y1, float x2, float y2)
        {
            SvgLine stub = this.doc.AddLine(g);
            stub.Stroke = Color.Black;
            stub.X1 = this.ToPx(x1);
            stub.X2 = this.ToPx(x2);
            stub.Y1 = this.ToPx(y1);
            stub.Y2 = this.ToPx(y2);
            stub.StrokeWidth = this.ToPx(this.BorderWidth);
        }

        void RenderGroup(SENodeGroup group,
            float screenX,
            float screenY,
            bool lineFlag,
            out float colWidth,
            out float colHeight,
            out List<PointF> endConnectors)
        {
            colWidth = 0;
            colHeight = 0;

            SvgGroup g = this.doc.AddGroup(null);
            float col1ScreenX = screenX;
            float col1ScreenY = screenY;
            float col1Width = 0;
            float col1Height = 0;

            float topConnectorY = float.MaxValue;
            float bottomConnectorY = float.MinValue;

            endConnectors = new List<PointF>();
            List<PointF> startConnectors = new List<PointF>();

            foreach (SENode node in group.Nodes)
            {
                this.Render(g, node, screenX, col1ScreenY, out float nodeWidth, out float nodeHeight);
                if (col1Width < nodeWidth)
                    col1Width = nodeWidth;

                float connectorY = col1ScreenY + nodeHeight / 2;
                if (topConnectorY > connectorY)
                    topConnectorY = connectorY;
                if (bottomConnectorY < connectorY)
                    bottomConnectorY = connectorY;
                startConnectors.Add(new PointF(screenX + nodeWidth, col1ScreenY + nodeHeight / 2));
                endConnectors.Add(new PointF(screenX, col1ScreenY + nodeHeight / 2));
                col1Height += nodeHeight + this.NodeGapY;
                col1ScreenY += nodeHeight + this.NodeGapY;
            }

            if (this.maxWidth < col1ScreenX + col1Width + this.NodeGapX)
                this.maxWidth = col1ScreenX + col1Width + this.NodeGapX;
            if (this.maxHeight < col1ScreenY)
                this.maxHeight = col1ScreenY;

            float col2ScreenX = screenX + col1Width + 2 * this.NodeGapX;
            float col2ScreenY = screenY;

            float col2Height = 0;
            bool endConnectorFlag = false;
            foreach (SENodeGroup child in group.Children)
            {
                this.RenderGroup(child,
                    col2ScreenX,
                    col2ScreenY,
                    lineFlag,
                    out float col2GroupWidth,
                    out float col2GroupHeight,
                    out List<PointF> col2EndConnectors);
                col2ScreenY += col2GroupHeight;
                col2Height += col2GroupHeight;

                if ((lineFlag) && (startConnectors.Count > 0))
                {
                    foreach (PointF stubEnd in col2EndConnectors)
                    {
                        endConnectorFlag = true;
                        this.CreateArrow(g, false, true, screenX + col1Width + this.NodeGapX, stubEnd.Y, stubEnd.X, stubEnd.Y);
                        if (topConnectorY > stubEnd.Y)
                            topConnectorY = stubEnd.Y;
                        if (bottomConnectorY < stubEnd.Y)
                            bottomConnectorY = stubEnd.Y;
                    }
                }
                float width = col1Width + 2 * this.NodeGapX + col2GroupWidth;
                if (colWidth < width)
                    colWidth = width;

                if (this.maxWidth < col2ScreenX + col2GroupWidth + this.NodeGapX)
                    this.maxWidth = col2ScreenX + col2GroupWidth + this.NodeGapX;
            }

            if ((lineFlag) && (endConnectorFlag == true))
            {
                foreach (PointF stubStart in startConnectors)
                    this.CreateArrow(g, true, false, stubStart.X, stubStart.Y, screenX + col1Width + this.NodeGapX, stubStart.Y);

                // Make vertical line that connects all stubs.
                if (group.Children.Count > 0)
                {
                    float x = screenX + col1Width + this.NodeGapX;
                    this.CreateLine(g, x, topConnectorY, x, bottomConnectorY);
                }
            }

            if (this.maxHeight < col2ScreenY + this.NodeGapY)
                this.maxHeight = col2ScreenY + this.NodeGapY;

            if (colHeight < col1Height)
                colHeight = col1Height;
            if (colHeight < col2Height)
                colHeight = col2Height;
        }

        void Render(SvgGroup parentGroup,
            SENode node,
            float screenX,
            float screenY,
            out float width,
            out float height)
        {
            const float CharMod = 0.7f;

            height = node.TextLines.Count * this.LineHeight + 2 * this.BorderMargin;
            width = node.Width * CharMod + 2 * this.BorderMargin;

            SvgGroup g = this.doc.AddGroup(parentGroup);

            SvgRect square;

            if (node.HRef != null)
            {
                SvgHyperLink l = this.doc.AddHyperLink(g);
                l.Target = "_blank";
                l.HRef = node.HRef.ToString();
                if (node.Title != null)
                {
                    SvgTitle title = this.doc.AddTitle(l);
                    title.Value = node.Title;
                }
                square = this.doc.AddRect(l);
            }
            else
            {
                square = this.doc.AddRect(g);
            }
            square.Stroke = Color.Black;
            square.StrokeWidth = this.ToPx(this.BorderWidth);
            square.RX = this.ToPx(this.RectRx);
            square.RY = this.ToPx(this.RectRy);
            square.X = this.ToPx(screenX);
            square.Y = this.ToPx(screenY);
            square.Width = this.ToPx(width);
            square.Height = this.ToPx(height);
            square.Fill = node.FillColor;

            float textX = screenX + this.BorderMargin;
            float textY = screenY + this.BorderMargin + 1;

            foreach (SEText line in node.TextLines)
            {
                SvgText t;
                if (line.HRef != null)
                {
                    SvgHyperLink l = this.doc.AddHyperLink(g);
                    l.HRef = line.HRef;
                    l.Target = "_blank";
                    if (line.Title != null)
                    {
                        SvgTitle title = this.doc.AddTitle(l);
                        title.Value = line.Title;
                    }
                    t = this.doc.AddText(l);
                }
                else
                {
                    t = this.doc.AddText(g);
                }
                t.X = this.ToPx(textX);
                t.Y = this.ToPx(textY);
                t.Value = line.Text;

                textY += this.LineHeight;
            }
        }

        public String GetXml()
        {
            return this.doc.GetXML();
        }

        public void Save(String path)
        {
            this.doc.SaveToFile(path);
        }
    }
}
