using System;
using System.Runtime.InteropServices;

namespace Support
{
	public class Timing
	{
		[ DllImport( "Kernel32.dll" )]
		private static extern int GetTickCount( );

		public static void Go()
		{
			start = GetTickCount();//DateTime.Now.Ticks;
		}

		public static void Stop(string n)
		{
			int stop = GetTickCount();//DateTime.Now.Ticks;
			Console.Out.WriteLine(n + " " + (stop-start));
		}
	
		static int start;

	}

	
}