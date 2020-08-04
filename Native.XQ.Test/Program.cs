using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Native.XQ.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SubstringSingle("Heershisb","Heer","sb"));
           // MsgSender.Api_SendGroupMsg("_me_", "_666666_", "_17674_");
            Console.ReadKey();
        }
        public static string SubstringSingle(string source, string startStr, string endStr)
        {
            Regex rg = new Regex("(?<=(" + startStr + "))[.\\s\\S]*?(?=(" + endStr + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(source).Value;
        }
    }

    public class MsgSender
    {
        [DllImport("msgsender.dll", EntryPoint = "Api_SendGroupMsg")]
        public static extern void Api_SendGroupMsg(string a, string b, string c);
    }
}
