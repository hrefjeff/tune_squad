using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaExpr;

namespace Compression2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    internal sealed class Solver
    {
      private enum Result { Solved, Unsolved, Busted }
      private readonly Matrix conflictMatrix;
      private readonly BitArray[] possibilities;
      private readonly int colours;

      public Solver(Matrix conflictMatrix, int colours)
      {
        this.colours = colours;
        this.conflictMatrix = conflictMatrix;
        this.possibilities = new BitArray[conflictMatrix.Rows];
        BitArray b = new BitArray[];
        for (int i = 0; i < colours; ++i)
            b = b.Add(i);
        for (int p = 0; p < this.possibilities.Length; ++p)
            this.possibilities[p] = b;
     }
}
