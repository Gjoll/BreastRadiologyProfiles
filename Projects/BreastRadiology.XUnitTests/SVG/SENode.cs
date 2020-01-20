﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    [DebuggerDisplay("{AllText()}")]
    public class SENode
    {
        private float width;
        public List<SEText> TextLines = new List<SEText>();
        public Color FillColor { get; }
        public String HRef {get; }
        public String Title {get; }
        public float Width { get => this.width; set => this.width = value; }

        public String Annotation { get; }

        public SENode(float width,
            Color fillColor,
            String annotation,
            String hRef = null,
            String title = null)
        {
            this.Width = width;
            this.FillColor = fillColor;
            Debug.Assert(String.IsNullOrEmpty(annotation) || annotation.Contains(".."));
            this.Annotation = annotation;
            this.HRef = hRef;
            this.Title = title;
        }

        public SENode()
        {
        }

        public String AllText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (SEText t in this.TextLines)
                sb.Append($"{t.Text} ");
            return sb.ToString();
        }

        public SENode AddTextLine(SEText text)
        {
            if (this.Width < text.Text.Length)
                this.Width = text.Text.Length;
            this.TextLines.Add(text);
            return this;
        }

        public SENode AddTextLine(String text, String hRef = null, String title = null)
        {
            return this.AddTextLine(new SEText(text, hRef, title));
        }
    }
}
