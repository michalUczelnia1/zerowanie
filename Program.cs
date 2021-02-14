using System;
using System.IO;


namespace zad4
{
    class Program
    {


        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            string line;
            string name = "pla1a.in";
            StreamReader sr = new StreamReader(name);
            line = sr.ReadToEnd();
            Console.WriteLine(line);

            int ArrayLength;
            string Length = "";

            //ilosc domkow
            int k1 = 0;
            while (true)
            {
                if (Convert.ToInt32(line[k1]) >= 48 && Convert.ToInt32(line[k1]) <= 57)
                    Length += Convert.ToString(line[k1]);
                else
                    break;
                k1++;
            }

            ArrayLength = Convert.ToInt32(Length);
            Console.WriteLine(ArrayLength);

            //tworze tablice z domkami(szerokosc ich nie ma znaczenia wiec jest 1 wymiarowa)
            int[] tab = new int[ArrayLength];
            string StrNumberToAdd = "";
            int IntNumberToAdd;
            //zapelniam tablice
            int CountMyArray = 0;


            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == 32)//kesli jest spacja
                {
                    i++;
                    while (Convert.ToInt32(line[i]) >= 48 && Convert.ToInt32(line[i]) <= 57)
                    {
                        StrNumberToAdd += line[i];
                        i++;
                        if (i == line.Length)
                            break;
                    }
                    IntNumberToAdd = Convert.ToInt32(StrNumberToAdd);
                    tab[CountMyArray] = IntNumberToAdd;
                    StrNumberToAdd = "";
                    CountMyArray++;
                }
            }


            //WYPISZ
            Console.Write("\n\ntablica: ");

            for (int i = 0; i < ArrayLength; i++)
                Console.Write(tab[i] + " ");


            //usuwam powtorzenia gdy obok sa
            for (int i0 = 0; i0 < ArrayLength - 2; i0++)
            {
                int k0 = i0;
                int l0 = i0 + 1;
                while (tab[l0] == 0)
                {
                    l0++;
                    if (l0 >= ArrayLength - 2)
                    {
                        break;
                    }
                }
                if (tab[k0] == tab[l0])
                {
                    tab[l0] = 0;
                    i0--;
                }

            }

            //WYPISZ bez powtorzen
            Console.Write("\n\ntablica bez powt: ");

            for (int i = 0; i < ArrayLength; i++)
                Console.Write(tab[i] + " ");

            int Posters = 0;

            int k, l, m;


                //wybieram weze i uuwam srodkowa // i usuwam takie same obok
                for (int i = 0; i < ArrayLength - 2; i++)
                {

                    k = i;
                    l = i + 1;
                    m = i + 2;

                    //GDY 0 TO ODDALAM od siebie 3 kroki
                    if (m < tab.Length - 2)
                    {

                        while (tab[k] == 0 || tab[l] == 0 || tab[m] == 0)
                        {
                            if (tab[k] == 0)
                            {
                                k += 1;
                                l += 1;
                                m += 1;
                            }

                            else if (tab[l] == 0)
                            {
                                l += 1;
                                m += 1;
                            }

                            else if (tab[m] == 0)
                            {
                                m += 1;
                            }

                            if (l + 2 == tab.Length - 1 || l + 2 == tab.Length - 2 || l + 2 == tab.Length - 3)
                            {
                                break;
                            }
                        }

                    }

                    //gdy wieza to poster++ i zeruje
                    if (tab[l] > tab[k] && tab[l] > tab[m] && tab[k] != 0 && tab[l] != 0 && tab[m] != 0)
                    {
                        Posters++;
                        tab[l] = 0;

                        //gdy usuwam to cofam sie o 3 miejsca(nie liczac zer)
                        //TEN ELEMENT PROGRAMU NALERZY DOPRACOWAC
                        //|
                        //|
                        //gdy spotkasz 3 niezera to oki


                        

                        k--;
                        if (k > 0)
                            k--;
                        while (tab[k] == 0)
                        {
                            k--;
                            if (k < 1)
                                break;
                        }

                        /*
                        if (k > 0)
                            k--;
                        while (tab[k] == 0)
                        {
                            k--;
                            if (k < 1)
                                break;
                        }
                        */
                        k--;
                        i = k;
                        //|
                        //|
                        //TEN ELEMENT PROGRAMU NALERZY DOPRACOWAC

                    }




                    //usuwam powtorzenia gdy obok sa
                    for (int i0 = 0; i0 < ArrayLength - 2; i0++)
                    {
                        int k0 = i0;
                        int l0 = i0 + 1;
                        while (tab[l0] == 0)
                        {
                            l0++;
                            if (l0 >= ArrayLength - 2)
                            {
                                break;
                            }
                        }
                        if (tab[k0] == tab[l0])
                        {
                            tab[l0] = 0;
                            i0--;
                        }

                    }

                    //zabezpieczenie
                    if (i < 0)
                        i = -1;
                }

            

            //WYPISZ 
            Console.Write("\n\nbez max: ");

            for (int i = 0; i < ArrayLength; i++)
                Console.Write(tab[i] + " ");




            //usuwam powtorzenia gdy obok sa
            for (int i0 = 0; i0 < ArrayLength - 2; i0++)
            {
                int k0 = i0;
                int l0 = i0 + 1;
                while (tab[l0] == 0)
                {
                    l0++;
                    if (l0 >= ArrayLength - 2)
                    {
                        break;
                    }
                }
                if (tab[k0] == tab[l0])
                {
                    tab[l0] = 0;
                    i0--;
                }

            }

            //gdy liczba nie rowna sie 0 to dodaje plakat
            for (int i = 0; i < ArrayLength; i++)
            {
                if (tab[i] != 0)
                {
                    Posters++;
                }
            }



            //WYPISZ 
            Console.Write("\n\nbez powt: ");
            for (int i = 0; i < ArrayLength; i++)
                Console.Write(tab[i] + " ");

            Console.WriteLine("\nLiczba Plakatow:" + Posters);

            DateTime Stop = DateTime.Now;
            TimeSpan myTime = (Stop - start);

            StreamWriter sw = new StreamWriter("pla.out");
            sw.WriteLine("Zadanie: " + name + "  Plakatow: " + Posters + "\nCzas trwania programu: " + myTime.TotalSeconds + "s");
            sw.Close();

            Console.WriteLine("Czas trwania programiu:" + (myTime));
            Console.ReadKey();
        }
    }
}

