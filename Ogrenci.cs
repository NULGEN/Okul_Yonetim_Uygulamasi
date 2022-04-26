using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasi_G023
{
    class Ogrenci
    {
        public int No;
        public string Ad;
        public string Soyad;
        public DateTime DogumTarihi;
        public CINSIYET Cinsiyet;
        public SUBE Sube;
        public DERSLER Ders;  // DERSGIR METODU İÇİN OLUŞTU
        public float Ortalama
        {
            get
            {
                if (this.Notlar.Sum(a => a.Not)==0)  
                {
                    return 0;
                }
                else
                {
                    return this.Notlar.Sum(a=>a.Not) / this.Notlar.Count;
                }
                
            }
        }
        public string Aciklama;
        public Adres Adresi = new Adres();
        public List<string> Kitaplar = new List<string>();
        public List<DersNotu> Notlar = new List<DersNotu>();

        public int KitapSayisi
        {
            get
            {
                return this.Kitaplar.Count;
            }
        }

    }

    public enum SUBE
    {
        Empty, A, B, C
    }
    public enum CINSIYET
    {
        Empty,
        Kiz,
        Erkek
    }

    public enum DERSLER  // BU DERS GIR METODU İÇİN OLUŞTURULDU
    {
        Empty,
        Fen,
        Matermatik,
        Sosyal,
        Türkce
    }


}
