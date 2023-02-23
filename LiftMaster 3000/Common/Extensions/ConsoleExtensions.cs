namespace LiftMaster_3000.Common.Extensions;

public static class ConsoleExtensions
{
    /// <summary>
    /// Just an extension to add 3 loading dots for effect
    /// </summary>
    /// <param name="message">extension string to add dots to</param>
    /// <param name="dots">Number of dots to print</param>
    /// <param name="timeSpan">Time in milliseconds between dots</param>
    public static void WriteWithLoadingDots(this String message, int dots, int timeSpan)
    {
        Console.Write(message);
        for (int i = 0; i < dots; i++)
        {
            Console.Write(".");
            Thread.Sleep(timeSpan);
        }

        Console.WriteLine();
    }

    public static string GetInputAndValidate(string question,int? max, Type tpe)
    {
        int intOutput = 0;
        string stringOutput;
        
        while (true)
        {
            Console.Write(question);
            var input = Console.ReadLine();

            if (tpe == typeof(int))
            {
                int.TryParse(input, out intOutput);

                var testMax = max == 0 ? intOutput : max;
                if (intOutput != 0 && intOutput <= testMax)
                { 
                    return (input);
                }
                Console.WriteLine("Please enter a valid number within the range...");
            }
            else
            {
                var canParse = Enum.IsDefined(typeof(Enums.ElevatorDirections), input.ToUpper());
        
                if (canParse)
                {
                    return input;
                }
                Console.WriteLine("Please enter a valid option between Up and Down...");
            }
            
        }
    }

    /// <summary>
    /// Some Extra cred attempting to do an elevator loader bar :D
    /// </summary>
    public static void ElevatorDownAnimation()
    {
        Console.WriteLine("V V V Cool attempt at an elevator loading screen V V V");
        for (int i = 6; i <= 10; i++)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 1;
            Console.WriteLine("|");

            Console.CursorLeft = 0;
            Console.CursorTop =  i;
            Console.WriteLine("|");

            Console.CursorLeft = 1;
            Console.CursorTop = i;
            Console.WriteLine(" ");
        }

        for (int i = 6; i <= 10; i++)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 1;
            Console.WriteLine("|");

            Console.CursorLeft = 0;
            Console.CursorTop =  i;
            Console.WriteLine("|");
    
            Console.CursorLeft = 1;
            Console.CursorTop = i-1;
            Console.WriteLine(" ");

            Console.CursorLeft = 1;
            Console.CursorTop = i;
            Console.WriteLine("█");
            Thread.Sleep(300);
        }
        
        Console.WriteLine("");
    }
}