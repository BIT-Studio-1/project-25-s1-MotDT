
using System.Runtime.CompilerServices;

namespace Studio_1
{
    internal class Selector
    {
        static ConsoleKey InitialKey = ConsoleKey.Spacebar;
        static ConsoleKey UpKey = ConsoleKey.UpArrow;
        static ConsoleKey DownKey = ConsoleKey.DownArrow;
        static ConsoleKey SubmitKey = ConsoleKey.Enter;
        const string SelectedTemplate = "\x1b[92m\x1b[1m▶ {0}\x1b[0m";
        const string DefaultTemplate = "  {0}";

        /// <summary> Wrapper function around SelectorMenuString. Creates a selection menu that can be navigated by arrow keys.
        //  Takes an array of strings to show as options, returns the selected string from the options. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string DefaultSelectorMenu(string[] options,string header) {
            return options[SelectorMenuString(options,header,SelectedTemplate,DefaultTemplate)];
        }

        /// <summary> Wrapper function around SelectorMenuString. Creates a selection menu that can be navigated by arrow keys. For Yes/No Dialog. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BoolSelectorMenu(string header) {
            return SelectorMenuString(["YES","NO"],header,SelectedTemplate,DefaultTemplate) == 0;
        }
        
        /// <summary> Creates a selection menu that can be navigated by arrow keys. Takes an array of strings to show as options, returns the selected option's index. </summary>
        public static int SelectorMenuString(string[] options,string header,string selectedTemplate, string defaultTemplate)
        {
            int selection = 0;
            Console.Write(header);
            RenderSelectionList(options, selection,selectedTemplate,defaultTemplate);

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
                RenderSelectionList(options, selection, selectedTemplate,defaultTemplate);

                KeyBuffer = Console.ReadKey().Key;
            }
            return selection;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void RenderSelectionList(string[] options, int index,string selectedTemplate, string defaultTemplate)
        {
            foreach (var (value, i) in options.Select((value, i) => (value, i)))
            {
                // Prints out the option, but cooses the format string depending on if it is the current option.
                Console.WriteLine(String.Format(i == index ? selectedTemplate : defaultTemplate, value));
            }
        }

        // Somehow working
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int mat_mod(int x, int m)
        {
            return (x % m + m) % m;
        }

    }
    // Console.WriteLine(dir);
}
