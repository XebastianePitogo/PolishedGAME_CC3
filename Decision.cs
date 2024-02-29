using System;
using Program;
using AsciiArt;

namespace Decision;
public class Decisions
{
    public static string ChooseCountry()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nChoose which country's mercenaries you would like to serve:");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n<1> Jahanid Jettaiah Sovereignty");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n<2> Rising Yuandao Dynasty");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n<3> Angevin Victornia Kingdom");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n>> ");
        Console.ResetColor();
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                return "Jahanid Jettaiah Sovereignty";
            case "2":
                return "Rising Yuandao Dynasty";
            case "3":
                return "Angevin Victornia Kingdom";
            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 3.");
                Console.ResetColor();
                return ChooseCountry();
        }
    }

    public static void DisplayChosenCountry(string chosenCountry)
    {
        CountryArt countryArt = new CountryArt();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nYou have chosen to serve the {chosenCountry}");
        Console.ResetColor();

        switch (chosenCountry)
        {
            case "Jahanid Jettaiah Sovereignty":
                DisplayCountryInfo(ConsoleColor.Red,
                    @"
        The Jahanid Jettaiah Sovereignty stands as a bastion of authoritarian rule, its foundation deeply entrenched 
        
        in the art of warfare—be it through cunning guerrilla tactics of the harsh desert or masterful army strategies.
        
        At its birth once stood the formidable Warlord Ogenhei-Uzal, spreading fear at the sight of his wide smile with
        
        a glowing tooth. Whose visionary barbaric leadership raised an empire that stretched across continents, toppling 
        
        numerous rival sovereignties in its wake. Though his passing waned the empire's dominion, the legacy of Ogenhei-Uzal
        
        endured, influence and legacy enduring through the passage of time through a story shared by parents to scare
        
        their children to not go out at night.");
                Console.WriteLine(countryArt.jettaiah());
                break;
            case "Rising Yuandao Dynasty":
                DisplayCountryInfo(ConsoleColor.Green,
                    @"
        Once a part of the grand empire of Li-Hindei, the Rising Yuandao Dynasty has risen from the ashes of

        familial strife and internal discord. Amidst the chaos of dynasty wars, the Yuandao Dynasty emerged

        from its conservatism and political prowess, Their unwavering dedication to traditional values and

        clever governance propelled them to the forefront of power struggles. One figure shines brightly—

        a legend whose courage and bravery is feared among opposing forces. Han-Changgul, identifiable with his
        
        glowing ring and tall stature, a warrior of raw resolve, His heroic defense of the dynasty's main city 
        
        against relentless assault and outnumbered by tenfold forces has planted his story and respect among 
        
        the commoners and higher-ranking individuals alike. Accounts of his heroic defense are now sculpted, in
        
        the Palace walls.");
                Console.WriteLine(countryArt.yuandao());
                break;
            case "Angevin Victornia Kingdom":
                DisplayCountryInfo(ConsoleColor.Cyan,
                    @"
        The Angevin Victornia Kingdom prides as a realm steeped in chivalry, honor, and the echoes of ancient glory.

        Its castles stand as proud reminder of a bygone era, where knights uphold the code of chivalry with unwavering devotion.

        At the heart of this kingdom lies the legend of Creyn Eardwulf, a hero whose name is known by every person who aspires to be righteous.

        His epic tale spans the realms of myth and reality, from extracting the fabled Sword of Trinity from the ruins of ancient kingdoms, charging 
        
        towards enemy lines with a glowing necklace to the liberation of Francia Burna, once a land deprived of hope. Now transformed into a sanctuary 
        
        where individuals of diverse backgrounds and statuses coexist in harmony, Francia Burna stands as a beacon of peace, shielded from the cruelty
        
        of war, plague, and injustice. Eardwulf embodies the virtues of courage, righteousness, and nobility. His deeds immortalized in the ballads sung
        
        by bards across the land. Eardwulf stands as a ray of hope in a world beset by darkness, his tale sung by every Angevin Victornia's people
         
        during times of crisis.");
                Console.WriteLine(countryArt.victornia());
                break;
            default:
                break;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n\nPress [Enter] ");
        Console.ResetColor();
        Console.ReadKey();
    }

    private static void DisplayCountryInfo(ConsoleColor color, string description)
    {
        Console.ForegroundColor = color;
        foreach (char c in description)
        {
            Console.Write(c);
            // checkpoint 2
            System.Threading.Thread.Sleep(1);
        }
        Console.ResetColor();
    }

    /// After country decision
    public static string ChooseDecisionOne()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Help the Children? <y> (yes) or <n> (no)\n");
        Console.ResetColor();
        Console.Write(">> ");
        string choice = Console.ReadLine()?.ToLower() ?? "";
        Console.WriteLine("");

        switch (choice)
        {
            case "y":
                Console.ForegroundColor = ConsoleColor.Yellow;
                return "You Helped the children.";
            case "n":
                Console.ForegroundColor = ConsoleColor.Yellow;
                return "You Ignored the children.";
            default:
                Console.Clear();
                Console.WriteLine("The mercenary, angered again. Raised his sword, to strike down the eldest child with a lethal blow.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Invalid choice. Please enter 'y' or 'n'\n");
                Console.ResetColor();
                return ChooseDecisionOne();
        }
    }
    ////////////////////////
    public static string ChooseDecisionTwo(Player player)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Help Eoghann to find Lysander? <y> (yes) or <n> (no)\n");
        Console.ResetColor();
        Console.Write(">> ");
        string choice = Console.ReadLine() ?? "";
        Console.WriteLine("");
        switch (choice)
        {
            case "y":
            Console.ForegroundColor = ConsoleColor.Yellow;
                return "You helped Eoghann.";
            case "n":
            Console.ForegroundColor = ConsoleColor.Yellow;
                return "You did not helped Eoghann.";
            default:
                Console.Clear();
                Console.WriteLine($"\"It's up to you whether you'll rejoin us and find Lysander or not, and I'll respect your decision no matter what, Captain— Sir {player.username}.\"\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Invalid choice. Please enter 'y' or 'n'\n");
                Console.ResetColor();
                return ChooseDecisionTwo(player);
        }
    }
}

