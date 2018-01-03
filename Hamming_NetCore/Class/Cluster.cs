using System;
using System.Collections.Generic;
using System.Text;

namespace Hamming_NetCore.Class
{
    public class Cluster
    {
        public Cluster(double pourcentage)
        {
            Pourcentage = pourcentage;
        }

        public Cluster(double pourcentage, List<Line> listLine) : this(pourcentage)
        {
            ListLine = listLine;
        }

        public double Pourcentage { get; set; }
        public List<Line> ListLine { get; set; }
     }
}
