using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TSPInsertion
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                char sel = 'a';
                do
                {
                    Console.WriteLine("Traveling salesman problem (insertion method)");
                    Console.WriteLine("Select the method of data entry:");
                    Console.WriteLine("[a] = enter points, [b] = enter matrix");
                    Console.WriteLine("[c] = random points, [d] = random matrix");
                    Console.WriteLine("[e] = load points.txt file, [f] = load matrix.txt file");
                    sel = Console.ReadKey().KeyChar;
                    Console.Clear();
                }
                while (!((sel >= 'a') && (sel <= 'f')));
                Console.Clear();
                Console.WriteLine("Enter the size of the matrix:");

                int c1;
                while (!Int32.TryParse(Console.ReadLine(), out c1))
                {
                    Console.WriteLine("Invalid character entered.");
                }
                int dim = Convert.ToInt32(c1);

                double[,] A = new double[dim, dim];

                // entering points from the keyboard
                if (sel == 'a')
                {
                    double[,] point = new double[dim, 2];
                    for (int i = 0; i < dim; i++)
                    {
                        Console.WriteLine("Enter point x" + i + ":");
                        int cc;
                        while (!Int32.TryParse(Console.ReadLine(), out cc))
                            Console.WriteLine("Invalid character entered.");
                        point[i, 0] = Convert.ToInt32(cc);
                        Console.WriteLine("Enter y" + i + " point:");
                        while (!Int32.TryParse(Console.ReadLine(), out cc))
                            Console.WriteLine("Invalid character entered.");
                        point[i, 1] = Convert.ToInt32(cc);
                    }
                    for (int i = 0; i < dim; i++)
                    {
                        Console.Write("\ni=" + i + " x=" + point[i, 0] + " y=" + point[i, 1]);
                    }
                    Console.Write("\n");
                    for (int i = 0; i < dim; i++)
                    {
                        for (int j = 0; j < dim; j++)
                        {
                            if (!(j == i))
                            {
                                A[i, j] = Math.Sqrt(Math.Pow((point[j, 0] - point[i, 0]), 2) + Math.Pow((point[j, 1] - point[i, 1]), 2));
                            }
                        }
                    }
                }

                // keyboard input
                if (sel == 'b')
                {
                    int n1 = 0;
                    while (n1 < (dim * dim))
                    {
                        Console.Clear();
                        for (int i = 0; i < dim; i++)
                        {
                            for (int j = 0; j < dim; j++)
                            {
                                Console.WriteLine("Traveling salesman problem (insertion method)");
                                Console.Write("      ");
                                for (int m = 0; m < dim; m++)
                                {
                                    if (m < 10) Console.Write(m.ToString() + "      ");
                                    else Console.Write(m.ToString() + "     ");
                                }
                                Console.Write("\n");
                                for (int o = 0; o < dim; o++)
                                {
                                    if (o < 10)
                                        Console.Write(o + "  ");
                                    else Console.Write(o + " ");
                                    for (int l = 0; l < dim; l++)
                                    {
                                        if (o == l) Console.Write(" [  -  ] ");
                                        else if (A[o, l] == 0) Console.Write(" [     ] ");
                                        else
                                        {
                                            if (A[o, l] < 10) Console.Write(" [  " + A[o, l] + "  ] ");
                                            else Console.Write(" [ " + A[o, l] + " ]");
                                        }
                                    }
                                    Console.Write("\n");
                                }
                                Console.WriteLine("Enter [" + i + "][" + j + "]\n");
                                if (!(j == i))
                                {
                                    int c2;
                                    while (!Int32.TryParse(Console.ReadLine(), out c2))
                                    {
                                        Console.WriteLine("Invalid character entered.");
                                    }
                                    A[i, j] = Convert.ToInt32(c2);
                                }
                                Console.Clear();
                                n1++;
                            }
                        }
                    }
                }

                // random points
                else if (sel == 'c')
                {
                    double[,] point = new double[dim, 2];

                    for (int i = 0; i < dim; i++)
                    {
                        var random1 = new Random().Next(1, 99);
                        point[i, 0] = random1;
                        var random2 = new Random().Next(1, 99);
                        point[i, 1] = random2;

                    }

                    for (int i = 0; i < dim; i++)
                    {
                        Console.Write("\ni=" + i + " x=" + point[i, 0] + " y=" + point[i, 1]);
                    }
                    Console.Write("\n");
                    Console.ReadKey();
                    for (int i = 0; i < dim; i++)
                    {
                        for (int j = 0; j < dim; j++)
                        {
                            if (!(j == i))
                            {
                                A[i, j] = Math.Sqrt(Math.Pow((point[j, 0] - point[i, 0]), 2) + Math.Pow((point[j, 1] - point[i, 1]), 2));
                            }
                        }
                    }
                }

                // random matrix
                else if (sel == 'd')
                {

                    for (int i = 0; i < dim; i++)
                    {
                        for (int j = 0; j < dim; j++)
                        {
                            if (!(j == i))
                            {
                                var random = new Random().Next(1, 99);
                                A[i, j] = random;
                            }
                        }
                    }
                }

                // loading points from a file
                else if (sel == 'e')
                {
                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"points.txt");
                    try
                    {
                        double[,] point = new double[dim, 2];
                        string[] dane = File.ReadAllLines(path);
                        if (dane.Length > 0)
                        {
                            for (int i = 0; i < dim; i++)
                            {
                                int[] nums = Array.ConvertAll(dane[i].Split(','), int.Parse);
                                point[i, 0] = nums[0];
                                point[i, 1] = nums[1];

                            }
                        }

                        for (int i = 0; i < dim; i++)
                        {
                            Console.Write("\ni=" + i + " x=" + point[i, 0] + " y=" + point[i, 1]);
                        }
                        Console.Write("\n");
                        Console.ReadKey();
                        for (int i = 0; i < dim; i++)
                        {
                            for (int j = 0; j < dim; j++)
                            {
                                if (!(j == i))
                                {
                                    A[i, j] = Math.Sqrt(Math.Pow((point[j, 0] - point[i, 0]), 2) + Math.Pow((point[j, 1] - point[i, 1]), 2));
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("File loading error. " +
                            "Place the points.txt file in the program folder." +
                            "Separate data with commas and new lines.");
                    }
                }

                // loading matrix from a file
                else if (sel == 'f')
                {
                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"matrix.txt");
                    try
                    {
                        string[] dane = File.ReadAllLines(path);
                        if (dane.Length > 0)
                        {
                            for (int i = 0; i < dim; i++)
                            {
                                int[] nums = Array.ConvertAll(dane[i].Split(','), int.Parse);
                                for (int j = 0; j < dim; j++) A[i, j] = nums[j];
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("File loading error. " +
                            "Place the matrix.txt file in the program folder." +
                            "Separate data with commas and new lines.");
                    }
                }

                // displaying a full matrix
                Console.Clear();
                Console.WriteLine("Traveling salesman problem (insertion method)");
                Console.Write("       ");
                for (int m = 0; m < dim; m++)
                {
                    Console.Write(m.ToString() + "         ");
                }
                Console.Write("\n");
                for (int o = 0; o < dim; o++)
                {
                    if (o < 10)
                        Console.Write(o + "  ");
                    else Console.Write(o + " ");
                    for (int l = 0; l < dim; l++)
                    {
                        if (o == l) Console.Write(" [  --  ] ");
                        else if (A[o, l] == 0) Console.Write(" [   ] ");
                        else
                        {
                            if (A[o, l] < 10) Console.Write(" [ " + Math.Round(A[o, l], 2).ToString("N") + " ] ");
                            else Console.Write(" [ " + Math.Round(A[o, l], 2).ToString("N") + " ]");
                        }
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // algorithm body
                int S = 0;
                double dl = 0;
                double[] d = new double[dim];
                for (int i = 0; i < dim; i++)
                {
                    d[i] = A[S, i];
                }
                double max = d.Max();
                int maxIndex = d.ToList().IndexOf(max);
                var c = new List<int> { S, maxIndex, S };
                double k = A[maxIndex, S] + A[S, maxIndex];
                dl = k;
                for (int i = 0; i < dim; i++)
                {
                    if (d[i] > A[maxIndex, i]) d[i] = A[maxIndex, i];
                }
                Console.Write("d = ");
                for (int i = 0; i < dim; i++)
                {
                    Console.Write(d[i] + " ");
                }
                while (true)
                {
                    int f = d.ToList().IndexOf(d.Max());
                    var min = new List<double> { };

                    for (int i = 0; i < c.Count - 1; i++)
                    {
                        min.Add(A[c[i], f] + A[f, c[i + 1]] - A[c[i], c[i + 1]]);
                    }

                    int mk = min.IndexOf(min.Min());
                    dl += min.Min();

                    if (c.IndexOf(f) == -1) c.Insert(mk + 1, f);

                    Console.Write("\nc = ");
                    for (int i = 0; i < c.Count; i++)
                    {
                        Console.Write((c[i]) + " ");
                    }

                    for (int i = 0; i < dim; i++)
                    {
                        if (d[f] > A[f, i]) d[i] = A[f, i];
                    }

                    Console.Write("\nd = ");
                    for (int i = 0; i < dim; i++)
                    {
                        if (d[i] == 0) Console.Write("- ");
                        else Console.Write(d[i] + " ");
                    }
                    Console.Write("\ndl = " + dl);
                    var allElementsAreZero = d.All(o => o == 0);
                    if (allElementsAreZero == true) break;
                }

                stopwatch.Stop();

                // displaying the result
                Console.Write("\n\nThe route is as follows: [ ");
                for (int i = 0; i < c.Count; i++)
                {
                    Console.Write((c[i]));
                    if (i != c.Count - 1) Console.Write(" - ");
                }
                Console.WriteLine(" ]\nThe length of the route is: " + dl);
                Console.WriteLine("Algorithm execution time: {0}", stopwatch.Elapsed);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}