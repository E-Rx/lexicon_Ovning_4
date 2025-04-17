using System;

namespace SkalProj_Datastrukturer_Minne;

  class Program
  {
    /// <summary>
    /// The main method, vill handle the menues for the program
    /// </summary>
    /// <param name="args"></param>
    static void Main()
    {

      while (true)
      {
        Console.WriteLine(" == Main Menu =="
          + "\n\nPlease navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
          + "\n\n1. Examine a List"
          + "\n2. Examine a Queue"
          + "\n3. Examine a Stack"
          + "\n4. CheckParenthesis"
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
        /*
          * Loop this method untill the user inputs something to exit to main menue.
          * Create a switch statement with cases '+' and '-'
          * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
          * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
          * In both cases, look at the count and capacity of the list
          * As a default case, tell them to use only + or -
          * Below you can see some inspirational code to begin working.
        */

        // Create a list of strings
        List<string> theList = new List<string>();

        // Create a boolean to control the loop
        bool stayInListMenu = true;

        while (stayInListMenu)
        {
          Console.WriteLine("\n== List Menu =="
            + "\n\nPlease Enter a command:"
            + "\n +Name  → Add a person to the list     (ex: +Adam)"
            + "\n -Name  → Remove a person from the list (ex: -Adam)"
            + "\n L      → Display the current list"
            + "\n 0      → Return to main menu");


            string input = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrEmpty(input))
            {
              Console.WriteLine("Please enter some input!");
              continue;
            }

            char nav = input[0];
            string value = input.Length > 1 ? input.Substring(1) : string.Empty;

            switch (nav)
            {
              case '+':
                theList.Add(value);
                Console.WriteLine($"Added '{value}' to the list");
                break;
              case '-':
                if (theList.Remove(value))
                  Console.WriteLine($"Removed '{value}' from the list");
                else
                  Console.WriteLine($"'{value}' was not found in the list");
                break;
              case 'L':
              case 'l':
                Console.WriteLine("The list contains: ");
                if (theList.Count == 0)
                {
                  Console.WriteLine("(empty)");
                }
                else
                {
                  foreach (string item in theList)
                  {
                    Console.WriteLine(item);
                  }
                }
                foreach (string item in theList)
                {
                  Console.WriteLine(item);
                }
              break;
              case '0':
                Console.WriteLine("Returning to main menu...");
                Console.Clear();
                return;
              default:
                Console.WriteLine("Please enter a valid command");
                break;
            }

            Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

          /*
        * Svar på frågorna:
        *
        * 2. När ökar listans kapacitet?
        *    Kapaciteten ökar när ett nytt element läggs till.
        *
        * 3. Med hur mycket ökar kapaciteten?
        *    Kapaciteten fördubblas varje gång den måste ökas.
        *
        * 4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
        *    För att det ska gå snabbare. Att ändra minnet tar tid,
        *    så det är bättre att göra det mer sällan genom att spara lite extra minne.
        *
        * 5. Minskar kapaciteten när element tas bort ur listan?
        *    Nej, kapaciteten behåller sin maximala värde som uppnåtts.
        *
        * 6. När är det fördelaktigt att använda en egendefinierad array istället för en lista?
        *    - När man vet i förväg exakt hur många element som behövs
        *    - När man behöver optimera minnesanvändningen
        *    - När storleken inte kommer att ändras under programmets körning
        */
      }




      /// <summary>
      /// Examines the datastructure Queue
      /// </summary>
      static void ExamineQueue()
      {
        /*
          * Loop this method untill the user inputs something to exit to main menue.
          * Create a switch with cases to enqueue items or dequeue items
          * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */

        // Create a queue of strings
        Queue<string> theQueue = new Queue<string>();

        // Create a boolean to control the loop
        bool running = true;

        // Loop until the user chooses to exit
        while (running)
        {
          Console.WriteLine("\n== Queue Menu =="
              + "\n\nPlease Enter a command:"
              + "\n add (name) → Add a person to the queue (ex: add Adam)"
              + "\n next       → Serve the next person in line (ex: next)"
              + "\n show       → Display the current queue"
              + "\n ICA        → Run the ICA queue simulation"
              + "\n 0          → Return to main menu");

          // Get the users input
          string input = Console.ReadLine() ?? string.Empty;
          if (string.IsNullOrEmpty(input))
          {
              Console.WriteLine("Please enter some input!");
              continue;
          }

          // Split the input into command and value
          string[] parts = input.Split(' ', 2);
          string command = parts[0].ToLower();

          switch (command)
          {
            case "add":
              string name = parts[1];
              theQueue.Enqueue(name);
              Console.WriteLine($"Added {name} to the queue");
              PrintQueue(theQueue);
              break;
            case "next":
              if (theQueue.Count > 0)
              {
                string nextPerson = theQueue.Dequeue();
                Console.WriteLine($"Serving {nextPerson}");
              }
              else
              {
                Console.WriteLine("The queue is empty");
              }
              PrintQueue(theQueue);
              break;
            case "show":
              PrintQueue(theQueue);
              break;
            case "ica":
            case "ICA":
              SimulateIcaQueue();
              break;
            case "0":
              Console.WriteLine("Returning to main menu...");
              running = false;
              Console.Clear();
              return;

            default:
              Console.WriteLine("Please enter a valid command");
              break;
          }
        }
      }

      private static void PrintQueue(Queue<string> theQueue)
      {
        Console.WriteLine($"People in queue: {theQueue.Count}");
        if (theQueue.Count == 0)
        {
          Console.WriteLine("None in queue");
        }

        // Convert the queue to an array for easier printing (because the queue is short)
        string[] people = theQueue.ToArray();

        //Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("FIRST : ");
        //Console.ResetColor();

        for (int i = 0; i < people.Length; i++)
        {
          Console.Write($"{i+1}. {people[i]}");
          if (i < people.Length - 1)
          {
              Console.Write(" <- ");
          }
        }

        Console.WriteLine(" -- END");
      }

      private static void SimulateIcaQueue()
      {
        Queue<string> icaQueue = new Queue<string>();

        Console.WriteLine("\n--- ICA Queue Simulation ---");

        // a. ICA opens and the queue is empty
        Console.WriteLine("\na. ICA opens and the queue is empty");
        PrintQueue(icaQueue);

        // b. Kalle gets in line
        Console.WriteLine("\nb. Kalle gets in line");
        icaQueue.Enqueue("Kalle");
        PrintQueue(icaQueue);

        // c. Greta gets in line
        Console.WriteLine("\nc. Greta gets in line");
        icaQueue.Enqueue("Greta");
        PrintQueue(icaQueue);

        // d. Kalle is served
        Console.WriteLine("\nd. Kalle is served and leaves the queue");
        string servedPerson = icaQueue.Dequeue();
        Console.WriteLine($"Ciao {servedPerson}");
        PrintQueue(icaQueue);

        // e. Stina gets in line
        Console.WriteLine("\ne. Stina gets in line");
        icaQueue.Enqueue("Stina");
        PrintQueue(icaQueue);

        // f. Greta is served and leaves the queue
        Console.WriteLine("\nf. Greta is served and leaves the queue");
        servedPerson = icaQueue.Dequeue();
        Console.WriteLine($"Ciao {servedPerson}");
        PrintQueue(icaQueue);

        // g. Olle gets in line
        Console.WriteLine("\ng. Olle gets in line");
        icaQueue.Enqueue("Olle");
        PrintQueue(icaQueue);

        Console.WriteLine("\nICA queue simulation completed.");
      }




        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
      static void ExamineStack()
      {
        /*
          * Loop this method until the user inputs something to exit to main menue.
          * Create a switch with cases to push or pop items
          * Make sure to look at the stack after pushing and and poping to see how it behaves
          *
        */

        // Create a stack of strings
        Stack<string> theStack = new Stack<string>();

        // Create a boolean to control the loop
        bool running = true;

        // Loop until the user chooses to exit
        while (running)
        {

          // Display the menu
          Console.WriteLine("\n== Stack Menu =="
          + "\n\nPlease Enter a command:"
          + "\n push (name) → Push a person onto the stack (ex: push Adam)"
          + "\n pop         → Pop the top person from the stack (ex: pop)"
          + "\n show        → Display the current stack"
          + "\n ICA         → Run the ICA queue simulation (stack version)"
          + "\n text        → Enter text to reverse"
          + "\n 0           → Return to main menu");

          // Get user input
          string input = Console.ReadLine() ?? string.Empty;
          if (string.IsNullOrEmpty(input))
          {
            Console.WriteLine("Please enter some input!");
            continue;
          }

          // Split the input into command and value
          string[] parts = input.Split(' ', 2);
          string command = parts[0].ToLower();

          switch (command)
          {
            case "push":
              if (parts.Length < 2)
              {
                Console.WriteLine("Please provide a name to push onto the stack");
                break;
              }
              string name = parts[1];
              theStack.Push(name);
              Console.WriteLine($"Pushed {name} onto the stack");
              PrintStack(theStack);
              break;
            case "pop":
              if (theStack.Count > 0)
              {
                string poppedPerson = theStack.Pop();
                Console.WriteLine($"Popped {poppedPerson} from the stack");
              }
              else
              {
                Console.WriteLine("The stack is empty");
              }
              PrintStack(theStack);
              break;
            case "show":
              PrintStack(theStack);
              break;
            case "ica":
            case "ICA":
              SimulateIcaStack();
              break;
            case "text":
              ReverseText();
              break;
            case "0":
              Console.WriteLine("Returning to main menu...");
              running = false;
              Console.Clear();
              return;
            default:
              Console.WriteLine("Please enter a valid command");
              break;

          }
        }
      }
      private static void PrintStack(Stack<string> theStack)
      {
        Console.WriteLine($"People in stack: {theStack.Count}");
        if (theStack.Count == 0)
        {
          Console.WriteLine("Stack is empty");
          return;
        }

        // Invert the order to keep the first-added item at position 1
        List<string> displayOrder = new List<string>(theStack);
        displayOrder.Reverse(); // This puts the first-added item at the top of the list

        //Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("FIRST : ");
        //Console.ResetColor();

        // Print the stack in the order of first-added to last-added
        for (int i = 0; i < displayOrder.Count; i++)
        {
          Console.Write($"{i+1}. {displayOrder[i]}");
          if (i < displayOrder.Count - 1)
          {
              Console.Write(" <- ");
          }
        }

        Console.WriteLine(" -- END");
      }

      private static void SimulateIcaStack()
      {
        Stack<string> icaStack = new Stack<string>();

        Console.WriteLine("\n--- ICA Stack Simulation ---");

        // a. ICA opens and the stack is empty
        Console.WriteLine("\na. ICA opens and the queue is empty");
        PrintStack(icaStack);

        // b. Kalle gets in line
        Console.WriteLine("\nb. Kalle gets in line");
        icaStack.Push("Kalle");
        PrintStack(icaStack);

        // c. Greta gets in line
        Console.WriteLine("\nc. Greta gets in line");
        icaStack.Push("Greta");
        PrintStack(icaStack);

        // d. The last person in line is served (Greta)
        Console.WriteLine("\nd. The last person in line is served");
        string servedPerson = icaStack.Pop();
        Console.WriteLine($"Ciao {servedPerson}");
        PrintStack(icaStack);

        // e. Stina gets in line
        Console.WriteLine("\ne. Stina gets in line");
        icaStack.Push("Stina");
        PrintStack(icaStack);

        // g. Olle gets in line
        Console.WriteLine("\ng. Olle gets in line");
        icaStack.Push("Olle");
        PrintStack(icaStack);

        // f. The last person in line is served (Olle)
        Console.WriteLine("\nf. The last person in line is served");
        servedPerson = icaStack.Pop();
        Console.WriteLine($"Ciao {servedPerson} ");
        PrintStack(icaStack);

        // h. The last person in line is served (Stina)
        Console.WriteLine("\nh. The last person in line is served");
        servedPerson = icaStack.Pop();
        Console.WriteLine($"Ciao {servedPerson} ");
        PrintStack(icaStack);

        Console.WriteLine("\nICA stack simulation completed.");
        Console.WriteLine("\nNotice: Kalle arrived first but is always last to be served!");
      }

          /*
          * Svar på frågorna:
          *
          * I en stack betjänas den sista personen som anländer först (FILO).
          * Så klart är detta inte rättvist för en butikskö där den första
          * personen som anlände borde betjänas först (FIFO).
          *
          */

      private static void ReverseText()
      {
        Console.WriteLine("\n--- Reverse Text ---");
        Console.WriteLine("Enter text to reverse (or '0' to exit):");
        string input = Console.ReadLine() ?? string.Empty;

        if (input == "0")
        {
          Console.WriteLine("Exiting reverse text...");
          return;
        }
        // Create a stack to hold the characters
        Stack<char> charStack = new Stack<char>();

        // Push each character onto the stack
        foreach (char c in input)
        {
          charStack.Push(c);
        }

        // Pop each character from the stack and build the reversed string
        string reversed = string.Empty;
        while (charStack.Count > 0)
        {
          reversed += charStack.Pop();
        }
        Console.WriteLine($"Reversed text: {reversed}");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();

      }





      static void CheckParanthesis()
      {
          /*
          * Use this method to check if the paranthesis in a string is Correct or incorrect.
          * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
          * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
          */

        bool running = true;

        while (running)
        {
          Console.WriteLine("\n=== Parenthesis Checker ===");
          Console.WriteLine("This tool checks if all parentheses in a text are properly balanced.");
          Console.WriteLine("Examples:");
          Console.WriteLine("  Well-formed: (()), {}, [({})], { I love [chocolate (so)] much}");
          Console.WriteLine("  Not well-formed: (()]), [), {[()]}, ( I {don't) love {chocolate ]");
          Console.WriteLine("\nEnter a string with parentheses to check if they're balanced (or '0' to exit):");

          string input = Console.ReadLine() ?? string.Empty;

          if (input == "0")
          {
            Console.WriteLine("Returning to main menu...");
            running = false;
            Console.Clear();
          }
          else
          {
            bool isWellFormed = CheckParenthesis(input);

            if (isWellFormed)
            {
              Console.WriteLine("✓ SUCCESS: All parentheses in your text are properly balanced!");
            }
            else
            {
              Console.WriteLine("✗ ERROR: The parentheses in your text are NOT properly balanced.");
              Console.WriteLine("  Remember: Each opening bracket must have a matching closing bracket in the correct order.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
          }
        }
      }

        static bool CheckParenthesis(string input)
        {

          // Create a stack to hold the opening brackets
          Stack<char> stack = new Stack<char>();

          // Create a dictionary to match opening and closing brackets
          // opening brackets are keys and closing brackets are values
          Dictionary<char, char> bracketPairs = new Dictionary<char, char>
          {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
          };

          // Go through each character in the input string
          foreach (char c in input)
          {
            // If it's an opening bracket (contains key in the dictionary)
            if (bracketPairs.ContainsKey(c))
            {
              // Push it onto the stack
              stack.Push(c);
            }
            // If it's a closing bracket (contains value in the dictionary)
            else if (bracketPairs.ContainsValue(c))
            {
              // Check if the stack is empty or if the current closing bracket doesn't match the expected one
              if (stack.Count == 0)
              {
                // We have a closing bracket with no matching opening bracket
                return false;
              }

              // Get the last opening bracket from the stack
              char lastOpenBracket = stack.Pop();

              // Check if the closing bracket matches what we expect for this opening bracket
              if (bracketPairs[lastOpenBracket] != c)
              {
                return false;
              }
            }
          }

            // At the end, the stack should be empty if all brackets were properly closed
            return stack.Count == 0;
        }

          /*
          * Svar på frågorna:
          *
          * 1. Vilken datastruktur använder du?
          *    Jag använder Stack strukturen tillsammans med en Dictionary.
          *    Stack används för att hålla reda på öppningsparenteser enligt LIFO principen
          *    vilket är perfekt för nästlade parenteser.
          *    Dictionary används för att koppla ihop varje typ av öppningsparentes med dess
          *    motsvarande stängningsparentes.
          *
          *    - För varje tecken i strängen:
          *      - Om det är en öppningsparentes, lägg den på stacken (push)
          *      - Om det är en stängningsparentes:
          *        - Om stacken är tom, returnera false (inget matchande par)
          *        - Ta bort den senaste öppningsparentesen från stacken (pop)
          *        - Använd dictionary för att kontrollera om de matchar, annars returnera false
          *    - I slutet, om stacken är tom är strängen välformad
          *
          */
  }
