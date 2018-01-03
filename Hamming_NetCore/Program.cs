using Hamming_NetCore.Class;
using System;

namespace Hamming_NetCore
{
    public class Program
    {
        static int[,] tabNotClass = new int[10, 4]
        {
            {0,1,1,0 },
            {0,0,1,0 },
            {1,1,1,0 },
            {0,1,0,0 },
            {0,1,1,1 },
            {0,0,0,1 },
            {1,1,1,1 },
            {1,0,0,0 },
            {1,0,0,1 },
            {1,1,0,1 }
        };
        static void Main(string[] args)
        {
           Matrix.DiviseInCluster(Matrix.AfficheHammingDistance(tabNotClass));
        }
    }
}
