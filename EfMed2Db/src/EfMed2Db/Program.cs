using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfMed2Db.Model;


namespace EfMed2Db
{
    public class Program
    {
        public static VarorContext contextV = new VarorContext();
        public static bool färdig = true;
        public static string varansNamn;
        public static int varansPris;
        public static int valAvGrupp;
        public static void Main(string[] args)
        {
           

            #region menyn
            färdig = false;
            while (!färdig)
            {
                Console.WriteLine("Hej och vällkommen vad vill du göra?");
                Console.WriteLine("Skriva ut alla varor i databasen tryck: 1");
                Console.WriteLine("Lägga till en ny vara tryck: 2");

                int meny = int.Parse(Console.ReadLine());
                CheckYesDigits(meny);
                switch (meny)
                {
                    case 1:
                        int numVaror = contextV.Varor.Count();
                        Console.WriteLine("så här många varor har vi : " + numVaror);
                    break;
                    case 2:
                        while (!färdig)
                        {
                            Console.WriteLine("Vad heter varan?");
                            varansNamn = Console.ReadLine();
                             CheckNoDigits(varansNamn);

                        }
                        färdig = false;
                        while (!färdig)
                        {
                            Console.WriteLine("Vad kostar {0} ?" + varansNamn);
                            varansPris = int.Parse(Console.ReadLine());
                            CheckYesDigits(varansPris);
                        }
                        färdig = false;
                        while (!färdig)
                        {
                            Console.WriteLine("vilken grupp till hör den?");
                            Console.WriteLine("1 = Mat");
                            Console.WriteLine("2 = Leksak");
                            valAvGrupp = int.Parse(Console.ReadLine());
                            CheckYesDigits(valAvGrupp);
                            if (valAvGrupp == 1 || valAvGrupp == 2)
                            {
                                färdig = true;
                            }
                            else
                            {
                                Console.WriteLine("Oj något blev fel vi får nog börja om du kan bara välja 1 eller 2 inte: "+ valAvGrupp);
                                färdig = false;
                            }
                        }
                        färdig = false;
                        Varor v = new Varor()
                        {
                            Namn = varansNamn,
                            pris = varansPris,
                            
                        };
                        Grupp g;
                        if (valAvGrupp == 1)
                        {
                            g = new Grupp()
                            {
                                Mat = true,
                                Leksak = false
                            };

                        }
                        else
                        {
                            g = new Grupp()
                            {                             
                                Leksak = true,
                                Mat = false
                            };
                        }
                        contextV.Varor.Add(v);
                        contextV.Grupp.Add(g);
                        contextV.SaveChanges();
                        Console.Clear();
                        Console.WriteLine("Du har lagt till förljande Vara");
                        Console.WriteLine("Namnet på varan = " + varansNamn);
                        Console.WriteLine("Priset på varan = " + varansPris);
                        if (valAvGrupp == 1)
                        {
                            Console.WriteLine("Du valde gruppen = Mat");
                        }
                        else
                        {
                            Console.WriteLine("Du valde gruppen = Leksak");

                        }
                        varansNamn = "";
                        varansPris = 0;
                        break;
                    case 0:

                        färdig = true;

                    break;
                }
            }
            #endregion




        }
        //En metod som ser så att det inte finns siffror i texten
        public static void CheckNoDigits(string x)
        {
            foreach (char item in x)
            {
                if (char.IsDigit(item))
                {
                    Console.WriteLine("Du får inte skriva nummer :" + item);
                    break;
                }
                else
                {
                    färdig = true;
                }

            }

        }
        //En metod som ser så att det bara är siffror i texten
        public static void CheckYesDigits(int x)
        {
            foreach (char item in x.ToString())
            {
                if (!char.IsDigit(item))
                {
                    Console.WriteLine("Du får bara skriva nummer :" + item);                   
                    break;
                }
                else
                {
                    färdig = true;
                }

            }

        }
    }
}
