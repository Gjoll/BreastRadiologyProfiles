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

    public abstract class BaseBase<T> : IBaseBase
        where T : Base, new()
    {
        public abstract String Id { get; set; }

        protected T resource;

        public BaseBase(T resource)
        {
            this.resource = resource;
        }

        public BaseBase()
        {
            this.resource = new T();
        }
    }
}
