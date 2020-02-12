using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IBaseBase
    {
        /// <summary>
        /// Fhir instance id.
        /// </summary>
        String Id { get; set; }
    }

    public abstract class BaseBase : IBaseBase
    {
        public abstract String Id { get; set; }

        protected Base resource;

        public BaseBase()
        {
        }

        public abstract void SetResource(Base r);

        public BaseBase(Base resource)
        {
            this.resource = resource;
        }
    }
}
