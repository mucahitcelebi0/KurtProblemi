// kurt problemini c# diliyle yazdım.Teşekkürler


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




class Sonuc
{
    
    public static int tekkurtlar(List<int> kurtlar)
    {
        
        Dictionary<int, int> kurtSayilari = new Dictionary<int, int>();

        
        foreach (int kurt in kurtlar)
        {
            if (kurtSayilari.ContainsKey(kurt))
            {
                
                kurtSayilari[kurt]++;
            }
            else
            {
                
                kurtSayilari[kurt] = 1;
            }
        }

        
        int maxSay = kurtSayilari.Values.Max();

        
        int enKucukId = kurtSayilari.Where(x => x.Value == maxSay).Select(x => x.Key).Min();

       
        return enKucukId;
    }
}

public class Çözüm
{
    public static void Main(string[] args)
    {
        string inputpath = @"C:\Users\ahmet\OneDrive\Desktop\Games\fgt421394\fgt421394\bin\Release\input.txt.txt";
        string outputpath = @"C:\Users\ahmet\OneDrive\Desktop\Games\fgt421394\fgt421394\bin\Release\output.txt.txt";

        
        if (!File.Exists(inputpath))
        {
            Console.WriteLine($"Giriş dosyası bulunamadı: {inputpath}");
            return;
        }

        
        using (StreamReader okuyucu = new StreamReader(inputpath))
        {
            using (StreamWriter yazici = new StreamWriter(outputpath))
            {
                
                int diziBoyutu = int.Parse(okuyucu.ReadLine().Trim());

                
                string inputSatiri = okuyucu.ReadLine()?.Trim();
                if (inputSatiri == null)
                {
                    Console.WriteLine("Giriş dosyasında ikinci satır bulunamadı.");
                    return;
                }

                List<int> kurtlar = new List<int>();

                
                foreach (char karakter in inputSatiri)
                {
                    if (char.IsDigit(karakter))
                    {
                        kurtlar.Add(int.Parse(karakter.ToString()));
                    }
                }

                
                int sonuc = Sonuc.tekkurtlar(kurtlar);
                yazici.WriteLine(sonuc);
            }
        }
    }
}
