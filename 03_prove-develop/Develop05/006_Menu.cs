namespace Develop05
{
    public class Menu
    {
        // ————————————————————————————————————————————————————————————————————————————————————————
        // ATTRIBUTES
        // ————————————————————————————————————————————————————————————————————————————————————————

        // A1....................................
        private string _title;
        // A2....................................
        private List<string> _options;
        // A3....................................
        private string _inputPrompt;

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // CONSTRUCTORS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // C1....................................
        public Menu(string title, List<string> options, string inputPrompt = "> Select an option (number): ")
        // Parameters: (1) title, (2) options, (3) inputPrompt, (4) suffix
        {
            _title = title;
            _options = options;
            _inputPrompt = inputPrompt;
        }

        //
        //
        //
        //
        //

        // ————————————————————————————————————————————————————————————————————————————————————————
        // METHODS
        // ————————————————————————————————————————————————————————————————————————————————————————

        // M1....................................
        public int GetValidatedMenuSelection()
        {
            int selection = -1;
            bool valid = false;

            do
            {
                Console.WriteLine($"{_title}");
                for (int i = 0; i < _options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_options[i]}");
                }

                Console.Write(_inputPrompt);
                string input = Console.ReadLine()?.Trim();

                if (int.TryParse(input, out selection) && selection >= 1 && selection <= _options.Count)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try again.\n");
                }

            } while (!valid);

            return selection; // One-based index
        }

        // M2....................................
        public string GetSelectedMenuOption()
        {
            int index = GetValidatedMenuSelection();
            return _options[index - 1]; // Convert to zero-based index
        }

    }
}
