using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Console.Title = "AT BI SHOT PARTY EDITION";

        while (true)
        {
            Console.Clear();
            PrintTitle();

            Console.WriteLine("1 - Oyunu Başlat");
            Console.WriteLine("2 - Çıkış");
            Console.Write("\nSeçim: ");

            string choice = Console.ReadLine();

            if (choice == "1")
                StartGame();
            else if (choice == "2")
                break;
        }
    }

    static void PrintTitle()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
             █████╗ ████████╗    ██████╗ ██╗    ███████╗██╗  ██╗ ██████╗ ████████╗
            ██╔══██╗╚══██╔══╝    ██╔══██╗██║    ██╔════╝██║  ██║██╔═══██╗╚══██╔══╝
            ███████║   ██║       ██████╔╝██║    ███████╗███████║██║   ██║   ██║   
            ██╔══██║   ██║       ██╔══██╗██║    ╚════██║██╔══██║██║   ██║   ██║   
            ██║  ██║   ██║       ██████╔╝██║    ███████║██║  ██║╚██████╔╝   ██║   
            ╚═╝  ╚═╝   ╚═╝       ╚═════╝ ╚═╝    ╚══════╝╚═╝  ╚═╝ ╚═════╝    ╚═╝                                          
        ");
        Console.ResetColor();
        Console.WriteLine("\n==================== AT BI SHOT ====================\n");
        Console.WriteLine("\n=================== MUTLU YILLAR ====================\n");
    }

    static void StartGame()
    {
        List<string> questions = LoadQuestions();

        if (questions.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Soru bulunamadı. Oyun başlatılamıyor.");
            Console.ResetColor();
            Console.ReadLine();
            return;
        }

        int playerCount;
        Console.Clear();
        do
        {
            Console.Write("Kaç kişi oynuyor? ");
        } while (!int.TryParse(Console.ReadLine(), out playerCount) || playerCount < 1);

        List<Player> players = new();
        for (int i = 0; i < playerCount; i++)
        {
            Console.Write($"Oyuncu {i + 1} adı: ");
            players.Add(new Player(Console.ReadLine()));
        }

        Random random = new();
        int currentPlayerIndex = 0;

        while (questions.Count > 0)
        {
            Player currentPlayer = players[currentPlayerIndex];

            Console.Clear();
            PrintTitle();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Sıra: {currentPlayer.Name} | Toplam Shot: {currentPlayer.Shots}");
            Console.ResetColor();
            Console.WriteLine("----------------------");

            int qIndex = random.Next(questions.Count);
            string question = questions[qIndex];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SORU:");
            Console.ResetColor();
            Console.WriteLine(question);
            Console.Write("\nShot atmak için S tuşuna bas, cevaplamak için ENTER: ");

            string input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "S")
            {
                currentPlayer.Shots++;
                ShowShotAt();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCevaplandı!");
                Console.ResetColor();
            }

            questions.RemoveAt(qIndex);

            Console.WriteLine("\nDevam etmek için ENTER");
            Console.ReadLine();

            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        }

        ShowScoreboard(players);
    }

    static void ShowShotAt()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
            ███████╗██╗  ██╗ ██████╗ ████████╗     █████╗ ████████╗
            ██╔════╝██║  ██║██╔═══██╗╚══██╔══╝    ██╔══██╗╚══██╔══╝
            ███████╗███████║██║   ██║   ██║       ███████║   ██║   
            ╚════██║██╔══██║██║   ██║   ██║       ██╔══██║   ██║   
            ███████║██║  ██║╚██████╔╝   ██║       ██║  ██║   ██║   
            ╚══════╝╚═╝  ╚═╝ ╚═════╝    ╚═╝       ╚═╝  ╚═╝   ╚═╝                                         
        ");
        Console.ResetColor();
        Thread.Sleep(1500); 
    }

    static List<string> LoadQuestions()
    {
        try
        {
            string path = Path.Combine(AppContext.BaseDirectory, "questions.json");
            if (!File.Exists(path))
                return new List<string>();

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
        }
        catch
        {
            return new List<string>();
        }
    }

    static void ShowScoreboard(List<Player> players)
    {
        Console.Clear();
        PrintTitle();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== SKOR TABLOSU ===\n");
        Console.ResetColor();

        players.Sort((p1, p2) => p2.Shots.CompareTo(p1.Shots));

        foreach (var player in players)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{player.Name}");
            Console.ResetColor();
            Console.Write(" → ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{player.Shots} shot");
            Console.ResetColor();
        }

        Console.WriteLine("\nENTER → tekrar oyna | başka tuş → menü");
        if (string.IsNullOrEmpty(Console.ReadLine()))
            StartGame();
    }
}

class Player
{
    public string Name { get; }
    public int Shots { get; set; }

    public Player(string name)
    {
        Name = string.IsNullOrWhiteSpace(name) ? "Oyuncu" : name;
        Shots = 0;
    }
}
