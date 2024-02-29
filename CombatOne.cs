using System;
using Program;
using AsciiArt;

namespace CombatOne;

public class CombatProgramOne
{
  private Player player;
  public int playerHP = 200;
  public int playerLeftHand = 100;
  public int playerRightHand = 100;
  public int asketillHP = 200;
  public int asketillLeftHand = 100;
  public int asketillRightHand = 100;

  public bool playerLeftHandLost = false;
  public bool playerRightHandLost = false;

  public bool asketillLeftHandLost = false;
  public bool asketillRightHandLost = false;

  public CombatProgramOne(Player player)
  {
    this.player = player;
  }

  public void StartGame()
  {
    FightEncounter encounter = new FightEncounter();
    BattleCondition condition = new BattleCondition();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("You find yourself unable to run, and the only way out is to... spill blood.");

    while (playerHP > 0 && asketillHP > 0)
    {
      DisplayStats();
      PlayerTurn();


      if (asketillHP <= 0 && asketillLeftHand <= 0 && asketillRightHand <= 0)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nAsketill Main HP fell to <0>!");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nAsketill the Giant fell in battle, such a huge target-dummy to hit. That was close");
        Console.WriteLine("\nYou stand tall and won in the aftermath of the battle, you are granted another day to endure the relentless suffering that awaits for your destiny... ");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\n" + condition.winart());
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Proceed?");
        Console.Write(">> ");
        Console.ReadKey();
        Console.Clear();
        break;
      }

      asketillTurn();

      if (playerHP == 0 && playerLeftHand == 0 && playerRightHand == 0)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{player.username} Main HP fell to <0>!");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\"I'm not gonna sugarcoat it!\"");
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
          CombatProgramOne combat = new CombatProgramOne(player);
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("\nBattle Encounter!");
          Console.WriteLine($"So you're Captain {player.username}, prepare to die for my country!\n");
          Console.WriteLine(encounter.warrior());
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("\nPress [Enter] >> ");
          Console.ReadKey();
          Console.ResetColor();
          Console.Clear();
          combat.StartGame();
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
    Console.WriteLine($"Asketill the Giant's Main HP: <{asketillHP}>     |   Left Limb: <{asketillLeftHand}>   |   Right Limb: <{asketillRightHand}>");
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
        Attackasketill(targetLimb);
      }

    }
  }

  void asketillTurn()
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
    int damage = new Random().Next(11, 23);

    Console.WriteLine("----------------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\nAsketill attacks your <{limb}> and deals <{damage}> damage!\n");
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


  private void Attackasketill(int targetLimb)
  {
    string limb = targetLimb == 1 ? "Left Limb" : "Right Limb";
    int damage = new Random().Next(12, 22);
    Console.WriteLine("\n----------------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"\nYou attack Asketill's <{limb}> and deal <{damage}> damage!\n");
    Console.ResetColor();
    UpdateasketillHP();

    if (targetLimb == 1)
    {
      asketillLeftHand = Math.Max(0, asketillLeftHand - damage);
      if (asketillLeftHand == 0 && !asketillLeftHandLost)
      {
        asketillLeftHandLost = true;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nAsketill's left hand is now fatally damaged. Damage reduction of 25% will be applied on his attacks.\n");
        Console.ResetColor();
        damage *= (int)(damage * 0.75);
        UpdateasketillHP();
      }
    }
    else if (targetLimb == 2)
    {
      asketillRightHand = Math.Max(0, asketillRightHand - damage);
      if (asketillRightHand == 0 && !asketillRightHandLost)
      {
        asketillRightHandLost = true;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nAsketill's right hand is now fatally damaged. Damage reduction of 25% will be applied on his attacks.\n");
        Console.ResetColor();
        damage = (int)(damage * 0.75);
        UpdateasketillHP();
      }
    }
  }

  void UpdatePlayerHP()
  {
    playerHP = (playerLeftHandLost ? 0 : playerLeftHand) + (playerRightHandLost ? 0 : playerRightHand);
  }

  void UpdateasketillHP()
  {
    asketillHP = (asketillLeftHandLost ? 0 : asketillLeftHand) + (asketillRightHandLost ? 0 : asketillRightHand);
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