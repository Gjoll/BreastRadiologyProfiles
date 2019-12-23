using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    /// <summary>
    /// Class that created a code system asynchronously, and lazy loads it into
    /// saved var for future use.
    /// </summary>
    class TaskVar<T>
    {
        T value;
        readonly Func<System.Threading.Tasks.Task<T>> entry;

        public async System.Threading.Tasks.Task<T> Value()
        {
            if (value == null)
                this.value = await System.Threading.Tasks.Task<T>.Run(entry);
            return value;

        }
        public TaskVar(Func<System.Threading.Tasks.Task<T>> entry)
        {
            this.entry = entry;
        }
    }
    class CSTaskVar : TaskVar<CodeSystem>
    {
        public CSTaskVar(Func<System.Threading.Tasks.Task<CodeSystem>> entry) : base(entry)
        {
        }
    }
}
