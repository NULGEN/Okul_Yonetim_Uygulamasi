using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasi_G023
{
    class AracGerecler
    {

       

        static public int SayiAl(string mesaj)
        {
            int sayi;

            do
            {
                Console.Write(mesaj);
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi))
                {
                    return sayi;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }

            } while (true);

        }

        static public string YaziAl(string yazi)
        {
            int sayi;
            
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();
                
                if (int.TryParse(giris, out sayi))
                {
                    Console.WriteLine("Hatalı islem tekrar girin.");
                }
                else
                {
                    return giris;
                }
            } while (true);
                
        }

        

        static public DateTime TarihAl(string yazi)
        {
            DateTime tarihx;
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();
                if (DateTime.TryParse(giris, out tarihx))
                {
                    return tarihx;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }
            } while (true);
        }


        //  22 numaraya için
        static public DateTime TarihAlGuncelle(string yazi) 
        {
            DateTime tarih;
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();
                if (DateTime.TryParse(giris, out tarih))
                {
                    return tarih;
                }
                else
                {
                    return DateTime.MinValue;  
                                              
                }

            } while (true);
        }

        static public CINSIYET KizMiErkekMi(string yazi)
        {
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();
                if (giris.ToUpper() == "K")
                {
                    return CINSIYET.Kiz;
                }
                else if(giris.ToUpper() == "E")
                {
                    return CINSIYET.Erkek;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }

            } while (true);
        }

        static public SUBE SubeMi(string yazi)
        {
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();
                if (giris.ToUpper() == "A")
                {
                    return SUBE.A;
                }
                else if (giris.ToUpper() == "B")
                {
                    return SUBE.B;
                }
                else if(giris.ToUpper() == "C")
                {
                    return SUBE.C;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }

            } while (true);
        }

        static public DERSLER DersGir()
        {
            Console.WriteLine("- Fen için 1");
            Console.WriteLine("- Matematik için 2");
            Console.WriteLine("- Sosyal için 3");
            Console.WriteLine("- Türkçe için 4");

            while (true)
            {
                Console.Write("Ders: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        return DERSLER.Fen;
                    case "2":
                        return DERSLER.Matermatik;
                    case "3":
                        return DERSLER.Sosyal;
                    case "4":
                        return DERSLER.Türkce;
                    default:
                        Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                        break;
                }

            }

        }









       

    }
}
