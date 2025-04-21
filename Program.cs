namespace LexiconEx4
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>

        //F:Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
        //A: Stacken är Snabbt minne som används för värdetyper (value types) och metodanrop. Den allokeras och frigörs automatiskt.Följer principen "Last In, First Out" (LIFO).
        //Heapen Större och lite långsammare minne som används för referenstyper. Kräver Garbage Collector för att frigöra minne.

        //F: Vad är Value Types respektive Reference Types och vad skiljer dem åt?
        //A: är Value Types datatyper som lagrar sitt värde direkt, medan Reference Types lagrar en referens (pekare) till ett objekt i minnet.
        //Skillnaden är att Value Types kopieras vid tilldelning, medan Reference Types pekar på samma minnesplats.
        //Exempel på Value Types är struct som int och double, medan classer som string, delegate, lists är Reference Types.

        //F:Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
        //A: För att operationen y = x i ReturnValue2 så sets y till att peka på samma instans av classen MyInt som x. 
        static void Main()
        {

            while (true)
            {

                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Fibonacci sequence"
                    + "\n6. Even number"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        Fibo();
                        break;
                    case '6':
                        Iterative();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            //F: När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
            //A: När man leger till ett värde över des nuvarande kapacitet.
            //
            //F:Med hur mycket ökar kapaciteten?
            //A:Det dublas.

            //F:Varför ökar inte listans kapacitet i samma takt som element läggs till?
            //A:För att varge gång den ökar sin kapacitet so skapar den en ny lista på heapen
            //och det är inte bra för prestanda och minneshantering att göra det för många gånger.

            //F:Minskar kapaciteten när element tas bort ur listan?
            //A: Nej.

            //F:När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            //A:när man vet storleken i förväg och behöver bättre prestanda och minneshantering.
            List<int> list = new List<int>();
            while (true)
            {
                Console.WriteLine(
                    $" write a positiv number to add that number of ellements to the list \n" +

                $" write a negativ number to remove that number of ellements to the list \n" +
                $" write 0 to go back");

                int input;
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input > 0) for (int i = 0; i < input; i++)
                        {
                            list.Add(i);
                            Console.WriteLine($" list cont: {list.Count} List cap: {list.Capacity}");
                        }
                    else if (input < 0) for (int i = 0; i > input; i--)
                        {
                            if (list.Count == 0)
                            {
                                Console.WriteLine("can not have negativ number of elements");
                                break;
                            }
                            list.RemoveAt(0);
                            Console.WriteLine($" list cont: {list.Count} List cap: {list.Capacity}");
                        }
                    else break;

                }
                catch (Exception)
                {

                    throw;
                }
            }
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> queue = new Queue<string>();
            char input = ' ';
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2,  0) of your choice"
                       + "\n1. Add custemer to queue"
                       + "\n2. Dequeue a custemer"

                       + "\n0. Go back");
                try
                {
                    input = Console.ReadLine()![0];
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                if (input == '0') break;
                switch (input)
                {

                    case '1':
                        Console.Write("Custemer name: ");
                        queue.Enqueue(Console.ReadLine());
                        Console.WriteLine($"queue count: {queue.Count} ");
                        break;
                    case '2':
                        Console.WriteLine($"{queue.Dequeue} has left the queue \n queue count: {queue.Count} ");
                        break;
                    default: break;
                }


            }
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Console.Write("What to revers: ");

            Stack<char> stack = new Stack<char>(Console.ReadLine().ToCharArray());
            foreach (char c in stack) Console.Write(c);
            Console.WriteLine("");
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            char[] input = Console.ReadLine().ToCharArray();
            int i=-1;
            bool corekt = true;
            check(null);
            
            Console.WriteLine(corekt);
            void check(char? end) {
                //if (!corekt) break; // om du vill att koden ska sluta sofårt som den har hittat ett fel
                for (i++; i < input.Length; i++)
                {
                    if (input[i] == '(') check(')');
                    else if (input[i] == '{') check('}');
                    else if (input[i] == '[') check(']');
                    else if (input[i] == end) return;
                    else if (input[i] == '}' || input[i] == ']' || input[i] == ')') {
                        corekt = false; 
                        Console.WriteLine($"charecter {i+1} could be {end}");
                        return; }

                    
                }
                if (end != null)
                {
                    Console.WriteLine($"Missing a {end}");
                    corekt = false;
                }
            }
            


        }
        static void Fibo()
        {
            uint input=0;
            Console.WriteLine("Write a positiv number");
            try
            {
                 input = uint.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong input");

            }
            Console.WriteLine(fibo(input));
            uint fibo(uint input) {
            if(input <= 1) return 0;
            if(input <= 2) return 1;
            return fibo(input-1)+fibo(input-2);
            
            }
        }
        static void Iterative()
        {
            Console.WriteLine("Write a positiv number");
            try
            {
                Console.WriteLine(IterativeEven(int.Parse(Console.ReadLine())));
            }
            catch (FormatException) {
                Console.WriteLine("Wrong input");
            }
            int IterativeEven(int n)
            {
                int output = 0;
                for (int i = 0; i < n; i++) {
                    output += 2;
                }
                return output;
                //F:Utgå ifrån era nyvunna kunskaper om iteration, rekursion och minneshantering. Vilken av
                //ovanstående funktioner är mest minnesvänlig och varför?
                //A:iteration, eftersom varje rekursivt anrop lägger till en ny ram i stacken.
                //medans iterativt anrop jober med samma  ram i stacken.
            }
        }
}

