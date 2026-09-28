Console.WriteLine("Pocket Dialer");

List<string> dialledNumbers = [];

void DialNumber(string number)
{
    if (number.Length != 10 || number.Any(digit => digit < '0' || digit > '9'))
    {
        throw new ArgumentException("The phone number must contain exactly 10 digits.");
    }
    Console.WriteLine($"Dialling {number}...");
    dialledNumbers.Insert(0, number);
}

void ViewDialledNumbers()
{
    Console.WriteLine("Dialled numbers (latest first):");
    foreach (string dialledNumber in dialledNumbers)
    {
        Console.WriteLine(dialledNumber);
    }
}

while (true)
{
    Console.WriteLine("\nHome");
    Console.WriteLine("1. Dial a number");
    Console.WriteLine("2. View history of dialled numbers");
    Console.WriteLine("3. Contacts");
    Console.Write("Choose an option: ");

    string? option = Console.ReadLine();
    if (option is null)
    {
        break;
    }

    try
    {
        switch (option)
        {
            case "1":
                Console.Write("Enter a 10-digit number: ");
                string? number = Console.ReadLine();
                if (number is null)
                {
                    return;
                }
                DialNumber(number);
                break;
            case "2":
                if (dialledNumbers.Count == 0)
                {
                    Console.WriteLine("No dialled numbers yet.");
                    break;
                }
                ViewDialledNumbers();
                break;
            case "3":
                throw new NotSupportedException("Contacts are not supported yet.");
            default:
                throw new ArgumentException("Choose option 1, 2, or 3.");
        }
    }
    catch (ArgumentException error)
    {
        Console.WriteLine($"Error: {error.Message}");
    }
    catch (NotSupportedException error)
    {
        Console.WriteLine($"Error: {error.Message}");
    }

    while (true)
    {
        Console.Write("Press H for home or Q to quit: ");
        string? next = Console.ReadLine();

        if (next is null || next.Equals("Q", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        if (next.Equals("H", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }

        Console.WriteLine("Please press H or Q.");
    }
}
