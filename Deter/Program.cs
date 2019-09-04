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
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                var arr = s.Split(' ');
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = int.Parse(arr[j]);
                }
            }
            Console.WriteLine(Det(matrix));
            Console.ReadLine();
        }

        static int Det(int[][] matrix)
        {
            if (matrix.Length != matrix[0].Length)
            {
                return 0;
            }
            else if (matrix.Length == 1)
            {
                return matrix[0][0];
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

                        nmatrix[i-1].Add(matrix[i][j]);
                    }
                }
                sum += matrix[0][k] * Det(nmatrix.Select(a => a.ToArray()).ToArray()) * 
                    (k % 2 == 0 ? 1 : -1);
            }
            return sum;
        }
    }
}
