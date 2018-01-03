using System;
using System.Collections.Generic;
using System.Text;

namespace Hamming_NetCore.Class
{
    public class Line
    { 

        public string LineMatrix { get; set; }
        public double MoyenneDistanceHamming { get; set; }

        public Line()
        {
        }

        public Line(string lineMatrix, double moyenneDistanceHamming)
        {
            LineMatrix = lineMatrix;
            MoyenneDistanceHamming = moyenneDistanceHamming;
        }
    }

}
