using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;






namespace csharp_sorting_algorithms
{
    internal class Program
    {
        static string insertion_siralamasi_baslangic_zamani=String.Empty;
        static string quicksort_siralamasi_baslangic_zamani=String.Empty;
        static string bubblesort_siralamasi_baslangic_zamani=String.Empty;


        
        public static void Main(string[] args)
        {
            List<int> sayiDeposu = RandomSayiUret(100000, 1, 100000);


            Barrier barrier = new Barrier(3);

            Task bubblesort_Gorevi = new Task(() =>
            {
                barrier.SignalAndWait();
                bublesort_siralamasi(sayiDeposu);
            });

            bubblesort_Gorevi.Start();

            Task quicksort_Gorevi = new Task(() =>
            {
                barrier.SignalAndWait();
                quicksort_siralamasi(sayiDeposu,0,sayiDeposu.Count-1);
            });
            
            
            
            Task insertionsort_Gorevi=new Task(() =>
            {
                barrier.SignalAndWait();
                insertion_siralamasi(sayiDeposu);
            });



            Task[] gorevler = { bubblesort_Gorevi,quicksort_Gorevi,insertionsort_Gorevi};
            Task.WaitAll(gorevler);
            Console.WriteLine("Bubble: {0}\n Quick : {1}\nInsertion:  {2}",bubblesort_siralamasi_baslangic_zamani,quicksort_siralamasi_baslangic_zamani,insertion_siralamasi_baslangic_zamani);


            
            
            
            





        }






        static List<int> insertion_siralamasi(List<int> numara_deposu)
        {

            if (string.IsNullOrEmpty(insertion_siralamasi_baslangic_zamani))
                insertion_siralamasi_baslangic_zamani = DateTime.Now.ToLongDateString();


            for (int j = 1; j < numara_deposu.Count; j++)
            {
                int deger = numara_deposu[j];
                int i = j - 1;
                while (i >=0 && numara_deposu[i] > deger)
                {
                    numara_deposu[i + 1] = numara_deposu[i];
                    i = i - 1;
                    

                }

                numara_deposu[i + 1] = deger;

            }

            return numara_deposu;
        }







        static List<int> quicksort_siralamasi(List<int> numara_deposu, int solDeger, int sagDeger)
        {
            if (string.IsNullOrEmpty(quicksort_siralamasi_baslangic_zamani))
            {
                quicksort_siralamasi_baslangic_zamani = DateTime.Now.ToLongDateString();
            }

            int i = solDeger;
            int j = sagDeger;
            double pivotDeger = ((solDeger + sagDeger) / 2);
            int x = numara_deposu[Convert.ToInt32(pivotDeger)];

            int w = 0;
            while (i<=j)
            {

                while (numara_deposu[i]<x)
                {
                    i++;

                }

                while (x<numara_deposu[j])
                {

                    j--;

                }

                if (i<=j)
                {

                    w = numara_deposu[i];

                    numara_deposu[i++] = numara_deposu[j];
                    numara_deposu[j] = w;

                }
               
            }

            if (solDeger<j)
            {

                quicksort_siralamasi(numara_deposu, solDeger, j);

            }

            if (i<sagDeger)
            {

                quicksort_siralamasi(numara_deposu, i, sagDeger);

            }
            
            
            
            
            

            return numara_deposu;



        }




        static List<int> bublesort_siralamasi(List<int> numaraDeposu)
        {

            if (string.IsNullOrEmpty(bubblesort_siralamasi_baslangic_zamani))
            {
                bubblesort_siralamasi_baslangic_zamani = DateTime.Now.ToLongDateString();

            }

            for (int i = 0; i < numaraDeposu.Count-1; i++)
            {

                for (int j = 1; j < numaraDeposu.Count-i; j++)
                {
                    if (numaraDeposu[j]<numaraDeposu[j-1])
                    {
                        int temp = numaraDeposu[j - 1];
                        numaraDeposu[j - 1] = numaraDeposu[j];
                        numaraDeposu[j] = temp;

                    }
                        
                    
                }
                
            }
        
            
     
            

            return numaraDeposu;
        }
        
        


        static List<int> RandomSayiUret(int sinir, int baslangic, int bitis)
        {
            List<int> yigin=new List<int>();
            Random rast=new Random();

            for (int i = 0; i <sinir ; i++)
            {
                yigin.Add(rast.Next(baslangic,bitis));
                
            }

            return yigin;

        }
        
        
        
        
        
        
    }
}