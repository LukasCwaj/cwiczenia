using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia
{
    class Program
    {
        //definicja ENUM
        public enum Ssaki : byte { Lew = 9, Cos = 1, Mysz, Kot = Cos, ssak};
        const int x2 = 10;
        static int Suma (int x22)                                   // odwolanie do metody przez wartosc
        {
            return (x22 + x22);
        }
        static int Suma2 (ref int x33)                              // metoda z odwolaniem referencyjnym
        {
            return x33=5;
        }
        public static void Wyliczenie(params object[] ilosc)        //wyliczanie elementow z tabeli obiektow
        {
            Console.Write("Dokonales wyliczenia z tabeli: (");
            for (int l = 0; l < ilosc.Length; l++)
            {
                if(l == ilosc.Length - 1)
                {
                    Console.Write(ilosc[l]);
                }
                else
                {
                    Console.Write(ilosc[l] + ", ");
                }
                

            }
            Console.WriteLine(")");
        }
        //dodanie czasu
        public static DateTime Today { get; }

        public static void Main(string[] args)      //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        {
            /*
             
            // wykorzystanie ENUM
            int x = (int)Ssaki.Kot;
            Console.WriteLine("Cos:{0}", x);
            Console.WriteLine($"Owsik to: { (int)Ssaki.ssak}");  // 2 bo jest jeszcze mysz
            
            //zmienna stala
            const int a = 1;
            int b = 0;
            int c = a + b;
            // a = c;   tak sie nie da bo to stala i wywali blad
            b = c;
            Console.WriteLine("Suma {0} i 0(b) = {1} \na z b zrobilo sie: {2}", a, c, b);

            //przyklad switch case i generowanie randomu
            Console.Write("Podaj numer dnia tyg:");
            int d = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();  // definicja random
            switch (d)
            {
                case 1: Console.WriteLine(rnd.Next(1,7));
                    break;
                case 2: Console.WriteLine("Wt");
                    break;
                default: Console.WriteLine("Blad");
                    break;
            }

            // test wiadomosci systemowej
            Console.Write("Podaj kolejna wartośc (2 to blad):");
            int e = Convert.ToInt32(Console.ReadLine());
            if (e==2) throw new InvalidOperationException("nie mozna podac 2");

            // drzewko odwrocone przez fora

            
                Console.WriteLine("Podaj od jakiej wart zaczac dla zbudowanie drzewka");
                int k = Convert.ToInt32(Console.ReadLine());
                for (int i = k; i >= 0; i--)
                {
                    for (int j=k; j >= 0; j--)
                    {
                    Console.Write("*");
                    }
                Console.Write("\n");
                k--;

                }

            //znajdowanie konkretnego ciągu w zdaniach
            string[] sentences =
                        {
                        "ala ma kota",
                        "kot ma ale",
                        "ale boli brzuch"
                        };

            string sPattern = "kot";

            foreach (string s in sentences)
            {
               Console.Write($"{s}");

                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    Console.WriteLine($"\t\t(znaleziono '{sPattern}')");
                }
            }


            // uzycie przez wartosc odwalania do metody  -                                                                                      do metody public/private nie da sie odwolac przez wartosc ???
            Console.WriteLine("Suma 2+2+10=" + Convert.ToString(Suma(2) + x2));
            int f = 4;
            Console.WriteLine("Suma 4+4+10=" + Convert.ToString(Suma(f) + x2));                     // przesyla sie tylko kopie wartosci, ktora nie zmienia wartosci rejestru wyslanego
            Console.WriteLine("Ale 'f' pozostaje: {0}", f);

            // odwolanie do metody przez referencje
            //  Console.WriteLine("Suma 2+2+10=" + Convert.ToString(Suma2(2) + x2));            nie można tak bo referencja ma być a nie wartość
            int g = 4;                                                                          // nie musi miec wartosci na poczatku
            Console.WriteLine("Suma {0}+10={1}",g,  Convert.ToString(Suma2(ref g) + x2));
            Console.WriteLine("Ale 'g' zmienia sie z 4 na: {0}", g);                        // po przeslaniu do metody zmieniona zostaje wartosc

            // odwolanie do metody przez parametr wieloobiektowy (taka mini tablica do wpisania na raz)
            object[] lista_elem = { 2, "las", 3, 4, "cos" };
            Wyliczenie(lista_elem);
 */

            //uzywanie wartosci w polach prywatnych za pomoca wlasciwosci z nowej klasy
            Console.Write("Podaj ile osob chcesz zdefiniowac: ");
            int h = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            string[,] tablud = new string[h,2];
            for (int m=0; m<h; m++)
            {
                Ludzie ludzie = new Ludzie();
                Console.WriteLine("Podaj ID: ");
                ludzie.Id = Console.ReadLine();
                Console.WriteLine("Podaj imie: ");
                ludzie.Imie = Console.ReadLine();
                tablud[m, 0] = ludzie.Id;                                                    
                tablud[m, 1] = ludzie.Imie;
                // dodac wczytanie do tablicy dwuwymiarowej i potem zestawienie zrobic
                
            }

            Console.WriteLine("Podaj ID do wczytania:");                                            // poprawne ID ponizej tu odniesienie do indeksu w tabeli
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dane pracownika o ID: {0} to: \n {1,30}", tablud[i-1, 0],tablud[i-1,1]);

            /*
                        // wykonanie wpisywanie ludzi do spisu
                        Console.Write("Podaj ile osob chcesz zdefiniowac: ");
                        int k = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        object[,] tablud = new object[k, 3];
                        for(int i=0; i<k; i++)
                        {
                            Console.Write("Podaj ID: ");
                            tablud[i, 0] = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Podaj Imie: ");
                            tablud[i, 1] = Console.ReadLine();
                            DateTime thisDay = DateTime.Today;
                            tablud[i, 2] = thisDay.ToString("T");
                        }

                        Console.WriteLine("Podaj ID do wczytania:");
                        int l = Convert.ToInt32(Console.ReadLine());
                        for (int j =0; j<k; j++)
                        {
                            if (Convert.ToInt32(tablud[j,0])==l)
                                Console.WriteLine("Dane pracownika o ID: {0} to: \n {1}\t {2}", l, tablud[j, 1], tablud[j, 2]);
                        }
             */

            //podtrzymanie wyswietlania
            Console.ReadKey();
        }
    }
    class Ludzie
    {
        private string id;                                                                             // utworzenie wlasciwosci dla ludzi
        private string imie;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Imie { get { return imie; } set { imie = value; } }           
        public override string ToString()
        {
            string returnedString = string.Format("ID: {0} \t\t Imie: {1}", id, imie);
            return returnedString;
        }
    }                                                                                               // zakonczenie wlasciwosci dla ludzi
}
