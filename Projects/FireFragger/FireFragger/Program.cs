using System;
using System.Drawing;

namespace FireFragger
{
    class Program
    {
        string filter = "*.json";
        CSBuilder csBuilder = new CSBuilder();

        void Usage()
        {
            Console.WriteLine("usage: [-frag 'fragdir']");
            throw new Exception("Usage error");
        }

        String GetArg(String arg,
            String[] args,
            ref Int32 i)
        {
            if (i >= args.Length)
                Usage();
            String retVal = args[i];
            if (retVal[0] == '"')
                retVal = retVal.Substring(1);
            if (retVal[retVal.Length - 1] == '"')
                retVal = retVal.Substring(0, retVal.Length - 1);
            i += 1;
            return retVal;
        }

        void ParseArgs(string[] args)
        {
            Int32 i = 0;
            while (i < args.Length)
            {
                String arg = args[i++];
                switch (arg.Trim().ToLower())
                {
                    case "-frags":
                        {
                            String dir = GetArg(arg, args, ref i);
                            csBuilder.AddFragmentDir(dir, filter);
                        }
                        break;

                    case "-c":
                        csBuilder.CleanFlag = true;
                        break;

                    case "-out":
                        csBuilder.OutputDir = GetArg(arg, args, ref i);
                        break;

                    default:
                        throw new Exception($"Unknown command line argument {arg}");
                }
            }
        }

        void Run()
        {
            this.csBuilder.Build();
        }

        private void Message(ConsoleColor color,
            string className,
            string method,
            string msg)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{className}.{method}: {msg}");
        }

        private bool StatusWarnings(string className, string method, string msg)
        {
            this.Message(ConsoleColor.Yellow, className, method, msg);
            return true;
        }
        private bool StatusInfo(string className, string method, string msg)
        {
            this.Message(ConsoleColor.White, className, method, msg);
            return true;
        }
        private bool StatusErrors(string className, string method, string msg)
        {
            this.Message(ConsoleColor.Red, className, method, msg);
            return true;
        }

        static void Main(string[] args)
        {
            try
            {
                Program p = new Program();
                p.ParseArgs(args);
                p.Run();
            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(err.Message);
            }
        }
    }
}
