using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading;

namespace MetaExpr
{
	public class CompilerContext
	{
		public CompilerContext()
		{
			indexVariableCount = 0;
		}

		public int Add(float [] v)
		{
			param[paramCount] = v;
			return indexVariableCount + paramCount++;
		}

		public int GetIndexOf(float[] v)
		{
			for(int i = 0; i < paramCount;i++)
				if(param[i] == v) return indexVariableCount+i;
			return -1;
		}

		public int Count
		{
			get { return paramCount; }
		}

		public float [][] Params
		{
			get { return param; }
		}

		public static void GenLocalLoad(ILGenerator g, int a)
		{
			switch(a)
			{
				case 0: g.Emit(OpCodes.Ldloc_0); break;
				case 1: g.Emit(OpCodes.Ldloc_1); break;
				case 2: g.Emit(OpCodes.Ldloc_2); break;
				case 3: g.Emit(OpCodes.Ldloc_3); break;
				default:
					g.Emit(OpCodes.Ldloc, a);
					break;
			}
		}

		public bool IsFirstPass() 
		{
			return pass == 0;
		}

		public void NextPass()
		{
			pass++;
			// initialize the local variables array
			indexVariables = new int[indexVariableCount];
			for(int i = 0; i < indexVariableCount; i++)
				indexVariables[i] = i;
		}

		// Generate the Code to access the index variable number		
		public int GetIndexVariable(int number)
		{
			return indexVariables[number];
		}
		
		public void SetIndexVariable(int number, int value)
		{
			indexVariables[number] = value;
		}
		
		public int AllocIndexVariable()
		{
			return indexVariableCount++;
		}
		
		public void GenerateLocalInit(ILGenerator g)
		{
			// declare the indexes ...
			for(int i = 0; i < indexVariableCount; i++)
				g.DeclareLocal(typeof(int));
				
			// declare the parameters
			for(int i = 0; i < paramCount; i++)
				g.DeclareLocal(typeof(float[]));

			// load the parameters from the array parameters
			for(int i = 0; i < paramCount; i++)
			{
				// this.parameters[i] 
				g.Emit(OpCodes.Ldarg_0);
				g.Emit(OpCodes.Ldfld, typeof(MatrixEvaluator).GetField("parameters"));
				g.Emit(OpCodes.Ldc_I4, i);
				g.Emit(OpCodes.Ldelem_Ref);
				g.Emit(OpCodes.Stloc, indexVariableCount+i);
			}
		}

		int pass = 0;
		float [][] param = new float[20][];
		int paramCount;
		int indexVariableCount;		
		int []indexVariables;
	}
   
	public class Compiler
	{
		

		static ModuleBuilder module;
		static AssemblyBuilder assembly;
		static int classid;
		static bool saveMode = false;		// optional
		
		public static bool SaveMode
		{
			get { return saveMode; }	
			set {
				if(module == null)
					saveMode = value;
				else
				{
					throw new Exception("SaveMode cannot be more Changed!");	
				}	
			}
		}

		public static MatrixEvaluator Compile(Expr e)
		{
			if(module == null) 
			{
				AssemblyName assemblyName = new AssemblyName();
				assemblyName.Name = "EmittedAssembly";
				assembly = Thread.GetDomain().DefineDynamicAssembly(assemblyName, SaveMode ? AssemblyBuilderAccess.RunAndSave : AssemblyBuilderAccess.Run);
				if(!SaveMode)
					module = assembly.DefineDynamicModule("EmittedModule");
				else
					module = assembly.DefineDynamicModule("EmittedModule","a.exe");
				classid = 0;
			}
			classid++;

			TypeBuilder helloWorldClass = module.DefineType("HelloWorld"+classid, TypeAttributes.Public, typeof(MatrixEvaluator));						
			Type[] constructorArgs = { };
			ConstructorBuilder constructor = helloWorldClass.DefineConstructor(
				MethodAttributes.Public, CallingConventions.Standard, null);
				
			ILGenerator constructorIL = constructor.GetILGenerator();
			constructorIL.Emit(OpCodes.Ldarg_0);
			ConstructorInfo superConstructor = typeof(Object).GetConstructor(new Type[0]);
			constructorIL.Emit(OpCodes.Call, superConstructor);
			constructorIL.Emit(OpCodes.Ret);

			Type [] args = {  };
			MethodBuilder fxMethod = helloWorldClass.DefineMethod("Eval", MethodAttributes.Public|MethodAttributes.Virtual , typeof(void), args);
			ILGenerator methodIL = fxMethod.GetILGenerator();					
			CompilerContext cc = new CompilerContext();			
									
			// first pass calculate the parameters			
			// initialize and declare the parameters, start with 
			// localVectorI = parameters[i];			
			// next pass implements the function
			e.Compile(methodIL, cc);						
			cc.NextPass();
			cc.GenerateLocalInit(methodIL);
			e.Compile(methodIL, cc);

			// finally return
			methodIL.Emit(OpCodes.Ret);

			// create the class...
			Type dt = helloWorldClass.CreateType();
			MatrixEvaluator ae = (MatrixEvaluator)Activator.CreateInstance(dt, new Object[] { });		
			ae.SetParams(cc.Params);			
			
			return ae;
		}
		
		public static void Save()
		{
			if(SaveMode)
				assembly.Save("a.exe");	
		}
		
	}

    public delegate void Evaluator();
 
	/// <summary>
	/// Base Class for the Generated Code
	/// </summary>
	public abstract class MatrixEvaluator
	{
		public abstract void Eval();

		public void SetParams(float[][] p)
		{
			parameters = p;
		}

		public float [][] parameters;
	}
	
}