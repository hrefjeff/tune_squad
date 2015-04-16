// Assignment Classes
using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading;

namespace MetaExpr
{
	/// <summary>
	/// A Matrix Class
	/// <summary>
	public class Matrix : LeftExpr
	{		
				
		/// create the Matrix from an existing array
		public Matrix(float [] dataArray, int numberOfColumns)
		{
			data = dataArray;
			columns = numberOfColumns;
			rows = Data.Length / Columns;
		}

		/// create a NxM Matrix
		public Matrix(int numberOfRows, int numberOfColumns)
		{
			rows = numberOfRows;
			columns = numberOfColumns;
			data = new float[Rows*Columns];						
		}


		/// LeftExpr assignment
		public override void Assign(int i,  int j, float v)
		{
			this[i,j] = v;	
		}

        public void printMatrix()
        {
            for (int i = 0; i < this.rows; i++)
            {
                Console.WriteLine("Row " + i + ": ");
                for (int j = 0; j < this.columns; j++)
                {
                    //"Matrix(" + i + "," + j + ") = " + 
                    Console.Write(this[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
		
		/// LeftExpr compilation
		/// Post is used on the second pass to handle the AfterValue handling,
		/// we assume that on the stack there is the assigned value
		public override void CompileAssign(ILGenerator g, CompilerContext cc, bool post)		
		{			
			/// on the first pass add a reference parameter to the data array
			if(cc.IsFirstPass())
			{				
				cc.Add(Data);						
				return;		
			}
						
			int i1 = cc.GetIndexVariable(0);
			int i2 = cc.GetIndexVariable(1);						
			
			if(!post)			
			{
				CompilerContext.GenLocalLoad(g, cc.GetIndexOf(data));		// x
				if(Rows > 1 && Columns > 1)
				{
					g.Emit(OpCodes.Ldloc, i1);
					if(Columns > 1)
					{
						g.Emit(OpCodes.Ldc_I4, Columns);
						g.Emit(OpCodes.Mul);
					}
					g.Emit(OpCodes.Ldloc, i2);
					g.Emit(OpCodes.Add);
				}	
				else 
				{
					g.Emit(OpCodes.Ldloc, (Rows == 1) ? i2 : i1);
				}							
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
				// a vector
				if(Rows == 1) 
				{
					g.Emit(OpCodes.Ldloc, cc.GetIndexVariable(1));	// colIndex					
				}
				else if(Columns == 1)
				{
					g.Emit(OpCodes.Ldloc, cc.GetIndexVariable(0));	// colIndex					
				}
				// a matrix
				else
				{
					g.Emit(OpCodes.Ldloc, cc.GetIndexVariable(0));	// rowIndex
					if(Columns > 1)
					{					
						g.Emit(OpCodes.Ldc_I4, Columns);
						g.Emit(OpCodes.Mul);
					}
					g.Emit(OpCodes.Ldloc, cc.GetIndexVariable(1));	// colIndex
					g.Emit(OpCodes.Add);										
				}	
				g.Emit(OpCodes.Ldelem_R4);						// 					
			}		
		}

		/// Expr evaluation
		public override float Eval(int i, int j)
		{
			return this[i,j];
		}

		/// Expr size determination		
		public override OpSize Size
		{
			get { return new OpSize(Rows, Columns); }
		}
				
		/// Identity matrix constructor		
		public static Matrix Identity(int matrixSize)
		{
			Matrix m = new Matrix(matrixSize,matrixSize);
			for(int i = 0; i < matrixSize; i++)
				m[i,i] = 1;
			return m;					
		}
			
		public float [] Data
		{
			get { return data; }
		}
		
		public int Columns
		{
			get { return columns; }	
		}

		public int Rows
		{
			get { return rows; }	
		}
		
		public SubMatrix GetRange(int r1, int r2, int c1, int c2)
		{
			// check arguments
			if(r1 > r2) { int q = r1; r1 = r2; r2 = q;	}
			if(c1 > c2) { int q = c1; c1 = c2; c2 = q;	}
			int nr = r2-r1+1;
			int nc = c2-c1+1;
			return new SubMatrix(Data, r1*Columns+c1, nr, nc, 0, Columns-nc);
		}
		
		public SubMatrix GetColumn(int j)
		{
			return GetRange(0, Rows-1, j, j);
		}
		
		public SubMatrix GetColumns(int j1, int j2)
		{
			return GetRange(0, Rows-1, j1, j2);
		}

		public SubMatrix GetRow(int i)
		{
			return GetRange(i, i, 0, Columns-1);			
		}
				
		public SubMatrix GetRows(int i1, int i2)
		{
			return GetRange(i1, i2, 0, Columns-1);			
		}
		
		/// get elements numbered considering the matrix as rows
		/// and get a row
		public SubMatrix GetElements(int e1, int e2)
		{			
			return new SubMatrix(Data, e1, 1, e2-e1+1, 0, 0);
		}
		
		// return the diagonal vector a column (if the matrix is rectangular
		// the result is the minimal diagonal)
		public SubMatrix Diagonal()
		{
			int q = columns < rows ? columns : rows;
			return new SubMatrix(Data, 0, q, 1, 0, Columns);
		}
		
		/// classic data accessor ...
		public float this[int idx, int idx2]
		{
			get { return data[idx*Columns+idx2]; }
			set { data[idx*Columns+idx2] = value; }
		}

		/// all row accessor to get one or more columns
		/// m[Matrix.All][3]		
		/// m[Matrix.All][Matrix.Range(1,2)]
		public MatrixRowRef this[AllPlaceHolder x]
		{
			get { return new MatrixRowRef(this, 0, Rows-1); }			
		}

		/// gets row r		
		public MatrixRowRef this[int r]
		{
			get { return new MatrixRowRef(this, r, r); }			
		}

		/// gets a range of rows
		public MatrixRowRef this[IndexRange q]
		{
			get { return new MatrixRowRef(this, q.first, q.last); }			
		}
		
		/// PlaceHolder class useful to write
		/// Matrix m;
		/// m[Matrix.All][2]
		public struct AllPlaceHolder 
		{			
		}
		
		/// IndexRange class useful to specify submatrix ranges
		/// m[Matrix.Range(5,2)]
		public struct IndexRange
		{
			internal IndexRange(int i1, int i2)
			{
				first = i1;
				last = i2;
			}	
			
			internal int first, last;
		}

		public static IndexRange Range(int i1, int i2)
		{
			return new IndexRange(i1,i2);
		}
		
		public struct MatrixRowRef
		{
			internal MatrixRowRef(Matrix m, int r1, int r2)
			{
				firstRow = r1;
				lastRow = r2;
				mtx = m;
			}

			/// gets all the rows in the firstRow-lastRow range
			public SubMatrix this[AllPlaceHolder x]
			{
				get { return mtx.GetRows(firstRow, lastRow); }			
			}
	
			/// gets a sub range
			public SubMatrix this[int r]
			{
				get { return mtx.GetRange(firstRow, lastRow, r, r); }			
			}
	
			/// gets a range of rows
			/// x(1:4, 3:5)
			public SubMatrix this[IndexRange q]
			{
				get { return mtx.GetRange(firstRow, lastRow, q.first, q.last); }			
			}
			
			/// same as MATLAB:
			/// x(1:4) are just the elements in range
			public static explicit operator  LeftExpr (MatrixRowRef r)
			{
				return r.mtx.GetElements(r.firstRow, r.lastRow);
			}
			
			Matrix mtx;
			int firstRow, lastRow;
		}
		
		public static AllPlaceHolder All = new AllPlaceHolder();

		protected float [] data;
		protected int columns, rows;		
	}

	// a one dimensional row vector
	public class Vector : Matrix
	{		
		public Vector(float [] n) : base(n, 1)
		{
		}

		public Vector(int n) : base(n,1)
		{
		}

		public new float this[int idx]
		{
			get { return data[idx]; }
			set { data[idx] = value; }
		}
			
		public override float Eval(int i, int j)
		{
			return data[i];
		}
	}
		
}