
List<string> smartphones = new List<string>()
{
    "Samsung Galaxy S20",
    "Pixel 2",
    "Pixel 3",
    "Pixel 4",
    "iPhone XR",
    "iPhone 12",
    "iPhone 12 Pro",
    "iPhone 12 Pro Max" 
};

Search();

// TODO: long method to refactor
void Search()
{
    bool continueSearch = true;

    while (continueSearch)
    {
        //user enters the term
        Console.Write("Search for smartphone: ");
        string keyword = Console.ReadLine();

        var results = smartphones
            .Where(phone => phone
                .ToLower()
                .Contains(keyword.ToLower()));
        
        //if there are resuls, they are displayed in the output
        if (results != null)
        {
            Console.WriteLine("Here are the matched results.\n");

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
        else
        {
            Console.WriteLine("No results found.");
        }

        //this asks user if he wants to search again
        //valid responses are Y and N
        //the program stops if the answer is N
        ConsoleKeyInfo continueSearchResponse;
        do
        {
            Console.Write("\nMake another search (y/n)?: ");
            continueSearchResponse = Console.ReadKey();

            if (continueSearchResponse.Key == ConsoleKey.N)
            {
                continueSearch = false;
                break;
            }
            if (continueSearchResponse.Key != ConsoleKey.Y)
            {
                Console.WriteLine("Invalid response.");
            }

        } while (continueSearchResponse.Key !=  ConsoleKey.N
                 && continueSearchResponse.Key != ConsoleKey.Y);
    }

    Console.Write("Thanks for searching!");
}
