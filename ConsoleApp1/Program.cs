using System;
using System.Collections.Generic;

enum CihazTuru
{
    Lamba = 1,
    Klima = 2,
    Guvenlik = 3
}

class Cihaz
{
    public int Kimlik;
    public string Ad;
    public CihazTuru Tur;
    public bool AcikMi;

    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
        AcikMi = false;
    }

    public void Ac()
    {
        AcikMi = true;
    }

    public void Kapat()
    {
        AcikMi = false;
    }

    public void BilgileriGoster()
    {
        Console.WriteLine("Kimlik: " + Kimlik);
        Console.WriteLine("Ad: " + Ad);
        Console.WriteLine("Tur: " + Tur);

        if (AcikMi)
            Console.WriteLine("Durum: Acik");
        else
            Console.WriteLine("Durum: Kapali");

        Console.WriteLine("----------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Cihaz> cihazlar = new List<Cihaz>();

        cihazlar.Add(new Cihaz(1, "Salon Lambasi", CihazTuru.Lamba));
        cihazlar.Add(new Cihaz(2, "Klima", CihazTuru.Klima));
        cihazlar.Add(new Cihaz(3, "Guvenlik Sistemi", CihazTuru.Guvenlik));

        while (true)
        {
            Console.WriteLine("\nAKILLI EV SIMULATORU");
            Console.WriteLine("1- Cihazlari listele");
            Console.WriteLine("2- Yeni cihaz ekle");
            Console.WriteLine("3- Cihaz ac");
            Console.WriteLine("4- Cihaz kapat");
            Console.WriteLine("0- Cikis");

            Console.Write("Seciminiz: ");

            int secim;

            if (!int.TryParse(Console.ReadLine(), out secim))
            {
                Console.WriteLine("Gecersiz secim!");
                continue;
            }

            if (secim == 0)
            {
                break;
            }
            else if (secim == 1)
            {
                foreach (Cihaz cihaz in cihazlar)
                {
                    cihaz.BilgileriGoster();
                }
            }
            else if (secim == 2)
            {
                Console.Write("Cihaz kimligi: ");
                int kimlik;

                if (!int.TryParse(Console.ReadLine(), out kimlik))
                {
                    Console.WriteLine("Gecersiz kimlik!");
                    continue;
                }

                bool varMi = false;

                foreach (Cihaz cihaz in cihazlar)
                {
                    if (cihaz.Kimlik == kimlik)
                    {
                        varMi = true;
                        break;
                    }
                }

                if (varMi)
                {
                    Console.WriteLine("Bu kimlik zaten mevcut!");
                    continue;
                }

                Console.Write("Cihaz adi: ");
                string ad = Console.ReadLine() ?? "";

                Console.WriteLine("1- Lamba");
                Console.WriteLine("2- Klima");
                Console.WriteLine("3- Guvenlik");

                Console.Write("Cihaz turu: ");
                int tur;

                if (!int.TryParse(Console.ReadLine(), out tur)
                    || tur < 1 || tur > 3)
                {
                    Console.WriteLine("Gecersiz cihaz turu!");
                    continue;
                }

                cihazlar.Add(new Cihaz(kimlik, ad, (CihazTuru)tur));

                Console.WriteLine("Cihaz eklendi.");
            }
            else if (secim == 3 || secim == 4)
            {
                Console.Write("Cihaz kimligi: ");
                int kimlik;

                if (!int.TryParse(Console.ReadLine(), out kimlik))
                {
                    Console.WriteLine("Gecersiz kimlik!");
                    continue;
                }

                bool bulundu = false;

                foreach (Cihaz cihaz in cihazlar)
                {
                    if (cihaz.Kimlik == kimlik)
                    {
                        bulundu = true;

                        if (secim == 3)
                        {
                            cihaz.Ac();
                            Console.WriteLine("Cihaz acildi.");
                        }
                        else
                        {
                            cihaz.Kapat();
                            Console.WriteLine("Cihaz kapatildi.");
                        }

                        break;
                    }
                }

                if (!bulundu)
                {
                    Console.WriteLine("Cihaz bulunamadi!");
                }
            }
            else
            {
                Console.WriteLine("Gecersiz secim!");
            }
        }
    }
}