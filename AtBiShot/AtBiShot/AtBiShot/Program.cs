using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Title = "AT BI SHOT PARTY EDITION";
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Kar ve müzik için thread
        Thread musicThread = new Thread(PlayJingleBells);
        musicThread.Start();

        Snow(); // Bu bitene kadar müzik devam edecek

        musicThread.Join(); // müzik thread'i bitene kadar bekle

        Console.Clear();
        PrintTitle();

        Console.WriteLine("1 - Oyunu Başlat");
        Console.WriteLine("2 - Çıkış");
        Console.Write("\nSeçim: ");

        string choice = Console.ReadLine();

        if (choice == "1")
            StartGame();
        else if (choice == "2")
            return;
    }

    static void PlayJingleBells()
    {
        int C = 262, D = 294, E = 330, F = 349, G = 392, A = 440, B = 493, CC = 523, DD = 587, EE = 659;

        int WHOLE = 600;     // eskiden 1600 ms
        int HALF = 400;      // eskiden 800 ms
        int QUARTER = 300;   // eskiden 400 ms
        int EIGHTH = 200;    // eskiden 200 ms

        try
        {
            Console.Beep(E, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, QUARTER); Thread.Sleep(100);
            Console.Beep(E, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, QUARTER); Thread.Sleep(100);
            Console.Beep(E, EIGHTH); Thread.Sleep(50);
            Console.Beep(G, EIGHTH); Thread.Sleep(50);
            Console.Beep(C, EIGHTH); Thread.Sleep(50);
            Console.Beep(D, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, HALF); Thread.Sleep(100);

            Console.Beep(F, EIGHTH); Thread.Sleep(50);
            Console.Beep(F, EIGHTH); Thread.Sleep(50);
            Console.Beep(F, QUARTER); Thread.Sleep(100);
            Console.Beep(F, EIGHTH); Thread.Sleep(50);
            Console.Beep(F, EIGHTH); Thread.Sleep(50);
            Console.Beep(F, QUARTER); Thread.Sleep(100);
            Console.Beep(F, EIGHTH); Thread.Sleep(50);
            Console.Beep(G, EIGHTH); Thread.Sleep(50);
            Console.Beep(C, EIGHTH); Thread.Sleep(50);
            Console.Beep(D, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, HALF); Thread.Sleep(100);

            Console.Beep(E, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, QUARTER); Thread.Sleep(100);
            Console.Beep(E, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, QUARTER); Thread.Sleep(100);
            Console.Beep(E, EIGHTH); Thread.Sleep(50);
            Console.Beep(G, EIGHTH); Thread.Sleep(50);
            Console.Beep(C, EIGHTH); Thread.Sleep(50);
            Console.Beep(D, EIGHTH); Thread.Sleep(50);
            Console.Beep(E, HALF); Thread.Sleep(100);
        }
        catch
        {
            Console.WriteLine("⚠️ Müzik çalarken hata oluştu.");
        }
    }




    static void Snow() 
    {
        // ------------------------------
        // KAR YAĞIŞI EKLENECEK KISIM
        // ------------------------------
        Random rand = new Random();
        int width = Console.WindowWidth;
        int height = 30; // kar yükseklik bölgesi
        List<(int x, int y)> snowflakes = new List<(int x, int y)>();

        int totalFrames = 50;
        int frameDelay = 150; // biraz daha yavaş ve tatlı

        for (int frame = 0; frame < totalFrames; frame++)
        {
            // Yeni kar taneleri ekle (az ve rastgele)
            int newFlakes = rand.Next(1, 3); // 1 veya 2 yeni kar
            for (int i = 0; i < newFlakes; i++)
            {
                snowflakes.Add((rand.Next(width), 0));
            }

            Console.Clear(); // önceki frame'i temizle

            // Kar tanelerini bir aşağı kaydır
            for (int i = 0; i < snowflakes.Count; i++)
            {
                snowflakes[i] = (snowflakes[i].x, snowflakes[i].y + 1);
            }

            // Kar tanelerini çiz
            foreach (var flake in snowflakes)
            {
                if (flake.y < height)
                {
                    Console.SetCursorPosition(Math.Min(flake.x, width - 1), flake.y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("*");
                }
            }

            Thread.Sleep(frameDelay);
        }

        // Sonunda karı tamamen sil
        Console.Clear();
        Console.ResetColor();
    }
    static void PrintTitle()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
             $$$$$$\    $$\           $$$$$$$\  $$\        $$$$$$\  $$\                  $$\     
            $$  __$$\   $$ |          $$  __$$\ \__|      $$  __$$\ $$ |                 $$ |    
            $$ /  $$ |$$$$$$\         $$ |  $$ |$$\       $$ /  \__|$$$$$$$\   $$$$$$\ $$$$$$\   
            $$$$$$$$ |\_$$  _|        $$$$$$$\ |$$ |      \$$$$$$\  $$  __$$\ $$  __$$\\_$$  _|  
            $$  __$$ |  $$ |          $$  __$$\ $$ |       \____$$\ $$ |  $$ |$$ /  $$ | $$ |    
            $$ |  $$ |  $$ |$$\       $$ |  $$ |$$ |      $$\   $$ |$$ |  $$ |$$ |  $$ | $$ |$$\ 
            $$ |  $$ |  \$$$$  |      $$$$$$$  |$$ |      \$$$$$$  |$$ |  $$ |\$$$$$$  | \$$$$  |
            \__|  \__|   \____/       \_______/ \__|       \______/ \__|  \__| \______/   \____/ 
        ");
        Console.ResetColor();

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var firstLine = "┌────────────────┐";
        var secondLine ="│  Mutlu Yıllar  │";
        var thirdLine =" └────────────────┘";

        // Ağacın dalları (yeşil)
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("        *                               *        ");
        Console.WriteLine("       ***                             ***       ");
        Console.WriteLine("      *****                           *****      ");
        Console.WriteLine("     *******   " +  firstLine + "    *******     ");
        Console.WriteLine("    *********  " + secondLine + "   *********    ");
        Console.WriteLine("   ***********" + thirdLine +   "  ***********   ");
        Console.WriteLine("  *************                   *************  ");
        Console.WriteLine(" ***************                 *************** ");

        // Gövde (kahverengi)
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("       |||                             |||         ");
        Console.WriteLine("       |||                             |||         ");

        Console.ResetColor();




        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n============ Bir Latif ALTAY Ürünüdür =================\n");
        Console.ResetColor();
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

        int defaultPasses;
        do
        {
            Console.Write("Her oyuncunun kaç pas hakkı olacak? ");
        } while (!int.TryParse(Console.ReadLine(), out defaultPasses) || defaultPasses < 0);

        List<Player> players = new();
        for (int i = 0; i < playerCount; i++)
        {
            Console.Write($"Oyuncu {i + 1} adı: ");
            players.Add(new Player(Console.ReadLine(), defaultPasses));
        }

        Random random = new();
        int currentPlayerIndex = 0;

        while (questions.Count > 0)
        {
            Player currentPlayer = players[currentPlayerIndex];

            Console.Clear();
            PrintTitle();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Sıra: {currentPlayer.Name} | Toplam Shot: {currentPlayer.Shots} | Kalan Pas: {currentPlayer.Passes}");
            Console.ResetColor();
            Console.WriteLine("----------------------");

            int qIndex = random.Next(questions.Count);
            string question = questions[qIndex];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SORU:");
            Console.ResetColor();
            Console.WriteLine(question);
            Console.Write("\nShot atmak için S, pas için P, cevaplamak için ENTER: ");

            string input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "S")
            {
                currentPlayer.Shots++;
                ShowShotAt();
            }
            else if (input == "P")
            {
                if (currentPlayer.Passes > 0)
                {
                    currentPlayer.Passes--;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nPas kullandı! Kalan pas: {currentPlayer.Passes}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPas hakkın kalmadı! Shot atmak zorundasın!");
                    Console.ResetColor();
                    currentPlayer.Shots++;
                    ShowShotAt();
                }
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
    public int Passes { get; set; }

    public Player(string name, int passes)
    {
        Name = string.IsNullOrWhiteSpace(name) ? "Oyuncu" : name;
        Shots = 0;
        Passes = passes;
    }
}