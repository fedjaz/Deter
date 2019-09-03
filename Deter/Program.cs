using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    a[i][j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine(Det(a));

        }

        static int Det(int[][] matrix)
        {
            if (matrix.Length != matrix[0].Length)
            {
                return 0;
            }
            else if (matrix.GetLength(0) == 2)
            {
                return matrix[0][0] * matrix[1][1] -
                       matrix[0][1] * matrix[1][0];
            }

            int sum = 0;
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                var nmatrix = new List<List<int>>();
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    nmatrix.Add(new List<int>());
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        if (j == k)
                            continue;

                        nmatrix[i].Add(matrix[i][j]);
                    }
                }
                sum += matrix[0][k] * Det(nmatrix.Select(a => a.ToArray()).ToArray());
            }
            return sum;
        }
    }
}
