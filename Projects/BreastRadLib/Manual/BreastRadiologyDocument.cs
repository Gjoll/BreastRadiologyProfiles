using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib.Manual
{
    /// <summary>
    /// This is the base of the Breast Radiology Report
    /// It Implements a Fhir Document, which is a special type of bundle,
    /// and provides access to the index of that document, which is the
    /// Composition instance.
    /// </summary>
    public class BreastRadiologyDocument
    {
        /// <summary>
        /// Contains the Fhir Bundle, and a dictionary of each of the items in the
        /// bundle to allow quick access of each item.
        /// </summary>
        ResourceBag resourceBag;
        
        /// <summary>
        /// Fhir documents main composition item. This is the 'index' of the
        /// fhir document, and must be the first item in the bundle.
        /// </summary>
        CompositionBase compositionBase;

        /// <summary>
        /// Private constructor. Use the static helper methods.
        /// </summary>
        private BreastRadiologyDocument()
        {
        }

        /// <summary>
        /// Create a new BreastRadiologyDocument.
        /// </summary>
        /// <returns></returns>
        public static BreastRadiologyDocument Create()
        {
            BreastRadiologyDocument retVal = new BreastRadiologyDocument();
            retVal.compositionBase = new CompositionBase(new Composition());
            retVal.resourceBag.AddResource(retVal.compositionBase.Resource);
            return retVal;
        }

    }
}
