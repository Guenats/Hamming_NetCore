using System;
using System.Collections.Generic;
using System.Text;

namespace Hamming_NetCore.Class
{
    public class Croissement
    {
        public string X { get; set; }
        public string Y { get; set; }
        public int DistanceHamming { get; set; }

        public Croissement()
        {

        }

        public Croissement(string x,string y,int distance)
        {
            X = x;
            Y = y;
            DistanceHamming = distance;
        }


    }
}
