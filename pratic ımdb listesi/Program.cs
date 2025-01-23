using System;
using System.Collections.Generic;
using System.Linq;

class Film
{
    public string Name { get; set; }
    public double ImdbScore { get; set; }

    public Film(string name, double imdbScore)
    {
        Name = name;
        ImdbScore = imdbScore;
    }
}

class Program
{
    static void Main()
    {
        List<Film> filmList = new List<Film>();

        while (true)
        {
            Console.Write("Film ismini giriniz: ");
            string name = Console.ReadLine();

            Console.Write("IMDb puanını giriniz (0.0 - 10.0): ");
            if (!double.TryParse(Console.ReadLine(), out double imdbScore) || imdbScore < 0 || imdbScore > 10)
            {
                Console.WriteLine("Geçerli bir IMDb puanı giriniz!");
                continue;
            }
            filmList.Add(new Film(name, imdbScore));

            Console.Write("Yeni bir film eklemek ister misiniz? (Evet/Hayır): ");
            string response = Console.ReadLine().Trim().ToLower();

            if (response != "evet")
            {
                break;
            }
        }

        Console.WriteLine("\n--- Bütün Filmler ---");
        foreach (var film in filmList)
        {
            Console.WriteLine($"{film.Name} - IMDb: {film.ImdbScore}");
        }

        Console.WriteLine("\n--- IMDb Puanı 4 ile 9 Arasında Olan Filmler ---");
        var filteredFilms = filmList.Where(f => f.ImdbScore >= 4 && f.ImdbScore <= 9);
        foreach (var film in filteredFilms)
        {
            Console.WriteLine($"{film.Name} - IMDb: {film.ImdbScore}");
        }

        Console.WriteLine("\n--- İsmi 'A' Harfi ile Başlayan Filmler ---");
        var filmsStartingWithA = filmList.Where(f => f.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
        foreach (var film in filmsStartingWithA)
        {
            Console.WriteLine($"{film.Name} - IMDb: {film.ImdbScore}");
        }

        Console.WriteLine("\nProgram sona erdi. Çıkmak için bir tuşa basınız.");
        Console.ReadKey();
    }
}
