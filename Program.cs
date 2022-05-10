using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Adventure_Game
{
    internal class Program
    {
        static class Globals
        {
            //map size
            public static int posx_map = 20;
            public static int posy_map = 20;
            //Global Position
            public static int posx;
            public static int posy;
            //flowers
            public static int flowers_amount = 0;
            public static int flowers_planted_amount = 0;
            public static int flowers_planted = 0; // 0 = false, 1 = true
            public static int flowers_watered_total = 0;
            //water
            public static int water_buckets = 0; // 0 = false, 1 = true
            public static int water_bucket_filled = 0; // 0 = false, 1 = true
            public static int water_storage = 0;
            //Coins Amount
            public static int mora = 10;
            //Quest Data
            public static bool home = false;
            public static bool fountain = false;
            public static bool display_fountain = false;
            public static bool market = false;
            public static bool display_market = false;
            public static bool glitch = false;
            public static bool glitch_figure = false;
            public static bool movement = false;

        }
        static void Main(string[] args)
        {
            Title();
        }
        public static void legende()
        {
            Console.SetCursorPosition(0, 23+Globals.posy_map);
            Console.WriteLine("Legende\nH = Haus\n");
            if (Globals.display_market == true) { Console.WriteLine("M = Markt\n"); }
            if (Globals.display_fountain == true) { Console.WriteLine("B = Brunnen\n"); }
            if (Globals.fountain == true) { Console.WriteLine("?? = Mr. Glitch, halte dich besser fern von ihm\n"); }
            if (Globals.fountain == true) { Console.WriteLine("C = Casino\n"); }
            if (Globals.fountain == true) { Console.WriteLine("L = Bibliothek"); }
        }
        public static void inventory()
        {
            Console.SetCursorPosition(100, 15);
            Console.WriteLine("Inventar");
            Console.SetCursorPosition(100, 16); Console.WriteLine($"Mora: {Globals.mora}");
            if (Globals.home == true) { Console.SetCursorPosition(100, 17); Console.WriteLine($"Blumen: {Globals.flowers_amount}"); Console.SetCursorPosition(100, 18); Console.WriteLine($"Wasservorrat: {Globals.water_storage}"); }
            if (Globals.home == true && Globals.water_buckets == 0) { Console.SetCursorPosition(100, 18); Console.WriteLine("Wassereimer: Nicht in Besitz"); }
            else if (Globals.home == true && Globals.water_buckets == 1 && Globals.water_bucket_filled == 0) { Console.SetCursorPosition(100, 19); Console.WriteLine("Wassereimer: Leer"); }
            else if (Globals.home == true && Globals.water_buckets == 1 && Globals.water_bucket_filled == 1) { Console.SetCursorPosition(100, 19); Console.WriteLine("Wassereimer: Voll (Bringe in zum Haus)"); }
        }
        public static void Play_Story (string story)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            int time = 1;
            if (story == "beginning")
            {
                Console.WriteLine("Du bist an einem unbekannten Ort angekommen");
                System.Threading.Thread.Sleep(time);
                Console.WriteLine("Du schaust dich um und siehst in der Nähe ein verlassenes Haus, welches dir vererbt wurde");
                System.Threading.Thread.Sleep(time);
                Console.WriteLine("Nähere dich dem Haus und betrete das Haus");
                System.Threading.Thread.Sleep(time);
                Movement();
            }
            else if (story == "house")
            {
                Console.WriteLine("Du bist am Haus angekommen");
                System.Threading.Thread.Sleep(time);
                Console.WriteLine("Du versuchst die Eingangstür zu öffnen, jedoch ist diese abgeschlossen!");
                System.Threading.Thread.Sleep(time);
                Console.WriteLine("Neber der Tür hängt ein Zettel, auf dem Zettel steht\n\n");
                System.Threading.Thread.Sleep(time);
                Console.WriteLine("'Falls ich mal meinen Schlüssel verliere, ein Ersatzschlüssel befindet sich unter der Matte\nIch bin grad auf dem Markt.\n~Mr. Glitch");
                System.Threading.Thread.Sleep(time + 2000);
                Console.WriteLine("Mache dich auf dem Weg zum Markt um Mr. Glitch zu finden");
                System.Threading.Thread.Sleep(time);
                Globals.home = true;
                Globals.display_market = true;
                Movement();
            }
            else if (story == "market")
            {
                Console.WriteLine("Du schaust dich auf dem Marktplatz");
                System.Threading.Thread.Sleep(time);
                Console.WriteLine("Während du dich umschaust siehst du einen Laden für Blumen, einen weiteren für einen Eimer aller größen");
                System.Threading.Thread.Sleep(time + 2000);
                Console.WriteLine("Auf einmal siehst du einen schwarz gekleideten Mensch, der sich rennend auf dem Weg zum Brunnen macht.");
                System.Threading.Thread.Sleep(time + 1000);
                Console.WriteLine("Mache dich auf dem Weg zum Brunnen!");
                System.Threading.Thread.Sleep(time);
                Globals.market = true;
                Globals.display_fountain = true;
                Movement();
            }
            else if (story == "fountain")
            {
                Console.WriteLine("Du bist am Brunnen angekommen");
                System.Threading.Thread.Sleep(time);
                Console.WriteLine("Auf einmal spricht dich eine unbekannte Stimme an...Es ist die Fee");
                System.Threading.Thread.Sleep(time);
                Console.WriteLine("Fee: Mache keinen Fehler und höre auf nach Mr. Glitch zu suchen. Er wird nicht mehr zurückkommen.");
                System.Threading.Thread.Sleep(time + 2000);
                Console.WriteLine("Fee: Das Haus gehört jetzt dir, kümmere dich um das Haus und die Blumen");
                System.Threading.Thread.Sleep(time + 1000);
                Globals.fountain = true;
                Globals.glitch = true;
                Movement();
            }
        }
        public static void Display_quests()
        {
            Console.SetCursorPosition(100, 0);
            Console.WriteLine("Quests");
            Console.SetCursorPosition(100, 6);
            Console.WriteLine("Nebenquests");
            Console.SetCursorPosition(100, 1);
            if (Globals.home == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Betrete das Haus");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Betrete das Haus (erledigt)");
                Console.SetCursorPosition(100, 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Betrete den Markt");
            }
            if (Globals.market == true)
            {
                Console.SetCursorPosition(100, 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Betrete den Markt (erledigt)");
                Console.SetCursorPosition(100, 3);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Verfolge den Schwarz gekleideten Mann zum Brunnen");
            }
            if (Globals.fountain == true)
            {
                Console.SetCursorPosition(100, 3);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Verfolge den Schwarz gekleideten Mann zum Brunnen");
            }
            if (Globals.market == true)
            {
                Console.SetCursorPosition(100, 7);
                if (Globals.flowers_planted_amount == 3)
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("Blumen gepflanzt 3/3");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Blumen gepflanzt {Globals.flowers_planted_amount}/3");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Title()
        {
            Console.WriteLine(@"
   _____       .___                    __                           ________                       
  /  _  \    __| _/__  __ ____   _____/  |_ __ _________   ____    /  _____/_____    _____   ____  
 /  /_\  \  / __ |\  \/ // __ \ /    \   __\  |  \_  __ \_/ __ \  /   \  ___\__  \  /     \_/ __ \ 
/    |    \/ /_/ | \   /\  ___/|   |  \  | |  |  /|  | \/\  ___/  \    \_\  \/ __ \|  Y Y  \  ___/ 
\____|__  /\____ |  \_/  \___  >___|  /__| |____/ |__|    \___  >  \______  (____  /__|_|  /\___  >
        \/      \/           \/     \/                        \/          \/     \/      \/     \/  
                                ");
            int ct = 5;
            while (ct != 0) { Console.SetCursorPosition(0, 10); Console.WriteLine($"Starte Spiel in {ct} sekunden..."); System.Threading.Thread.Sleep(1000); ct--; }
            Console.Clear();
            Play_Story("beginning");
            
        }
        public static void Nomora()
        {
            Console.WriteLine("Du hast kein Mora mehr, vielleicht findest du etwas beim rumwandern.");
        }
        public static void Map()
        {
            Console.SetCursorPosition(1+Globals.posx_map, 2+Globals.posy_map);
            Console.WriteLine("H");
            if (Globals.display_fountain == true)
            {
                Console.SetCursorPosition(-7 + Globals.posx_map, -4 + Globals.posy_map);
                Console.WriteLine("B");
            }
            if (Globals.display_market == true)
            {
                Console.SetCursorPosition(14+Globals.posx_map, -8+Globals.posy_map);
                Console.WriteLine("M");
            }
            if (Globals.glitch == true)
            {
                Console.SetCursorPosition(8 + Globals.posx_map, -13 + Globals.posy_map);
                Console.WriteLine("??");
            }
            if (Globals.fountain == true)
            {
                Console.SetCursorPosition(-15+Globals.posx_map, -15+Globals.posy_map);
                Console.WriteLine("C");
            }
            if (Globals.fountain == true)
            {
                Console.SetCursorPosition(20+Globals.posx_map, 0+Globals.posy_map);
                Console.WriteLine("L");
            }
        }
        public static void Movement()
        {
            Globals.movement = true;
            Console.Clear();
            Display_quests();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Bewege dich mit den Pfeiltasten. Drücke 'Escape' um das Spiel zu verlassen.");
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                Console.Clear();
                Display_quests();
                legende();
                Map();
                inventory();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Bewege dich mit den Pfeiltasten. Drücke 'Escape' um das Spiel zu verlassen.");
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: if (Globals.posy > -Globals.posy_map) { Globals.posy--; } break; // Console.WriteLine("UP"); break;
                    case ConsoleKey.DownArrow: if (Globals.posy < Globals.posy_map) { Globals.posy++; } break; // Console.WriteLine("DOWN"); break;
                    case ConsoleKey.RightArrow: if (Globals.posx < Globals.posx_map) { Globals.posx++; } break; // Console.WriteLine("RIGHT"); break;
                    case ConsoleKey.LeftArrow: if (Globals.posx > -Globals.posx_map) { Globals.posx--; } break; // Console.WriteLine("LEFT"); break;
                }
                Console.SetCursorPosition(0, 21+Globals.posy_map);
                Console.WriteLine($"Deine aktuellen Koordinaten sind {Globals.posx} / {Globals.posy}");
                Console.SetCursorPosition(Globals.posx + Globals.posx_map, Globals.posy + Globals.posy_map);
                if (Globals.glitch_figure == true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Fee: Ich habe dich gewarnt, Mr. Glitch nicht zu verfolgen!");
                    while (true)
                    {
                        Console.SetCursorPosition(Globals.posx + Globals.posx_map, Globals.posy + Globals.posy_map);
                        Random rnd = new Random();
                        Random bin = new Random();
                        int number1 = bin.Next(1, 100);
                        int number2 = bin.Next(1, 100);
                        Console.ForegroundColor = (ConsoleColor)bin.Next(0,16);
                        Console.BackgroundColor = (ConsoleColor)bin.Next(0,16);
                        Console.SetCursorPosition(number1, number2);
                        char randomChar = (char)rnd.Next('a', 'z');
                        Console.Write(randomChar);
                        
                        //if (Globals.movement == false) { break; }
                    }
                }
                if (Globals.posy == 2 && Globals.posx == 1) { Home(); }
                else if (Globals.posy == -4 && Globals.posx == -7 && Globals.display_fountain == true) { Fountain(); Globals.movement = false; }
                else if (Globals.posy == -8 && Globals.posx == 14 && Globals.display_market == true) { Market(); Globals.movement = false; }
                else if (Globals.posy == -13 && Globals.posx == 8) { Globals.glitch = false; Globals.glitch_figure = true; }
                else if (Globals.posy == -13 && Globals.posx == 9) { Globals.glitch = false; Globals.glitch_figure = true; }
                else if (Globals.posy == -15 && Globals.posx == -15 && Globals.fountain == true) { casino(); }
                else if (Globals.posy == 0 && Globals.posx == 20 && Globals.fountain == true) { library(); }
            }
        }
        public static void Home()
        {
            inventory();
            Console.SetCursorPosition(0, 0);
            if (Globals.home == true)
            {
                if (Globals.water_bucket_filled == 1)
                {
                    Console.Clear();
                    inventory();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Du hast den Inhalt des Wassereimers in deinen Wasserspeicher gekippt");
                    Globals.water_bucket_filled = 0;
                    Globals.water_storage++;
                    System.Threading.Thread.Sleep(2000);
                }
                Console.Clear();
                inventory();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Du hast dein Zuhause betreten. Drücke 'Escape' um dein Zuhause zu verlasssen.\n\nWas willst du machen?\n1. Blumen Pflanzen\n2. Blumen gießen\n3. Aus dem Fenster schauen");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape: int timer = 3; while (timer != 0) { Console.SetCursorPosition(0, 10); Console.WriteLine($"Verlasse Zuhause in {timer}..."); System.Threading.Thread.Sleep(1000); timer--; } Movement(); break;
                    case ConsoleKey.D1: if (Globals.flowers_amount == 0) { Console.WriteLine("Du hast keine Blume zum Pflanzen, du kannst eine auf dem Markt kaufen!"); System.Threading.Thread.Sleep(2000); Home(); } else if (Globals.flowers_amount > 0) { Globals.flowers_amount--; Globals.flowers_planted = 1; Globals.flowers_planted_amount++; Console.WriteLine($"Du hast eine Blume gepflanzt."); } System.Threading.Thread.Sleep(2000); Home(); break;
                    case ConsoleKey.D2: if (Globals.flowers_planted == 0) { Console.WriteLine("Du hast keine Blumen gepflanzt. Pflanze erst welche, um diese auch zu gießen!"); System.Threading.Thread.Sleep(2000); Home(); } else if (Globals.water_storage == 0) { Console.WriteLine("Du hast kein Wasser mehr auf Reserve, hole welches beim Brunnen, um deine Blumen zu gießen."); System.Threading.Thread.Sleep(2000); Home(); break; } else if (Globals.flowers_planted == 1 && Globals.water_storage > 0) { Globals.water_storage--; Globals.flowers_watered_total++; Console.WriteLine($"Du gießt deine Blumen. "); } System.Threading.Thread.Sleep(2000); Home(); break;
                    case ConsoleKey.D3: timer = 5; while (timer != 0) { Console.SetCursorPosition(0, 10); Console.WriteLine($"Du schaust für weitere {timer} Sekunden aus dem Fenster..."); System.Threading.Thread.Sleep(1000); timer--; } Home(); break;
                    default: Home(); break;
                }
            }
            else
            {
                Play_Story("house");
            }
        }
        public static void Fountain()
        {
            inventory();
            Console.SetCursorPosition(0, 0);
            if (Globals.fountain == true)
            {
                Console.Clear();
                inventory();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Du bist am Brunnen angekommen. Drücke 'Escape' um den Brunnenplatz zu verlassen.\n\nWas möchtest du machen?\n1.Eine Münze in den Brunnen werfen\n2.Wasser mit einem Eimer schöpfen");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape: int timer = 3; while (timer != 0) { Console.SetCursorPosition(0, 10); Console.WriteLine($"Verlassen den Brunnenplatz in {timer}..."); System.Threading.Thread.Sleep(1000); timer--; } Movement(); break;
                    case ConsoleKey.D1: if (Globals.mora > 0) { Globals.mora--; Console.WriteLine("Du hast eine Münze in den Brunnen geworfen."); System.Threading.Thread.Sleep(3000); Fountain(); } else { Nomora(); System.Threading.Thread.Sleep(3000); Fountain(); } break;
                    case ConsoleKey.D2: if (Globals.water_buckets == 0) { Console.WriteLine("Du hast keinen Wassereimer, kaufe einen beim Markt."); System.Threading.Thread.Sleep(3000); Fountain(); } else if (Globals.water_bucket_filled == 1) { Console.WriteLine("Du hast bereits einen vollen Wassereimer in deiner Hand. Bringe diesen erstmal zurück zu deinem Haus!"); System.Threading.Thread.Sleep(3000); Fountain(); } else { Globals.water_bucket_filled = 1; Console.WriteLine("Du hast einen Eimer Wasser aus dem Brunnen geschöpft, bringe diesen als nächstes zurück zu deinem Haus!"); System.Threading.Thread.Sleep(3000); Fountain(); } break;
                    default: Fountain(); break;
                }
            }
            else
            {
                Play_Story("fountain");
            }
        }
        public static void Market()
        {
            inventory();
            Console.SetCursorPosition(0, 0);
            if (Globals.market == true)
            {
                Console.Clear();
                inventory();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Du bist auf dem Marktplatz angekommen. Drücke 'Escape' um den Marktplatz zu verlassen.\n\nWas möchtest du machen?\n1. Blumen kaufen (1 Mora)\n2. Eimer kaufen (3 Mora)\n3. Dich auf dem Markt umschauen");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape: int timer = 3; while (timer != 0) { Console.SetCursorPosition(0, 10); Console.WriteLine($"Verlassen den Marktplatz in {timer}..."); System.Threading.Thread.Sleep(1000); timer--; } Movement(); break;
                    case ConsoleKey.D1: if (Globals.mora == 0) { Nomora(); } else if (Globals.mora > 0) { Globals.mora--; Globals.flowers_amount++; } System.Threading.Thread.Sleep(2000); break;
                    case ConsoleKey.D2: if (Globals.mora < 3) { Nomora(); } else if (Globals.water_buckets == 1) { Console.WriteLine("Du hast bereits einen Eimer"); System.Threading.Thread.Sleep(2000); Market(); } else if (Globals.mora >= 3) { Globals.mora = Globals.mora - 3; Globals.water_buckets = 1; Console.WriteLine("Du hast einen Eimer gekauft!"); System.Threading.Thread.Sleep(2000); } Market(); break;
                }
            }
            else
            {
                Play_Story("market");
            }
        }
        public static void casino()
        {
            Console.Clear();
            inventory();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Du bist im Casino angekommen. Zum verlassen gebe 'l' Nach der Eingabe deiner Wette, werden Zwei Zahlen zufällig generiert.\nWenn diese beiden Zahlen gleich sind, erhälst du das doppelte deines Einsatzes wieder!\n\nGib eine Zahl zwischen 1 und 9 ein");
            var input = Console.ReadLine();
            if (input == "l") { int timer = 3; while (timer != 0) { Console.SetCursorPosition(0, 10); Console.WriteLine($"Verlassen das Casino in {timer}..."); System.Threading.Thread.Sleep(1000); timer--; } Movement(); }
            else if (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7" && input != "8" && input != "9") { Console.WriteLine("Dies ist keine gültige Eingabe"); System.Threading.Thread.Sleep(3000); casino(); }
            int bet = Convert.ToInt32(input);
            if (bet > Globals.mora) { Console.WriteLine("Du hast nicht genug Mora!"); System.Threading.Thread.Sleep(3000); casino(); }
            Random bin = new Random();
            int number1 = bin.Next(0, 2);
            int number2 = bin.Next(0, 2);
            if (number1 == number2) { Console.WriteLine($"Du hast {bet * 2} Mora gewonnen!"); Globals.mora = Globals.mora + bet; System.Threading.Thread.Sleep(3000); casino(); }
            else { Console.WriteLine($"Du hast {bet} Mora verloren!"); Globals.mora = Globals.mora - bet; System.Threading.Thread.Sleep(3000); casino(); }

        }
        public static void library()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Du bist in der der Bibliothek angekommen.Drücke 'Escape' um die Bibliothek zu verlassen.\n\nWas möchtest du machen?\n1. Statistiken ansehen\n\n");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.Escape: int timer = 3; while (timer != 0) { Console.WriteLine($"Verlasse die Bibliothek in {timer}..."); timer--; System.Threading.Thread.Sleep(1000); } Movement(); break;
                case ConsoleKey.D1: Console.WriteLine("Statistiken Adventure Game\n"); Console.WriteLine($"Mora: {Globals.mora}\nBlumen: {Globals.flowers_amount}\nMenge an gepflanzten Blumen: {Globals.flowers_planted_amount}\nWie viel die Blumen gegossen: {Globals.flowers_watered_total} Liter\nWasserspeicherinhalt:  {Globals.water_storage} Liter"); timer = 10; while (timer != 0) { Console.SetCursorPosition(0, 15); Console.WriteLine($"Kehre zur Optionsauswahl zurück in {timer}..."); timer--; System.Threading.Thread.Sleep(1000); } library(); break;
            }
        }
    }
}
