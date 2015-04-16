// Assignment Classes
using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading;

namespace MetaExpr
{	

	// It's a submatrix: given a matrix this takes:
	//		(i,j) offset of first
	//		column stride
	//		row stride
	//		width and height
	//
	// This let you define sub ranges of rows and columns
	public class SubMatrix : LeftExpr
	{		
		// start = number of elements to skip
		// n = rows
		// m = cols
		// cstride = distance (in elements) between subsequent columns in a row 
		// rstride = distance (in elements) between subsequent rows 
		public SubMatrix(float [] d, int s, int n, int m, int cs, int rs)
		{
			data = d;
			cols = m;
			rows = n;
			start   = s;
			cstride = cs+1;					// save the distance to write columnIndex * cstride
			rowlength = rs+cols*cstride;	// save the distance to write rowIndex * rowlength
			
			// size check: start offset
			//	+ length of the rows 
			//  + length of last row
			if(start + rowlength*(rows-1)+ cstride*(cols-1) >= d.Length)
				throw new SizeMismatchException("SubMatrix");
		}

		public float this[int idx, int idx2]
		{
			get { return data[start+idx*rowlength+idx2*cstride]; }
			set { data[start+idx*rowlength+idx2*cstride] = value; }
		}

		public override void Assign(int i,  int j, float v)
		{
			this[i,j] = v;	
		}
		
		public override void CompileAssign(ILGenerator g, CompilerContext cc, bool post)
		{
			if(cc.IsFirstPass())
			{				
				cc.Add(data);						
				return;		
			}
									
			int i1 = cc.GetIndexVariable(0);
			int i2 = cc.GetIndexVariable(1);
				
			if(!post)
			{
				CompilerContext.GenLocalLoad(g, cc.GetIndexOf(data));		// x
				if(start != 0)
					g.Emit(OpCodes.Ldc_I4, start);					
				if(rows > 1 && cols > 1)
				{
					g.Emit(OpCodes.Ldloc, i1);
					g.Emit(OpCodes.Ldc_I4, rowlength);
					g.Emit(OpCodes.Mul);
					g.Emit(OpCodes.Add);
					g.Emit(OpCodes.Ldloc, i2);
					g.Emit(OpCodes.Ldc_I4, cstride);
					g.Emit(OpCodes.Mul);
				}	
				else if(rows == 1)
				{
					g.Emit(OpCodes.Ldloc, i2);
					if(cstride != 1) {
						g.Emit(OpCodes.Ldc_I4, cstride);
						g.Emit(OpCodes.Mul);
					}
				}							
				else if(cols == 1)
				{
					Console.WriteLine("here {0}", rowlength);
					g.Emit(OpCodes.Ldloc, i1);
					if(rowlength != 1) {
						g.Emit(OpCodes.Ldc_I4, rowlength);
						g.Emit(OpCodes.Mul);
					}
				}
				if(start != 0)
					g.Emit(OpCodes.Add);					
			}
			else
			{
				g.Emit(OpCodes.Stelem_R4);
			}
			
		}
		
		// Compilation First Pass: add a reference to the array variable
		// Code Generation: access the element through the i index
		public override void Compile(ILGenerator g, CompilerContext cc)
		{			
			if(cc.IsFirstPass()) 
			{
				cc.Add(data);
			}
			else 
			{
				CompilerContext.GenLocalLoad(g, cc.GetIndexOf(data));        	// x
				int i1 = cc.GetIndexVariable(0);
				int i2 = cc.GetIndexVariable(1);
				
				// a vector
				g.Emit(OpCodes.Ldc_I4, start);
				if(rows == 1) 
				{					
					g.Emit(OpCodes.Ldloc, i2);
					g.Emit(OpCodes.Ldc_I4, cstride);
					g.Emit(OpCodes.Mul);					
				}				
				else if(cols == 1)
				{
					g.Emit(OpCodes.Ldloc, i1);
					g.Emit(OpCodes.Ldc_I4, rowlength);
					g.Emit(OpCodes.Mul);					
				}
				// a matrix
				else
				{
					g.Emit(OpCodes.Ldloc, i1);
					g.Emit(OpCodes.Ldc_I4, rowlength);
					g.Emit(OpCodes.Mul);
					g.Emit(OpCodes.Add);
					g.Emit(OpCodes.Ldloc, i2);
					g.Emit(OpCodes.Ldc_I4, cstride);
					g.Emit(OpCodes.Mul);
				}				
				g.Emit(OpCodes.Add);					
				g.Emit(OpCodes.Ldelem_R4);					
			}		
		}

		public override OpSize Size
		{
			get { return new OpSize(rows, cols); }
		}
					
		public override float Eval(int i, int j)
		{
			return this[i,j];
		}
		
		public float [] Data
		{
			get { return data; }
		}
				

		protected float [] data;
		protected int cols, rows;				
		protected int cstride;
		protected int start;
		protected int rowlength;
	}
	
}