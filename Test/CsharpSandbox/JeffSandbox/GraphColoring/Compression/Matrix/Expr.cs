using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading;

namespace MetaExpr
{	
	// Binary Operator classes for the BinOpExpr
	public abstract class BinaryOp
	{
		public abstract float Apply(float a, float b);
		public abstract void Compile(ILGenerator g);
	}
	
	public class Plus : BinaryOp
	{
		public override float Apply(float a, float b)
		{
			return a+b;
		}

		public override void Compile(ILGenerator g)
		{
			g.Emit(OpCodes.Add);
		}						
	}

	public class Minus : BinaryOp
	{
		public override float Apply(float a, float b)
		{
			return a-b;
		}

		public override void Compile(ILGenerator g)
		{
			g.Emit(OpCodes.Sub);
		}
	}

	public class Times : BinaryOp
	{
		public override float Apply(float a, float b)
		{
			return a*b;
		}

		public override void Compile(ILGenerator g)
		{
			g.Emit(OpCodes.Mul);
		}
	}

	public class Div : BinaryOp
	{
		public override float Apply(float a, float b)
		{
			return a/b;
		}

		public override void Compile(ILGenerator g)
		{
			g.Emit(OpCodes.Div);
		}
	}
	

	// A literal expression specified as a floating point
	public class LiteralExpr : Expr
	{
		public LiteralExpr(float vv)
		{
			thevalue = vv;
		}

		// Compilation First Pass: none
		// Code Generation: push a float literal (partial evaluation)
		public override void Compile(ILGenerator g, CompilerContext cc)
		{
			if(cc.IsFirstPass()) return ;
			g.Emit(OpCodes.Ldc_R4, thevalue);
		}

		public override float Eval(int i, int j)
		{			
			return thevalue;
		}
		
		public override OpSize Size
		{
			get { return OpSize.Scalar; }
		}

		float thevalue;
	}

	public class UnOpExpr : Expr
	{
		public UnOpExpr(Expr ee)
		{
			e = ee;
		}
		
		public override float Eval(int i, int j)
		{
			return e.Eval(j,i);	
		}
		
		public override OpSize Size
		{
			get { return e.Size; }
		}
		
		public override void Compile(ILGenerator g, CompilerContext cc)
		{
			e.Compile(g, cc);
		}
		
		protected Expr e;
	}

	public abstract class BinaryOpExpr : Expr
	{
		public BinaryOpExpr(Expr e1, Expr e2)
		{
			expr1 = e1;
			expr2 = e2;			
		}
		
		protected Expr expr1, expr2;		
	}

	// A element by element binary operation
	public class BinaryMemOpExpr : BinaryOpExpr
	{
		public BinaryMemOpExpr(Expr e1, Expr e2, BinaryOp op) : base(e1,e2)
		{
			oper = op;
			OpSize o1 = expr1.Size;
			OpSize o2 = expr2.Size;
				
			if(o1 != o2 && (o1 != OpSize.Scalar && o2 != OpSize.Scalar))
				throw new SizeMismatchException("Binary Memberwise Mismatch");
			size = o1 == OpSize.Scalar ? o2: o1;
		}

		// Compilation First Pass: check sizes
		// Code Generation: the operator code
		public override void Compile(ILGenerator g, CompilerContext cc)
		{
			expr1.Compile(g,cc);
			expr2.Compile(g,cc);
			if(cc.IsFirstPass()) 
				return;			
			oper.Compile(g);
		}

		public override float Eval(int i, int j)
		{
			return oper.Apply(expr1.Eval(i, j), expr2.Eval(i, j));
		}

		
		public override OpSize Size
		{
			get { return size; }
		}
		
		BinaryOp oper;
		OpSize   size;
	}

	public class PowMemExpr : BinaryOpExpr
	{
		public PowMemExpr (Expr e1, Expr e2) : base(e1,e2)
		{
			
		}
		
		public override void Compile(ILGenerator g, CompilerContext cc)
		{
			if(cc.IsFirstPass())		
			{
				expr1.Compile(g, cc);
				expr2.Compile(g, cc);
				if(!(expr2.Size == OpSize.Scalar))
					throw new SizeMismatchException("Pow Operator requires a scalar second operand");
				return;				
			}
			expr1.Compile(g,cc);
			g.Emit(OpCodes.Conv_R8);
			expr2.Compile(g,cc);
			g.Emit(OpCodes.Conv_R8);
			g.EmitCall(OpCodes.Call, typeof(Math).GetMethod("Pow"), null);
			g.Emit(OpCodes.Conv_R4);							
		}			
		
		public override float Eval(int i, int j)
		{
			return (float)Math.Pow(expr1.Eval(i,j), expr2.Eval(i,j));
		}
		
		public override OpSize Size
		{
			get { return expr1.Size; }
		}
	}	

	public class FxExprOp : UnOpExpr
	{			
		public enum FxType { Cos, Sin, Ln, Log };
		
		public FxExprOp(Expr ee, FxType fx) : base(ee)
		{
			effx = fx;			
		}
		
		public override void Compile(ILGenerator g, CompilerContext cc)
		{
			if(cc.IsFirstPass())		
			{
				e.Compile(g, cc);
				return;				
			}
			MethodInfo mi = null;
			bool doublemeth = true;
			switch(effx)
			{
				case FxType.Cos: mi = typeof(Math).GetMethod("Cos"); break;
				case FxType.Sin: mi = typeof(Math).GetMethod("Sin"); break;
				case FxType.Ln: mi = typeof(Math).GetMethod("Log");  break;
				case FxType.Log: mi = typeof(Math).GetMethod("Log10");  break;
				default:
					break;					
			}
			if(mi == null) return;
			
			e.Compile(g,cc);
			if(doublemeth) 			
				g.Emit(OpCodes.Conv_R8);			
			g.EmitCall(OpCodes.Call, mi, null);
			if(doublemeth) 			
				g.Emit(OpCodes.Conv_R4);							
		}			
		
		public override float Eval(int i, int j)
		{
			float f = e.Eval(i,j);
			switch(effx)
			{
			case FxType.Cos: return (float)Math.Cos(f);
			case FxType.Sin: return (float)Math.Sin(f);
			case FxType.Ln: return (float)Math.Log(f);
			case FxType.Log: return (float)Math.Log10(f);
			default:
				return f;
			}			
		}
		
		public override OpSize Size
		{
			get { return e.Size; }
		}
		
		FxType effx;
	}	
	
	public class TransposeExpr : UnOpExpr
	{			
		public TransposeExpr(Expr e) : base(e)
		{
			
		}
		
		public override void Compile(ILGenerator g, CompilerContext cc)
		{
			if(cc.IsFirstPass())		
			{
				e.Compile(g, cc);
				return;				
			}
			
			// swap the indexes at the compiler level
			int i1 = cc.GetIndexVariable(0);
			int i2 = cc.GetIndexVariable(1);
			cc.SetIndexVariable(1, i1);
			cc.SetIndexVariable(0, i2);
			e.Compile(g,cc);
			cc.SetIndexVariable(0, i1);
			cc.SetIndexVariable(1, i2);
		}
		
		public override float Eval(int i, int j)
		{
			return e.Eval(j,i);	
		}
		
		public override OpSize Size
		{
			get {
				OpSize o = e.Size;
				return new OpSize(o.cols, o.rows);	
			}
		}
		
	}
	
	class MatrixMulOp : BinaryOpExpr
	{
		public MatrixMulOp(Expr e1, Expr e2) : base(e1,e2)
		{
			
		}
		
		// Compilation First Pass: check sizes
		// Code Generation: the operator code
		public override void Compile(ILGenerator g, CompilerContext cc)
		{
			if(cc.IsFirstPass()) {
				expr1.Compile(g,cc);
				expr2.Compile(g,cc);
				if(expr1.Size.cols != expr2.Size.rows)
					throw new SizeMismatchException("Matrix Multiplication Error");
				// allocate a new temporaneous variable
				myIndex = cc.AllocIndexVariable();
				return;
			}
			
			Label topLabel = g.DefineLabel();			
			int i1 = cc.GetIndexVariable(0);
			int i2 = cc.GetIndexVariable(1);
			int me = cc.GetIndexVariable(myIndex);
			// generate an inner loop with the variable k, we can use the stack
			/*
				double r = 0;	// the value is on the stack!
				k = 0;
				do {
					r += e1[i,k]*e2[k,j]
					k++;
				} while (k < e1.cols)
			*/
			g.Emit(OpCodes.Ldc_I4_0);	// k = 0
			g.Emit(OpCodes.Stloc, me);	

			g.Emit(OpCodes.Ldc_R4,0);
			g.MarkLabel(topLabel);								

			cc.SetIndexVariable(1, me);
			expr1.Compile(g,cc);
			cc.SetIndexVariable(0, me);
			cc.SetIndexVariable(1, i2);
			expr2.Compile(g,cc);
			cc.SetIndexVariable(0, i1);
			cc.SetIndexVariable(1, i2);
			g.Emit(OpCodes.Mul);
			g.Emit(OpCodes.Add);
			
			// increment k
			g.Emit(OpCodes.Ldloc, me);			// k =>
			g.Emit(OpCodes.Ldc_I4_1);			// 1
			g.Emit(OpCodes.Add);				// +
			g.Emit(OpCodes.Dup);
			g.Emit(OpCodes.Stloc, me);			// k <=
			
			// here from first jump
			g.Emit(OpCodes.Ldc_I4, expr1.Size.cols);	// k < cols
			g.Emit(OpCodes.Blt, topLabel);			
			
			// on the stack we have a value ...
		}

		public override float Eval(int i, int j)
		{
			int q = expr1.Size.cols;
			float r = 0;
			for(int k = 0; k < q; q++)
				r += expr1.Eval(i,k)*expr2.Eval(k,j);
			return r;
		}

		
		public override OpSize Size
		{
			get { return new OpSize(expr1.Size.rows, expr2.Size.cols); }
		}
				
		int myIndex;
	}


}

