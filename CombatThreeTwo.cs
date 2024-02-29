using System;
using AsciiArt;
using Program;
using CombatThree;
using Ending;
using Dialogue;

namespace CombatLast;
public class CombatProgramLast
{
    private Player player;

    public int playerHP = 6;
    public int playerLeftHand = 3;
    public int playerRightHand = 3;

    public int lysanderHP = 1000;
    public int lysanderLeftHand = 500;
    public int lysanderRightHand = 500;

    public bool playerLeftHandLost = false;
    public bool playerRightHandLost = false;

    public bool lysanderLeftHandLost = false;
    public bool lysanderRightHandLost = false;

    public CombatProgramLast(Player player)
    {
        this.player = player;
    }

    public void StartGameLast()
    {
        End end = new End(player);
        DialogueArt dialArt = new DialogueArt();
        Dialogues dial = new Dialogues(player);

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nCrawl Through Mud and Blood.....");



        while (playerHP > 0 && lysanderHP > 0)
        {
            PrintOnce(playerHP);
            DisplayStats();
            PlayerTurn();

            lysanderTurn();

            void PrintMessage(string message)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\n {message}");
            }

            if (playerHP <= 0 && playerLeftHand <= 0 && playerRightHand <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{player.username} Main HP fell to <0>!");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\"Just stay there.\"");
                Console.WriteLine("\n\"Stop your senseless suffering.\"");
                Console.ForegroundColor = ConsoleColor.Yellow;

                string userTry;
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nGO on <y> <n>??");
                    Console.Write(">> ");
                    userTry = Console.ReadLine().ToLower();
                } while (userTry != "y" && userTry != "n");

                if (userTry == "y")
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Even if my Legs are lost, I crawl towards you.");
                    Console.WriteLine("Even if my Arms are lost, I will use my teeth to bite jsut to move an inch.");
                    Console.WriteLine("Even if you blind my eye, I will still find a way");
                    Console.WriteLine("And bring destruction on your body.");
                    Console.WriteLine("To Kill You.");
                    Console.WriteLine("Every single thing what makes of you.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nKill him >> ");
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.Clear();
                    end.StartGameEnd();
                    Console.Clear();
                    Console.ResetColor();
                }
                else if (userTry == "n")
                {
                    Console.Clear();
                    Console.ResetColor();
                    for (int i = 0; i < dial.DialogueEndingC().Length; i++)
                    {
                        Console.WriteLine(dial.DialogueEndingC()[i] + "\n");
                        if ((i + 1) % 5 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Press [Enter] to continue...");
                            Console.ResetColor();
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }

                    Console.WriteLine(dialArt.endingC());
                    Console.WriteLine("Ending C - God of Liberation.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nPress [Enter] >> ");
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.Clear();
                    MudAndBloodGame.MainMenu();
                }
                else
                {
                    Console.Clear();
                }
            }

            void PrintOnce(int playerHP)
            {
                if (playerHP == 6)
                    PrintMessage("?????");

                if (playerHP == 5)
                    PrintMessage("You still wish to stand?");

                if (playerHP == 4)
                    PrintMessage("Until failure?");
                if (playerHP == 3)
                    PrintMessage("Just Stop.");

                if (playerHP == 2)
                    PrintMessage("Forget everything what happened.");

                if (playerHP == 1)
                    PrintMessage("Forget everything what happened.");
            }
        }
    }
    public void DisplayStats()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n================================================================================");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(player.username + $"'s Main HP: <{playerHP}>     |   Left Limb: <{playerLeftHand}>   |   Right Limb: <{playerRightHand}>");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Lysander the Liberator's Main HP: <999999>     |   Left Limb: <999999>   |   Right Limb: <999999>");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("================================================================================");
        Console.ResetColor();
    }

    void PlayerTurn()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n===================================");
        Console.WriteLine("| |Your Turn!|    Choose an Action:|");
        Console.WriteLine("|==================================|");
        Console.WriteLine("| <1> Attack                       |");
        Console.WriteLine("====================================");
        Console.ResetColor();

        int choice = GetValidInput(1, 2);

        if (choice == 1)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n==================================");
            Console.WriteLine("| Choose target limb:           |");
            Console.WriteLine("|===============================|");
            Console.WriteLine("| <1> Left Limb                 |");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("| <2> Right Limb                |");
            Console.WriteLine("=================================");
            Console.ResetColor();

            int targetLimb = GetValidInput(1, 2);

            if ((targetLimb == 1) || (targetLimb == 2))
            {
                Attacklysander(targetLimb);
            }

        }
    }
    void lysanderTurn()
    {
        Random random = new Random();

        if (playerLeftHandLost)
        {
            AttackPlayer(2);
            return;
        }
        else if (playerRightHandLost)
        {
            AttackPlayer(1);
            return;
        }

        int choice = random.Next(1, 3);
        AttackPlayer(choice);
    }

    private void Attacklysander(int targetLimb)
    {
        string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
        int damage = 0;
        Console.WriteLine("\n----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\n You attack Lysander's <{limb}> and deal <{damage}> damage!\n");
        Console.ResetColor();

        if (targetLimb == 1)
        {
            lysanderLeftHand = 0;
        }
        else if (targetLimb == 2)
        {
            lysanderRightHand = 0;
        }
    }

    private void AttackPlayer(int targetLimb)
    {
        string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
        int damage = 1;

        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"\nLysander attacks your <{limb}> and deals <{damage}> damage!\n");
        Console.ResetColor();
        Console.WriteLine("----------------------------------------------------------------------");
        UpdatePlayerHP();

        if (targetLimb == 1)
        {
            playerLeftHand = playerLeftHand - damage;
            if (playerLeftHand == 0 && !playerLeftHandLost)
            {
                playerLeftHandLost = true;
                UpdatePlayerHP();
            }
        }
        else if (targetLimb == 2)
        {
            playerRightHand = playerRightHand - damage;
            if (playerRightHand == 0 && !playerRightHandLost)
            {
                playerRightHandLost = true;
                UpdatePlayerHP();
            }
        }
    }

    void UpdatePlayerHP()
    {
        playerHP = (playerLeftHandLost ? 0 : playerLeftHand) + (playerRightHandLost ? 0 : playerRightHand);
    }


    static int GetValidInput(int minValue, int maxValue)
    {
        int choice;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n [Enter your choice] >> ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
            {
                break;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nInvalid input. Please enter a valid option.");
                Console.ResetColor();
            }
        }
        return choice;
    }
}