using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ktu10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] eilutes = duomenuNuskaitymas();
            double sumaMot = 0;
            double vidMot = 0;
            double sumaVyr = 0;
            double vidVyr = 0;

            skaiciavimas(ref sumaMot, ref vidMot, ref sumaVyr, ref vidVyr, eilutes);
            double suma = visaSuma(sumaMot, sumaVyr);
            spausdinimas(sumaMot, vidMot, sumaVyr, vidVyr, suma);
        }

        static string[,] duomenuNuskaitymas()
        {
            string[] tekstas = System.IO.File.ReadAllLines(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu10-1\ktu10-1\duomenys.txt");
            int n = Convert.ToInt32(tekstas[0]);
            string[,] eilutes = new string[n, 2];
            for (int i = 0; i < tekstas.Length - 1; i++)
            {
                string[] eilute = tekstas[i + 1].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                eilutes[i, 0] = eilute[0];
                eilutes[i, 1] = eilute[1];
            }
            return eilutes;
        }

        static void skaiciavimas(ref double sumaMot, ref double vidMot, ref double sumaVyr, ref double vidVyr, string[,] eilutes)
        {
            double kiekisMot = 0;
            double kiekisVyr = 0;
            for (int i = 0; i < eilutes.Length / 2; i++)
            {
                if (eilutes[i, 0] == "m")
                {
                    kiekisMot++;
                    sumaMot += Convert.ToDouble(eilutes[i, 1]);
                }
                else if (eilutes[i, 0] == "v")
                {
                    kiekisVyr++;
                    sumaVyr += Convert.ToDouble(eilutes[i, 1]);
                }
            }
            if(kiekisMot == 0)
            {
                vidMot = 0;
            }
            else
            {
                vidMot = sumaMot / kiekisMot;
            }
            if (kiekisVyr == 0)
            {
                vidVyr = 0;
            }
            else
            {
                vidVyr = sumaVyr / kiekisVyr;
            }
        }

        static double visaSuma(double sumaMot, double sumaVyr)
        {
            double suma = sumaMot + sumaVyr;
            return suma;
        }
        static void spausdinimas(double sumaMot, double vidMot, double sumaVyr, double vidVyr, double suma)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu10-1\ktu10-1\rezultatai.txt"))
            {
                file.WriteLine("Moteriška avalynė: per dieną parduota už "+ String.Format("{0:0.00}", sumaMot) + 
                    " Lt,\nvidutiniškai viena pora batų kainavo"+ String.Format("{0:0.00}", vidMot) +
                    " Lt.\nVyriška avalynė: per dieną parduota už "+ String.Format("{0:0.00}", sumaVyr) +
                    " Lt,\nvidutiniškai viena pora batų kainavo "+ String.Format("{0:0.00}", vidVyr) + 
                    " Lt.\nIš viso per dieną parduota avalynės už "+ String.Format("{0:0.00}", suma) + " Lt");
                    
            }
        }
    }
}