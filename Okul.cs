using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasi_G023
{
    class Okul
    {
      
        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();
        

        public void NotEkle(int ogrenciNo, string ders, int not)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == ogrenciNo).FirstOrDefault();

            if (o != null)
            {
                DersNotu dn = new DersNotu(ders, not);
                o.Notlar.Add(dn);
            }
        }

        public void OgrenciEkle(int no, string ad, string soyad, DateTime dogumTarihi, CINSIYET cinsiyet, SUBE sube)
        {
            Ogrenci o = new Ogrenci();
            
            o.No = no;
            o.Ad = ad;
            o.Soyad = soyad;
            o.DogumTarihi = dogumTarihi;
            o.Cinsiyet = cinsiyet;
            o.Sube = sube;

            Ogrenciler.Add(o);

        }
        public void SahteAdresEkle(int no, string il, string ilce, string mahalle)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                o.Adresi.Il = il;
                o.Adresi.Ilce = ilce;
                o.Adresi.Mahalle = mahalle;
            }
        }

        public void SahteKitapEkle(int no, string kitapAdi)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                o.Kitaplar.Add(kitapAdi);
            }
        }

        public void KitapEkle(int no, string kitapAdi)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                o.Kitaplar.Add(kitapAdi);
            }
        }

        public void OgrenciSil(int no)  
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                Ogrenciler.Remove(o);
            }
        }

        public void Guncelle(int no, string isim, string soyisim, DateTime dogumTarihi, CINSIYET cinsiyet, SUBE sube)   
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            int x = Ogrenciler.IndexOf(o);
            Ogrenciler.RemoveAt(x);

            if (o != null)
            {
                if (isim != "")
                {
                    o.Ad = isim;
                    
                }
                if(soyisim != "")
                {
                    o.Soyad = soyisim;
                }
                if(dogumTarihi != DateTime.MinValue) 
                {
                    o.DogumTarihi = dogumTarihi;
                }
                if(cinsiyet != CINSIYET.Empty)   

                {
                    o.Cinsiyet = cinsiyet;
                }
                if(sube != SUBE.Empty)  
                {
                    o.Sube = sube;
                }
            }
            
            Ogrenciler.Insert(x,o);
            
        }



        public float OrtalamaGetir(int no)  
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                return o.Ortalama;
            }
            return 0;
        }

        public void AdresEkle(int no, string il, string ilce, string mahalle) 
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            int x = Ogrenciler.IndexOf(o);
            Ogrenciler.RemoveAt(x);

            if (o != null)
            {
                o.Adresi.Il = il;
                o.Adresi.Ilce = ilce;
                o.Adresi.Mahalle = mahalle;

                Ogrenciler.Insert(x, o);
            }    
        }
        


        public int OgrenciVarMi(int no)    
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            Ogrenci lasto = this.Ogrenciler.OrderByDescending(a => a.No).FirstOrDefault();
            if (o != null)
            {
                return  lasto.No+ 1;
            }
            return no;
        }


        public bool VarMi(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                return true;
            }
            return false;
        }

        public string AdiSoyadiGetir(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            
            string tamIsim="";

            if (o != null)
            {
                tamIsim = o.Ad + " " + o.Soyad;
            }

            return tamIsim;
        }

        public SUBE SubeGetir(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                return o.Sube;
            }
            return SUBE.Empty;

        }

        
        public List<DersNotu> OgrenciNotlariGetir(int no)    
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            List<DersNotu> notlar;            

            if (o != null)
            {
                notlar = o.Notlar.ToList();
                return notlar;
            }
            return null;

        }

        public List<string> KitapListele(int no)    
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            List<string> kitaplar;

            if (o != null)
            {
                kitaplar = o.Kitaplar.ToList();
                return kitaplar;
            }
            return null;
        }

        public List<string> SonKitapGetir(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            List<string> kitaplar;


            if (o != null)
            {
                kitaplar = o.Kitaplar.ToList();
                kitaplar.Reverse();

                return kitaplar.Take(1).ToList();
            }
            return null;
        }



        public void AciklamaAl(int no, string aciklama)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                o.Aciklama += aciklama+"\n";
            }
        }


        public string AciklamaGoster(int no)  
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            
            if (o != null)
            {
                 return o.Aciklama;               
            }
            throw new Exception("Böyle bir ögrenci yok");
        }

        public void AciklamaVarMi(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if(o.Aciklama == null)
            {
                throw new Exception("Bu ögrenciye ait açıklama bulunmamaktadır.");
            }
        }




    }
}
