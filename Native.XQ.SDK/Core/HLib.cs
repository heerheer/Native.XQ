using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Core;

namespace Native.XQ.SDK.Core
{
    internal class HLib
    {
        private const string DLLName = "Plugin\\HLib.XQ.dll";

        private const string _HLib_SendMsgEx = "HLib_SendMsgEx";
        private delegate void D_Hlib_SendMsgEx(string robot, int type, string targetgroup, string targetqq, string content, int bubble, bool anyn);

        public static bool HLibExist()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + DLLName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SendMsgEx(string robot, int type, string targetgroup, string targetqq, string content, int bubble, bool anyn)
        {
            if (!HLibExist())
                return;
            var handle = Kernel32.LoadLibraryA(DLLName);
            var dhandle = Kernel32.GetProcAddress(handle, _HLib_SendMsgEx);
            if (dhandle.ToInt32() != 0)
            {
                D_Hlib_SendMsgEx deleg = (D_Hlib_SendMsgEx)Marshal.GetDelegateForFunctionPointer(dhandle,typeof(D_Hlib_SendMsgEx));
                deleg.Invoke(robot, type, targetgroup, targetqq, content, bubble, anyn);
                Kernel32.FreeLibrary(handle);
            }
        }


    }
}
