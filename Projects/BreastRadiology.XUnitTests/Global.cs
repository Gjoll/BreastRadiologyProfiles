﻿using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    class Global
    {
        public const String BaseFragmentUrl = "http://www.fragment.com/";
        public static String FragmentUrl = $"{BaseFragmentUrl}fragment";
        public static String IsFragmentExtensionUrl = $"{BaseFragmentUrl}isFragment";
        public static String IncompatibleFragmentUrl = $"{BaseFragmentUrl}incompatibleFragment";
        public static String GroupExtensionUrl = $"{BaseFragmentUrl}Group";

        public static String ResourceMapNameUrl = $"{BaseFragmentUrl}mapname";
        public static String ResourceMapLinkUrl = $"{BaseFragmentUrl}maplink";

        public static String ElementAnchor(String elementName)
        {
            return $"StructureDefinition-" + "{SDName}" + $"-definitions.html#Observation.{elementName}";
        }

        public static String ComponentAnchor(String sliceName)
        {
            return $"StructureDefinition-" + "{SDName}" + "-definitions.html#Observation.component:" + sliceName;
        }
    }
}
