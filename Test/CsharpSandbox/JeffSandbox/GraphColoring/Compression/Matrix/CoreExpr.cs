using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading;

namespace MetaExpr
{
	// Matrix Operation Size
	public struct OpSize
	{
		public OpSize(int i, int j)
		{
			rows = i;
			cols = j;	
		}
				
		public int rows;
		public int cols;
		
		public static OpSize Scalar = new OpSize(1,1);

		public override bool Equals(object o)
		{
			if(o is OpSize) return ((OpSize)o) == this;
			return false;	
		}
		
		public static bool operator != (OpSize o1, OpSize o2)
		{
			return o1.rows != o2.rows || o1.cols != o2.cols;
		}
		
		public static bool operator == (OpSize o1, OpSize o2)
		{
			return o1.rows == o2.rows && o1.cols == o2.cols;
		}
		
		public override int GetHashCode() 
		{
			return rows*cols;	
		}		
		
		public override string ToString()
		{
			return "" + rows + " " + cols;
		}
	}
	
	public class SizeMismatchException : Exception
	{
		public SizeMismatchException (string s) : base(s)
		{
			
		}
	}

	/// <summary>
	/// Summary description for Expr.
	/// </summary>
	public abstract class Expr
	{
		
		// abstract methods
		public abstract float Eval(int i, int j);
		public abstract void Compile(ILGenerator g, CompilerContext cc);
		public virtual OpSize Size 
		{ 
			get { 
				return new OpSize(0,0); 
			}
		}
		
		// member by member addition
		public static Expr operator + (Expr e1, Expr e2)
		{
			return new BinaryMemOpExpr(e1, e2, new Plus());
		}

		// member by member subtraction
		public static Expr operator - (Expr e1, Expr e2)
		{
			return new BinaryMemOpExpr(e1, e2, new Minus());
		}

		// member by member multiplication
		public Expr MemMul (Expr e2)
		{
			return new BinaryMemOpExpr(this, e2, new Times());
		}

		// member by member exponentiation, e2 is always a literal
		public Expr Pow (Expr e2)
		{
			return new PowMemExpr(this, e2);
		}

		public static Expr MemPow (Expr e1, Expr e2)
		{
			return new PowMemExpr(e1, e2);
		}
			
		// member by member division
		public static Expr operator / (Expr e1, Expr e2)
		{
			return new BinaryMemOpExpr(e1, e2, new Div());
		}
		
		public Evaluator AssignTo(LeftExpr m)
		{					
			MatrixEvaluator evaluator = Compiler.Compile(new MatrixAssignExpr(m, this));
			return new Evaluator(evaluator.Eval);
		}
		
		public Evaluator AssignTo(out Matrix mtx)
		{					
			OpSize s = Size;
			mtx = new Matrix(s.rows, s.cols);
			MatrixEvaluator evaluator = Compiler.Compile(new MatrixAssignExpr(mtx, this));
			return new Evaluator(evaluator.Eval);
		}
		
		public Expr Transpose()
		{
			return new TransposeExpr(this);
		}

		// multiplication
		public static Expr operator * (Expr e1, Expr e2)
		{
			return new MatrixMulOp(e1, e2);
		}
		
		// cast from float
		public static implicit operator Expr(float f)
		{
			return new LiteralExpr(f);
		}
		
		public static Expr Cos(Expr e)
		{
			return new FxExprOp(e, FxExprOp.FxType.Cos);
		}

		public static Expr Sin(Expr e)
		{
			return new FxExprOp(e, FxExprOp.FxType.Sin);
		}

		public static Expr Log(Expr e)
		{
			return new FxExprOp(e, FxExprOp.FxType.Log);
		}		
	}
		
}