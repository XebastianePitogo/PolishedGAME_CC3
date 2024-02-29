using System;
using Program;
using AsciiArt;

namespace CombatZero;

public class CombatProgramZero
{
  private Player player;
  public int playerHP = 20;
  public int playerLeftHand = 10;
  public int playerRightHand = 10;
  public int mercenaryHP = 20;
  public int mercenaryLeftHand = 10;
  public int mercenaryRightHand = 10;

  public bool playerLeftHandLost = false;
  public bool playerRightHandLost = false;

  public bool mercenaryLeftHandLost = false;
  public bool mercenaryRightHandLost = false;

  public CombatProgramZero(Player player)
  {
    this.player = player;
  }

  public void StartGameZero()
  {
    FightEncounter encounter = new FightEncounter();
    BattleCondition condition = new BattleCondition();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("You find yourself unable to run, and the only way out is to... spill blood.");

    while (playerHP > 0 && mercenaryHP > 0)
    {
      DisplayStats();
      PlayerTurn();


      if (mercenaryHP <= 0 && mercenaryLeftHand <= 0 && mercenaryRightHand <= 0)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nMercenary Main HP fell to <0>!");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nMercenary fell in battle, What a creep...");
        Console.WriteLine("\nYou stand tall and won in the aftermath of the battle, you look forward what happens onwards.");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\n" + condition.winart());
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Proceed?");
        Console.Write(">> ");
        Console.ReadKey();
        Console.Clear();
        break;
      }

      mercenaryTurn();

      if (playerHP == 0 && playerLeftHand == 0 && playerRightHand == 0)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{player.username} Main HP fell to <0>!");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\"I can finally sell them to Salt Port! HAHAHAHAH\"");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nYou succumbed during battle, You have finally embraced bliss after enduring the prolonged suffering of battle...");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\n" + condition.skullArt());
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
          CombatProgramZero combat = new CombatProgramZero(player);
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("\nBattle Encounter!");
          Console.WriteLine("What the hell you are doing here?");
          Console.WriteLine("Mind your own business!");
          Console.WriteLine(encounter.mercenary());
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("\nPress [Enter] >> ");
          Console.ReadKey();
          Console.ResetColor();
          Console.Clear();
          combat.StartGameZero();
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
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Mercenary's Main HP: <{mercenaryHP}>     |   Left Limb: <{mercenaryLeftHand}>   |   Right Limb: <{mercenaryRightHand}>");
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
        Attackmercenary(targetLimb);
      }

    }
  }

  void mercenaryTurn()
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
    int damage = new Random().Next(3, 5);

    Console.WriteLine("----------------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\nMercenary attacks your <{limb}> and deals <{damage}> damage!\n");
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


  private void Attackmercenary(int targetLimb)
  {
    string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
    int damage = new Random().Next(3, 5);
    Console.WriteLine("\n----------------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"\nYou attack mercenary's <{limb}> and deal <{damage}> damage!\n");
    Console.ResetColor();
    UpdatemercenaryHP();

    if (targetLimb == 1)
    {
      mercenaryLeftHand = Math.Max(0, mercenaryLeftHand - damage);
      if (mercenaryLeftHand == 0 && !mercenaryLeftHandLost)
      {
        mercenaryLeftHandLost = true;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nMercenary's left hand is now fatally damaged. Damage reduction of 25% will be applied on his attacks.\n");
        Console.ResetColor();
        damage *= (int)(damage * 0.75);
        UpdatemercenaryHP();
      }
    }
    else if (targetLimb == 2)
    {
      mercenaryRightHand = Math.Max(0, mercenaryRightHand - damage);
      if (mercenaryRightHand == 0 && !mercenaryRightHandLost)
      {
        mercenaryRightHandLost = true;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nMercenary's right hand is now fatally damaged. Damage reduction of 25% will be applied on his attacks.\n");
        Console.ResetColor();
        damage = (int)(damage * 0.75);
        UpdatemercenaryHP();
      }
    }
  }

  void UpdatePlayerHP()
  {
    playerHP = (playerLeftHandLost ? 0 : playerLeftHand) + (playerRightHandLost ? 0 : playerRightHand);
  }

  void UpdatemercenaryHP()
  {
    mercenaryHP = (mercenaryLeftHandLost ? 0 : mercenaryLeftHand) + (mercenaryRightHandLost ? 0 : mercenaryRightHand);
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