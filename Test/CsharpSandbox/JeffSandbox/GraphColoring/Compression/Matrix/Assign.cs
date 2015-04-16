// Assignment Classes
using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading;

namespace MetaExpr
{	
	
	/// <summary>
	/// Incapsulates the LValues, an assignable matrix like Matrix or SubMatrix
	/// <summary>
	public abstract class LeftExpr : Expr
	{
		public abstract void Assign(int i,  int j, float v);
		public abstract void CompileAssign(ILGenerator g, CompilerContext cc, bool post);
	}
	

	// Assignment -> generates evaluates the loops
	class MatrixAssignExpr : Expr
	{
		internal MatrixAssignExpr(LeftExpr m, Expr e)
		{
			lexpr = m;			
			expr = e;
			size = expr.Size;
			OpSize ms = m.Size;
			if(ms.rows < size.rows && ms.cols < size.cols)
				throw new SizeMismatchException("Matrix Assignment");			
		}

		public override void Compile(ILGenerator g, CompilerContext cc)
		{
			bool biloop = size.rows > 1 && size.cols > 1;
			
			if(cc.IsFirstPass()) 
			{
				iI = cc.AllocIndexVariable();	// i
				iJ = cc.AllocIndexVariable();	// j				
				expr.Compile(g, cc);								
				lexpr.CompileAssign(g,cc, true);
			}
			else
			{
				int i1,i2,svi1,svi2;
				Label topLabel; 
				Label topLabelE;

				topLabel = g.DefineLabel();				
				topLabelE = g.DefineLabel();				
				
				i1 = cc.GetIndexVariable(iI);
				i2 = cc.GetIndexVariable(iJ);							
			
				// then
				svi1 = cc.GetIndexVariable(0);
				svi2 = cc.GetIndexVariable(1);
				cc.SetIndexVariable(0, i1);
				cc.SetIndexVariable(1, i2);
					
				// we have four cases: 
				//    full matrix (two loops)
				//	  scalar
				//    row vector & column vector (a loop with 0 instead of 1 varying)		
				
				/* 
					i = 0
					TP_E: do {
						j = 0
						TP: do {
							APPLY
							j++
						} while(j < cols)
				     	i++;
				 	} while(i < rows);				 
				 */				
				g.Emit(OpCodes.Ldc_I4_0);	// i = 0
				g.Emit(OpCodes.Stloc, i1);	
				g.Emit(OpCodes.Ldc_I4_0);		// j = 0
				g.Emit(OpCodes.Stloc, i2);
				
				if(biloop)
				{
					// generate head part of exterior loop					
					
					g.MarkLabel(topLabelE);
					g.Emit(OpCodes.Ldc_I4_0);		// j = 0
					g.Emit(OpCodes.Stloc, i2);
					g.MarkLabel(topLabel);			// TP:
								
					lexpr.CompileAssign(g, cc, false);	
					expr.Compile(g, cc);						// value
					lexpr.CompileAssign(g, cc, true);						
			
					// increment j
					g.Emit(OpCodes.Ldloc, i2);			// 1
					g.Emit(OpCodes.Ldc_I4_1);			// j =>	
					g.Emit(OpCodes.Add);				// +
					g.Emit(OpCodes.Dup);
					g.Emit(OpCodes.Stloc, i2);			// j <=
	
					// here from first jump
					g.Emit(OpCodes.Ldc_I4, size.cols);	// j < cols
					g.Emit(OpCodes.Blt, topLabel);
				
					// increment i
					g.Emit(OpCodes.Ldloc, i1);			// i =>
					g.Emit(OpCodes.Ldc_I4_1);			// 1 	
					g.Emit(OpCodes.Add);				// +
					g.Emit(OpCodes.Dup);
					g.Emit(OpCodes.Stloc, i2);			// i <=
	
					// here from first jump
					g.Emit(OpCodes.Ldc_I4, size.rows);	// i < rows
					g.Emit(OpCodes.Blt, topLabelE);					
				}
				else if(size.rows > 1 || size.cols > 1)
				{
					// iterate rows, so move
					int index;
					int count;					
					if(size.rows > 1)
					{
						index = i1;
						count = size.rows;
					}
					else
					{
						index = i2;
						count = size.cols;	
					}										
					
					// just one loop. Set wich 
					g.MarkLabel(topLabel);			// TP:
					
					lexpr.CompileAssign(g, cc, false);	
					expr.Compile(g, cc);						// value
					lexpr.CompileAssign(g, cc, true);						
								
					// increment j
					g.Emit(OpCodes.Ldloc, index);			// 1
					g.Emit(OpCodes.Ldc_I4_1);				// j =>	
					g.Emit(OpCodes.Add);					// +
					g.Emit(OpCodes.Dup);
					g.Emit(OpCodes.Stloc, index);			// j <=									
	
					// here from first jump
					g.Emit(OpCodes.Ldc_I4, count);	// j < cols
					g.Emit(OpCodes.Blt, topLabel);
				}
				else
				{
					// scalar!
					lexpr.CompileAssign(g, cc, false);	
					expr.Compile(g, cc);						// value
					lexpr.CompileAssign(g, cc, true);	
				}
				cc.SetIndexVariable(0, svi1);
				cc.SetIndexVariable(1, svi2);
			}
			
		}
		
		public override float Eval(int i, int j)
		{
			size = expr.Size;
			for(int q = 0; q < size.rows; q++)
			{
				for(int k = 0; k < size.cols; k++)
					lexpr.Assign(q, k, expr.Eval(q,k));
			}
			return 0;
		}
	
		int iI,iJ;
		Expr expr;
		LeftExpr lexpr;
		OpSize  size;
	}
	
}