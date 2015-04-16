using System;
using Support;

namespace MetaExpr
{

	class Test
	{
	
		static void PrintExpr(string s, Expr e)
		{
			Console.WriteLine(s);			
			OpSize oo = e.Size;
			
			for(int i = 0; i < oo.rows; i++) {
				for(int j = 0; j < oo.cols; j++){
					Console.Write("{0} ", e.Eval(i,j));			
				}
				Console.WriteLine("");			
			}
		}
		
		static void MatrixTest()
		{
			Vector qq = new Vector(3);
			Vector qq2 = new Vector(3);			
			Matrix qx = new Matrix(3,3);
			
			// Initialize the Matrix
			for(int i = 0; i < 9; i++)
				qx.Data[i] = i;

			// Print Some SubMatrixes
			PrintExpr("Matrix qx", qx);
			PrintExpr("Diagonal...", qx.Diagonal());
			PrintExpr("Row 2...", qx[2][Matrix.All]);
			PrintExpr("Column 1...", qx[Matrix.All][1]);
			PrintExpr("Row 1-2...", qx[Matrix.Range(1,2)][Matrix.All]);
							
			PrintExpr("qq =", qq);
			(qq + qx[Matrix.All][1]).AssignTo(qq2)();
			PrintExpr("qq2 = qq + qx(:,2)", qq2);
			
			PrintExpr("qq =", qq);
			(qq + 22).AssignTo(qq2)();
			PrintExpr("qq2 <= qq+2 ", qq2);			
			(qq + 22).AssignTo(qx[Matrix.All][0])();			
			// qx[Matrix.All][1].Assign(1,0,(qq+22).Eval(1,0));
			PrintExpr("qx(:,1) <= qq+22, show qx", qx);						

		}

		
		static void Main()
		{
			// Initialization
			int n = 9;
			Vector w = new Vector(n);
			Vector x = new Vector(n);
			Vector y = new Vector(n);
			Vector z = new Vector(n);			
			Matrix q = Matrix.Identity(3);
			Vector qq = new Vector(3), qq2 = new Vector(3);			
			
			for(int i = 0; i < 3;i++)
				qq[i] = i+2;
				
			for(int i = 0; i < n; i++)
			{
				x[i] = i*0.33f;
				y[i] = 10.0f+i;
				z[i] = 100.0f*i;
			}

			//Compiler.SaveMode = true;
			
			// This is the Fastest way to use the MetaExpressions
			Console.WriteLine(y[2,3]);
			PrintExpr("w =", w);
			PrintExpr("x =", x);
			PrintExpr("y =", y);
			PrintExpr("z =", z);
			(x + y.MemMul( z + 2 )).AssignTo(w)();
			PrintExpr("w = x + y .* (z+2)", w);
			(q * ( qq + 7 )).AssignTo(qq2)();
			PrintExpr("qq2 =", qq2);
			PrintExpr("qq =", qq);
			(qq.Transpose() * qq).AssignTo(qq2)();			
			PrintExpr("qq2 = qq'*qq", qq2);
			
			// alternativly if you want to store an expression and iterate it ...
			// maybe changing some parameters
			Evaluator ed = (q * ( qq + 7 )).AssignTo(qq2);
			for(int i = 0; i < 3; i++)
			{
				qq[i] = i;
				ed();
				Console.WriteLine("Hello: " + qq2[i]);
			}			
				
			MatrixTest();
						
			Compiler.Save();						
		}

	}

}
