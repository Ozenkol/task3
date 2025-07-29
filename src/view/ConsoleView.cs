namespace View;
using Controller;
using Model;

class ConsoleView
{
    private static readonly DiceStore store = Model.DiceStore.Instance; 
    public void WelcomeView()
    {
        Console.WriteLine("Let's determine who makes the first move.");
    }

    public void SecretWordView() {
        Console.WriteLine("Firstly, let's think a new secret word for for fair game");
        string secretWord = "";
        try
        {
            secretWord = Console.ReadLine();
            Controller.SetSecretWord(secretWord);
        }
        catch
        {
            Console.WriteLine("Error! Invalid input");
        }
    }

    public void FirstMoveView() {
        Model.FirstMove.generateComputerChoice(0, 2);
        Model.Encryption.GenerateHMAC(Model.FirstMove.getComputerChoice());
        Console.WriteLine("I selected a random value in the range 0..1 " + Model.Encryption.GetHMAC() + ". ");
        Console.WriteLine("Try to guess my selection.\n 0 - 0 \n 1 - 1 \n X - exit \n ? - help");
        Console.Write("Your selection: ");
        string input = "";
        try
        {
            input = Console.ReadLine();
            Controller.SetChoice(input);
        }
        catch
        {
            Console.WriteLine("Error! Invalid input");
        }

        Console.WriteLine("My selection: " + Model.FirstMove.getComputerChoice());

        if (Model.FirstMove.getUserChoice() == Model.FirstMove.getComputerChoice()) {
            Console.WriteLine("It's your turn");
            Controller.AddUserPlayerFirst();
        }
        else {
            Console.WriteLine("It's mine turn");
            Controller.AddVirtualPlayerFirst();
        }

    }

    public void DiceChooseView() {
        var game = Model.DiceGame.Instance;
        if(game.IsFirstPlayerVirtual()) {
            
        }
        Console.WriteLine("");
        for (int i = 0; i < store.DiceCount; i++)
        {
            store.GetDiceAt(i).PrintFaces();
            Console.WriteLine(i);
        }
    }


    public void HelpView() {
        
    }

}