using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    class Global
    {
        public const String FragmentUrl = "http://www.fragment.com/";
        public static String IsFragmentExtensionUrl = $"{FragmentUrl}isFragment";
        public static String GroupExtensionUrl = $"{FragmentUrl}Group";

        public static String ResourceMapNameUrl = $"{FragmentUrl}mapname";
        public static String ResourceMapLinkUrl = $"{FragmentUrl}maplink";
    }
}
