using FhirKhit.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireFragger
{
    public class CodeBlockMerger
    {
        CodeEditor code;
        public CodeBlockMerger(CodeEditor code)
        {
            this.code = code;
        }

        public void Merge(CodeEditor mergeCode)
        {
            foreach (CodeBlock mergeBlock in mergeCode.Blocks.Children)
            {
                CodeBlockNested mergeBlockNested = mergeBlock as CodeBlockNested;
                if (mergeBlockNested == null)
                    throw new Exception($"Base merge block must be of type MergeBlockNested");

                CodeBlockNested codeBlockNested = this.code.Blocks.Find(mergeBlockNested.Name);
                if (codeBlockNested == null)
                    throw new Exception($"Base code editor does not contain a top level block named {mergeBlockNested.Name}");
                Merge(codeBlockNested, mergeBlockNested);
            }
        }

        void Merge(CodeBlockNested codeBlock, CodeBlockNested mergeBlock)
        {
            foreach (CodeBlock mergeBlockChild in code.Blocks.Children)
            {
                switch (mergeBlockChild)
                {
                    case CodeBlockText mergeBlockChildText:
                        codeBlock.AppendBlock(mergeBlockChild);
                        break;

                    case CodeBlockNested mergeBlockChildNested:
                        CodeBlockNested codeBlockChildNested = codeBlock.Find(mergeBlockChildNested.Name);
                        if (codeBlockChildNested == null)
                            codeBlock.AppendBlock(mergeBlockChild);
                        else
                            Merge(codeBlockChildNested, mergeBlockChildNested);
                        break;
                }
            }
        }
    }
}
