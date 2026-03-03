namespace Studio_1
{
    internal class Selector
    {
        const ConsoleKey InitialKey = ConsoleKey.Spacebar;
        const ConsoleKey UpKey = ConsoleKey.UpArrow;
        const ConsoleKey DownKey = ConsoleKey.DownArrow;
        const ConsoleKey SubmitKey = ConsoleKey.Enter;
        const string SelectedTemplate = "\x1b[92m\x1b[1m◆ {0}\x1b[0m";
        const string DefaultTemplate = "  {0}";

        /// <summary> Wrapper function around SelectorMenuString. Creates a selection menu that can be navigated by arrow keys. Takes an array of strings to show as options, returns the selected string from the options. </summary>
        public static string DefaultSelectorMenu(string[] options, string header)
        {
            Console.WriteLine(header);
            return options[SelectorMenuString(options, SelectedTemplate, DefaultTemplate)];
        }

        /// <summary> Wrapper function around SelectorMenuString. Creates a selection menu that can be navigated by arrow keys. For Yes/No Dialog. </summary>
        public static bool BoolSelectorMenu(string header)
        {
            Console.WriteLine(header);
            return SelectorMenuString(["YES", "NO"], SelectedTemplate, DefaultTemplate) == 0;
        }

        /// <summary> Creates a selection menu that can be navigated by arrow keys. Takes an array of strings to show as options, returns the selected option's index. </summary>
        public static int SelectorMenuString(string[] options, string selectedTemplate, string defaultTemplate)
        {
            // Init the selection variable to the first element.
            int selection = 0;
            // Initialize the keybuffer to a key that does nothing. 
            ConsoleKey KeyBuffer = InitialKey;
            // Initially render the list.
            RenderSelectionList(options, selection, selectedTemplate, defaultTemplate);

            // Repeat and refresh until the submitkey is pressed (usually ENTER)
            while (KeyBuffer != SubmitKey)
            {
                // Check for keyboard input and react accordingly.
                switch (KeyBuffer)
                {
                    case UpKey:
                        selection = mat_mod(selection - 1, options.Length);
                        break;
                    case DownKey:
                        selection = mat_mod(selection + 1, options.Length);
                        break;
                    default:
                        break;
                }
                // Set the cursor position to the top.
                Console.SetCursorPosition(0, Console.CursorTop - options.Length);
                // Render/Update the selection list.
                RenderSelectionList(options, selection, selectedTemplate, defaultTemplate);
                // Read keystroke and assign KeyBuffer to the result.
                KeyBuffer = Console.ReadKey().Key;
            }
            // Return final selection value
            return selection;
        }
        ///<summary> Renders all options in a series of lines. int index: the 0-indexed entry that is the currently selected option. selectedTemplate is the format string for the option that is selected. defaultTemplate is used for other options. </summary>
        static void RenderSelectionList(string[] options, int index, string selectedTemplate, string defaultTemplate)
        {
            // Iterate through (value,index) pairs in a loop, so we can compare them with the selection index.
            foreach (var (value, i) in options.Select((value, i) => (value, i)))
            {
                // Prints out the option, but chooses the format string depending on if it is the current option.
                Console.WriteLine(String.Format(i == index ? selectedTemplate : defaultTemplate, value));
            }
        }

        ///<summary> Function used to make Selector index conform to length by looping around, because % does not handle negative numbers well, and Math has no suitable function. </summary>
        static int mat_mod(int x, int m)
        {
            return (x % m + m) % m;
        }

    }
}
