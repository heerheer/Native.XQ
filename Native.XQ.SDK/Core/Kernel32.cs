using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Native.XQ.Sdk.Core
{
	public class Kernel32
	{
		[DllImport ("kernel32.dll", EntryPoint = "lstrlenA", CharSet = CharSet.Ansi)]
		public extern static int LstrlenA (IntPtr ptr);

		[DllImport("kernel32.dll")]
		public extern static IntPtr LoadLibraryA(string path);

		[DllImport("kernel32.dll")]
		public extern static IntPtr GetProcAddress(IntPtr lib, string funcName);

		[DllImport("kernel32.dll")]
		public extern static bool FreeLibrary(IntPtr lib);

		[DllImport("Library.dll")]
		public static extern void InfiniteLoop();

		[DllImport("kernel32")]
		public static extern int CreateThread(
		   IntPtr lpThreadAttributes,
		   UInt32 dwStackSize,
		   IntPtr lpStartAddress,
		   IntPtr param,
		   UInt32 dwCreationFlags,
		   UInt32 lpThreadId
		 );

		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
		public static extern int TerminateThread(int hThread);

		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
		public static extern int GetLastError();
	}
}
