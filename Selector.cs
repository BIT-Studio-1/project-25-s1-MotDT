
using System.Runtime.CompilerServices;

namespace Studio_1
{
    internal class Selector
    {

        static ConsoleKey InitialKey = ConsoleKey.Spacebar;
        static ConsoleKey UpKey = ConsoleKey.UpArrow;
        static ConsoleKey DownKey = ConsoleKey.DownArrow;
        static ConsoleKey SubmitKey = ConsoleKey.Enter;
        const string SelectedTemplate = "\x1b[92m> {0}\x1b[0m";
        const string DefaultTemplate = "  {0}";

        /// <summary> Creates a selection menu that can be navigated by arrow keys. Takes an array of strings to show as options, returns the selected option. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SelectorMenuString(string[] options)
        {
            int selection = 1;
            Console.WriteLine("-- Select --");
            RenderSelectionList(options, selection);

            ConsoleKey KeyBuffer = InitialKey;
            // Repeat and refresh
            while (KeyBuffer != SubmitKey)
            {
                // I HATE THIS BUT IT WORKS
                if (KeyBuffer == UpKey)
                {
                    selection = mat_mod(selection - 1, options.Length);
                }
                else if (KeyBuffer == DownKey)
                {
                    selection = mat_mod(selection + 1, options.Length);
                }
                Console.SetCursorPosition(0, Console.CursorTop - options.Length);
                RenderSelectionList(options, selection);

                KeyBuffer = Console.ReadKey().Key;
            }
            return options[selection];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void RenderSelectionList(string[] options, int index)
        {
            foreach (var (value, i) in options.Select((value, i) => (value, i)))
            {
                // Prints out the option, but cooses the format string depending on if it is the current option.
                Console.WriteLine(String.Format(i == index ? SelectedTemplate : DefaultTemplate, value));
            }
        }

        // Somehow working
        static int mat_mod(int x, int m)
        {
            return (x % m + m) % m;
        }

    }
    // Console.WriteLine(dir);
}
