using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hamming_NetCore.Class
{
    public class Matrix
    {
        public static List<Cluster> listClusterBase = new List<Cluster>();
        public static int x = 0;

        public static void AfficheMatrice(int[,] tab)
        {
            int rowLength = tab.GetLength(0);
            int colLength = tab.GetLength(1);
            int test = tab.Rank;

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", tab[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadLine();
        }

        //Compare le nombre d'occurence entre deux string
        public static int CompareOccurenceString(string item1, string item2)
        {
            int i = 0;
            int result = 0;
            foreach (char charItem1 in item1)
            {
                if (charItem1 == item2[i])
                {
                    result += 1;
                }
                i++;
            }
            return result;
        }

        //Permet d'afficher la distance d'hamming pour chaque croissement d'une matrice
        public static List<Line> AfficheHammingDistance(int[,] tab)
        {
            List<Croissement> listCroissement = new List<Croissement>();
            int rowLength = tab.GetLength(0);
            int colLength = tab.GetLength(1);
            int l = 0;
            int k = 1; ;
            List<string> listString= new List<string>() ;
            List<Line> listLine = new List<Line>();
            string line="";

            int[,] tabHamming = new int[10, 10];

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    line += tab[i, j];
                }
                listString.Add(line);
                line = "";
            }

            foreach (string item in listString)
            {
                for (k = 0; k < listString.Count; k++)
                {
                    if (item != listString[k])
                    {
                        Croissement croissement = new Croissement(item, listString[k], CompareOccurenceString(item, listString[k]));
                        listCroissement.Add(croissement);
                    }
                }
                Line newLine = new Line(item, listCroissement.Average(croissement => croissement.DistanceHamming));
                listLine.Add(newLine);
                listCroissement.Clear();
                l++;
            }
            return listLine;
        }

        //Permet de recalculer les cluster et ainsi trouver le meilleur résultat
        public static void RecalculCluster(List<Cluster> listCluster)
        {
            if(listCluster.Exists(item=>item.ListLine.Count == 1))
            {
                Cluster c= listCluster.OrderByDescending(item => item.Pourcentage).FirstOrDefault();
                Random rnd = new Random();
                int r = rnd.Next(c.ListLine.Count);
                (listCluster.Where(item => item.ListLine.Count == 1).FirstOrDefault()).ListLine.Add(c.ListLine[r]);
                c.ListLine.RemoveAt(r);
            }
            List<Line> newListLine = new List<Line>();
            
            List<Croissement> test = new List<Croissement>();
            int k = 1;
            foreach (var cluster in listCluster)
            {
                foreach (var item in cluster.ListLine)
                {
                    {
                        for (k = 0; k < cluster.ListLine.Count; k++)
                        {
                            if (item.LineMatrix != (cluster.ListLine[k]).LineMatrix)
                            {
                                Croissement croissement = new Croissement(item.LineMatrix, cluster.ListLine[k].LineMatrix, CompareOccurenceString(item.LineMatrix, cluster.ListLine[k].LineMatrix));
                                test.Add(croissement);
                            }
                        }
                        Line newLine = new Line(item.LineMatrix, test.Average(croissement => croissement.DistanceHamming));
                        newListLine.Add(newLine);
                        test.Clear();
                    }
                }
            }
            if(x == 100)
            {
                AfficheCluster(listCluster);
            }
            else if(listClusterBase.Count == 0)
            {
                listClusterBase = listCluster;
                DiviseInCluster(newListLine);
            }
            else
            {
                listClusterBase = listCluster;
                DiviseInCluster(newListLine);
            }   
        }

        //Permet de diviser dans des clusters les elements
        public static void DiviseInCluster(List<Line> listLine)
        {
            
            List<Cluster> listCluster = new List<Cluster>();
            foreach (var item in listLine)
            {
                if (listCluster.Count == 0)
                {
                    listCluster.Add(new Cluster(item.MoyenneDistanceHamming, new List<Line>() { item }));
                }
                else if (listCluster.Exists(itemLine => itemLine.Pourcentage == item.MoyenneDistanceHamming))
                {
                    Cluster cluster = listCluster.Single(itemLine => itemLine.Pourcentage == item.MoyenneDistanceHamming);
                    cluster.ListLine.Add(item);
                }
                else
                {
                    listCluster.Add(new Cluster(item.MoyenneDistanceHamming, new List<Line>() { item }));
                }
            }
            x++;
            RecalculCluster(listCluster);
            }

        //Affiche les clusters
        public static void AfficheCluster(List<Cluster> listCluster)
        { 
            int n = 1;
            foreach (var line in listCluster)
            {
                Console.WriteLine("Cluster " + n + " ;" + " Ecart " + line.Pourcentage);
                foreach (var itemLine in line.ListLine)
                {
                    Console.WriteLine(itemLine.LineMatrix);
                }
                n++;
            }
        }
    }

    
    }
