using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    /// <summary>
    /// Class that created an item and lazy loads it into
    /// saved var for future use.
    /// </summary>
    class TaskVar<T>
    {
        T value;
        readonly Func<T> entry;

        public T Value()
        {
            if (value == null)
                this.value = entry();
            return value;
        }
        public TaskVar(Func<T> entry)
        {
            this.entry = entry;
        }
    }
    class VSTaskVar : TaskVar<ValueSet>
    {
        public VSTaskVar(Func<ValueSet> entry) : base(entry)
        {
        }
    }

    class CSTaskVar : TaskVar<CodeSystem>
    {
        public CSTaskVar(Func<CodeSystem> entry) : base(entry)
        {
        }
    }

    /// <summary>
    /// Class that created a code system asynchronously, and lazy loads it into
    /// saved var for future use.
    /// </summary>
    class StringTaskVar
    {
        public delegate void CreateDel(out String value);
        String value;
        readonly CreateDel entry;

        public String Value()
        {
            if (this.value == null)
                entry(out this.value);
            return this.value;
        }

        public StringTaskVar(CreateDel entry)
        {
            this.entry = entry;
        }
    }
}
