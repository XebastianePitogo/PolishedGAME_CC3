using System;
using AsciiArt;
using Dialogue;
using Decision;
using CombatZero;
using CombatTwo;
using CombatOne;
using CombatThree;
using CombatLysander;


namespace Program;

public class Player
{
    public string? username { get; set; }
}

public class MudAndBloodGame
{
    public static void Main(string[] args)
    {
        DisplayIntroduction();
        MainMenu();
    }

    public static void DisplayIntroduction()
    {
        DialogueArt dialArt = new DialogueArt();
        Console.ResetColor();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPlaying the game at full screen is advised for optimized gameplay.");
        Console.Write("\n\nPress [Enter] ");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
        Console.Write("\"While many can pursue their dreams in solitude, other dreams are like great storms blowing hundreds,\n" +
            "even thousands of dreams apart in their wake. Dreams breathe life into men and can cage them in suffering." +
            "\nMen live and die by their dreams. But long after they have been abandoned they still smolder deep in men's hearts.\n" +
            "Some see nothing more than life and death. They are dead, for they have no dreams.\" \n\n" +
            "\t- Griffith\n\tBerserk (1997)\n\tKentaro Miura");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n\nPress [Enter] ");
        Console.ReadKey();
        Console.Clear();
    }

    public static void MainMenu()
    {
        while (true)
        {
            DialogueArt dialArt = new DialogueArt();
            Console.WriteLine(dialArt.titleArt());
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\"Through Mud and Blood\"");
            Console.WriteLine("\t\ta Turn-Based Dungeon Crawler Game");
            Console.WriteLine("\t\tMade by Pitogo, Xebastiane\n\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t<1> >> Play <<\n");
            Console.WriteLine("\t\t<2> >> Credits <<\n");
            Console.WriteLine("\t\t<3> >> Quit <<\n");
            Console.Write("\t\t>> ");
            Console.ResetColor();
            string userInput = Console.ReadLine() ?? string.Empty;

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    Console.ResetColor();
                    PlayGame();
                    break;
                case "2":
                    Console.Clear();
                    Credits();
                    Console.ResetColor();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Quitting Game...");
                    Environment.Exit(0);

                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Invalid choice! Please enter [1], [2], [3]\n");
                    Console.ResetColor();
                    break;
            }
        }
    }
    private static void Credits()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nDon Harl - Teaching C# Basics");
        Console.WriteLine("\nMichael Hadley (@mikewesthad) - Gamedev tutorials");
        Console.WriteLine("\nDaFluffyPotato (@DaFluffyPotato) - Gamedev tutorials");
        Console.WriteLine("\n(www.ascii.co.uk) SSt/JaWa - Window ASCII art");
        Console.WriteLine("\n\"www.asciiart.eu\" - For provided ASCII arts");
        Console.WriteLine("\n\"www.loveascii.com\" - Castle tower ASCII art");
        Console.WriteLine("\n\"www.asciiart.eu\" - For provided ASCII arts");
        Console.WriteLine("\n\t(www.asciiart.eu) Tua Xiong - Knight, Warrior ASCII art");
        Console.WriteLine("\n\t(www.asciiart.eu) Marcin Glinski - Castle ASCII art");
        Console.WriteLine("\n\t(www.asciiart.eu) Glory Moon - Temple ASCII art");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n>> ");
        Console.ReadKey();
        Console.Clear();
    }
    public static void PlayGame()
    {
        Player player = new Player();
        DialogueArt dialArt = new DialogueArt();
        Dialogues dial = new Dialogues(player);
        CombatProgramZero combatzero = new CombatProgramZero(player);
        CombatProgramOne combat = new CombatProgramOne(player);
        CombatProgramTwo combatTwo = new CombatProgramTwo(player);
        CombatProgramLysander combatLysander = new CombatProgramLysander(player);
        CombatProgramThree combatThree = new CombatProgramThree(player);
        FightEncounter encounter = new FightEncounter();

        ////////////////////////////////=============line=============////////////////////////////////

        int dialoguePerClear = 5;
        //checkpoint
        int sleepTime = 500;
        //////////////
        ///


        void PrintDialogues(string[] dialogues, int dialoguePerClear, int sleepTime)
        {
            ConsoleColor initialColor = Console.ForegroundColor;

            for (int i = 0; i < dialogues.Length; i++)
            {
                Console.ForegroundColor = i == 0 ? initialColor : ConsoleColor.White;
                Console.WriteLine(dialogues[i] + "\n");

                if ((i + 1) % dialoguePerClear == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press [Enter] to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }
                Thread.Sleep(sleepTime);
            }
            Console.ForegroundColor = initialColor;
        }

        string[][] introDialogues =
        {
            new string [] { dialArt.hedgeStone() },
            dial.DialogueZero(),
            new string [] { dialArt.hungry() },
            dial.DialogueIntro(),
        };

        foreach (string[] dialogues in introDialogues)
        {
            PrintDialogues(dialogues, dialoguePerClear, sleepTime);
        }

        //country choose decision
        string chosenCountry = Decisions.ChooseCountry();
        Decisions.DisplayChosenCountry(chosenCountry);
        Console.Clear();
        //

        string[][] firstDialogues =
        {
            dial.DialogueIntroOne(),
        };

        foreach (string[] dialogues in firstDialogues)
        {
            PrintDialogues(dialogues, dialoguePerClear, sleepTime);
        }
        Console.WriteLine(dialArt.eyes());
        Console.ResetColor();
        string chosenDecisionOne = Decisions.ChooseDecisionOne();
        Console.Clear();
        Console.WriteLine(chosenDecisionOne);
        Console.ResetColor();
        if (chosenDecisionOne == "You Ignored the children.")
        {
            Console.ResetColor();
            for (int i = 0; i < dial.DialogueIntroOneDecisionOne().Length; i++)
            {
                Console.WriteLine(dial.DialogueIntroOneDecisionOne()[i] + "\n");
                Thread.Sleep(500);
                if ((i + 1) % dialoguePerClear == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press [Enter] to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        else if (chosenDecisionOne == "You Helped the children.")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(encounter.mercenary());
            Console.WriteLine("\nBattle Encounter!");
            Console.WriteLine("What the hell you are doing here?");
            Console.WriteLine("Mind your own business!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPress [Enter] >> ");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
            combatzero.StartGameZero();
            Console.Clear();
            Console.ResetColor();
            for (int i = 0; i < dial.DialogueIntroOneDecisionTwo().Length; i++)
            {
                Console.WriteLine(dial.DialogueIntroOneDecisionTwo()[i] + "\n");
                Thread.Sleep(500);
                if ((i + 1) % dialoguePerClear == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press [Enter] to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        Console.Clear();
        string[][] getNameDialogues =
        {
            dial.DialogueIntroTwo(chosenCountry),
        };
        foreach (string[] dialogues in getNameDialogues)
        {
            PrintDialogues(dialogues, dialoguePerClear, sleepTime);
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Its, ");
        string input = Console.ReadLine() ?? string.Empty;
        player.username = !string.IsNullOrWhiteSpace(input) ? char.ToUpper(input[0]) + input.Substring(1).ToLower() : string.Empty;

        while (string.IsNullOrWhiteSpace(player.username) || player.username.Length > 11)
        {
            if (player.username.Length > 11)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nUsername cannot be longer than 11 characters.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPlease enter a username.");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nIts, ");
            Console.ResetColor();
            input = Console.ReadLine() ?? string.Empty;
            player.username = !string.IsNullOrWhiteSpace(input) ? char.ToUpper(input[0]) + input.Substring(1).ToLower() : string.Empty;
        }
        Console.ResetColor();

        string[][] DialogueIntroThree =
        {
            dial.DialogueIntroThree(chosenCountry),
        };

        foreach (string[] dialogues in DialogueIntroThree)
        {
            PrintDialogues(dialogues, dialoguePerClear, sleepTime);
        }

        Console.WriteLine(dialArt.fortaare());

        string[][] DialogueIntroThreefight =
        {
            dial.DialogueIntroThreePart(),
        };
        foreach (string[] dialogues in DialogueIntroThreefight)
        {
            PrintDialogues(dialogues, dialoguePerClear, sleepTime);
        }
        Console.WriteLine(encounter.warrior());
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nBattle Encounter!");
        Console.WriteLine($"So you're Captain {player.username}, prepare to die for my country!\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nPress [Enter] >> ");
        Console.ReadKey();
        Console.ResetColor();
        Console.Clear();
        combat.StartGame();
        Console.Clear();
        Console.ResetColor();
        string[][] DialogueOne =
        {
            dial.DialogueOne(chosenCountry),
        };
        foreach (string[] dialogues in DialogueOne)
        {
            PrintDialogues(dialogues, dialoguePerClear, sleepTime);
        }
        Console.WriteLine(encounter.lysanderHuman());
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nBattle Encounter!");
        Console.WriteLine($"{player.username}, you are now not a part of my band, Kin of Lionhearths.\n");
        Console.WriteLine($"Therefore.\n");
        Console.WriteLine($"You no longer have any use for me...\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nPress [Enter] >> ");
        Console.ReadKey();
        Console.ResetColor();
        Console.Clear();
        combatLysander.StartGameLysander();
        Console.Clear();
        Console.ResetColor();
        string[][] DialogueTwo =
        {
            dial.DialogueTwo(chosenCountry),
        };
        foreach (string[] dialogues in DialogueTwo)
        {
            PrintDialogues(dialogues, dialoguePerClear, sleepTime);
        }
        Console.WriteLine(dialArt.farm());
        string chosenDecisionTwo = Decisions.ChooseDecisionTwo(player);
        Console.WriteLine(chosenDecisionTwo);
        if (chosenDecisionTwo == "You did not helped Eoghann.")
        {
            Console.ResetColor();
            string[][] DialogueThreeDecisionTwo =
            {
            dial.DialogueThreeDecisionTwo(chosenCountry),
            };
            foreach (string[] dialogues in DialogueThreeDecisionTwo)
            {
                PrintDialogues(dialogues, dialoguePerClear, sleepTime);
            }
            Console.WriteLine("Ending A - Peaceful life?");
            Console.WriteLine(dialArt.endingA());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPress [Enter] >> ");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
            MainMenu();
        }

        if (chosenDecisionTwo == "You helped Eoghann.")
        {
            string[][] DialogueThreeDecisionOne =
            {
            dial.DialogueThreeDecisionOne(chosenCountry),
            };
            foreach (string[] dialogues in DialogueThreeDecisionOne)
            {
                PrintDialogues(dialogues, dialoguePerClear, sleepTime);
            }
        }
        Console.WriteLine(encounter.knight());
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\nBattle Encounter!");
        Console.WriteLine($"That DAMNED Kin of Lionheart and their cursed Lysander with his antics!{player.username}\n");
        Console.WriteLine($"In the name of our Country and God, our sword will bear answers!\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nPress [Enter] >> ");
        Console.ReadKey();
        Console.ResetColor();
        Console.Clear();
        combatTwo.StartGameTwo();

        string[][] DialogueFourDecisionOne =
        {
            dial.DialogueFourDecisionOne(),
        };
        foreach (string[] dialogues in DialogueFourDecisionOne)
        {
            PrintDialogues(dialogues, dialoguePerClear, sleepTime);
        }
        Console.WriteLine(dialArt.oldGod());
        string[][] DialogueFive =
        {
            dial.DialogueFive(),
        };
        foreach (string[] dialogues in DialogueFive)
        {
            PrintDialogues(dialogues, dialoguePerClear, sleepTime);
        }
        Console.WriteLine(encounter.lysander());
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nBattle Encounter!");
        Console.WriteLine($"Do you really wish to be this way? {player.username}.\n");
        Console.WriteLine($"I will never sacrifice my dream...\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nPress [Enter] >> ");
        Console.ReadKey();
        Console.ResetColor();
        Console.Clear();
        combatThree.StartGameThree();
        Console.Clear();
        Console.ResetColor();


    }
}