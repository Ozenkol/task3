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
        var game = Model.DiceGame.Instance(new VirtualPlayer(), new UserPlayer());
    }
    public static void AddUserPlayerFirst()
    {
        var game = Model.DiceGame.Instance(new UserPlayer(), new VirtualPlayer());
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