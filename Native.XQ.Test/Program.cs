using System;
using System.Runtime.InteropServices;

namespace Native.XQ.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MsgSender.Api_SendGroupMsg("_me_", "_666666_", "_17674_");
            Console.ReadKey();
        }
    }

    public class MsgSender
    {
        [DllImport("msgsender.dll", EntryPoint = "Api_SendGroupMsg")]
        public static extern void Api_SendGroupMsg(string a, string b, string c);
    }
}
