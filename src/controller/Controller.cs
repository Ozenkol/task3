using System.Numerics;
using Model;

namespace Controller;

class Controller
{
    List<ValidationError> errors = new();
    ValidateDice validateDice = new();

    public static void SetChoice(string choice)
    {
        Model.FirstMove.setUserChoice(choice);
    }
    public static void SetSecretWord(string secretWord)
    {
        Encryption.SetSecretWord(secretWord);
    }
    public static void AddVirtualPlayerFirst()
    {
        Model.DiceGame.Instance.SetPlayers(VirtualPlayer.GetInstance(), UserPlayer.GetInstance());
    }
    public static void AddUserPlayerFirst()
    {
        Model.DiceGame.Instance.SetPlayers(UserPlayer.GetInstance(), VirtualPlayer.GetInstance());
    }

    public static void SetUserChoice(string arg) {
        Model.UserPlayer.GetInstance().SetUserChoice(int.Parse(arg));
        Model.VirtualPlayer.GetInstance().SetUserChoice(int.Parse(arg));
    }
     public static void SetComputerChoice()
    {
        Model.VirtualPlayer.GetInstance().SetComputerChoice();
        Model.UserPlayer.GetInstance().SetComputerChoice();   
    }
    public static void SetDice(string i) {

        Model.UserPlayer.GetInstance().SetDice(int.Parse(i));
    }
    public void ValidateArgs(string[] args)
    {
        if (args.Length < 2)
        {
            errors.Add(ValidationError.InvalidDiceCountLength);
            Console.WriteLine(string.Join("\n", errors));
            Environment.Exit(1);
        }
        foreach (string item in args)
        {
            if(!validateDice.validate(item)) {
                errors.Add(ValidationError.InvalidFaceCount);
                Console.WriteLine(string.Join("\n", errors));
                Environment.Exit(1);
            }
        }
    }
}