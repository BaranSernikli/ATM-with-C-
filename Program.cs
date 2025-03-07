using System;

class Program
{
    static void Main()
    {
        double bakiye = 500;  
        string sifre = "1234";  
        string girilenSifre;
        int deneme = 0;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("===============================================");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("        ATM'ye Hoşgeldiniz!");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("===============================================");
        Console.ResetColor();

        while (deneme < 3)
        {
            Console.Write("Lütfen şifrenizi girin: ");
            girilenSifre = Console.ReadLine();

            if (girilenSifre == sifre)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Şifre doğru! Giriş başarılı.");
                break;
            }
            else
            {
                deneme++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Yanlış şifre! {3 - deneme} denemeniz kaldı.");
            }

            if (deneme == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3 kez yanlış şifre girildi. Hesap kilitlendi.");
                return;  
            }
        }

        bool cikis = false;
        while (!cikis)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1 - Bakiye Sorgulama");
            Console.WriteLine("2 - Para Yatırma");
            Console.WriteLine("3 - Para Çekme");
            Console.WriteLine("4 - Çıkış");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Mevcut bakiyeniz: " + bakiye + " TL");
                    break;

                case "2":
                    Console.Write("Yatırmak istediğiniz miktarı girin: ");
                    double yatirilacak = Convert.ToDouble(Console.ReadLine());
                    if (yatirilacak > 0)
                    {
                        bakiye += yatirilacak;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(yatirilacak + " TL yatırıldı. Yeni bakiye: " + bakiye + " TL");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Geçersiz miktar.");
                    }
                    break;

                case "3":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Çekmek istediğiniz miktarı girin: ");
                    double cekilecek = Convert.ToDouble(Console.ReadLine());
                    if (cekilecek > 0 && cekilecek <= bakiye)
                    {
                        bakiye -= cekilecek;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(cekilecek + " TL çekildi. Yeni bakiye: " + bakiye + " TL");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Yetersiz bakiye veya geçersiz miktar.");
                    }
                    break;

                case "4":
                    cikis = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Çıkış yapılıyor");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
