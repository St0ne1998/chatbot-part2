using System;
using System.Threading;

namespace CybersecurityBot
{
    public static class BotUI
    {
        public static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================================");
            Console.WriteLine(@"            .---.            ");
            Console.WriteLine(@"           /     \           ");
            Console.WriteLine(@"           | () () |         ");
            Console.WriteLine(@"           \  \_/  /  < [ Squawk! Welcome to WEchat Security Bot ]");
            Console.WriteLine(@"            `---`            ");
            Console.WriteLine(@"           /     \           ");
            Console.WriteLine(@"          /|     |\          ");
            Console.WriteLine(@"         / |     | \         ");
            Console.WriteLine(@"  __  __ _____ _          _           ____        _   ");
            Console.WriteLine(@" |  \/  | ____| |__   ___| |__   __ _| __ )  ___ | |_ ");
            Console.WriteLine(@" | |\/| |  _| | '_ \ / __| '_ \ / _` |  _ \ / _ \| __|");
            Console.WriteLine(@" | |  | | |___| | | | (__| | | | (_| | |_) | (_) | |_ ");
            Console.WriteLine(@" |_|  |_|_____|_| |_|\___|_| |_|\__,_|____/ \___/ \__|");
            Console.WriteLine("==================================================================");
            Console.ResetColor();
        }

        public static void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------------------------------------------");
            Console.ResetColor();
        }

        public static void TypeWriterEffect(string message, ConsoleColor color = ConsoleColor.White, int delay = 15)
        {
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}