using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;

namespace BreastRadiology.XUnitTests
{
    public static class CodingExtensions
    {
        public static CodeableConcept ToCodeableConcept(this Coding coding)
        {
            CodeableConcept retVal = new CodeableConcept(coding.System, coding.Code, coding.Display, coding.Display);
            return retVal;
        }
    }
}
