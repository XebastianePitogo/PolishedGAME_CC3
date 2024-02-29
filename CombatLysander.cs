using System;
using Program;
using AsciiArt;

namespace CombatLysander;

public class CombatProgramLysander
{
  private Player player;

  public int playerHP = 800;
  public int playerLeftHand = 400;
  public int playerRightHand = 400;

  public int LysanderHP = 900;
  public int LysanderLeftHand = 450;
  public int LysanderRightHand = 450;

  public bool playerLeftHandLost = false;
  public bool playerRightHandLost = false;

  public bool LysanderLeftHandLost = false;
  public bool LysanderRightHandLost = false;

  public CombatProgramLysander(Player player)
  {
    this.player = player;
  }

  public void StartGameLysander()
  {
    BattleCondition condition = new BattleCondition();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    FightEncounter encounter = new FightEncounter();

    Console.WriteLine("Despite your unwillingness to fight. It has to, if it will near you towards your dream.");

    while (playerHP > 0 && LysanderHP > 0)
    {
      DisplayStats();
      PlayerTurn();
      if (LysanderHP <= 0 && LysanderLeftHand <= 0 && LysanderRightHand <= 0)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nLysander's Main HP fell to <0>!");
        Console.WriteLine("\nLysander is incapacitated from the fight!");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n\"I am sorry Lysander- but I have to chase my own dreams too...\"\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Proceed?");
        Console.Write(">> ");
        Console.ReadKey();
        break;
      }

      LysanderTurn();

      if (playerHP == 0 && playerLeftHand == 0 && playerRightHand == 0)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{player.username} Main HP fell to <0>!");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n\"You will die by the hand that took you in...\"");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nThings went silent.");
        Console.ForegroundColor = ConsoleColor.Yellow;

        string userTry;
        do
        {
          Console.WriteLine("Restart fight? <y>(Yes) or <n>(No)");
          Console.Write(">> ");
          userTry = Console.ReadLine().ToLower();
        } while (userTry != "y" && userTry != "n");

        if (userTry == "y")
        {
          CombatProgramLysander combat = new CombatProgramLysander(player);
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.WriteLine("\nBattle Encounter!");
          Console.WriteLine($"{player.username}, you are now not a part of my band, Kin of Lionhearths.\n");
          Console.WriteLine($"Therefore.\n");
          Console.WriteLine($"You no longer have any use for me...\n");
          Console.WriteLine(encounter.lysanderHuman());
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("\nPress [Enter] >> ");
          Console.ReadKey();
          Console.ResetColor();
          Console.Clear();
          combat.StartGameLysander();
          Console.Clear();
          Console.ResetColor();
        }
        else if (userTry == "n")
        {
          Console.Clear();
          MudAndBloodGame.MainMenu();
        }
        else
        {
          Console.Clear();
        }
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
    Console.WriteLine($"Lysander's Main HP: <{LysanderHP}>     |   Left Limb: <{LysanderLeftHand}>   |   Right Limb: <{LysanderRightHand}>");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("================================================================================");
    Console.ResetColor();
  }

  public void PlayerTurn()
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
        AttackLysander(targetLimb);
      }

    }
  }

  public void LysanderTurn()
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


  public void AttackPlayer(int targetLimb)
  {
    string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
    int damage = new Random().Next(50, 70);

    Console.WriteLine("----------------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine($"\nLysander attacks your <{limb}> and deals <{damage}> damage!\n");
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


  public void AttackLysander(int targetLimb)
  {
    string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
    int damage = new Random().Next(45, 80);
    Console.WriteLine("\n----------------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"\nYou attack Lysander's <{limb}> and deal <{damage}> damage!\n");
    Console.ResetColor();
    UpdateLysanderHP();

    if (targetLimb == 1)
    {
      LysanderLeftHand = Math.Max(0, LysanderLeftHand - damage);
      if (LysanderLeftHand == 0 && !LysanderLeftHandLost)
      {
        LysanderLeftHandLost = true;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nLysander's left hand is now fatally damaged. Damage reduction of 25% will be applied on its attacks.\n");
        Console.ResetColor();
        damage = (int)(damage * 0.75);
        UpdateLysanderHP();
      }
    }
    else if (targetLimb == 2)
    {
      LysanderRightHand = Math.Max(0, LysanderRightHand - damage);
      if (LysanderRightHand == 0 && !LysanderRightHandLost)
      {
        LysanderRightHandLost = true;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nLysander's right hand is now fatally damaged. Damage reduction of 25% will be applied on its attacks.\n");
        Console.ResetColor();
        damage = (int)(damage * 0.75);
        UpdateLysanderHP();
      }
    }
  }

  void UpdatePlayerHP()
  {
    playerHP = (playerLeftHandLost ? 0 : playerLeftHand) + (playerRightHandLost ? 0 : playerRightHand);
  }

  void UpdateLysanderHP()
  {
    LysanderHP = (LysanderLeftHandLost ? 0 : LysanderLeftHand) + (LysanderRightHandLost ? 0 : LysanderRightHand);
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