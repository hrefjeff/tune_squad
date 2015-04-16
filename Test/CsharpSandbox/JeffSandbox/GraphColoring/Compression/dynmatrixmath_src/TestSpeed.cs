using System;
using Support;
using System.Runtime.InteropServices;

namespace MetaExpr
{

	/// <summary>
	/// Summary description for Test
	/// </summary>
	class Test
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		///
		static void fx(float[] tw, float [] tx, float [] ty, float [] tz)
		{
			int n = tw.Length;
			for(int i = 0; i < n; i++)
			{
				tw[i] = tx[i]+ty[i]*tz[i]+2;
			}		
		}
		static void Main(string[] args)
		{
			int N = 1000;
			int n = 12345;
			Vector w = new Vector(n);
			Vector x = new Vector(n);
			Vector y = new Vector(n);
			Vector z = new Vector(n);

			for(int i = 0; i < n; i++)
			{
				x[i] = i*0.33f;
				y[i] = 10.0f+i;
				z[i] = 100.0f*i;
			}

			Timing.Go(); 
			Timing.Stop("Test Null Delay (to check GetTickCount)");
			
			Timing.Go(); 
				((Expr)2).AssignTo(w);
			Timing.Stop("Test First Expr Creation (initializes the Dynamic Assembly)");

			// testing ...
			Expr e = x+y.MemMul(z)+2;
			Evaluator ev = e.AssignTo(w);
			Timing.Go();
				ev();
			Timing.Stop("My Compiled Expr - One Time (to check compilation time)");

			Timing.Go();
				for(int j = 0; j < N; j++)
					ev();
			Timing.Stop("My Compiled Expr - N Times");

			Timing.Go();
				for(int j = 0; j < N; j++)
					fx(w.Data,x.Data,y.Data,z.Data);				
			Timing.Stop("Native Code N times");
			
			Timing.Go();
				for(int j = 0; j < N; j++)
					e.Eval(0,j);
			Timing.Stop("Tree based Evaluation (quite long)");
		}		
	}


}
