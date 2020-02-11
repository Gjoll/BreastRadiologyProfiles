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
            bool AllBlank(String[] lines)
            {
                foreach (String line in lines)
                {
                    if (line.Trim().Length > 0)
                        return false;
                }
                return true;
            }

            void ProcessBlock(CodeBlock mergeBlock)
            {
                CodeBlockNested mergeBlockNested = mergeBlock as CodeBlockNested;
                if (mergeBlockNested == null)
                {
                    if (AllBlank(mergeBlock.AllLines()) == false)
                        throw new Exception($"Base merge block must be of type MergeBlockNested");
                    return;
                }

                CodeBlockNested codeBlockNested = this.code.Blocks.Find(mergeBlockNested.Name);
                if (codeBlockNested == null)
                    throw new Exception($"Base code editor does not contain a top level block named {mergeBlockNested.Name}");
                Merge(codeBlockNested, mergeBlockNested);
            }

            foreach (CodeBlock mergeBlock in mergeCode.Blocks.AllNamedBlocks)
                ProcessBlock(mergeBlock);
        }

        void Merge(CodeBlockNested codeBlock, CodeBlockNested mergeBlock)
        {
            foreach (CodeBlock mergeBlockChild in mergeBlock.Children)
            {
                switch (mergeBlockChild)
                {
                    case CodeBlockText mergeBlockChildText:
                        foreach (String line in mergeBlockChild.AllLines())
                            codeBlock.AppendLine(line, "");
                        break;

                    case CodeBlockNested mergeBlockChildNested:
                        CodeBlockNested codeBlockChildNested = codeBlock.Find(mergeBlockChildNested.Name);
                        if (codeBlockChildNested == null)
                            codeBlockChildNested = codeBlock.AppendBlock(mergeBlockChildNested.Name);
                        Merge(codeBlockChildNested, mergeBlockChildNested);
                        break;
                }
            }
        }
    }
}
