namespace TextAdventure
{
    internal class Animation
    {
        public static void title()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            #if (WINDOWS)
                Console.Beep(1000, 400);
            #endif
            Thread.Sleep(500);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            #if (WINDOWS)
                Console.Beep(1500, 400);
            #endif
            Thread.Sleep(500);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();
            #if (WINDOWS)
                Console.Beep(2000, 400);
            #endif
            Thread.Sleep(500);
            Console.BackgroundColor = ConsoleColor.Black;
            #if (WINDOWS)
                Console.Beep(2500, 400);
            #endif
            Console.Clear();
            Console.WriteLine("   ___                                                               __        ___                                    ");
            Thread.Sleep(200);
            Console.WriteLine("  / _ \\ __ __  ___   ___ _ ___  ___   ___   ___      ___ _  ___  ___/ /       / _ \\  ____ ___ _  ___ _ ___   ___   ___\r");
            Thread.Sleep(200);
            Console.WriteLine(" / // // // / / _ \\ / _ `// -_)/ _ \\ / _ \\ (_-<     / _ `/ / _ \\/ _  /       / // / / __// _ `/ / _ `// _ \\ / _ \\ (_-<");
            Thread.Sleep(200);
            Console.WriteLine("/____/ \\_,_/ /_//_/ \\_, / \\__/ \\___//_//_//___/     \\_,_/ /_//_/\\_,_/       /____/ /_/   \\_,_/  \\_, / \\___//_//_//___/");
            Thread.Sleep(200);
            Console.WriteLine("                   /___/                                                                       /___/                  ");
            Thread.Sleep(200);
        }
        public static void Start()
        { 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("             ║     ║    ╔═══╗");
            Console.WriteLine("╔═══╗        ║     ║    ║▓▓▓║");
            Console.WriteLine("║░P░║        ║     ║    ║▓▓▓║");
            Console.WriteLine("╠   ╩════════╝XXXXX╚════╩   ╩══════╗");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("╠    ═╦═════════════════╦   ╦══════╝");
            Console.WriteLine("║▒▒▒▒▒║                 ║░░░║");
            Console.WriteLine("║▒▒▒▒▒║                 ╚═══╝");
            Console.WriteLine("║▒▒▒▒▒║");
            Console.WriteLine("╚═════╝");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void StoreRoom()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("             ║     ║    ╔═══╗");
            Console.WriteLine("╔═══╗        ║     ║    ║▓▓▓║");
            Console.WriteLine("║░░░║        ║     ║    ║▓▓▓║");
            Console.WriteLine("╠   ╩════════╝XXXXX╚════╩   ╩══════╗");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("╠    ═╦═════════════════╦   ╦══════╝");
            Console.WriteLine("║▒▒▒▒▒║                 ║░░░║");
            Console.WriteLine("║▒▒P▒▒║                 ╚═══╝");
            Console.WriteLine("║▒▒▒▒▒║");
            Console.WriteLine("╚═════╝");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Hall()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("             ║     ║    ╔═══╗");
            Console.WriteLine("╔═══╗        ║     ║    ║▓▓▓║");
            Console.WriteLine("║░░░║        ║     ║    ║▓▓▓║");
            Console.WriteLine("╠   ╩════════╝XXXXX╚════╩   ╩══════╗");
            Console.WriteLine("║               P                  ║");
            Console.WriteLine("╠    ═╦═════════════════╦   ╦══════╝");
            Console.WriteLine("║▒▒▒▒▒║                 ║░░░║");
            Console.WriteLine("║▒▒▒▒▒║                 ╚═══╝");
            Console.WriteLine("║▒▒▒▒▒║");
            Console.WriteLine("╚═════╝");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void GuardRoom()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("             ║     ║    ╔═══╗");
            Console.WriteLine("╔═══╗        ║     ║    ║▓M▓║");
            Console.WriteLine("║░░░║        ║     ║    ║▓P▓║");
            Console.WriteLine("╠   ╩════════╝XXXXX╚════╩   ╩══════╗");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("╠    ═╦═════════════════╦   ╦══════╝");
            Console.WriteLine("║▒▒▒▒▒║                 ║░░░║");
            Console.WriteLine("║▒▒▒▒▒║                 ╚═══╝");
            Console.WriteLine("║▒▒▒▒▒║");
            Console.WriteLine("╚═════╝");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void TesasureRoom()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("             ║     ║    ╔═══╗");
            Console.WriteLine("╔═══╗        ║     ║    ║▓▓▓║");
            Console.WriteLine("║░░░║        ║     ║    ║▓▓▓║");
            Console.WriteLine("╠   ╩════════╝XXXXX╚════╩   ╩══════╗");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("╠    ═╦═════════════════╦ P ╦══════╝");
            Console.WriteLine("║▒▒▒▒▒║                 ║░M░║");
            Console.WriteLine("║▒▒▒▒▒║                 ╚═══╝");
            Console.WriteLine("║▒▒▒▒▒║");
            Console.WriteLine("╚═════╝");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void GameOver()
        {
            Console.Clear();
            string border = new string('=', 75);
            Console.WriteLine(border);
            Console.WriteLine("                         Game Over");
            Console.WriteLine(border);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n");
            Thread.Sleep(1000);
            Console.WriteLine("                       ____    _________");
            Thread.Sleep(500);
            Console.WriteLine("                     /     \\ /           \\     ");
            Thread.Sleep(500);
            Console.WriteLine("                    /                      \\  ");
            Thread.Sleep(500);
            Console.WriteLine("                    /  ___            ___   \\  ");
            Thread.Sleep(500);
            Console.WriteLine("                   /  /   \\__      __/   \\   \\ ");
            Thread.Sleep(500);
            Console.WriteLine("                  |   \\      | __ |      /   |  ");
            Thread.Sleep(500);
            Console.WriteLine("                  /    \\____/ :..: \\____/     \\ ");
            Thread.Sleep(500);
            Console.WriteLine("                 |__  .      / ;: \\          __| ");
            Thread.Sleep(500);
            Console.WriteLine("                    ~--_     --  --      _--~   ");
            Thread.Sleep(500);
            Console.WriteLine("                    |  ||               ||  |   ");
            Thread.Sleep(500);
            Console.WriteLine("                    |  ||_             _||  |  ");
            Thread.Sleep(500);
            Console.WriteLine("                    :  |  ~V+-I_I_I-+V~  |  : ");
            Thread.Sleep(500);
            Console.WriteLine("                    \\:  T\\   _     _   /T  : ");
            Thread.Sleep(500);
            Console.WriteLine("                     :    T^T T-+-T T^T    ;");
            Thread.Sleep(500);
            Console.WriteLine("                      `_       -+-       _'  ");
            Thread.Sleep(500);
            Console.WriteLine("                        `--=.._____..=--'       ");
            Thread.Sleep(500);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("                       ____    _________");
            Console.WriteLine("                     /     \\ /           \\     ");
            Console.WriteLine("                    /                      \\  ");
            Console.WriteLine("                    /  ___            ___   \\  ");
            Console.WriteLine("                   /  /   \\__      __/   \\   \\ ");
            Console.WriteLine("                  |   \\      | __ |      /   |  ");
            Console.WriteLine("                  /    \\____/ :..: \\____/     \\ ");
            Console.WriteLine("                 |__  .      / ;: \\          __| ");
            Console.WriteLine("                    ~--_     --  --      _--~   ");
            Console.WriteLine("                    |  ||               ||  |   ");
            Console.WriteLine("                    |  ||_             _||  |  ");
            Console.WriteLine("                    :  |  ~V+-I_I_I-+V~  |  : ");
            Console.WriteLine("                    \\:  T\\   _     _   /T  : ");
            Console.WriteLine("                     :    T^T T-+-T T^T    ;");
            Console.WriteLine("                      `_       -+-       _'  ");
            Console.WriteLine("                        `--=.._____..=--'       ");
            Thread.Sleep(400);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n");
            Console.WriteLine("                             (                   ");
            Console.WriteLine("                .            )        )");
            Console.WriteLine("                         (  (|              .");
            Console.WriteLine("                     )   )\\/ ( ( (");
            Console.WriteLine("             *  (   ((  /     ))\\))  (  )    )");
            Console.WriteLine("           (     \\   )\\(          |  ))( )  (|");
            Console.WriteLine("           >)     ))/   |          )/  \\((  ) \\");
            Console.WriteLine("           (     (      .        -.     V )/   )(    (");
            Console.WriteLine("            \\   /     .   \\            .       \\))   ))");
            Console.WriteLine("              )(      (  | |   )            .    (  /");
            Console.WriteLine("             )(    ,'))     \\ /          \\( `.    )");
            Console.WriteLine("             (\\>  ,'/__      ))            __`.  /");
            Console.WriteLine("            ( \\   | /  ___   ( \\/     ___   \\ | ( (");
            Console.WriteLine("             \\.)  |/  /   \\__      __/   \\   \\|  ))");
            Console.WriteLine("            .  \\. |>  \\      | __ |      /   <|  /");
            Console.WriteLine("                 )/    \\____/ :..: \\____/     \\ <");
            Console.WriteLine("          )   \\ (|__  .      / ;: \\          __| )  (");
            Console.WriteLine("         ((    )\\)  ~--_     --  --      _--~    /  ))");
            Console.WriteLine("          \\    (    |  ||               ||  |   (  /");
            Console.WriteLine("                \\.  |  ||_             _||  |  /");
            Console.WriteLine("                  > :  |  ~V+-I_I_I-+V~  |  : (.");
            Console.WriteLine("                 (  \\:  T\\   _     _   /T  : ./");
            Console.WriteLine("                  \\  :    T^T T-+-T T^T    ;<");
            Console.WriteLine("                   \\..`_       -+-       _'  )");
            Console.WriteLine("                      . `--=.._____..=--'. ./        ");
            Thread.Sleep(400);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\n\n");
            Console.WriteLine("                             (                   ");
            Console.WriteLine("                .            )        )");
            Console.WriteLine("                         (  (|              .");
            Console.WriteLine("                     )   )\\/ ( ( (");
            Console.WriteLine("             *  (   ((  /     ))\\))  (  )    )");
            Console.WriteLine("           (     \\   )\\(          |  ))( )  (|");
            Console.WriteLine("           >)     ))/   |          )/  \\((  ) \\");
            Console.WriteLine("           (     (      .        -.     V )/   )(    (");
            Console.WriteLine("            \\   /     .   \\            .       \\))   ))");
            Console.WriteLine("              )(      (  | |   )            .    (  /");
            Console.WriteLine("             )(    ,'))     \\ /          \\( `.    )");
            Console.WriteLine("             (\\>  ,'/__      ))            __`.  /");
            Console.WriteLine("            ( \\   | /  ___   ( \\/     ___   \\ | ( (");
            Console.WriteLine("             \\.)  |/  /   \\__      __/   \\   \\|  ))");
            Console.WriteLine("            .  \\. |>  \\      | __ |      /   <|  /");
            Console.WriteLine("                 )/    \\____/ :..: \\____/     \\ <");
            Console.WriteLine("          )   \\ (|__  .      / ;: \\          __| )  (");
            Console.WriteLine("         ((    )\\)  ~--_     --  --      _--~    /  ))");
            Console.WriteLine("          \\    (    |  ||               ||  |   (  /");
            Console.WriteLine("                \\.  |  ||_             _||  |  /");
            Console.WriteLine("                  > :  |  ~V+-I_I_I-+V~  |  : (.");
            Console.WriteLine("                 (  \\:  T\\   _     _   /T  : ./");
            Console.WriteLine("                  \\  :    T^T T-+-T T^T    ;<");
            Console.WriteLine("                   \\..`_       -+-       _'  )");
            Console.WriteLine("                      . `--=.._____..=--'. ./        ");
            Thread.Sleep(400);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Combat()
        {
            Console.Clear();
            string border = new string('=', 75);
            Console.WriteLine(border);
            Console.WriteLine("                         Combat Begins");
            Console.WriteLine(border);
            Console.WriteLine("\n\n\n\n\n\n\n");
            Thread.Sleep(1000);
            Console.WriteLine("            _");
            Thread.Sleep(500);
            Console.WriteLine(" _         | |");
            Thread.Sleep(500);
            Console.WriteLine("| | _______| |---------------------------------------------\\");
            Thread.Sleep(500);
            Console.WriteLine("|:-)_______|==[]============================================>");
            Thread.Sleep(500);
            Console.WriteLine("|_|        | |---------------------------------------------/");
            Thread.Sleep(500);
            Console.WriteLine("           |_|");
            Thread.Sleep(500);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("            _");
            Console.WriteLine(" _         | |");
            Console.WriteLine("| | _______| |---------------------------------------------\\");
            Console.WriteLine("|:-)_______|==[]============================================>");
            Console.WriteLine("|_|        | |---------------------------------------------/");
            Console.WriteLine("           |_|");
            Thread.Sleep(400);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("            _");
            Console.WriteLine(" _         | |");
            Console.WriteLine("| | _______| |---------------------------------------------\\");
            Console.WriteLine("|:-)_______|==[]============================================>");
            Console.WriteLine("|_|        | |---------------------------------------------/");
            Console.WriteLine("           |_|");
            Thread.Sleep(400);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("            _");
            Console.WriteLine(" _         | |");
            Console.WriteLine("| | _______| |---------------------------------------------\\");
            Console.WriteLine("|:-)_______|==[]============================================>");
            Console.WriteLine("|_|        | |---------------------------------------------/");
            Console.WriteLine("           |_|");
            Thread.Sleep(400);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Victory()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("            88                                                       ");
                Console.WriteLine("            \"\"              ,d                                      ");
                Console.WriteLine("                            88                                       ");
                Console.WriteLine("8b       d8 88  ,adPPYba, MM88MMM ,adPPYba,  8b,dPPYba, 8b       d8  ");
                Console.WriteLine("`8b     d8' 88 a8\"     \"\"   88   a8\"     \"8a 88P'   \"Y8 `8b     d8'  ");
                Console.WriteLine(" `8b   d8'  88 8b           88   8b       d8 88          `8b   d8'   ");
                Console.WriteLine("  `8b,d8'   88 \"8a,   ,aa   88,  \"8a,   ,a8\" 88           `8b,d8'   ");
                Console.WriteLine("    \"8\"     88  `\"Ybbd8\"'   \"Y888 `\"YbbdP\"'  88             Y88'     ");
                Console.WriteLine("                                                            d8'      ");
                Thread.Sleep(300);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("            88                                                       ");
                Console.WriteLine("            \"\"              ,d                                      ");
                Console.WriteLine("                            88                                       ");
                Console.WriteLine("8b       d8 88  ,adPPYba, MM88MMM ,adPPYba,  8b,dPPYba, 8b       d8  ");
                Console.WriteLine("`8b     d8' 88 a8\"     \"\"   88   a8\"     \"8a 88P'   \"Y8 `8b     d8'  ");
                Console.WriteLine(" `8b   d8'  88 8b           88   8b       d8 88          `8b   d8'   ");
                Console.WriteLine("  `8b,d8'   88 \"8a,   ,aa   88,  \"8a,   ,a8\" 88           `8b,d8'   ");
                Console.WriteLine("    \"8\"     88  `\"Ybbd8\"'   \"Y888 `\"YbbdP\"'  88             Y88'     ");
                Console.WriteLine("                                                            d8'      ");
                Thread.Sleep(300);
                Console.Clear();
            }
            Thread.Sleep(500);
        }

    }
}
