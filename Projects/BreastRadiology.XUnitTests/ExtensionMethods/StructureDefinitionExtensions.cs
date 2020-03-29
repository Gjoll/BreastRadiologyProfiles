using Hl7.Fhir.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    internal static class StructureDefinitionExtensions
    {
        public static StructureDefinition AddExtensionLink(this StructureDefinition sd, 
            String url,
            SDefEditor.Cardinality cardinalityLeft,
            String localName,
            String componentRef)
        {
            dynamic packet = new JObject();
            packet.LinkType = SVGGlobal.ExtensionType;
            packet.CardinalityLeft = cardinalityLeft.ToString();
            packet.ComponentHRef = componentRef;
            packet.LocalName = localName;
            packet.LinkTarget = url;
            sd.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));

            return sd;
        }

        public static StructureDefinition AddTargetLink(this StructureDefinition sd, 
            String url,
            SDefEditor.Cardinality cardinalityLeft)
        {
            dynamic packet = new JObject();
            packet.LinkType = SVGGlobal.TargetType;
            packet.CardinalityLeft = cardinalityLeft.ToString();
            packet.LinkTarget = url;
            sd.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));
            return sd;
        }

        public static StructureDefinition AddValueSetLink(this StructureDefinition sd, 
            ValueSet vs)
        {
            dynamic packet = new JObject();
            packet.LinkType = SVGGlobal.ValueSetType;
            packet.LinkTarget = vs.Url;
            sd.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));

            return sd;
        }

        internal static dynamic AddComponentChildLink(this StructureDefinition sd,
            String url,
            String parent,
            SDefEditor.Cardinality cardinalityLeft,
            SDefEditor.Cardinality cardinalityRight,
            String componentRef,
            String types,
            params String[] targets)
        {
            dynamic packet = new JObject();
            packet.LinkType = SVGGlobal.ComponentChildType;
            packet.Parent = parent;
            if (cardinalityLeft != null)
                packet.CardinalityLeft = cardinalityLeft.ToString();
            packet.LinkTarget = url;
            packet.ComponentHRef = componentRef;
            packet.Types = types;
            packet.References = new JArray(targets);
            if (cardinalityRight != null)
                packet.CardinalityRight = cardinalityRight.ToString();
            sd.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));
            return packet;
        }

        internal static dynamic AddComponentLink(this StructureDefinition sd,
            String url,
            SDefEditor.Cardinality cardinalityLeft,
            SDefEditor.Cardinality cardinalityRight,
            String componentRef,
            String types,
            params String[] targets)
        {
            dynamic packet = new JObject();
            packet.LinkType = SVGGlobal.ComponentType;
            if (cardinalityLeft != null)
                packet.CardinalityLeft = cardinalityLeft.ToString();
            packet.LinkTarget = url;
            packet.ComponentHRef = componentRef;
            packet.Types = types;
            packet.References = new JArray(targets);
            if (cardinalityRight != null)
                packet.CardinalityRight = cardinalityRight.ToString();
            sd.AddExtension(Global.ResourceMapLinkUrl, new FhirString(packet.ToString()));
            return packet;
        }
    }
}