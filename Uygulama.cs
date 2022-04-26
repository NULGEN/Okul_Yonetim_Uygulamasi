using System;
using System.Collections.Generic;
using System.Linq;

namespace OkulYonetimUygulamasi_G023
{
    class Uygulama
    {
        static Okul Okul = new Okul();

        public void Calistir()
        {
            SahteVeriGir();
            SahteNotGir();
            SahteAdresGir();
            SahteKitapEkle();
            Menu();
            while (true)
            {
                Console.WriteLine();
                string secim = SecimAl();

                switch (secim)
                {
                    case "1":
                        OgrenciGir();
                        break;
                    case "2":
                        NotGir();
                        break;
                    case "3":
                        OrtalamaGoster();
                        break;
                    case "4":
                        AdresGoster();
                        break;
                    case "5":
                        TümOgrencileriListele();
                        break;
                    case "6":
                        SubeyeGoreListele();
                        break;
                    case "7":
                        NotlariGoster();
                        break;
                    case "8":
                        SinifinOrtalamasi();
                        break;
                    case "9":
                        CinsiyeteGoreListele();
                        break;
                    case "10":
                        TarihtenSonraDoganlar();
                        break;
                    case "11":
                        SemtlereGoreListele();
                        break;
                    case "12":
                        OkulEnBasariliBes();
                        break;
                    case "13":
                        OkulEnBasarisizUc();
                        break;
                    case "14":
                        SinifEnBasariliBes();
                        break;
                    case "15":
                        SinifEnBasarisizUc();
                        break;
                    case "16":
                        AciklamaGir();
                        break;
                    case "17":
                        AciklamaGoster();
                        break;
                    case "18":
                        KitapGir();
                        break;
                    case "19":
                        KitapListele();
                        break;
                    case "20":
                        SonKitap();
                        break;
                    case "21":
                        OgrenciSil();
                        break;
                    case "22":
                        Guncelle();
                        break;
                    case "cikis":
                    case "çıkış":   
                        Close();  
                        break;
                    case "liste":
                        Console.WriteLine();
                        Calistir();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Hatalı islem gerçeklestirildi. Tekrar deneyin.");
                        break;

                }
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkıs yapmak için \"çıkıs\" yazın.");
            }

        }

        public void OgrenciGir() 
        {
            Console.WriteLine();
            Console.WriteLine("1-Ögrenci Gir ---------------------------------------------");
            int alinanno = AracGerecler.SayiAl("Ögrencinin numarası: ");
            int yenino = Okul.OgrenciVarMi(alinanno);

            string yeniAd;
            do
            {
                yeniAd = AracGerecler.YaziAl("Ögrencinin adı: ");
            } while (yeniAd == "");

            yeniAd = IlkHarfiBuyut(yeniAd);

            string yeniSoyad;
            do
            {
                yeniSoyad = AracGerecler.YaziAl("Ögrencinin soyadı: ");
            } while (yeniSoyad == "");

            yeniSoyad = IlkHarfiBuyut(yeniSoyad);
            
            DateTime tarih = AracGerecler.TarihAl("Ögrencinin dogum tarihi: ");
            CINSIYET cins = AracGerecler.KizMiErkekMi("Ögrencinin cinsiyeti(K / E): ");
            SUBE sube = AracGerecler.SubeMi("Ögrencinin subesi(A / B / C): ");

            Okul.OgrenciEkle(yenino, yeniAd, yeniSoyad, tarih, cins, sube);

            Console.WriteLine(yenino + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
           
            if (alinanno!=yenino) 
            {
                Console.WriteLine($"Sistemde {alinanno} numaralı öğrenci olduğu için verdiğiniz öğrenci no {yenino} olarak değiştirildi. ");
            }
                                 
        }

       

        public void NotGir()       
        {
            Console.WriteLine();
            Console.WriteLine("2 - Not Gir-------------------------------------------------");

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");   
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdiSoyadiGetir(no));    
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));        
            Console.WriteLine();

            Console.WriteLine("---- Eklenilebilecek Dersler ----");
            DERSLER dersx = AracGerecler.DersGir();
            string ders = dersx.ToString();

            int adet = AracGerecler.SayiAl("Eklemek istediginiz not adedi: ");



            for (int i = 1; i <= adet; i++)
            {

                int not = AracGerecler.SayiAl(i + ". notu girin: ");

                if (not < 0 || not > 100)
                {
                    Console.WriteLine("Girdiğiniz değer 0 ve 100 arasında olmalıdır.");
                    i--;
                    continue;
                }
                
                Okul.NotEkle(no, ders, not);
            }

            Console.WriteLine("Bilgiler sisteme girilmistir.");
        }
         
        public void OrtalamaGoster()     
        {
            Console.WriteLine();
            Console.WriteLine("3-Ögrencinin not ortalamasını gör --------------------------");


            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");   
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdiSoyadiGetir(no));    
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));        
            Console.WriteLine();

            Console.Write("Ögrencinin not ortalaması: " + Okul.OrtalamaGetir(no));
            Console.WriteLine();

        }

        public void AdresGoster()        
        {
            Console.WriteLine();
            Console.WriteLine("4 - Ögrencinin adresini gir--------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");   
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdiSoyadiGetir(no));    
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));        
            Console.WriteLine();

            string yeniIl;  
            do
            {
                yeniIl = AracGerecler.YaziAl("Il: "); ;

            } while (yeniIl == "");

            yeniIl= IlkHarfiBuyut(yeniIl);

            string yeniIlce;
            do
            {
                yeniIlce = AracGerecler.YaziAl("Ilce: ");

            } while (yeniIlce == "");

            yeniIlce = IlkHarfiBuyut(yeniIlce);

            string yeniMah;
            do
            {
                yeniMah = AracGerecler.YaziAl("Mahalle: ");

            } while (yeniMah=="");

            yeniMah = IlkHarfiBuyut(yeniMah);
                       
            Okul.AdresEkle(no, yeniIl, yeniIlce, yeniMah);
            
            Console.WriteLine("Bilgiler sisteme girilmistir.");

        }

        public void TümOgrencileriListele() 
        {
            Console.WriteLine();
            Console.WriteLine("5- Bütün Ögrencileri Listele -------------------------------------"); 

            if (Okul.Ogrenciler.Count == 0) 
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            Listele(Okul.Ogrenciler);
            
        }

        public void SubeyeGoreListele() 
        {
            Console.WriteLine();
            Console.WriteLine("6-Subeye Göre Ögrencileri Listele -------------------------------");
            
            if (Okul.Ogrenciler.Count == 0)   
            {                                
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            List<Ogrenci> liste;

            while (true)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin(A/B/C):");
                string secim = Console.ReadLine();

                if (secim.ToUpper() == "A")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Sube == SUBE.A).ToList();
                    break;
                }
                else if (secim.ToUpper() == "B")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Sube == SUBE.B).ToList();
                    break;
                }
                else if (secim.ToUpper() == "C")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Sube == SUBE.C).ToList();
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı tekrar deneyin.");
                }
            }
            Listele(liste);
            return;

        }

        public void NotlariGoster()  
        {
            Console.WriteLine();
            Console.WriteLine("7-Ögrencinin notlarını görüntüle ------------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");   
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdiSoyadiGetir(no));    
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));        
            Console.WriteLine();
            

            List<DersNotu> list = Okul.OgrenciNotlariGetir(no);
            Listele2(list);           

        }

        public void SinifinOrtalamasi()  
        {
            Console.WriteLine();
            Console.WriteLine("8-Sinifin not ortalamasını gör --------------------------");
                       

            List<Ogrenci> liste;
            float ort = 0;
                       
            
                SUBE sube= AracGerecler.SubeMi("Bir şube seçin(A/B/C): ");  
                Console.WriteLine();
               
                if (sube==SUBE.A)
                {
                    ort = Okul.Ogrenciler.Where(a => a.Sube == SUBE.A).Average(a => a.Ortalama);
                }
                else if (sube == SUBE.B)
                {
                    ort = Okul.Ogrenciler.Where(a => a.Sube == SUBE.B).Average(a => a.Ortalama);
                }
                else 
                {
                    ort = Okul.Ogrenciler.Where(a => a.Sube == SUBE.C).Average(a => a.Ortalama);
                }
                

                Console.Write("Sinifin not ortalaması: " + decimal.Round((decimal)ort, 2));  
                Console.WriteLine();
                return;
                                     

        }

        public void CinsiyeteGoreListele() 
        {
            Console.WriteLine();
            Console.WriteLine("9-Cinsiyete Göre Öğrencileri Listele-------------------------------");

            if (Okul.Ogrenciler.Count == 0)   
            {
                Console.WriteLine("Listelenecek ögrenci bulunamadı.");
                return;
            }

            List<Ogrenci> liste;


            while (true)
            {
                Console.Write("Listelemek istediğiniz cinsiyeti girin(K / E):");
                string secim = Console.ReadLine();

                if (secim.ToUpper() == "K")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Cinsiyet == CINSIYET.Kiz).ToList();
                    break;
                }
                else if (secim.ToUpper() == "E")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Cinsiyet == CINSIYET.Erkek).ToList();
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı tekrar deneyin.");
                }
            }
            Listele(liste);
            return;

        }

        public void TarihtenSonraDoganlar() 
        {
            Console.WriteLine();
            Console.WriteLine("10-Dogum Tarihine Göre Ögrencileri Listele -------------------------------");

            if (Okul.Ogrenciler.Count == 0)  
                                             
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            DateTime tarih = AracGerecler.TarihAl("Hangi tarihten sonraki ögrencileri listelemek istersiniz: ");

            List<Ogrenci> liste;

            liste = Okul.Ogrenciler.Where(a => a.DogumTarihi > tarih).ToList();

            Listele(liste);
            return;
        }

        public void SemtlereGoreListele()  
        {
            Console.WriteLine();
            Console.WriteLine("11-Semte Göre Ögrencileri Listele -------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            List<Ogrenci> liste;

            liste = Okul.Ogrenciler.OrderBy(a => a.Adresi.Il).ToList();

            Listele1(liste);
            return;

        }

        public void OkulEnBasariliBes()  
        {
            Console.WriteLine();
            Console.WriteLine("12-Okuldaki en basarılı 5 ögrenciyi listele --------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            List<Ogrenci> liste;

            liste = Okul.Ogrenciler.OrderByDescending(a => a.Ortalama).Take(5).ToList();

            Listele(liste);
            return;

        }

        public void OkulEnBasarisizUc() 
        {
            Console.WriteLine();
            Console.WriteLine("13-Okuldaki en basarısız 3 ögrenciyi listele --------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            List<Ogrenci> liste;

            liste = Okul.Ogrenciler.OrderBy(a => a.Ortalama).Take(3).ToList();

            Listele(liste);
            return;

        }

        public void SinifEnBasariliBes() 
        {
            Console.WriteLine();
            Console.WriteLine("14-Sınıftaki en basarılı 5 ögrenciyi listele --------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            List<Ogrenci> liste;

            while (true)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin(A/B/C):");
                string secim = Console.ReadLine();

                if (secim.ToUpper() == "A")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Sube == SUBE.A).OrderByDescending(a => a.Ortalama).Take(5).ToList();
                    break;
                }
                else if (secim.ToUpper() == "B")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Sube == SUBE.B).OrderByDescending(a => a.Ortalama).Take(5).ToList();
                    break;
                }

                else if (secim.ToUpper() == "C")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Sube == SUBE.C).OrderByDescending(a => a.Ortalama).Take(5).ToList();
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı tekrar deneyin.");
                }
            }
            Listele(liste);
            return;

        }

        public void SinifEnBasarisizUc()  
        {
            Console.WriteLine();
            Console.WriteLine("15-Sınıftaki en basarısız 3 ögrenciyi listele --------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            List<Ogrenci> liste;

            while (true)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin(A/B/C):");
                string secim = Console.ReadLine();

                if (secim.ToUpper() == "A")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Sube == SUBE.A).OrderBy(a => a.Ortalama).Take(3).ToList();
                    break;
                }
                else if (secim.ToUpper() == "B")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Sube == SUBE.B).OrderBy(a => a.Ortalama).Take(3).ToList();
                    break;
                }
                else if (secim.ToUpper() == "C")
                {
                    liste = Okul.Ogrenciler.Where(item => item.Sube == SUBE.C).OrderBy(a => a.Ortalama).Take(3).ToList();
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı tekrar deneyin.");
                }

            }
            Listele(liste);
            return;

        }

        public void AciklamaGir()    
        {
            Console.WriteLine();
            Console.WriteLine("16 - Ögrenci için açıklama gir--------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");   
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdiSoyadiGetir(no));    
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));       
            Console.WriteLine();

            Console.Write("Aciklama: ");
            string aciklama = Console.ReadLine().ToString();
            Okul.AciklamaAl(no, aciklama);

            Console.WriteLine("Bilgiler sisteme girilmistir.");
        }

        public void AciklamaGoster()     
        {
            Console.WriteLine();
            Console.WriteLine("17 - Ögrencinin açıklamasını gör--------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");   
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdiSoyadiGetir(no));    
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));        
            Console.WriteLine();

          

            try
            {
                Okul.AciklamaVarMi(no);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Aciklama: ");
            Console.WriteLine(Okul.AciklamaGoster(no));

            Console.WriteLine();
        }

        public void KitapGir()     
        {
            Console.WriteLine();
            Console.WriteLine("18 - Ögrencinin okudugu kitabı gir--------------------------------");

            if(Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");   
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdiSoyadiGetir(no));    
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));        
            Console.WriteLine();

            Console.Write("Eklenecek Kitap Adı: ");
            string kitap =IlkHarfiBuyut(Console.ReadLine());  
            Okul.KitapEkle(no, kitap);

            Console.WriteLine("Bilgiler sisteme girilmistir.");

        }

        public void KitapListele()     
        {
            Console.WriteLine();
            Console.WriteLine("19-Ögrencinin okudugu kitapları listele --------------------------");

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");   
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdiSoyadiGetir(no));    
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));        
            Console.WriteLine();

            List<string> Kitaplar = Okul.KitapListele(no);
            Listele3(Kitaplar);

        }

        public void SonKitap()        
        {
            Console.WriteLine();
            Console.WriteLine("20-Ögrencinin okudugu son kitabı listele --------------------------");

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");   
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdiSoyadiGetir(no));    
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));        
            Console.WriteLine();

            Console.WriteLine("Okudugu Son Kitap");
            Console.WriteLine("------------------");

            List<string> Kitaplar = Okul.SonKitapGetir(no);

            foreach (string item in Kitaplar)
            {
                Console.WriteLine(item);
            }

        }

        public void OgrenciSil()  
        {
            Console.WriteLine();
            Console.WriteLine("Ögrenci sil --------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek ögrenci yok.");
                return;
            }

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");   
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdiSoyadiGetir(no));    
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));        
            Console.WriteLine();

            
            string secim = AracGerecler.YaziAl("Ögrenciyi silmek istediginize emin misiniz (E/H).");  

            if (secim.ToUpper() == "E")
            {
                Okul.OgrenciSil(no);
                Console.WriteLine("Ögrenci basarılı sekilde silindi.");

            }
            else if(secim.ToUpper() == "H")
            {
                return;
            }
            
        }

        public void Guncelle() 
        {
            Console.WriteLine();
            Console.WriteLine("22 - Ögrenciyi güncelle --------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek ögrenci yok.");
                return;
            }

            int no;
            bool donsunMu = true;
            do
            {
                no = AracGerecler.SayiAl("Ögrenci no giriniz: ");  
                if (!Okul.VarMi(no))  
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin");
                    continue;
                }
                donsunMu = false;

            } while (donsunMu == true);

            string isim =AracGerecler.YaziAl("Ögrencinin adı: ");
            if (isim != "")
            {
               isim = IlkHarfiBuyut(isim);
            }
            
            string soyisim =AracGerecler.YaziAl("Ögrencinin soyadı: ");
            if (soyisim != "")
            {
                soyisim = IlkHarfiBuyut(soyisim);
            }
          
            DateTime tarih = AracGerecler.TarihAlGuncelle("Ögrencinin dogum tarihi: "); 
            CINSIYET cins = AracGerecler.KizMiErkekMi("Ögrencinin cinsiyeti(K/E): ");
            SUBE sube = AracGerecler.SubeMi("Ögrencinin subesi(A/B/C): ");

            Okul.Guncelle(no, isim, soyisim, tarih, cins, sube);
            Console.WriteLine(); 
            Console.WriteLine("Ogrenci güncellendi.");
           
        }

        public void Listele(List<Ogrenci> liste) 
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Listede silinecek ögrenci yok.");
                return;
            }

            Console.WriteLine("Sube".PadRight(10,' ') + "No".PadRight(10,' ') +
               "Adı" + " " + "Soyadı".PadRight(21,' ') + 
               "Not Ort.".PadRight(15,' ') + "Okuduğu Kitap Say.");
            
            Console.WriteLine("".PadRight(79, '-')); 

            foreach (Ogrenci item in liste)
            {                
                Console.WriteLine(item.Sube.ToString().PadRight(10,' ') +
                    item.No.ToString().PadRight(10,' ') +
                    (item.Ad + " " + item.Soyad).PadRight(25,' ') + 
                    item.Ortalama.ToString().PadRight(15,' ') 
                    + item.KitapSayisi); 
            }

        }

        public void Listele1(List<Ogrenci> liste) 
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Listede silinecek ögrenci yok.");
                return;
            }
            
            Console.WriteLine("Sube".PadRight(10,' ') +
                              "No".PadRight(10,' ') + ("Adı" + " " + "Soyadı").PadRight(21,' ') +
                              "Sehir".PadRight(15,' ') + "Semt");

            Console.WriteLine("".PadRight(79, '-'));

            foreach (Ogrenci item in liste)
            {
                Console.WriteLine(item.Sube.ToString().PadRight(10,' ') +
                                  item.No.ToString().PadRight(10,' ') +
                                  (item.Ad + " " + item.Soyad).PadRight(21,' ') +
                                  item.Adresi.Il.PadRight(15,' ') + item.Adresi.Ilce);
            }

        }

        public void Listele2(List<DersNotu> liste)  
        {
            if (liste.Count == 0)  
            {
                Console.WriteLine("Listede ögrencinin notu yok.");
                return;
            }

            Console.WriteLine("Dersin Adi".PadRight(15,' ') + "Notu");

            Console.WriteLine("".PadRight(20, '-'));

            foreach (DersNotu item in liste)
            {
                Console.WriteLine(item.DersAdi.ToString().PadRight(15) + item.Not);
            }
        }

        public void Listele3(List<string> liste)
        {
            Console.WriteLine("Okudugu Kitaplar");

            Console.WriteLine("-----------------");

            foreach(string item in liste)
            {
                Console.WriteLine(item);
            }
        }


        public void Close() 
        {
            Environment.Exit(0);
        }

        public void Menu() 
        {
            Console.WriteLine("------Ögrenci Yönetim Sistemi  -----");
            Console.WriteLine("1 - Ögrenci Gir");
            Console.WriteLine("2 - Not Gir");
            Console.WriteLine("3 - Ögrencinin ortalamasını gör");
            Console.WriteLine("4 - Ögrencinin adresini gir");
            Console.WriteLine("5 - Bütün Ögrencileri Listele");
            Console.WriteLine("6 - Subeye Göre Ögrencileri Listele");
            Console.WriteLine("7 - Ögrencinin notlarını görüntüle");
            Console.WriteLine("8 - Sınıfın Not Ortalamasını Gör");
            Console.WriteLine("9 - Cinsiyetine göre ögrenci listele");
            Console.WriteLine("10 - Su tarihten sonra dogan ögrencileri listele");
            Console.WriteLine("11 - Tüm ögrencileri semtlerine göre sıralayarak listele");
            Console.WriteLine("12 - Okuldaki En basarılı 5 ögrenciyi listele");
            Console.WriteLine("13 - Okuldaki En basarısız 3 ögrenciyi listele");
            Console.WriteLine("14 - Sınıftaki En basarılı 5 ögrenciyi listele");
            Console.WriteLine("15 - Sınıftaki En basarısız 3 ögrenciyi listele");
            Console.WriteLine("16 - Ögrenci için açıklama gir");
            Console.WriteLine("17 - Ögrencinin açıklamasını gör");
            Console.WriteLine("18 - Ögrencinin okudugu kitabı gir");
            Console.WriteLine("19 - Ögrencinin okudugu kitapları listele");
            Console.WriteLine("20 - Ögrencinin okudugu son kitabı görüntüle");
            Console.WriteLine("21 - Ögrenci sil");
            Console.WriteLine("22 - Ögrenci güncelle");
            Console.WriteLine();
            Console.WriteLine("Çıkıs yapmak için \"çıkıs\" yazıp \"enter\"a basın.");
        } 

        public string SecimAl() 
        {
            Console.Write("Yapmak istediginiz islemi seçiniz: ");
            return Console.ReadLine();
        }

        static string IlkHarfiBuyut(string veri)
        {
            string a = veri.Substring(0, 1).ToUpper() + veri.Substring(1).ToLower();
            return a;
        }

        public void SahteVeriGir() 
        {
            Okul.OgrenciEkle(1, "Elif", "Selçuk", new DateTime(2001, 5, 5), CINSIYET.Kiz, SUBE.A);
            Okul.OgrenciEkle(2, "Betül", "Yılmaz", new DateTime(2000, 10, 2), CINSIYET.Kiz, SUBE.B);
            Okul.OgrenciEkle(3, "Hakan", "Çelik", new DateTime(2001, 8, 12), CINSIYET.Erkek, SUBE.C);
            Okul.OgrenciEkle(4, "Kerem", "Akay", new DateTime(2002, 6, 10), CINSIYET.Erkek, SUBE.A);
            Okul.OgrenciEkle(5, "Hatice", "Çınar", new DateTime(2000, 6, 5), CINSIYET.Kiz, SUBE.B);
            Okul.OgrenciEkle(6, "Selim", "İleri", new DateTime(2004, 7, 20), CINSIYET.Erkek, SUBE.B);
            Okul.OgrenciEkle(7, "Selin", "Kamış", new DateTime(2002, 5, 20), CINSIYET.Kiz, SUBE.C);
            Okul.OgrenciEkle(8, "Sinan", "Avcı", new DateTime(2003, 2, 15), CINSIYET.Erkek, SUBE.A);
            Okul.OgrenciEkle(9, "Deniz", "Çoban", new DateTime(2000, 2, 2), CINSIYET.Erkek, SUBE.C);
            Okul.OgrenciEkle(10, "Selda", "Kavak", new DateTime(1999, 9, 20), CINSIYET.Kiz, SUBE.B);

        }

        public void SahteNotGir() 
        {
            Okul.NotEkle(1,"Türkçe", 80);
            Okul.NotEkle(1,"Matermatik",85);
            Okul.NotEkle(1,"Fen",90);           
            Okul.NotEkle(1,"Sosyal",70);
            Okul.NotEkle(2,"Türkçe", 65);
            Okul.NotEkle(2,"Matermatik",55);
            Okul.NotEkle(2,"Fen",40);
            Okul.NotEkle(2,"Sosyal",70);
            Okul.NotEkle(3,"Türkçe", 45);
            Okul.NotEkle(3,"Matermatik",70);
            Okul.NotEkle(3,"Fen",30);           
            Okul.NotEkle(3,"Sosyal",50);
            Okul.NotEkle(4,"Türkçe", 40);
            Okul.NotEkle(4,"Matermatik",64);
            Okul.NotEkle(4,"Fen",82);          
            Okul.NotEkle(4,"Sosyal",50);
            Okul.NotEkle(5,"Türkçe", 75);
            Okul.NotEkle(5,"Matermatik",70);
            Okul.NotEkle(5,"Fen",72);            
            Okul.NotEkle(5,"Sosyal",60);
            Okul.NotEkle(6,"Türkçe", 37);
            Okul.NotEkle(6,"Matermatik",64);
            Okul.NotEkle(6,"Fen",35);            
            Okul.NotEkle(6,"Sosyal",50);
            Okul.NotEkle(7,"Türkçe", 65);
            Okul.NotEkle(7,"Matermatik",74);
            Okul.NotEkle(7,"Fen",82);           
            Okul.NotEkle(7,"Sosyal",40);
            Okul.NotEkle(8, "Türkçe", 37);
            Okul.NotEkle(8,"Matermatik",55);
            Okul.NotEkle(8,"Fen",48);            
            Okul.NotEkle(8,"Sosyal",20);
            Okul.NotEkle(9, "Türkçe", 55);
            Okul.NotEkle(9,"Matermatik",90);
            Okul.NotEkle(9,"Fen",82);           
            Okul.NotEkle(9,"Sosyal",40);
            Okul.NotEkle(10, "Türkçe", 32);
            Okul.NotEkle(10,"Matermatik",30);
            Okul.NotEkle(10,"Fen",55);
            Okul.NotEkle(10,"Sosyal",55);

        }
        public void SahteAdresGir() 
        {

            Okul.SahteAdresEkle(1, "Ankara", "Çankaya", "Bağlıca");
            Okul.SahteAdresEkle(2, "Ankara", "Keçiören", "Osmangazi");
            Okul.SahteAdresEkle(3, "Ankara", "Çankaya", "Çukurambar");
            Okul.SahteAdresEkle(4, "İzmir", "Karşıyaka", "Alaybey");
            Okul.SahteAdresEkle(5, "İzmir", "Gaziemir", "Atıfbey");
            Okul.SahteAdresEkle(6, "İzmir", "Gaziemir", "Irmak");
            Okul.SahteAdresEkle(7, "İzmir", "Bayraklı", "Adalet");
            Okul.SahteAdresEkle(8, "İstanbul", "Arnavutköy", "Anadolu");
            Okul.SahteAdresEkle(9, "İstanbul", "Beykoy", "Acarlar");
            Okul.SahteAdresEkle(10, "İstanbul", "Ataşehir", "Atatürk");
        }
        public void SahteKitapEkle()
        {
            Okul.SahteKitapEkle(1, "Ölü Ozanlar Derneği");
            Okul.SahteKitapEkle(1, "George Orwell- 1984");
            Okul.SahteKitapEkle(1, "Bülbülü Öldürmek");
            Okul.SahteKitapEkle(2, "Hayvan Çiftliği");
            Okul.SahteKitapEkle(2, "Harry Potter ve Felsefe Taşı");
            Okul.SahteKitapEkle(3, "Çavdar Tarlasında Çocuklar");
            Okul.SahteKitapEkle(4, "Büyük Umutlar");
            Okul.SahteKitapEkle(4, "Gurur ve Ön Yargı");
            Okul.SahteKitapEkle(5, "Jane Eyre");
            Okul.SahteKitapEkle(6, "Uğultulu Tepeler");
            Okul.SahteKitapEkle(6, "Frankenstein");
            Okul.SahteKitapEkle(7, "Kuşların Şarkısı");
            Okul.SahteKitapEkle(8, "Noel Şarkısı");
            Okul.SahteKitapEkle(8, "Harry Potter Sırlar Odası");
            Okul.SahteKitapEkle(8, "Harry Potter Azkaban Tutsağı");
            Okul.SahteKitapEkle(9, " Bir Ses Böler Geceyi");
            Okul.SahteKitapEkle(9, "Masal Masal İçinde");
            Okul.SahteKitapEkle(9, "Sis ve Gece");
            Okul.SahteKitapEkle(10, "Agatha'nın Anahtarı ");
        }

    }
}
