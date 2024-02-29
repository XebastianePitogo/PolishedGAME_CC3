using System;
using AsciiArt;
using Program;
using Dialogue;

namespace Ending;
public class End
{
    private Player player;

    public int playerHP = 6;
    public int playerLeftHand = 3;
    public int playerRightHand = 3;

    public int lysanderHP = 6;
    public int lysanderLeftHand = 3;
    public int lysanderRightHand = 3;

    public bool playerLeftHandLost = false;
    public bool playerRightHandLost = false;

    public bool lysanderLeftHandLost = false;
    public bool lysanderRightHandLost = false;

    public End(Player player)
    {
        this.player = player;
    }

    public void StartGameEnd()
    {
        FightEncounter fight = new FightEncounter();
        End end = new End(player);
        DialogueArt dialArt = new DialogueArt();
        Dialogues dial = new Dialogues(player);

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("You found his bracelet with the weird stone fallen unto the ground.");
        Console.WriteLine("You got a hold of it and founf Lysander panicking.");


        while (playerHP > 0 && lysanderHP > 0)
        {
            PrintOnce(playerHP);
            DisplayStats();
            PlayerTurn();

            if (lysanderHP <= 0 && lysanderLeftHand <= 0 && lysanderRightHand <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nLysander Main HP fell to <0>!\n");
                Console.ResetColor();
                for (int i = 0; i < dial.DialogueEndingB().Length; i++)
                {
                    Console.WriteLine(dial.DialogueEndingB()[i] + "\n");
                    if ((i + 1) % 5 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Press [Enter] to continue...");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                Console.WriteLine(dialArt.endingB());
                Console.WriteLine("Ending B - God of Destruction.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nPress [Enter] >> ");
                Console.ReadKey();
                Console.ResetColor();
                Console.Clear();
                MudAndBloodGame.MainMenu();
                break;
            }

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
                Console.WriteLine("\"Just stay there.\"");
                Console.WriteLine("\n\"Stop your senseless suffering.\"");
                Console.ForegroundColor = ConsoleColor.Yellow;

                string userTry;
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("GO on <y> <n>??");
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
            }

            void PrintOnce(int playerHP)
            {
                if (playerHP == 6)
                    PrintMessage("DON'T DO IT!");

                if (playerHP == 5)
                    PrintMessage("I AM THE BASIC CONCEPT OF LIBERATION.");

                if (playerHP == 4)
                    PrintMessage("KILLING ME WOULD CAUSE WARS.");
                if (playerHP == 3)
                    PrintMessage("STOP I SAID.");

                if (playerHP == 2)
                    PrintMessage($"{player.username}!!!");

                if (playerHP == 1)
                    PrintMessage($"{player.username}!!!!!!!");
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
        Console.WriteLine($"Lysander the Liberator's Main HP: <{lysanderHP}>     |   Left Limb: <{lysanderLeftHand}>   |   Right Limb: <{lysanderRightHand}>");
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


    private void AttackPlayer(int targetLimb)
    {
        string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
        int damage = 1;

        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nlysander attacks your <{limb}> and deals <{damage}> damage!\n");
        Console.ResetColor();
        Console.WriteLine("----------------------------------------------------------------------");
        UpdatePlayerHP();

        if (targetLimb == 1)
        {
            playerLeftHand = Math.Max(0, playerLeftHand - damage);
            if (playerLeftHand == 0 && !playerLeftHandLost)
            {
                playerLeftHandLost = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYour left hand is now fatally damaged. Damage reduction of 25% will be applied on your attacks.\n");
                Console.ResetColor();
                Console.WriteLine("----------------------------------------------------------------------");
                damage = (int)(damage * 0.75);
                UpdatePlayerHP();
            }
        }
        else if (targetLimb == 2)
        {
            playerRightHand = Math.Max(0, playerRightHand - damage);
            if (playerRightHand == 0 && !playerRightHandLost)
            {
                playerRightHandLost = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYour right hand is now fatally damaged. Damage reduction of 25% will be applied on your attacks.\n");
                Console.ResetColor();
                Console.WriteLine("----------------------------------------------------------------------");
                damage = (int)(damage * 0.75);
                UpdatePlayerHP();
            }
        }
    }


    private void Attacklysander(int targetLimb)
    {
        string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
        int damage = 1;
        Console.WriteLine("\n----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\nYou attack lysander's <{limb}> and deal <{damage}> damage!\n");
        Console.ResetColor();
        UpdatelysanderHP();

        if (targetLimb == 1)
        {
            lysanderLeftHand = Math.Max(0, lysanderLeftHand - damage);
            if (lysanderLeftHand == 0 && !lysanderLeftHandLost)
            {
                lysanderLeftHandLost = true;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nlysander's left hand is now fatally damaged. Damage reduction of 25% will be applied on his attacks.\n");
                Console.ResetColor();
                damage *= (int)(damage * 0.75);
                UpdatelysanderHP();
            }
        }
        else if (targetLimb == 2)
        {
            lysanderRightHand = Math.Max(0, lysanderRightHand - damage);
            if (lysanderRightHand == 0 && !lysanderRightHandLost)
            {
                lysanderRightHandLost = true;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nlysander's right hand is now fatally damaged. Damage reduction of 25% will be applied on his attacks.\n");
                Console.ResetColor();
                damage = (int)(damage * 0.75);
                UpdatelysanderHP();
            }
        }
    }

    void UpdatePlayerHP()
    {
        playerHP = (playerLeftHandLost ? 0 : playerLeftHand) + (playerRightHandLost ? 0 : playerRightHand);
    }

    void UpdatelysanderHP()
    {
        lysanderHP = (lysanderLeftHandLost ? 0 : lysanderLeftHand) + (lysanderRightHandLost ? 0 : lysanderRightHand);
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